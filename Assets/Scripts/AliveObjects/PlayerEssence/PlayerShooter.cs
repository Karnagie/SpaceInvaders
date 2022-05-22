using Input;
using PoolEssence;
using UnityEngine;
using Zenject;

namespace AliveObjects.PlayerEssence
{
    public class PlayerShooter : MonoBehaviour, IShooter, IPausable
    {
        [SerializeField] private PlayerBullet _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnPlace;
        [SerializeField] private Transform _bulletSpawner;

        private PlayerBulletPool _bulletPool;

        [Inject] private IInputHandler _input;
        
        public void Awake()
        {
            _bulletPool = new PlayerBulletPool(_bulletPrefab.gameObject);
            _input.OnShoot += Shoot;
        }
        
        public void Shoot()
        {
            if(!IsPaused)_bulletPool.Get(_bulletSpawnPlace, _bulletSpawner.position);
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