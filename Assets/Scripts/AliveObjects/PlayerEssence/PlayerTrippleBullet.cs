using PoolEssence;
using ShootingEssence;
using UnityEngine;

namespace AliveObjects.PlayerEssence
{
    public class TripleBullet : Bullet, IMover
    {
        [SerializeField] private float _speed = 2f;
        [SerializeField] private LayerMask _ignore;

        private void Update() => Move();

        public override void Pause()
        {
            IsPaused = true;
        }

        public override void Unpause()
        {
            IsPaused = false;
        }

        public bool IsPaused { get; private set; }
        
        public override void Kill(IKillable target)
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

        public void Init(IPool<Bullet> pool)
        {
            Pool = pool;
        }

        public IPool<Bullet> Pool { get; private set; }
    }
}