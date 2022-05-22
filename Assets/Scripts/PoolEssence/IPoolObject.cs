namespace PoolEssence
{
    public interface IPoolObject<T> where T : IPoolObject<T>
    {
        void Init(IPool<T> pool);
        
        IPool<T> Pool { get; }
    }
}