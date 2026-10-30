 

namespace CircularDoublyLinkedList
{
    public class CircularDoublyLinkedList
    {
        private class Node(int data)
        {
            public int Data { get; set; } = data;
            public Node Next { get; set; } = null!;
            public Node Previous { get; set; } = null!;


        }

        private Node? _head;
        private Node? _tail;
        private int _count;
        public int Count => _count;
        public bool IsEmpty => _count == 0;

        #region Add 
        
        public void AddFirst(int data)
        {
            Node newNode = new(data);
            if (IsEmpty)
            {
                _head = _tail = newNode;
                newNode.Next = newNode;
                newNode.Previous = newNode;
            } else
            {
                newNode.Next = _head!;
                newNode.Previous = _tail!;
                _head!.Previous = newNode;
                _tail!.Next = newNode;
                _head = newNode;
            }
            _count++;
        }
        public void AddLast(int data)
        {
            Node newNode = new(data);
            if (IsEmpty)
            {
                _head = _tail = newNode;
                newNode.Previous = newNode;
                newNode.Next = newNode;
            } else
            {
                newNode.Previous = _tail!;
                newNode.Next = _tail!.Next;
                _tail!.Next = newNode;
                _tail = newNode;
                _head!.Previous = _tail;
            }
            _count++;
        }

        public void Insert(int index, int data)
        {
            if (index < 0 || index > _count)
            {
                Console.WriteLine("Invalid Index");
                return;
            }
            if (index == 0)
            {
                AddFirst(data);

            }else if (index == _count)
            {
                AddLast(data);
            }else
            {
                Node newNode = new(data);
                Node current = _head!;
                for(int i = 0; i < index - 1; i++)
                    current = current.Next;

                newNode.Next = current.Next;
                newNode.Previous = current;
                current.Next.Previous = newNode;
                current.Next = newNode;
                _count++;
            }
           
        }
        #endregion

        #region Remove 
        public bool RemoveFirst()
        {
            if(IsEmpty)
            {
                return false;
            }else if (_head == _tail)
            {
                _head = _tail = null;
                _count--;
                return true;
            }else
            {
                _head = _head.Next;
                _head.Previous = _tail;
                _tail.Next = _head;
                _count--;
                return true;
            }
        }
        public bool RemoveLast()
        {
            if (IsEmpty) return false;
            else if (_head == _tail) return RemoveFirst();
            else
            {
                _tail.Previous.Next = _head;
                _head.Previous = _tail.Previous;
                _tail = _tail.Previous;
                _count--;
                return true;
                //or
                //_tail=_tail.Previous;
                //_tail.Next=_head;
                //_head.Previous=_tail;
             }

        }
        public bool RemoveAt(int position)
        {
            if (position <= 0 || position > _count)
            {
                return false;
            }
            if (position == 1) return RemoveFirst();
            if (position == _count) return RemoveLast();
            Node Current = _head;
            for(int i = 1; i < position; i++)
            {
                Current = Current.Next;
            }
            Current.Previous.Next = Current.Next;
            Current.Next.Previous = Current.Previous;
            _count--;
            return true;
        }
        #endregion
        public void DisplayForward()
        {
            Node? Current = _head;
            for(int i = 0; i < _count; i++)
            {
                Console.Write(Current!.Data + " ");
                Current = Current.Next;
            }
            Console.WriteLine();
        }
    }
}
