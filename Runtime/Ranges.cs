using UnityEngine;
using Sirenix.OdinInspector;

namespace SimpleMan.Utilities
{
    [System.Serializable]
    public struct IntRange
    {
        //------FIELDS
        [SerializeField, HideInInspector]
        private Vector2Int _range;




        //------PROPERTIES
        public int Min
        {
            get => _range.x;
            set
            {
                if (value > _range.y)
                {
                    throw new System.ArgumentOutOfRangeException(
                        "Min value",
                        "Min value can't be greater than max value");
                }

                _range.x = value;
            }
        }
        public int Max
        {
            get => _range.y;
            set
            {
                if (value < _range.x)
                {
                    throw new System.ArgumentOutOfRangeException(
                        "Max value",
                        "max value can't be less than min value");
                }

                _range.y = value;
            }
        }

        [ShowInInspector, LabelText("Min")]
        private int InspectorMin
        {
            get => _range.x;
            set => _range.x = Mathf.Clamp(value, int.MinValue, _range.y);
        }

        [ShowInInspector, LabelText("Max")]
        private int InspectorMax
        {
            get => _range.y;
            set => _range.y = Mathf.Clamp(value, _range.x, int.MaxValue);
        }




        //------CONSTRUCTORS
        public IntRange(int min, int max)
        {
            if (min > max || max < min)
                throw new System.ArgumentException("Incorrect min/max values");

            _range = new Vector2Int(min, max);
        }

        public IntRange(Vector2Int range)
        {
            _range = range;
        }




        //------METHODS
        public bool InRange(int value)
        {
            return value >= Min && value <= Max;
        }
        public int Clamp(int value)
        {
            return Mathf.Clamp(value, Min, Max);
        }
    }

    [System.Serializable]
    public struct FloatRange
    {
        //------FIELDS
        [SerializeField, HideInInspector]
        private Vector2 _range;




        //------PROPERTIES
        public float Min
        {
            get => _range.x;
            set
            {
                if (value > _range.y)
                {
                    throw new System.ArgumentOutOfRangeException(
                        "Min value",
                        "Min value can't be greater than max value");
                }

                _range.x = value;
            }
        }
        public float Max
        {
            get => _range.y;
            set
            {
                if (value < _range.x)
                {
                    throw new System.ArgumentOutOfRangeException(
                        "Max value",
                        "max value can't be less than min value");
                }

                _range.y = value;
            }
        }

        [ShowInInspector, LabelText("Min")]
        private float InspectorMin
        {
            get => _range.x;
            set => _range.x = Mathf.Clamp(value, float.NegativeInfinity, _range.y);
        }

        [ShowInInspector, LabelText("Max")]
        private float InspectorMax
        {
            get => _range.y;
            set => _range.y = Mathf.Clamp(value, _range.x, float.PositiveInfinity);
        }




        //------CONSTRUCTORS
        public FloatRange(float min, float max)
        {
            if (min > max || max < min)
                throw new System.ArgumentException("Incorrect min/max values");

            _range = new Vector2(min, max);
        }

        public FloatRange(Vector2 range)
        {
            _range = range;
        }




        //------METHODS
        public bool InRange(float value)
        {
            return value >= Min && value <= Max;
        }
        public float Clamp(float value)
        {
            return Mathf.Clamp(value, Min, Max);
        }
    }
}