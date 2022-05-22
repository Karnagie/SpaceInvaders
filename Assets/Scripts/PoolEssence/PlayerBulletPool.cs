using System.Collections.Generic;
using System.Linq;
using AliveObjects.PlayerEssence;
using ShootingEssence;
using UnityEngine;

namespace PoolEssence
{
    public class PlayerBulletPool : IPool<Bullet>
    {
        private List<PoolElement<Bullet>> _objects;
        private Bullet _prefab;

        public PlayerBulletPool(Bullet prefab)
        {
            _objects = new List<PoolElement<Bullet>>();
            _prefab = prefab;
        }

        public void ChangePrefab(Bullet newType)
        {
            _prefab = newType;
        }

        public Bullet Get()
        {
            return GetInternal(null, Vector3.zero);
        }
        
        public Bullet Get(Transform parent, Vector3 position)
        {
            return GetInternal(parent, position);
        }

        public void Return(Bullet obj)
        {
            PoolElement<Bullet> poolElement = _objects.First(o => o.Obj == obj);
            poolElement.Obj.gameObject.SetActive(false);
            poolElement.IsFree = true;
        }

        private Bullet GetInternal(Transform parent, Vector3 position)
        {
            foreach (var poolObject in _objects)
            {
                if (poolObject.IsFree && poolObject.GetType() == _prefab.GetType())
                {
                    poolObject.Obj.gameObject.SetActive(true);
                    poolObject.Obj.transform.SetParent(parent);
                    poolObject.Obj.transform.position = position;
                    poolObject.IsFree = false;
                    poolObject.Obj.Init(this);
                    return poolObject.Obj;
                }
            }
            GameObject g = MonoBehaviour.Instantiate(_prefab.gameObject, parent);
            g.transform.position = position;
            
            PoolElement<Bullet> newElement = new PoolElement<Bullet>();
            newElement.Obj = g.GetComponent<Bullet>();
            newElement.Obj.gameObject.SetActive(true);
            newElement.IsFree = false;
            newElement.Obj.Init(this);
            _objects.Add(newElement);
            
            return g.GetComponent<Bullet>();
        }
    }

    public class PoolElement<T> where T : class
    {
        public T Obj;
        public bool IsFree;
    }
}