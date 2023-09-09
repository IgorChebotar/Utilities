using UnityEngine;

namespace SimpleMan.Utilities
{
    public static class QuaternionExtensions
    {
        public static Vector3 ExtractVector(this Quaternion rotation, Vector3 direction)
        {
            return rotation * direction;
        }

        public static Vector3 ExtractForwardVector(this Quaternion rotation)
        {
            return rotation * Vector3.forward;
        }

        public static Vector3 ExtractRightVector(this Quaternion rotation)
        {
            return rotation * Vector3.right;
        }
    }
}