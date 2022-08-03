using System;
using System.Collections.Generic;


namespace SimpleMan.Utilities
{

    public interface IContainer<T> : IComponent
    {
        //------PROPERTIES
        IReadOnlyList<T> RegisteredItems { get; }




        //------EVENTS
        event Action<T> OnItemRegistered;
        event Action<T> OnItemUnregistered;
        




        //------METHODS
        void Register(T instance);

        void Unregister(T instance);
    }
}