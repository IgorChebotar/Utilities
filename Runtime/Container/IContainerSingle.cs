namespace SimpleMan.Containers
{
    public interface IContainerSingle<T> : IReadonlyContainerSingle<T>
    {
        //------METHODS
        void Register(T instance);

        void Unregister();

        void UnregisterImmidiate();
    }
}