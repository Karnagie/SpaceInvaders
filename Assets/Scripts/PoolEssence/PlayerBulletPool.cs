using System.Collections.Generic;
using System.Linq;
using AliveObjects.PlayerEssence;
using UnityEngine;

namespace PoolEssence
{
    public class PlayerBulletPool : IPool<PlayerBullet>
    {
        private List<PoolElement<PlayerBullet>> _objects;
        private GameObject _prefab;

        public PlayerBulletPool(GameObject prefab)
        {
            _objects = new List<PoolElement<PlayerBullet>>();
            _prefab = prefab;
        }

        public PlayerBullet Get()
        {
            return GetInternal(null, Vector3.zero);
        }
        
        public PlayerBullet Get(Transform parent, Vector3 position)
        {
            return GetInternal(parent, position);
        }

        public void Return(PlayerBullet obj)
        {
            PoolElement<PlayerBullet> poolElement = _objects.First(o => o.Obj == obj);
            poolElement.Obj.gameObject.SetActive(false);
            poolElement.IsFree = true;
        }

        private PlayerBullet GetInternal(Transform parent, Vector3 position)
        {
            foreach (var poolObject in _objects)
            {
                if (poolObject.IsFree)
                {
                    poolObject.Obj.gameObject.SetActive(true);
                    poolObject.Obj.transform.SetParent(parent);
                    poolObject.Obj.transform.position = position;
                    poolObject.IsFree = false;
                    poolObject.Obj.Init(this);
                    return poolObject.Obj;
                }
            }
            GameObject g = MonoBehaviour.Instantiate(_prefab, parent);
            g.transform.position = position;
            
            PoolElement<PlayerBullet> newElement = new PoolElement<PlayerBullet>();
            newElement.Obj = g.GetComponent<PlayerBullet>();
            newElement.Obj.gameObject.SetActive(true);
            newElement.IsFree = false;
            newElement.Obj.Init(this);
            _objects.Add(newElement);
            
            return g.GetComponent<PlayerBullet>();
        }
    }

    public class PoolElement<T> where T : class
    {
        public T Obj;
        public bool IsFree;
    }
}