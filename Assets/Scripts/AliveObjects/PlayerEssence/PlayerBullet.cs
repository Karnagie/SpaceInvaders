using System;
using PoolEssence;
using ShootingEssence;
using UnityEngine;

namespace AliveObjects.PlayerEssence
{
    public class PlayerBullet : Bullet, IMover
    {
        [SerializeField] private float _speed = 2f;
        [SerializeField] private LayerMask _ignore;

        private void Update()
        {
            if (!IsPaused) Move();
        }

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
    }
}