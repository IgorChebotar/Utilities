using System;
using UnityEngine;

namespace SimpleMan.Utilities
{
    public abstract class BaseComponentRef<T> where T : Component
    {
        private readonly bool _required;
        private T _value;
        protected readonly GameObject _owner;

        public BaseComponentRef(GameObject owner, bool required = true)
        {
            if (owner.NotExist())
            {
                throw new ArgumentNullException(
                    "Owner can not be null");
            }

            _owner = owner;
            _required = required;
        }

        public T Value
        {
            get
            {
                _value ??= GetComponent();
                if (_value.NotExist() && _required)
                {
                    throw new NullReferenceException(
                        $"Component of type '{typeof(T).Name}' doesn't exist on " +
                        $"Object '{_owner.name}'");
                }

                return _value;
            }
        }

        protected abstract T GetComponent();
    }
}