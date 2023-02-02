using UnityEngine;

namespace SimpleMan.Utilities
{
    public class ChildComponentRef<T> : BaseComponentRef<T> where T : Component
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