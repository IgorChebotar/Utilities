using System;
using System.Collections;
using UnityEngine;


namespace SimpleMan.Utilities
{
    public static class Coroutines
    {
        #region DESTROY AFTER
        /// <summary>
        /// Destroy game object after delay
        /// </summary>
        /// <param name="component"></param>
        /// <param name="delay"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static Coroutine DestroyAfter(this MonoBehaviour component, float delay, Action callback = null, bool useScaledTime = false)
        {
            if (delay < 0)
                component.ThrowArgumentNullException("Delay", "Delay argument must be equal or greater than 0");


            return component.StartCoroutine(DestroyCounter(component.gameObject, delay, callback, useScaledTime));
        }

        /// <summary>
        /// Destroy target component after delay
        /// </summary>
        /// <param name="component"></param>
        /// <param name="delay"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static Coroutine DestroyComponentAfter(this MonoBehaviour component, float delay, Action callback = null, bool useScaledTime = false)
        {
            if (delay < 0)
                component.ThrowArgumentNullException("Delay", "Delay argument must be equal or greater than 0");


            return component.StartCoroutine(DestroyCounter(component, delay, callback, useScaledTime));
        }

        private static IEnumerator DestroyCounter(UnityEngine.Object target, float delay, Action _callback, bool useScaledTime)
        {
            if(useScaledTime)
                yield return new WaitForSeconds(delay);

            else
                yield return new WaitForSecondsRealtime(delay);

            UnityEngine.Object.Destroy(target);
            _callback?.Invoke();
        }
        #endregion

        #region DELAY
        /// <summary>
        /// Invoke callback after delay
        /// </summary>
        /// <param name="component"></param>
        /// <param name="delay"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static Coroutine Delay(this MonoBehaviour component, float delay, Action callback, bool useScaledTime = true)
        {
            if (delay < 0)
                component.ThrowArgumentNullException("Delay", "Delay argument must be equal or greater than 0");

            return component.StartCoroutine(DelayCounter(delay, callback, useScaledTime));
        }

        private static IEnumerator DelayCounter(float _time, Action _callback, bool useRealtime)
        {
            if(useRealtime)
                yield return new WaitForSeconds(_time);

            else
                yield return new WaitForSecondsRealtime(_time);

            _callback?.Invoke();
        }
        #endregion

        #region WAIT UNTIL
        public static Coroutine WaitUntil(this MonoBehaviour component, Func<bool> condition, Action callback, float delay = 0)
        {
            if (delay < 0)
                component.ThrowArgumentNullException("Delay", "Delay argument must be equal or greater than 0");


            return component.StartCoroutine(WaitUntilCounter(condition, callback, delay));
        }


        private static IEnumerator WaitUntilCounter(Func<bool> condition, Action callback = null, float delay = 0)
        {
            while (condition())
            {
                if (delay < 0)
                    yield return null;

                else
                    yield return new WaitForSeconds(delay);
            }

            callback?.Invoke();
        }
        #endregion

        #region WAIT FRAMES
        public static Coroutine WaitFrames(this MonoBehaviour component, int frames, Action callback)
        {
            if (frames < 0)
                component.ThrowArgumentNullException("Frames", "Frames argument must be equal or greater than 0");


            return component.StartCoroutine(WaitFramesCounter(frames, callback));
        }


        private static IEnumerator WaitFramesCounter(int waitFrames, Action callback = null)
        {
            for (int i = 0; i < waitFrames; i++)
            {
                yield return null;
            }

            callback?.Invoke();
        }
        #endregion

        #region REPEAT
        /// <summary>
        /// Call action each [delay] seconds forever
        /// </summary>
        /// <param name="component"></param>
        /// <param name="repeatAction"></param>
        /// <param name="delay"></param>
        /// <returns></returns>
        public static Coroutine RepeatForever(this MonoBehaviour component, Action repeatAction, float delay = 0)
        {
            if(delay < 0)
                component.ThrowArgumentNullException("Delay", "Delay argument must be equal or greater than 0");


            return component.StartCoroutine(RepeatUntilCounter(() => true, repeatAction, null, delay));
        }

        /// <summary>
        /// Call action each [delay] seconds while condition is false
        /// </summary>
        /// <param name="component"></param>
        /// <param name="condition"></param>
        /// <param name="repeatAction"></param>
        /// <param name="callback"></param>
        /// <param name="delay"></param>
        /// <returns></returns>
        public static Coroutine RepeatUntil(this MonoBehaviour component, Func<bool> condition, Action repeatAction, Action callback, float delay = 0)
        {
            return component.StartCoroutine(RepeatUntilCounter(condition, repeatAction, callback, delay));
        }

        private static IEnumerator RepeatUntilCounter(Func<bool> condition, Action repeatAction, Action callback, float delay = 0)
        {
            while (condition())
            {
                repeatAction?.Invoke();


                if (delay < 0)
                    yield return null;

                else
                    yield return new WaitForSeconds(delay);
            }

            callback?.Invoke();
        }
        #endregion
    }
}
