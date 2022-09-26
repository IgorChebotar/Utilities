

using System;
using System.Collections.Generic;

namespace SimpleMan.Containers
{
    public interface IReadOnlyContainer<T>
    {
        //------PROPERTIES
        IReadOnlyList<T> Instances { get; }
        IReadOnlyList<T> InstancesRegisteredInLastFrame { get; }
        IReadOnlyList<T> InstancesUnregisteredInLastFrame { get; }




        //------EVENTS
        event Action<FLastFrameActions<T>> OnLastFrameResultCompleted;
        event Action<IReadOnlyList<T>> OnInstancesListChanged;
        event Action<IReadOnlyList<T>> OnInstancesListChangedOPF;
    }
}