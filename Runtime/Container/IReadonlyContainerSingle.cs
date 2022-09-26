using System;

namespace SimpleMan.Containers
{
    public interface IReadonlyContainerSingle<T>
    {
        //------PROPERTIES
        T Instance { get; }




        //------EVENTS
        event Action<T> OnInstanceRegistered;
        event Action<T> OnInstanceUnregistered;
    }
}