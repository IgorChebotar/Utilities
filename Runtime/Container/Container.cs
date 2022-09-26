using System;
using System.Collections.Generic;
using System.Linq;
using SimpleMan.Utilities;
using static SimpleMan.Utilities.ExecuteOnceSystem;

namespace SimpleMan.Containers
{
    public class Container<T> : IContainer<T>, IContainerSingle<T> where T : class
    {
        //------FIELDS
        private const int DEFAULT_INSTANCES_CAPACITY = 32;
        private List<T> _instances;
        private List<T> _registeredInLastFrame;
        private List<T> _unregisteredInLastFrame;
        private List<T> _pendingRemove;




        //------PROPERTIES
        public T Instance
        {
            get => _instances[0];
        }
        public IReadOnlyList<T> Instances
        {
            get => _instances;
        }
        public IReadOnlyList<T> InstancesRegisteredInLastFrame
        {
            get => _registeredInLastFrame;
        }
        public IReadOnlyList<T> InstancesUnregisteredInLastFrame
        {
            get => _unregisteredInLastFrame;
        }




        //------EVENTS
        public event Action<T> OnInstanceRegistered;
        public event Action<T> OnInstanceUnregistered;
        public event Action<FLastFrameActions<T>> OnLastFrameResultCompleted;
        public event Action<IReadOnlyList<T>> OnInstancesListChanged;
        public event Action<IReadOnlyList<T>> OnInstancesListChangedOPF;




        //------CONSTUCTORS
        public Container()
        {
            _instances = new List<T>(DEFAULT_INSTANCES_CAPACITY);
            _registeredInLastFrame = new List<T>(DEFAULT_INSTANCES_CAPACITY);
            _unregisteredInLastFrame = new List<T>(DEFAULT_INSTANCES_CAPACITY);
            _pendingRemove = new List<T>(DEFAULT_INSTANCES_CAPACITY);
        }

        public Container(int capacity)
        {
            capacity = capacity.ClampPositive();


            _instances = new List<T>(capacity);
            _registeredInLastFrame = new List<T>(capacity);
            _unregisteredInLastFrame = new List<T>(capacity);
            _pendingRemove = new List<T>(capacity);
        }




        //------METHODS
        public void Register(T instance)
        {
            if (instance == null)
            {
                ThrowException.ArgumentNull(this, nameof(instance));
                return;

            }

            if (_instances.Contains(instance))
            {
                ThrowException.InvalidArgument(
                    this,
                    $"Multiple times registration detected for instance '{instance.GetType().Name}'. " +
                        $"Instance can only be registered once. Check the '{nameof(Register)}' method calling");

                return;
            }


            _instances.Add(instance);
            _registeredInLastFrame.Add(instance);


            OnInstanceRegistered?.Invoke(instance);
            OnInstancesListChanged?.Invoke(Instances);


            InstanceRegistered(instance);
            ExecuteOnceInNextFrame(MakeEndOfFrameActions);
        }

        public void Register(params T[] instances)
        {
            if (instances == null)
            {
                ThrowException.ArgumentNull(this, nameof(instances));
                return;
            }

            foreach (var item in instances)
            {
                Register(item);
            }
        }

        public void Unregister(params T[] instances)
        {
            if (instances == null)
            {
                ThrowException.ArgumentNull(this, nameof(instances));
                return;
            }

            foreach (var item in instances)
            {
                Unregister(item);
            }
        }

        public void Unregister()
        {
            if (_instances.Count > 0)
                Unregister(_instances[0]);
        }

        public void Unregister(T instance)
        {
            if(instance == null)
            {
                PrintToConsole.Warning(
                    this,
                    "You trying to unregister non existong object. Operation will be ignored");
            }
            else if (!_instances.Contains(instance))
            {
                PrintToConsole.Warning(
                    this,
                    "You trying to unregister object that didn't registered in this container. " +
                    $"Operation will be ignored. Object: '{instance}'");
            }
            else
            {
                PrepareToRemove(instance);
            }
        }

        public void UnregisterImmidiate()
        {
            if (_instances.Count > 0)
                _instances[0] = null;
        }

        public void UnregisterAll()
        {
            for (int i = 0; i < _instances.Count; i++)
            {
                PrepareToRemove(_instances[i]);
            }
        }

        public void UnregisterAllImmidiate()
        {
            _instances.Clear();
        }

        public virtual void Dispose()
        {
            UnregisterAllImmidiate();
            ClearTempRegistrationLists();
        }

        protected virtual void InstanceRegistered(T instance)
        {

        }

        protected virtual void InstanceUnregistered(T instance)
        {

        }

        protected virtual void LastFrameResultCompleted(FLastFrameActions<T> lastFrameActions)
        {

        }

        private void PrepareToRemove(T instance)
        {
            _unregisteredInLastFrame.Add(instance);


            _pendingRemove.Add(instance);
            _instances.Remove(instance);


            OnInstanceUnregistered?.Invoke(instance);
            OnInstancesListChanged.Invoke(Instances);


            InstanceUnregistered(instance);
            ExecuteOnceInNextFrame(MakeEndOfFrameActions);
        }

        private void MakeEndOfFrameActions()
        {
            CallEndOfFrameEvents();
            RemoveMarkedInstances();
            ClearTempRegistrationLists();




            void CallEndOfFrameEvents()
            {
                FLastFrameActions<T> lastFrameActions = new FLastFrameActions<T>(
                    _registeredInLastFrame.ToArray(),
                    _unregisteredInLastFrame.ToArray());


                OnLastFrameResultCompleted?.Invoke(lastFrameActions);
                OnInstancesListChangedOPF?.Invoke(Instances);
                LastFrameResultCompleted(lastFrameActions);
            }

            void RemoveMarkedInstances()
            {
                for (int i = 0; i < _unregisteredInLastFrame.Count; i++)
                {
                    _instances.Remove(_pendingRemove[i]);
                }
            }
        }

        private void ClearTempRegistrationLists()
        {
            _pendingRemove.Clear();
            _registeredInLastFrame.Clear();
            _unregisteredInLastFrame.Clear();
        }
    }
}