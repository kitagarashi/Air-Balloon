namespace _Project.Scripts.Gameplay.Spawn
{
    public interface IPoolable
    {
        void OnSpawned();
        void OnReturned();
    }
}