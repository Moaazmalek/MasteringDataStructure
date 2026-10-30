

using System.Collections;
using System.Collections.Generic;

namespace DataStructure2026
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        private Node<T>? _head;
        private Node<T>? _tail;
        private int _count;

        public int Count => _count;
        public bool IsEmpty => _count == 0;
        
        // Add First
        public void AddFirst(T value)
        {
            var node =new Node<T>(value);
            if (IsEmpty)
            {
                _head = _tail = node;
            }else
            {
                node.Next = _head;
                _head = node;
            }
            _count++;
        }

        // Add Last 
        public void AddLast(T value)
        {
            var node = new Node<T>(value);
            if (IsEmpty)
            {
                _head = _tail = node;

            }
            else
            {
                _tail!.Next = node;
                _tail = node;
            }
            _count++;
        }
        // Get First
        public T GetFirst()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("List is empty.");
            }else
            {
                return _head!.Value;
            }
        }

        // Get Last
        public T GetLast()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("List is empty.");
            }
            return _tail!.Value;
        }

        // Contains
        public bool Contains(T value)
        {
            return Find(value) != null;
        }

        // Find value
        public Node<T>? Find(T value)
        {
            var comparer = EqualityComparer<T>.Default;
            var current = _head;

            while(current != null)
            {
                if (comparer.Equals(current.Value, value))
                    return current;
                current = current.Next;
            }
            return null;
        }
        // Remove First (O(1));
        public void RemoveFirst()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }
            if (_head == _tail)
            {
                _head = _tail = null;
            }
            else
            {
                _head = _head!.Next;
            }
            _count--;
        }

        // Remove Last (O(n))
        public void RemoveLast()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            if (_head == _tail)
            {
                _head = _tail = null;
                _count--;
                return;
            }
            var current = _head;
            while(current!.Next != _tail)
            {
                current = current.Next;
            }
            current.Next = null;
            _tail = current;

            _count--;
        }

        // Remove By Value
        public bool Remove(T value)
        {
            if (IsEmpty)
                return false;
            var comparer = EqualityComparer<T>.Default;

            if (comparer.Equals(_head!.Value, value))
            {
                RemoveFirst();
                return true;
            }
            var previous = _head;
            var current = _head.Next;

            while(current != null)
            {
                if (comparer.Equals(current.Value, value))
                {
                    previous.Next = current.Next;
                    if (current == _tail)
                    {
                        _tail = previous;
                    }
                    _count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }
        // Update 
        public bool Update(T oldValue, T newValue)
        {
            var node = Find(oldValue);
            if (node == null)
                return false;
            node.Value = newValue;
            return true;
        }
        // Clear
        public void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }
        //Indexer
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                var current = _head;
                for(int i = 0; i < index; i++)
                {
                    current = current!.Next;
                }
                return current!.Value;
            }
        }
        // Reverse (Interview Favorite)
        public void Reverse()
        {
            if(IsEmpty || _head == _tail)
            {
                return;
            }
            Node<T>? previous = null;
            var current = _head;
            _tail = _head;
            while(current != null)
            {
                var next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }
            _head = previous;
        }
        
        // TO Array 
        public T[] ToArray()
        {
            var array = new T[_count];
            var current = _head;
            int index = 0;
            while(current != null)
            {
                array[index++] = current.Value;
                current = current.Next;
            }
            return array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;
            while(current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
       
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
