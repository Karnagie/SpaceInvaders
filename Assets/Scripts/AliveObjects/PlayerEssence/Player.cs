using Input;
using UnityEngine;
using Zenject;

namespace AliveObjects.PlayerEssence
{
    public class Player : MonoBehaviour, IPausable
    {
        [SerializeField] private float _speed = 10;
        
        private IMover _mover;

        [Inject] private IInputHandler _input;
        
        private void Awake()
        {
            _mover = new PlayerMover(transform, _input, _speed);
        }

        private void FixedUpdate()
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
    }
}