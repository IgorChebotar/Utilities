using UnityEngine;

namespace SimpleMan.Utilities
{
    public static class ComponentExtensions
    {
        public static bool TryGetComponentInChildren<T>(this Component target, out T component)
        {
            component = target.GetComponentInChildren<T>(true);
            return component != null;
        }

        public static bool TryGetComponentInParent<T>(this Component target, out T component)
        {
            component = target.GetComponentInParent<T>();
            return component != null;
        }
    }
}