using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3HW1
{
    public class MyList<T> : IReadOnlyList<T>
    {
        private const int _defaultCapacity = 4;
        private T[] _array;
        private int _counter = 0;
        private int _capacity;
        public MyList()
        {
            _capacity = _defaultCapacity;
            _array = new T[_capacity];
        }

        public int Count => ((IReadOnlyCollection<T>)_array).Count;

        public T this[int index] => ((IReadOnlyList<T>)_array)[index];

        public void Add(T item)
        {
            if (_capacity <= _counter)
            {
                _capacity *= 2;
                Array.Resize(ref _array, _capacity);
            }

            _array[_counter++] = item;
        }

        public void AddRange(IEnumerable<T> range)
        {
            foreach (var item in range)
            {
                Add(item);
            }
        }

        public bool Remove(T item)
        {
            for (var index = 0; index < _capacity; index++)
            {
                if (_array[index].Equals(item))
                {
                    RemoveAt(index);
                    return true;
                }
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            _array[index] = default(T);
            _counter--;
        }

        public void Sort(IComparer<T> comparer)
        {
            Array.Sort(_array, 0, _capacity, comparer);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < _capacity; i++)
            {
                yield return _array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
