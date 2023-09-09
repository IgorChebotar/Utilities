using UnityEngine;

namespace SimpleMan.Utilities
{
    public static class FloatExtensions
    {
        /// <summary>
        /// Returns reflected value. Ex. 1 -> -1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float Mirror(this float value)
        {
            return -value;
        }

        /// <summary>
        /// Returns reflected value. Ex. 1 -> -1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void MirrorRef(ref this float value)
        {
            value = -value;
        }

        /// <summary>
        /// Clamps the given value between the given minimum float and maximum float values.
        /// Returns the given value if it is within the minimum and maximum range.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static float Clamp(this float value, float min, float max)
        {
            return Mathf.Clamp(value, min, max);
        }

        /// <summary>
        /// Clamps the given value between the given minimum float and maximum float values.
        /// Returns the given value if it is within the minimum and maximum range.
        /// </summary>
        /// <returns></returns>
        public static void ClampRef(ref this float value, float min, float max)
        {
            value = value.Clamp(min, max);
        }

        /// <summary>
        /// Clamps the given value between the given minimum float and maximum float values.
        /// Returns the given value if it is within the minimum and maximum range.
        /// </summary>
        /// <returns></returns>
        public static float Clamp(this float value, Vector2 range)
        {
            return Mathf.Clamp(value, range.x, range.y);
        }

        /// <summary>
        /// Clamps the given value between the given minimum float and maximum float values.
        /// Returns the given value if it is within the minimum and maximum range.
        /// </summary>
        /// <returns></returns>
        public static void ClampRef(ref this float value, Vector2 range)
        {
            value = value.Clamp(range);
        }

        /// <summary>
        /// Clamps the given value between the given minimum float and maximum float values.
        /// Returns the given value if it is within the minimum and maximum range.
        /// </summary>
        /// <returns></returns>
        public static float Clamp(this float value, FloatRange range)
        {
            return Mathf.Clamp(value, range.Min, range.Max);
        }

        /// <summary>
        /// Clamps the given value between the given minimum float and maximum float values.
        /// Returns the given value if it is within the minimum and maximum range.
        /// </summary>
        /// <returns></returns>
        public static void ClampRef(ref this float value, FloatRange range)
        {
            value = value.Clamp(range);
        }

        /// <summary>
        /// From 0 to infinity
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float ClampPositive(this float value)
        {
            return value.SetMin(0);
        }

        /// <summary>
        /// From 0 to infinity
        /// </summary>
        /// <returns></returns>
        public static void ClampPositiveRef(ref this float value)
        {
            value = value.ClampPositive();
        }

        /// <summary>
        /// From negative infinity to 0
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float ClampNegative(this float value)
        {
            return value.SetMax(0);
        }

        /// <summary>
        /// From negative infinity to 0
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void ClampNegativeRef(ref this float value)
        {
            value = value.SetMax(0);
        }

        /// <summary>
        /// From value to infinity
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float SetMin(this float value, float minValue)
        {
            return Mathf.Clamp(value, minValue, float.PositiveInfinity);
        }

        /// <summary>
        /// From value to infinity
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetMinRef(ref this float value, float minValue)
        {
            value = value.SetMin(minValue);
        }

        /// <summary>
        /// From negative infinity to max value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float SetMax(this float value, float maxValue)
        {
            return Mathf.Clamp(value, float.NegativeInfinity, maxValue);
        }

        /// <summary>
        /// From negative infinity to max value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetMaxRef(ref this float value, float maxValue)
        {
            value = value.SetMax(maxValue);
        }

        /// <summary>
        /// From 0 to 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float Clamp01(this float value)
        {
            return Mathf.Clamp01(value);
        }

        /// <summary>
        /// From 0 to 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void Clamp01Ref(ref this float value)
        {
            value = value.Clamp01();
        }

        /// <summary>
        /// From -1 to 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float ClampAxis(this float value)
        {
            return Mathf.Clamp(value, -1, 1);
        }

        /// <summary>
        /// From -1 to 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void ClampAxisRef(ref this float value)
        {
            value = value.ClampAxis();
        }

        /// <summary>
        /// Normalizes an input angle in degrees to the range of -180 to 180 degrees 
        /// by removing complete revolutions (360 degrees) while preserving the angle's direction.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float NormalizeAngle(this float value)
        {
            return value - 180f * Mathf.Floor((value + 180f) / 180f);
        }

        /// <summary>
        /// Normalizes an input angle in degrees to the range of -180 to 180 degrees 
        /// by removing complete revolutions (360 degrees) while preserving the angle's direction.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void NormalizeAngleRef(ref this float value)
        {
            value = value.NormalizeAngle();
        }

