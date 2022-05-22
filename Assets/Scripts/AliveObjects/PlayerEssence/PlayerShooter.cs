using GameEssence;
using Input;
using PoolEssence;
using ShootingEssence;
using UnityEngine;
using Zenject;

namespace AliveObjects.PlayerEssence
{
    public class PlayerShooter : MonoBehaviour, IShooter, IPausable
    {
        [SerializeField] private Bullet _defaultBulletPrefab;
        [SerializeField] private Transform _bulletSpawnPlace;
        [SerializeField] private Transform _bulletSpawner;

        private PlayerBulletPool _bulletPool;

        [Inject] private IInputHandler _input;
        [Inject] private Game _game;

        public void Awake()
        {
            _bulletPool = new PlayerBulletPool(_defaultBulletPrefab);
            _input.OnShoot += Shoot;
        }

        public void ChangeBulletType(Bullet prefab)
        {
            _bulletPool.ChangePrefab(prefab);
        }
        
        public void Shoot()
        {
            if (!IsPaused)
            {
                Bullet bullet = _bulletPool.Get(_bulletSpawnPlace, _bulletSpawner.position);
                _game.AddPausable(bullet);
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