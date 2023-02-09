using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SimpleMan.Utilities
{
    public static class TransformExtensions
    {
        public static bool IsDirectChildOf(this Transform child, Transform parent)
        {
            return child.parent == parent;
        }

        public static bool IsDirectParentOf(this Transform parent, Transform child)
        {
            return child && child.parent == parent;
        }

        public static Transform[] GetDirectChildren(this Transform target, bool ignoreDisabled = true)
        {
            if (!target)
                throw new System.ArgumentNullException("Target");

            List<Transform> result = new List<Transform>(target.childCount);
            Transform childTransform;
            for (int i = 0; i < target.childCount; i++)
            {
                childTransform = target.GetChild(i);
                if (ignoreDisabled && !childTransform.gameObject.activeSelf)
                    continue;

                result.Add(childTransform);
            }
                
            return result.ToArray();
        }

        public static T[] GetDirectChildrenOfType<T>(this Transform target, bool includeDisabled = true)
        {
            if (!target)
                throw new System.ArgumentNullException("Target");

            List<T> result = new List<T>(target.childCount);
            for (int i = 0; i < target.childCount; i++)
            {
                if (target.GetChild(i).TryGetComponent(out T component))
                {
                    if (!includeDisabled && !(component as Component).gameObject.activeSelf)
                        continue;

                    result.Add(component);
                }     
            }

            return result.ToArray();
        }

        public static void DestroyChildren(this Transform target, int from = 0)
        {
            if (from > target.childCount)
                throw new System.ArgumentOutOfRangeException($"From", "Can not destroy not existing children");

            for (int i = from; i < target.childCount; i++)
                Object.Destroy(target.GetChild(i).gameObject);
        }

        public static void DestroyChildrenImmediate(this Transform target, int from = 0)
        {
            if (from >= target.childCount)
                throw new System.ArgumentOutOfRangeException($"From", "Can not destroy not existing children");

            GameObject[] children = new GameObject[target.childCount - from];
            for (int i = from; i < target.childCount; i++)
                children[i - from] = target.GetChild(i).gameObject;

            for (int i = 0; i < children.Length; i++)
                Object.DestroyImmediate(children[i]);
        }

        public static void SetPositionAndRotation(this Transform target, PositionAndRotation value)
        {
            target.position = value.position;
            target.rotation = value.rotation;   
        }

        public static void SetLocalPositionAndRotation(this Transform target, PositionAndRotation value)
        {
            target.localPosition = value.position;
            target.localRotation = value.rotation;
        }

        public static PositionAndRotation GetPositionAndRotation(this Transform target)
        {
            return new PositionAndRotation(target.position, target.rotation);
        }

        public static PositionAndRotation GetLocalPositionAndRotation(this Transform target)
        {
            return new PositionAndRotation(target.localPosition, target.localRotation);
        }
    }
}