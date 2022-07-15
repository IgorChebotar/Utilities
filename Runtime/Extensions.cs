using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SimpleMan.Utilities
{
    public static class CollectionsExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T item in source)
                action(item);
        }

        public static IEnumerable<T> Except<T>(this IEnumerable<T> source, T element)
        {
            foreach(T item in source)
            {
                if (item.Equals(element))
                    continue;

                yield return item;
            }
        }

        public static int GetElementIndexByKey<TKey, TValue>(this Dictionary<TKey, TValue> source, TKey element)
        {
            if(!source.ContainsKey(element))
            {
                throw new ArgumentException(
                    $"Dictionary not contains key '{element}'. " +
                    $"Use 'Contains' method before index cheking");
            }
            
            int index = 0;
            foreach (var pair in source)
            {
                if(pair.Key.Equals(element))
                    return index;

                index++;
            }

            return -1;
        }

        public static void AddUnique<T>(this List<T> target, T item)
        {
            if (target.Contains(item))
                return;
            else
                target.Add(item);
        }

        public static void AddUnique<T>(this Queue<T> target, T item)
        {
            if (target.Contains(item))
                return;
            else
                target.Enqueue(item);
        }

        public static void AddUnique<T>(this Stack<T> target, T item)
        {
            if (target.Contains(item))
                return;
            else
                target.Push(item);
        }

        public static void AddUnique<TKey, TValue>(this Dictionary<TKey, TValue> target, TKey key, TValue value)
        {
            if (target.ContainsKey(key))
                return;
            else
                target.Add(key, value);
        }
    }

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
    }

    public static class ObjectExtensions
    {
        public static void ThrowNullReferenceException(this Object target, string message)
        {
            throw new System.NullReferenceException($"<b>{target.GetNameWithoutPrefix()}:</b> {message}");
        }

        public static void ThrowEmptyFieldException(this Object target, string fieldName, string message = "")
        {
            throw new System.NullReferenceException($"<b>{target.GetNameWithoutPrefix()}:</b> field <b>'{fieldName}'</b> is empty. {message}");
        }

        public static void ThrowArgumentNullException(this Object target, string argumentName, string message = "")
        {
            throw new System.ArgumentNullException($"<b>{argumentName}</b>", $"<b>{target.GetNameWithoutPrefix()}:</b>. {message}");
        }

        public static void ThrowComponentNullException(this Object target, string componentName)
        {
            throw new System.NullReferenceException(
                $"<b>{target.GetNameWithoutPrefix()}:</b> " +
                $"Component <b>'{componentName}'</b> " +
                $"not exist on this game object");
        }

        public static void ThrowInvalidOperationException(this Object target, string message)
        {
            throw new System.InvalidOperationException($"<b>{target.GetNameWithoutPrefix()}:</b> {message}");
        }

        public static void ThrowArgumentOutOfRangeException(this Object target, string indexName, string message = "")
        {
            throw new System.ArgumentOutOfRangeException($"<b>{target.GetNameWithoutPrefix()}:</b>", $"<b>'{indexName}'</b> is out of range. {message}");
        }

        public static void ThrowIndexOutOfRangeException(this Object target, string indexName, string message = "")
        {
            throw new System.IndexOutOfRangeException($"<b>{target.GetNameWithoutPrefix()}:</b> <b>'{indexName}'</b> is out of range. {message}");
        }

        public static void ThrowEventNullException(this Object target, string eventName)
        {
            throw new System.NullReferenceException($"<b>{target.GetNameWithoutPrefix()}:</b> Game event/request/vote named <b>'{eventName}'</b> can not be found. Check the <b>'Event library'</b> object on scene");
        }

        public static void ThrowSceneObjectNullException(this Object target, string objectName, string message = "")
        {
            throw new System.NullReferenceException(
                $"<b>{target.GetNameWithoutPrefix()}:</b> Game object <b>'{objectName}'</b> not exist. " +
                $"You need to add <b>'{objectName}'</b> prefab on scene. {message}");
        }

        public static void ThrowMustBeChildOfException(this Object target, string parentComponentName, string message = "")
        {
            throw new System.NullReferenceException(
                $"<b>{target.GetNameWithoutPrefix()}:</b> This game object must be child " +
                $"of <b>'{parentComponentName}'</b>. {message}");
        }

        public static void ThrowForbiddenInEditorMode(this Object target, string methodName, string message = "")
        {
            throw new System.InvalidOperationException(
                $"<b>{target.GetNameWithoutPrefix()}:</b> Operation '{methodName}' " +
                $"forbidden in editor mode. {message}");
        }

        public static void PrintLogRequestReceived(this Object target, Object sender, string requestName)
        {
            string senderName = sender ? sender.GetNameWithoutPrefix() : "Anonym";
            Debug.Log($"<b>{target.GetNameWithoutPrefix()}:</b> Request '{requestName}' has been received from '{senderName}'");
        }

        public static void PrintLogValueChanged(this Object target, string protertyName, object value)
        {
            Debug.Log($"<b>{target.GetNameWithoutPrefix()}:</b> Value <b>'{protertyName}'</b> has been changed. New value is <b>'{value}'</b>");
        }

        public static void PrintLog(this Object target, string message)
        {
            Debug.Log($"<b>{target.GetNameWithoutPrefix()}:</b> {message}");
        }

        public static void PrintWarning(this Object target, string message)
        {
            Debug.LogWarning($"<b>{target.GetNameWithoutPrefix()}</b>: {message}");
        }

        public static void SetPrefix(this GameObject target, string prefix)
        {
            if (target == null)
                return;

            string[] separatedName = target.name.Split(']');

            if (separatedName.Length == 2)
                target.name = $"[{prefix}]{separatedName[1]}";

            else if (separatedName.Length == 1)
                target.name = $"[{prefix}]{target.name}";
        }

        public static string GetNameWithoutPrefix(this Object target)
        {
            if (target == null)
                return string.Empty;

            string[] separatedName = target.name.Split(']');

            if (separatedName.Length == 2)
                return separatedName[1];

            else
                return target.name;
        }
    }

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

    public static class BaseTypesExtensions
    { 
        /// <summary>
        /// SadButTrue -> Sad But True
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToSplitPascalCase(this string input)
        {
            if (input == null || input.Length == 0)
            {
                return input;
            }

            StringBuilder stringBuilder = new StringBuilder(input.Length);
            if (char.IsLetter(input[0]))
            {
                stringBuilder.Append(char.ToUpper(input[0]));
            }
            else
            {
                stringBuilder.Append(input[0]);
            }

            for (int i = 1; i < input.Length; i++)
            {
                char c = input[i];
                if (char.IsUpper(c) && !char.IsUpper(input[i - 1]))
                {
                    stringBuilder.Append(' ');
                }

                stringBuilder.Append(c);
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Sad But True -> SadButTrue
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string WithoutSpaces(this string input)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (c == ' ' && i + 1 < input.Length)
                {
                    char c2 = input[i + 1];
                    if (char.IsLower(c2))
                    {
                        c2 = char.ToUpper(c2, CultureInfo.InvariantCulture);
                    }

                    stringBuilder.Append(c2);
                    i++;
                }
                else
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString();
        }

        public static float ClampPositive(this float value)
        {
            return Mathf.Clamp(value, 0, float.MaxValue);
        }

        public static int ClampPositive(this int value)
        {
            return Mathf.Clamp(value, 0, int.MaxValue);
        }

        public static string FirstCharToUpper(this string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new System.ArgumentNullException(nameof(input));


            return input[0].ToString().ToUpper() + input.Substring(1);
        }

        public static Vector3 XY2XZ(this Vector2 target)
        {
            return new Vector3(target.x, 0, target.y);
        }

        public static Vector2 XZ2XY(this Vector3 target)
        {
            return new Vector2(target.x, target.z);
        }

        public static Color Invert(this Color value)
        {
            return new Color(1 - value.r, 1 - value.g, 1 - value.b);
        }

        public static Color WithAlpha(this Color value, float alpha)
        {
            return new Color(
                    value.r,
                    value.g,
                    value.b,
                    Mathf.Clamp01(alpha));
        }

        public static Color MaxAlpha(this Color value)
        {
            return new Color(
                    value.r,
                    value.g,
                    value.b,
                    1);
        }

        public static Color MinAlpha(this Color value)
        {
            return new Color(
                    value.r,
                    value.g,
                    value.b,
                    0);
        }

        public static Quaternion ExtractRotation(this Matrix4x4 matrix)
        {
            Vector3 forward;
            forward.x = matrix.m02;
            forward.y = matrix.m12;
            forward.z = matrix.m22;

            Vector3 upwards;
            upwards.x = matrix.m01;
            upwards.y = matrix.m11;
            upwards.z = matrix.m21;

            return Quaternion.LookRotation(forward, upwards);
        }

        public static Vector3 ExtractPosition(this Matrix4x4 matrix)
        {
            Vector3 position;
            position.x = matrix.m03;
            position.y = matrix.m13;
            position.z = matrix.m23;
            return position;
        }

        public static Vector3 ExtractScale(this Matrix4x4 matrix)
        {
            Vector3 scale;
            scale.x = new Vector4(matrix.m00, matrix.m10, matrix.m20, matrix.m30).magnitude;
            scale.y = new Vector4(matrix.m01, matrix.m11, matrix.m21, matrix.m31).magnitude;
            scale.z = new Vector4(matrix.m02, matrix.m12, matrix.m22, matrix.m32).magnitude;
            return scale;
        }
    }
}