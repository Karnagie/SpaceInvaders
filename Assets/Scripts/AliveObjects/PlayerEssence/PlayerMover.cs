using Input;
using UnityEngine;

namespace AliveObjects.PlayerEssence
{
    public class PlayerMover : IMover
    {
        private IInputHandler _input;
        private Transform _player;
        private float _speed;
        
        public PlayerMover(Transform player, IInputHandler input, float speed)
        {
            _input = input;
            _player = player;
            _speed = speed;
        }
        
        public void Move()
        {
            Vector3 velocity = _input.GetVelocity();
            _player.position += velocity * Time.deltaTime * _speed;
        }
    }
}