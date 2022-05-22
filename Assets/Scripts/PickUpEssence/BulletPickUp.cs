using System;
using AliveObjects;
using AliveObjects.PlayerEssence;
using ShootingEssence;
using UnityEngine;

namespace PickUpEssence
{
    [RequireComponent(typeof(Collider2D))]
    public class BulletPickUp : MonoBehaviour, IMover, IPausable
    {
        [SerializeField] private Bullet _bullet;
        [SerializeField] private float _speed = 1.5f;
        
        private void Update() => Move();

        public void Move()
        {
            if(!IsPaused)transform.position += Vector3.down*_speed*Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out Player player))
            {
                player.ChangeBulletType(_bullet);
                Destroy(gameObject);
            }
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
    }
}