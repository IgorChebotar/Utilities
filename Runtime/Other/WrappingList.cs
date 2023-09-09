using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SimpleMan.Utilities
{
    /// <summary>
    /// Fixed-size queue. Replaces first element when it's full.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class WrappingList<T> : IEnumerable, IEnumerable<T>
    {
        private List<T> _values;


        public int Count => _values.Count;
        public int Capacity => _values.Capacity;
        public int FreeSpace => Capacity - Count;
        public bool IsFull => Count == Capacity;
        public T this[int index]
        {
            get => _values[index];
            set => _values[index] = value;
        }


        public WrappingList(int capacity)
        {
            if(capacity < 1)
            {
                throw new ArgumentOutOfRangeException(
                    "Capacity", "Capacity must be greater than 0");
            }
            _values = new List<T>(capacity);
        }

        public WrappingList(IEnumerable<T> elements)
        {
            if (elements.NotExist() || elements.Count() < 1)
            {
                throw new ArgumentOutOfRangeException(
                    "Capacity", "Capacity must be greater than 0");
            }

            _values = new List<T>(elements);
        }


        public void Add(T value)
        {
            if (_values.Count == _values.Capacity)
            {
                for (int i = 1; i < _values.Count; i++)
                {
                    T element = _values[i];
                    _values[i - 1] = element;
                }

                RemoveLast();
            }

            _values.Add(value);
        }

        public void Remove(T value)
        {
            _values.Remove(value);
        }

        public void RemoveAt(int index)
        {
            _values.RemoveAt(index);
        }

        public void RemoveFirst()
        {
            if (_values.Count > 0)
                RemoveAt(0);
        }

        public void RemoveLast()
        {
            if (_values.Count > 0)
                RemoveAt(_values.Count - 1);
        }

        public void Clear()
        {
            _values.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _values.GetEnumerator();
        }
    }
}