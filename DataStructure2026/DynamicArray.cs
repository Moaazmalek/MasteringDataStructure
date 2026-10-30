using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructure2026
{
    public class DynamicArray<T>: IEnumerable<T>
    {

        private T[] _items;
        private int _count;

        public DynamicArray()
        {
            _items = new T[4];

        }
        public int Count => _count;
        public int Capacity => _items.Length;
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                    throw new IndexOutOfRangeException();
                return _items[index];

            }set
            {
                if (index < 0 || index >= _count)
                    throw new IndexOutOfRangeException();
                _items[index] = value;

            }

            
        }
        public void Add(T item)
        {
            if (_count == _items.Length)
            {
                Resize();
            }
            _items[_count++] = item;
        }
        public void Insert(int index, T item)
        {
            if (index < 0 || index > _count)
                throw new IndexOutOfRangeException();
            if (_count == _items.Length)
                Resize();
            for (int i = _count; i > index; i--)
            {
                _items[i] = _items[i - 1];
            }
            _items[index] = item;
            _count++;
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index >=Count)
                throw new IndexOutOfRangeException();
            for(int i = index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }
            _items[--_count] = default!;
        }
        public bool Contains(T item)
        {
            for(int i = 0; i < _count; i++)
            {
                if (Equals(_items[i], item))
                    return true;
            }
            return false;
        }
        public void Resize()
        {
            T[] newArray = new T[_items.Length * 2];
            for(int i = 0; i < _count; i++)
            {
                newArray[i] = _items[i];
            }
            _items = newArray;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < _count; i++)
            {
                yield return _items[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
