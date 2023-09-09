using System;
using UnityEngine;

namespace SimpleMan.Utilities
{
    [Serializable]
    public struct FloatRange
    {
        [SerializeField]
        private float _min;

        [SerializeField]
        private float _max;

        public FloatRange(float min, float max)
        {
            _min = min;
            _max = max;
        }

        public FloatRange(Vector2 range)
        {
            _min = range.x;
            _max = range.y;
        }

        public float Min
        {
            get => _min;
            set => _min = value.SetMax(_max);
        }
        public float Max
        {
            get => _max;
            set => _min = value.SetMin(_min);
        }
    }
}