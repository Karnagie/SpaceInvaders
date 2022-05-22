using AliveObjects;

namespace ShootingEssence
{
    public interface IBullet : IPausable
    {
        void Kill(IKillable target);
    }
}