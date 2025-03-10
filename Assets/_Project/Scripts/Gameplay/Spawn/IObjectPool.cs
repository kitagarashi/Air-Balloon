namespace _Project.Scripts.Gameplay.Spawn
{
    public interface IObjectPool<T> where T : IPoolable
    {
        T Get();
        void Return(T obj);
    }
}