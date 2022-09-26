using System.Collections.Generic;

namespace SimpleMan.Containers
{
    public interface IContainer<T> : IReadOnlyContainer<T>
    {
        //------METHODS
        void Register(params T[] instances);

        void Unregister(params T[] instances);

        void Unregister(T instance);

        void UnregisterAll();

        void UnregisterAllImmidiate();
    }
}