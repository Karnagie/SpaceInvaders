namespace AliveObjects
{
    public interface IPausable
    {
        void Pause();
        
        void Unpause();

        bool IsPaused { get; }
    }
}