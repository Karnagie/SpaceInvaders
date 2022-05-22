using AliveObjects;
using AliveObjects.PlayerEssence;
using PoolEssence;
using UnityEngine;

namespace ShootingEssence
{
    public abstract class Bullet : MonoBehaviour, IPausable, IPoolObject<Bullet>
    {
        public abstract void Kill(IKillable target);

        public virtual void Pause()
        {
            IsPaused = true;
        }

        public virtual void Unpause()
        {
            IsPaused = false;
        }

        public bool IsPaused { get; private set; }

        public void Init(IPool<Bullet> pool)
        {
            Pool = pool;
        }

        public IPool<Bullet> Pool { get; private set; }
    }
}