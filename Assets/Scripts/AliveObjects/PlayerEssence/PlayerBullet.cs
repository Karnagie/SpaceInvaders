using System;
using PoolEssence;
using ShootingEssence;
using UnityEngine;

namespace AliveObjects.PlayerEssence
{
    public class PlayerBullet : MonoBehaviour, IBullet, IMover, IPoolObject<PlayerBullet>
    {
        [SerializeField] private float _speed = 2f;
        [SerializeField] private LayerMask _ignore;

        private void Update()
        {
            if (!IsPaused) Move();
        }

        public void Pause()
        {
            IsPaused = true;
        }

        public void Unpause()
        {
            IsPaused = false;
        }

        public bool IsPaused { get; private set; }
        
        public void Kill(IKillable target)
        {
            target.Kill();
        }

        public void Move()
        {
            if(!IsPaused)transform.position += Vector3.up*_speed*Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IKillable target) && other.gameObject.layer != _ignore)
            {
                target.Kill();
                Pool.Return(this);
            }
        }

        public void Init(IPool<PlayerBullet> pool)
        {
            Pool = pool;
        }

        public IPool<PlayerBullet> Pool { get; private set; }
    }
}