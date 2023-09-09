using UnityEngine;

namespace SimpleMan.Utilities
{
    public static class IntExtensions
    {
        /// <summary>
        /// Returns reflected value. Ex. 1 -> -1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Mirror(this int value)
        {
            return -value;
        }

        /// <summary>
        /// Returns reflected value. Ex. 1 -> -1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void MirrorRef(ref this int value)
        {
            value = -value;
        }

        /// <summary>
        /// Clamps the given value between the given minimum float and maximum float values.
        /// Returns the given value if it is within the minimum and maximum range.
        /// </summary>
        /// <returns></returns>
        public static int Clamp(this int value, float min, float max)
        {
            return Mathf.Clamp(value, min, max).FloorToInt();
        }

        /// <summary>
        /// Clamps the given value between the given minimum float and maximum float values.
        /// Returns the given value if it is within the minimum and maximum range.
        /// </summary>
        /// <returns></returns>
        public static void ClampRef(ref this int value, float min, float max)
        {
            value = value.Clamp(min, max);
        }

        /// <summary>
        /// Clamps the given value between the given minimum float and maximum float values.
        /// Returns the given value if it is within the minimum and maximum range.
        /// </summary>
        /// <returns></returns>
        public static int Clamp(this int value, Vector2 range)
        {
            return Mathf.Clamp(value, range.x, range.y).FloorToInt();
        }

        /// <summary>
        /// Clamps the given value between the given minimum float and maximum float values.
        /// Returns the given value if it is within the minimum and maximum range.
        /// </summary>
        /// <returns></returns>
        public static void ClampRef(ref this int value, Vector2 range)
        {
            value = value.Clamp(range);
        }

        /// <summary>
        /// Clamps the given value between the given minimum float and maximum float values.
        /// Returns the given value if it is within the minimum and maximum range.
        /// </summary>
        /// <returns></returns>
        public static int Clamp(this int value, FloatRange range)
        {
            return Mathf.Clamp(value, range.Min, range.Max).FloorToInt();
        }

        /// <summary>
        /// Clamps the given value between the given minimum float and maximum float values.
        /// Returns the given value if it is within the minimum and maximum range.
        /// </summary>
        /// <returns></returns>
        public static void ClampRef(ref this int value, FloatRange range)
        {
            value = value.Clamp(range);
        }

        /// <summary>
        /// From 0 to infinity
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ClampPositive(this int value)
        {
            return SetMin(value, 0);
        }

        /// <summary>
        /// From 0 to infinity
        /// </summary>
        /// <returns></returns>
        public static void ClampPositiveRef(ref this int value)
        {
            value = value.ClampPositive();
        }

        /// <summary>
        /// From negative infinity to 0
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ClampNegative(this int value)
        {
            return value.SetMax(0);
        }

        /// <summary>
        /// From negative infinity to 0
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void ClampNegativeRef(ref this int value)
        {
            value = value.SetMax(0);
        }

        /// <summary>
        /// Clamps value from from specified value to positive infinity
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int SetMin(this int value, float minValue)
        {
            return Mathf.Clamp(value, minValue, float.PositiveInfinity).FloorToInt();
        }

        /// <summary>
        /// Clamps value from from specified value to positive infinity
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetMinRef(ref this int value, float minValue)
        {
            value = SetMin(value, minValue);
        }

        /// <summary>
        /// Clamps value from from negative infinity to specified value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int SetMax(this int value, float maxValue)
        {
            return Mathf.Clamp(value, float.NegativeInfinity, maxValue).FloorToInt();
        }

        /// <summary>
        /// Clamps value from from negative infinity to specified value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetMaxRef(ref this int value, float maxValue)
        {
            value = value.SetMax(maxValue);
        }

        /// <summary>
        /// Returns true if value within given range (min, max included)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static bool InRange(this int value, float min, float max)
        {
            return value >= min && value <= max;
        }

        /// <summary>
        /// Returns true if value within given range (min, max included)
        /// </summary>
        public static bool InRange(this int value, Vector2 range)
        {
            return value.InRange(range.x, range.y);
        }

        /// <summary>
        /// Returns true if value within given range (min, max included)
        /// </summary>
        public static bool InRange(this int value, FloatRange range)
        {
            return value.InRange(range.Min, range.Max);
        }

        /// <summary>
        /// Returns true if value out of given range (min, max excluded)
        /// </summary>
        public static bool OutOfRange(this int value, float min, float max)
        {
            return value < min || value > max;
        }

        /// <summary>
        /// Returns true if value out of given range (min, max excluded)
        /// </summary>
        public static bool OutOfRange(this int value, Vector2 range)
        {
            return value.OutOfRange(range.x, range.y);
        }

        /// <summary>
        /// Returns true if value out of given range (min, max excluded)
        /// </summary>
        public static bool OutOfRange(this int value, FloatRange range)
        {
            return value.OutOfRange(range.Min, range.Max);
        }

        /// <summary>
        /// Returns the absolute value of value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Abs(this int value)
        {
            return Mathf.Abs(value);
        }

        /// <summary>
        /// Returns the absolute value of value.
        /// </summary>
        /// <param name="value"></param>
        public static void AbsRef(ref this int value)
        {
            value = value.Abs();
        }
    }
}