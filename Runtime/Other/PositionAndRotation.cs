using System;
using UnityEngine;

namespace SimpleMan.Utilities
{
    [Serializable]
    public struct PositionAndRotation
    {
        public Vector3 position;
        public Quaternion rotation;




        public static PositionAndRotation Default { get; } = new PositionAndRotation(
            Vector3.zero,
            Quaternion.identity);




        public PositionAndRotation(Vector3 position, Quaternion rotation)
        {
            this.position = position;
            this.rotation = rotation;
        }
    }
}