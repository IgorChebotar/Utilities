using UnityEngine;

namespace SimpleMan.Utilities
{
    public class ChildComponentRef<T> : BaseComponentRef<T>
    {
        public ChildComponentRef(GameObject owner, bool required = true) : base(owner, required)
        {
        }

        protected override T GetComponent()
        {
            return _owner.GetComponentInChildren<T>(true);
        }
    }
}