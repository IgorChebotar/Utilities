using UnityEngine;

namespace SimpleMan.Utilities
{
    public class ParentComponentRef<T> : BaseComponentRef<T> where T : Component
    {
        public ParentComponentRef(GameObject owner, bool required = true) : base(owner, required)
        {
        }

        protected override T GetComponent()
        {
            return _owner.GetComponentInParent<T>(true);
        }
    }
}