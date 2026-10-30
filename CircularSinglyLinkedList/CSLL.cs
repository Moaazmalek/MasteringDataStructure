
namespace CircularSinglyLinkedList
{
    public class CSLL
    {
        private Node? _head;
        private Node? _tail;
        private int _count = 0;
        public bool IsEmpty => _head == null;
        public int Count => _count;

        public void AddFirst(int value)
        {
            Node newNode = new(value);
            if (IsEmpty)
            {
                _head = newNode;
                _tail = newNode;
                _tail.Next = _head;

            } else
            {
                newNode.Next = _head;
                _head = newNode;
                _tail!.Next = _head;

            }
            _count++;

        }
        public void AddLast(int value)
        {
            Node newNode = new(value);
            if (IsEmpty)
            {
                _head = _tail = newNode;
                //  _tail.Next = _head;
            } else
            {
                _tail!.Next = newNode;
                _tail = newNode;
                //  _tail.Next = _head;

            }
            _tail.Next = _head;
            _count++;

        }


        public bool AddAtPosition(int value, int position)
        {
            if (position < 0 || position > _count)
                return false;

            if (position == 0)
            {
                AddFirst(value);
                return true;
            }

            if (position == _count)
            {
                AddLast(value);
                return true;
            }

            Node newNode = new(value);
            Node current = _head!;

            for (int i = 0; i < position - 1; i++)
            {
                current = current.Next!;
            }

            newNode.Next = current.Next;
            current.Next = newNode;

            _count++;

            return true;
        }
        public bool RemoveFirst()
            {
                if (IsEmpty) return false;
                if(_head==_tail)
                {
                    _head = _tail = null;
                    _count--;
                    return true;
                }
                _tail!.Next = _head?.Next;
                _head = _head?.Next;
                _count--;
                return true;
            }
        
        public bool RemoveLast()
        {
            if (IsEmpty) return false;
            if(_head==_tail)
            {
                _head = _tail = null;
                _count--;
                return true;
            }
            Node current = _head!;
            while(current.Next != _tail)
            {
                current = current.Next;
            }
            current.Next = _head;
            _tail = current;
            _count--;
            return true;

        }

        public void Reverse()
        {
            if (_head == null || _head == _tail) return;

            Node oldHead = _head;
            Node? previous = _tail;
            Node current = _head;

            do
            {
                Node next = current.Next!;
                current.Next = previous;
                previous = current;
                current = next;
            }while(current != oldHead);
            _tail = oldHead;
            _head = previous;
        }
        public void Print()
        {
            if (_head == null) return;
            Node current = _head;
            do
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            } while (current != _head);
            Console.WriteLine();
        }
    }
}
