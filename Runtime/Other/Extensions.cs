using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace SimpleMan.Utilities
{
    public static class PrintToConsole
    {
        public static void Info(string sender, string message)
        {
            Debug.Log($"<b>{sender}</b>: {message}");
        }

        public static void Warning(string sender, string message)
        {
            Debug.LogWarning($"<b>{sender}</b>: {message}");
        }

        public static void ValueChangedInfo(string sender, string propertyName, string value)
        {
            Info(sender, $"Value <b> '{propertyName}' </b> has been changed. New value is <b> '{value}' </b>");
        }
    }

    public static class ThrowException
    {
        public static void Pure(string sender, string message)
        {
            throw new Exception($"<b>{sender}</b>: {message}");
        }

        public static void NullReference(string sender, string message)
        {
            throw new NullReferenceException($"<b>{sender}</b>: {message}");
        }

        public static void ArgumentNull(string sender, string argumentName, string message = "")
        {
            throw new Exception(
                $"<b>{sender}</b>: Argument '{argumentName}' is null. {message}");
        }

        public static void ArgumentOutOfRange(string sender, string argumentName, string message = "")
        {
            throw new Exception(
                $"<b>{sender}</b>: Argument '{argumentName}' is out of range. {message}");
        }

        public static void IndexOutOfRange(string sender, string indexname, string message = "")
        {
            throw new Exception(
                $"<b>{sender}</b>: Index '{indexname}' is out of range. {message}");
        }

        public static void InvalidOperation(string sender, string message)
        {
            throw new InvalidOperationException($"<b>{sender}</b>: {message}");
        }
    }



    public static class Check
    {
        public interface IBaseActionSelector
        {
            void PrintLog(string sender, string message);

            void PrintWaring(string sender, string message);

            void Execute(Action action);
        }

        public interface IExceptionThrowable : IBaseActionSelector
        {
            void ThrowExcetion(string sender, string message);
        }

        public class BaseActionSelector : IBaseActionSelector
        {
            public void Execute(Action action)
            {
                action?.Invoke();
            }

            public void PrintLog(string sender, string message)
            {
                PrintToConsole.Info(sender, message);
            }

            public void PrintWaring(string sender, string message)
            {
                PrintToConsole.Warning(sender, message);
            }
        }

        public class PassiveActionSelector : IExceptionThrowable
        {
            public void Execute(Action action)
            {

            }

            public void PrintLog(string sender, string message)
            {

            }

            public void PrintWaring(string sender, string message)
            {

            }

            public void ThrowExcetion(string sender, string message)
            {

            }
        }

        public class ActionSelector : BaseActionSelector, IExceptionThrowable
        {
            public void ThrowExcetion(string sender, string message)
            {
                ThrowException.Pure(sender, message);
            }
        }




        public static IExceptionThrowable IfNull(this object target)
        {
            if (target == null)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }

        public static IExceptionThrowable IfNotNull(this object target)
        {
            if (target != null)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }




        public static IExceptionThrowable IfEqualZero(this int target)
        {
            if (target == 0)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }

        public static IExceptionThrowable IfEqualZero(this float target)
        {
            if (target == 0)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }

        public static IExceptionThrowable INotEqualZero(this int target)
        {
            if (target != 0)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }

        public static IExceptionThrowable INotEqualZero(this float target)
        {
            if (target != 0)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }

        public static IExceptionThrowable IfLessThanZero(this int target)
        {
            if (target < 0)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }

        public static IExceptionThrowable IfLessThanZero(this float target)
        {
            if (target < 0)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }

        public static IExceptionThrowable IfLessOrEqualZero(this int target)
        {
            if (target <= 0)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }

        public static IExceptionThrowable IfLessOrEqualZero(this float target)
        {
            if (target <= 0)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }

        public static IExceptionThrowable IfGreaterThanZero(this int target)
        {
            if (target > 0)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }

        public static IExceptionThrowable IfGreaterThanZero(this float target)
        {
            if (target > 0)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }

        public static IExceptionThrowable IfGreaterOrEqualZero(this int target)
        {
            if (target >= 0)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }

        public static IExceptionThrowable IfGreaterOrEqualZero(this float target)
        {
            if (target >= 0)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }




        public static IExceptionThrowable IfEqual(this int target, int value)
        {
            if (target == value)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }

        public static IExceptionThrowable IfEqual(this float target, int value)
        {
            if (target == value)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }

        public static IExceptionThrowable INotEqual(this int target, int value)
        {
            if (target != value)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }

        public static IExceptionThrowable INotEqual(this float target, float value)
        {
            if (target != value)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }

        public static IExceptionThrowable IfLessThan(this int target, int value)
        {
            if (target < value)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }

        public static IExceptionThrowable IfLessThan(this float target, int value)
        {
            if (target < value)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }

        public static IExceptionThrowable IfLessOrEqual(this int target, int value)
        {
            if (target <= value)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }

        public static IExceptionThrowable IfLessOrEqual(this float target, int value)
        {
            if (target <= value)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }

        public static IExceptionThrowable IfGreaterThan(this int target, int value)
        {
            if (target > value)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }

        public static IExceptionThrowable IfGreaterThan(this float target, int value)
        {
            if (target > value)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }

        public static IExceptionThrowable IfGreaterOrEqual(this int target, int value)
        {
            if (target >= value)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }

        public static IExceptionThrowable IfGreaterOrEqual(this float target, int value)
        {
            if (target >= value)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }




        public static IExceptionThrowable IfEqual(this int target, float value)
        {
            if (target == value)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }

        public static IExceptionThrowable IfEqual(this float target, float value)
        {
            if (target == value)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }

        public static IExceptionThrowable IfLessThan(this int target, float value)
        {
            if (target < value)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }

        public static IExceptionThrowable IfLessThan(this float target, float value)
        {
            if (target < value)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }

        public static IExceptionThrowable IfLessOrEqual(this int target, float value)
        {
            if (target <= value)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }

        public static IExceptionThrowable IfLessOrEqual(this float target, float value)
        {
            if (target <= value)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }

        public static IExceptionThrowable IfGreaterThan(this int target, float value)
        {
            if (target > value)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }

        public static IExceptionThrowable IfGreaterThan(this float target, float value)
        {
            if (target > value)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }

        public static IExceptionThrowable IfGreaterOrEqual(this int target, float value)
        {
            if (target >= value)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }

        public static IExceptionThrowable IfGreaterOrEqual(this float target, float value)
        {
            if (target >= value)
                return new ActionSelector();

            else
                return new PassiveActionSelector();
        }
    }

    public static class CollectionsExtensions
    {
        public static T Random<T>(this IEnumerable<T> source)
        {
            int randomIndex = UnityEngine.Random.Range(0, source.Count());
            return source.ElementAt(randomIndex);
        }

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

        /// <summary>
        /// Returns collection without null elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<T> Validate<T>(this IEnumerable<T> source)
        {
            foreach (T item in source)
            {
                if (item != null)
                    yield return item;
            }
        }

        /// <summary>
        /// Throws an exeption when at lest one elemet is null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<T> NullCheck<T>(this IEnumerable<T> source, string exceptionText, Object context = null)
        {
            foreach (T item in source)
            {
                if (item == null)
                {
                    if (!context)
                        throw new NullReferenceException(exceptionText);

                    else
                        context.ThrowNullReferenceException(exceptionText);
                }
            }

            return source;
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
        public static T With<T>(this T source, Action<T> apply) 
        {
            apply?.Invoke(source);
            return source;
        }

        public static T With<T>(this T source, Action<T> apply, bool when) 
        {
            if (when)
                apply?.Invoke(source);

            return source;
        }

        public static T With<T>(this T source, Action<T> apply, Func<bool> when) 
        {
            if (when())
                apply?.Invoke(source);

            return source;
        }

        public static void ThrowNullReferenceException(this Object target, string message)
        {
            ThrowException.NullReference(target.name.WithoutPrefix(), message);
        }

        public static void ThrowArgumentNullException(this Object target, string argumentName, string message = "")
        {
            ThrowException.ArgumentNull(target.name.WithoutPrefix(), argumentName, message);
        }

        public static void ThrowInvalidOperationException(this Object target, string message)
        {
            ThrowException.InvalidOperation(target.name.WithoutPrefix(), message);
        }

        public static void ThrowArgumentOutOfRangeException(this Object target, string indexName, string message = "")
        {
            ThrowException.ArgumentOutOfRange(target.name.WithoutPrefix(), indexName, message);
        }

        public static void ThrowIndexOutOfRangeException(this Object target, string indexName, string message = "")
        {
            ThrowException.IndexOutOfRange(target.name.WithoutPrefix(), indexName, message);
        }

        public static void ThrowMustBeChildOfException(this Object target, string parentComponentName, string message = "")
        {
            ThrowException.Pure(
                target.name.WithoutPrefix(), 
                $"<b>{target.GetNameWithoutPrefix()}:</b> This game object must be child " +
                $"of <b>'{parentComponentName}'</b>. {message}");
        }

        public static void PrintLogValueChanged(this Object target, string protertyName, object value)
        {
            PrintToConsole.ValueChangedInfo(target.name.WithoutPrefix(), protertyName, value.ToString());
        }

        public static void PrintLog(this Object target, string message)
        {
            PrintToConsole.Info(target.name.WithoutPrefix(), message);
        }

        public static void PrintWarning(this Object target, string message)
        {
            PrintToConsole.Warning(target.name.WithoutPrefix(), message);
        }

        public static void SetPrefix(this GameObject target, string prefix)
        {
            if (target == null)
                return;

            target.name = target.name.WithPrefix(prefix);
        }

        public static string GetNameWithoutPrefix(this Object target)
        {
            if (target == null)
                return string.Empty;

            return target.name.WithoutPrefix();
        }

        public static GameObject ToScene(this GameObject target, string sceneName)
        {
            Scene GetSceneByName()
            {
                int scenesCount = SceneManager.sceneCount;
                for (int i = 0; i < scenesCount; i++)
                {
                    if (SceneManager.GetSceneAt(i).name == sceneName)
                        return SceneManager.GetSceneAt(i);
                }

                throw new System.NullReferenceException(
                    $"No opened scenes with name '{sceneName}'");
            }
            SceneManager.MoveGameObjectToScene(target, GetSceneByName());
            return target;
        }

        public static GameObject ToScene(this GameObject target, Scene scene)
        {
            SceneManager.MoveGameObjectToScene(target, scene);
            return target;
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
        /// sad but true -> Sad but true
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// 
        public static string FirstCharToUpper(this string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new System.ArgumentNullException(nameof(input));


            return input[0].ToString().ToUpper() + input.Substring(1);
        }

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

        /// <summary>
        /// ObjectName -> [Prefix]ObjectName
        /// </summary>
        /// <param name="source"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static string WithPrefix(this string source, string prefix)
        {
            if (source == null)
                return $"[{prefix}]";

            string[] separatedName = source.Split(']');

            if (separatedName.Length == 2)
                source = $"[{prefix}]{separatedName[1]}";

            else if (separatedName.Length == 1)
                source = $"[{prefix}]{source}";


            return source;
        }

        /// <summary>
        /// [Prefix]ObjectName -> ObjectName
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string WithoutPrefix(this string source)
        {
            if (source == null)
                return string.Empty;

            string[] separatedName = source.Split(']');

            if (separatedName.Length == 2)
                return separatedName[1];

            else
                return source;
        }





        public static float ClampPositive(this float value)
        {
            return Mathf.Clamp(value, 0, float.MaxValue);
        }

        public static int ClampPositive(this int value)
        {
            return Mathf.Clamp(value, 0, int.MaxValue);
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