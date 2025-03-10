using _Project.Scripts.Gameplay.Spawn;

namespace _Project.Scripts.Gameplay.Factory
{
    public interface IFactory<T> where T : IPoolable
    {
        T Create();
    }
}