using System;
using System.Collections.Generic;
using System.Linq;
using AliveObjects.PlayerEssence;
using PoolEssence;
using UnityEngine;

namespace AliveObjects.EnemyEssence
{
    public class EnemyPool : IPool<DefaultShip>
    {
        private List<PoolElement<DefaultShip>> _objects;
        private DefaultShip.Factory _factory;

        public EnemyPool(DefaultShip prefab, DefaultShip.Factory factory)
        {
            _objects = new List<PoolElement<DefaultShip>>();
            _factory = factory;
        }

        public DefaultShip Get()
        {
            return GetInternal(null, Vector3.zero);
        }
        
        public DefaultShip Get(Transform parent, Vector3 position)
        {
            return GetInternal(parent, position);
        }

        public void Return(DefaultShip obj)
        {
            PoolElement<DefaultShip> poolElement = _objects.First(o => o.Obj == obj);
            poolElement.Obj.gameObject.SetActive(false);
            poolElement.IsFree = true;
        }

        private DefaultShip GetInternal(Transform parent, Vector3 position)
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

            GameObject g = _factory.Create().gameObject;
            g.transform.SetParent(parent);
            g.transform.position = position;
            
            PoolElement<DefaultShip> newElement = new PoolElement<DefaultShip>();
            newElement.Obj = g.GetComponent<DefaultShip>();
            newElement.Obj.gameObject.SetActive(true);
            newElement.IsFree = false;
            newElement.Obj.Init(this);
            _objects.Add(newElement);
            
            return g.GetComponent<DefaultShip>();
        }
    }
}