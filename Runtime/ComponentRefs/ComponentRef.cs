using UnityEngine;

namespace SimpleMan.Utilities
{
    public class ComponentRef<T> : BaseComponentRef<T> 
    {
        public ComponentRef(GameObject owner, bool required = true) : base(owner, required)
        {
        }

        protected override T GetComponent()
        {
            return _owner.GetComponent<T>();
        }
    }
}