using AliveObjects.PlayerEssence;
using UnityEngine;

namespace AliveObjects.EnemyEssence
{
    public class EnemyMover : IMover
    {
        private Transform _transform;
        private float _speed;

        public EnemyMover(Transform transform, float speed)
        {
            _transform = transform;
            _speed = speed;
        }
        
        public void Move()
        {
            _transform.position += Vector3.down*_speed*Time.deltaTime;
        }
    }
}