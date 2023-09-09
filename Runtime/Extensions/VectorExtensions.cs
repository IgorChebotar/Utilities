using UnityEngine;

namespace SimpleMan.Utilities
{
    public static class VectorExtensions
    {
        /// <summary>
        /// (1, 2) -> (1, 0, 2)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Vector3Int XY2XZ(this Vector2Int value)
        {
            return new Vector3Int(value.x, 0, value.y);
        }

        /// <summary>
        /// (1, 2) -> (1, 0, 2)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Vector3 XY2XZ(this Vector2 value)
        {
            return new Vector3(value.x, 0, value.y);
        }

        /// <summary>
        /// (1, 2, 3) -> (1, 3)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Vector2 XZ2XY(this Vector3 value)
        {
            return new Vector2(value.x, value.z);
        }

        /// <summary>
        /// (1, 2, 3) -> (1, 3)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Vector2Int XZ2XY(this Vector3Int value)
        {
            return new Vector2Int(value.x, value.z);
        }

        public static Vector2 ToFloatVector(this Vector2Int value)
        {
            return new Vector2(value.x, value.y);
        }

        public static Vector3 ToFloatVector(this Vector3Int value)
        {
            return new Vector3(value.x, value.y, value.z);
        }

        public static Vector2Int ToIntVector(this Vector2 value)
        {
            return new Vector2Int(
                value.x.RoundToInt(), 
                value.y.RoundToInt());
        }

        public static Vector3Int ToIntVector(this Vector3 value)
        {
            return new Vector3Int(
                value.x.RoundToInt(), 
                value.y.RoundToInt(),
                value.z.RoundToInt());
        }

        public static Vector2Int Normalized(this Vector2Int value)
        {
            return new Vector2Int(
                value.x.Clamp(-1, 1),
                value.y.Clamp(-1, 1));
        }

        public static Vector3Int Normalized(this Vector3Int value)
        {
            return new Vector3Int(
                value.x.Clamp(-1, 1),
                value.y.Clamp(-1, 1),
                value.z.Clamp(-1, 1));
        }

        public static void NormalizeRef(ref this Vector2Int value)
        {
            value = value.Normalized();
        }

        public static void NormalizeRef(ref this Vector3Int value)
        {
            value = value.Normalized();
        }
    }
}