using System;
using System.Threading;
using System.Threading.Tasks;
using Extensions;
using UI.TestEssence;
using UnityEngine;
using Zenject;

namespace AliveObjects.EnemyEssence
{
    public class EnemySpawner : MonoBehaviour, IPausable
    {
        [SerializeField] private int _enemyLayer = 5;
        [SerializeField] private int _layersCount = 2;
        [SerializeField] private float _layerDelay = 2;
        [SerializeField] private Transform[] _layerPositions;
        [SerializeField] private DefaultShip _enemy;

        private EnemyPool _enemyPool;
        private bool _isSpawning;
        
        [Inject] private Remainder _remainder;
        [Inject] private DefaultShip.Factory _factory;
        
        private async void Start()
        {
            _isSpawning = true;
            _enemyPool = new EnemyPool(_enemy, _factory);
            _remainder.Init(_enemyLayer*_layersCount);
            await SpawnEnemy();
        }

        private async Task SpawnEnemy()
        {
            while (IsPaused)
            {
                await Task.Yield();
            }
            
            for (int i = 0; i < _layersCount; i++)
            {
                if(!_isSpawning) return;

                while (IsPaused)
                {
                    await Task.Yield();
                }
                
                for (int j = 0; j < _enemyLayer; j++)
                {
                    _enemyPool.Get(transform, _layerPositions[j].position);
                }
            
                await Task.Delay((int)(_layerDelay * 1000));
            }
        }

        private void OnDestroy()
        {
            _isSpawning = false;
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