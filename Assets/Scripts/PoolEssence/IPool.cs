namespace PoolEssence
{
    public interface IPool<T> where T : IPoolObject<T>
    {
        T Get();
        
        void Return(T obj);
    }
}