using System;
using System.Collections.Generic;


namespace SimpleMan.Utilities
{
    public interface IFrameStashContainer<T> : IContainer<T>
    {
        //------PROPERTIES
        IReadOnlyList<T> RegisteredInCurrentFrame { get; }
        IReadOnlyList<T> UnregisteredInCurrentFrame { get;  }




        //------EVENTS
        event Action<T[]> OnItemsRegisteredInLastFrame;
        event Action<T[]> OnItemsUnregisteredInLastFrame;
    }
}