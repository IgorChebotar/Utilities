using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace SimpleMan.Utilities
{
    public static class UnityObjectExtensions
    {
        /// <summary>
        /// Returns first object of specified type on scene (interfaces supported)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FindObjectOfType<T>() where T : class
        {
            MonoBehaviour[] allMonobehaviors = Object.FindObjectsOfType<MonoBehaviour>();
            return allMonobehaviors.OfType<T>().First();
        }

        /// <summary>
        /// Returns array of objects of specified type on scene (interfaces supported)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T[] FindObjectsOfType<T>() where T: class
        {
            MonoBehaviour[] allMonobehaviors = Object.FindObjectsOfType<MonoBehaviour>();
            return allMonobehaviors.OfType<T>().ToArray();
        }

        /// <summary>
        /// Pseudo-builder
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="apply"></param>
        /// <returns></returns>
        public static T With<T>(this T source, Action<T> apply) 
        {
            apply?.Invoke(source);
            return source;
        }

        /// <summary>
        /// Pseudo-builder
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="apply"></param>
        /// <param name="when"></param>
        /// <returns></returns>
        public static T With<T>(this T source, Action<T> apply, bool when) 
        {
            if (when)
                apply?.Invoke(source);

            return source;
        }

        /// <summary>
        /// Pseudo-builder
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="apply"></param>
        /// <param name="when"></param>
        /// <returns></returns>
        public static T With<T>(this T source, Action<T> apply, Func<bool> when) 
        {
            if (when())
                apply?.Invoke(source);

            return source;
        }

        /// <summary>
        /// Print debug log message with name of the object caller
        /// </summary>
        /// <param name="target"></param>
        /// <param name="message"></param>
        public static void PrintLog(this Object target, string message)
        {
            PrintToConsole.Info(target.name.WithoutSquarePrefix(), message);
        }

        /// <summary>
        /// Print debug warning message with name of the object caller
        /// </summary>
        /// <param name="target"></param>
        /// <param name="message"></param>
        public static void PrintWarning(this Object target, string message)
        {
            PrintToConsole.Warning(target.name.WithoutSquarePrefix(), message);
        }

        /// <summary>
        /// Print debug error message with name of the object caller
        /// </summary>
        /// <param name="target"></param>
        /// <param name="message"></param>
        public static void PrintError(this Object target, string message)
        {
            PrintToConsole.Error(target.name.WithoutSquarePrefix(), message);
        }

        /// <summary>
        /// ObjectName -> [Prefix]ObjectName
        /// </summary>
        /// <param name="target"></param>
        /// <param name="prefix"></param>
        public static void SetSquarePrefix(this GameObject target, string prefix)
        {
            target.name = target.name.WithSquarePrefix(prefix);
        }

        /// <summary>
        /// ObjectName -> Prefix_ObjectName
        /// </summary>
        /// <param name="target"></param>
        /// <param name="prefix"></param>
        public static void SetUnderscorePrefix(this GameObject target, string prefix)
        {
            target.name = target.name.WithUnderscorePrefix(prefix);
        }

        /// <summary>
        /// Returns name of the target game object without prefix
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string GetNameWithoutSquarePrefix(this Object target)
        {
            return target.name.WithoutSquarePrefix();
        }

        /// <summary>
        /// Returns name of the target game object without prefix
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string GetNameWithoutUnderscorePrefix(this Object target)
        {
            return target.name.WithoutUnderscorePrefix();
        }

        /// <summary>
        /// Move object to the target scene
        /// </summary>
        /// <param name="target"></param>
        /// <param name="sceneName"></param>
        /// <returns></returns>
        /// <exception cref="System.NullReferenceException"></exception>
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

        /// <summary>
        /// Move object to the target scene
        /// </summary>
        /// <param name="target"></param>
        /// <param name="scene"></param>
        /// <returns></returns>
        public static GameObject ToScene(this GameObject target, Scene scene)
        {
            SceneManager.MoveGameObjectToScene(target, scene);
            return target;
        }
    }
}