        /// <summary>
        /// Use if you need to stay in (0; 360) range
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static float ClampAngle(this float value, float min, float max)
        {
            float dtAngle = Mathf.Abs(((min - max) + 180) % 360 - 180);
            float hdtAngle = dtAngle * 0.5f;
            float midAngle = min + hdtAngle;

            float offset = Mathf.Abs(Mathf.DeltaAngle(value, midAngle)) - hdtAngle;

            if (offset > 0)
                value = Mathf.MoveTowardsAngle(value, midAngle, offset);

            return value;
        }

        /// <summary>
        /// Clamps an input angle between the specified minimum and maximum angles
        /// while considering their mid-angle.
        /// </summary>
        /// <param name="value">The input angle to clamp.</param>
        /// <param name="min">The minimum angle of the range.</param>
        /// <param name="max">The maximum angle of the range.</param>
        /// <returns>The clamped angle.</returns>
        public static float ClampAngle(this float value, Vector2 range)
        {
            return ClampAngle(value, range.x, range.y);
        }

        /// <summary>
        /// Clamps an input angle between the specified minimum and maximum angles
        /// while considering their mid-angle.
        /// </summary>
        /// <param name="value">The input angle to clamp.</param>
        /// <returns>The clamped angle.</returns>
        public static void ClampAngleRef(ref this float value, Vector2 range)
        {
            value = value.ClampAngle(range);
        }

        /// <summary>
        /// Clamps an input angle between the specified minimum and maximum angles
        /// while considering their mid-angle.
        /// </summary>
        /// <param name="value">The input angle to clamp.</param>
        /// <returns>The clamped angle.</returns>
        public static void ClampAngleRef(ref this float value, float min, float max)
        {
            value = value.ClampAngle(min, max);
        }

        /// <summary>
        /// Returns the absolute value of value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float Abs(this float value)
        {
            return Mathf.Abs(value);
        }

        /// <summary>
        /// Returns the absolute value of value.
        /// </summary>
        /// <param name="value"></param>
        public static void AbsRef(ref this float value)
        {
            value = value.Abs();
        }

        /// <summary>
        /// Returns nearest integer to value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float Round(this float value)
        {
            return Mathf.Round(value);
        }

        /// <summary>
        /// Returns nearest integer to value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void RoundRef(ref this float value)
        {
            value = value.Round();
        }

        /// <summary>
        /// Returns nearest integer to value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int RoundToInt(this float value)
        {
            return Mathf.RoundToInt(value);
        }

        /// <summary>
        /// Returns the largest integer smaller than or equal to f.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float Floor(this float value)
        {
            return Mathf.Floor(value);
        }

        /// <summary>
        /// Returns the largest integer smaller than or equal to f.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void FloorRef(ref this float value)
        {
            value = value.Floor();
        }

        /// <summary>
        /// Returns the largest integer smaller than or equal to f.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int FloorToInt(this float value)
        {
            return Mathf.FloorToInt(value);
        }

        /// <summary>
        /// Returns the smallest integer greater to or equal to f.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float Ceil(this float value)
        {
            return Mathf.Ceil(value);
        }

        /// <summary>
        /// Returns the smallest integer greater to or equal to f.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void CeilRef(ref this float value)
        {
            value = value.Ceil();
        }

        /// <summary>
        /// Returns the smallest integer greater to or equal to f.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int CeilToInt(this float value)
        {
            return Mathf.CeilToInt(value);
        }

        /// <summary>
        /// Returns true if value within given range (min, max included)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static bool InRange(this float value, float min, float max)
        {
            return value >= min && value <= max;
        }

        /// <summary>
        /// Returns true if value within given range (min, max included)
        /// </summary>
        public static bool InRange(this float value, Vector2 range)
        {
            return value.InRange(range.x, range.y);
        }

        /// <summary>
        /// Returns true if value within given range (min, max included)
        /// </summary>
        public static bool InRange(this float value, FloatRange range)
        {
            return value.InRange(range.Min, range.Max);
        }

        /// <summary>
        /// Returns true if value out of given range (min, max excluded)
        /// </summary>
        public static bool OutOfRange(this float value, float min, float max)
        {
            return value < min || value > max;
        }

        /// <summary>
        /// Returns true if value out of given range (min, max excluded)
        /// </summary>
        public static bool OutOfRange(this float value, Vector2 range)
        {
            return value.OutOfRange(range.x, range.y);
        }

        /// <summary>
        /// Returns true if value out of given range (min, max excluded)
        /// </summary>
        public static bool OutOfRange(this float value, FloatRange range)
        {
            return value.OutOfRange(range.Min, range.Max);
        }
    }
}