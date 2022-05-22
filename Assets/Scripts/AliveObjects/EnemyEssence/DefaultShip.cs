using AliveObjects.PlayerEssence;
using GameEssence;
using PickUpEssence;
using PoolEssence;
using UI.TestEssence;
using UnityEngine;
using Zenject;

namespace AliveObjects.EnemyEssence
{
    public class DefaultShip : MonoBehaviour, IEnemy, IPausable, IKillable, IPoolObject<DefaultShip>
    {
        [SerializeField] private float _speed = 0.5f;
        [SerializeField] private EnemyDrop _drop;

        private IMover _mover;

        [Inject] private Score _score;
        [Inject] private Remainder _remainder;
        [Inject] private Game _game;

        [Inject]
        public void Construct(Score score, Remainder remainder)
        {
            _score = score;
            _remainder = remainder;
        }

        private void Awake()
        {
            _mover = new EnemyMover(transform, _speed);
        }

        private void Update()
        {
            if(!IsPaused)_mover.Move();
        }
        
        public void Pause()
        {
            IsPaused = true;
        }

        public void Unpause()
        {
            IsPaused = false;
        }

        public bool IsPaused { get; set; }
        
        public void Kill()
        {
            BulletPickUp drop = _drop.Drop(null, transform.position);
            if (drop) _game.AddPausable(drop);
            _score.AddPoint();
            _remainder.RemoveShip();
            Pool.Return(this);
        }

        public void Init(IPool<DefaultShip> pool)
        {
            Pool = pool;
        }

        public IPool<DefaultShip> Pool { get; private set; }
        
        public class Factory : PlaceholderFactory<DefaultShip> {}
    }
}