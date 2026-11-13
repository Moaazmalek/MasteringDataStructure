 
namespace QueueUsingArray
{
    public class ArrayQueue
    {
        private readonly int[] _items;
        private int _front;
        private int _rear;
        private int _count;
        public int Count => _count;
        public int Capacity => _items.Length;
        public bool IsEmpty => _count == 0;
        public bool IsFull => _rear == -_items.Length - 1; 
    
        public ArrayQueue(int capacity)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(capacity);
            _items = new int[capacity];
            _front = -1;
            _rear = -1;
            _count = 0;
        }
        public void Enqueue(int value)
        {
            if (IsFull)
                throw new ArgumentOutOfRangeException();
            else if (IsEmpty)
                _front = _rear = 0;
            else
                _rear++;
            _items[_rear] = value;
            _count++;
        }
        public int Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Queue is empty.");

            int value = _items[_front];

            if (_front == _rear)
                _front = _rear = -1;
            else
                _front++;

            _count--;

            return value;

        }
        public void Display()
        {
            if (IsEmpty)
                Console.WriteLine("Queue is empty.");
            Console.Write("[");
            for (int i = _front; i <= _rear; i++)
            {
                if (i == _rear) 
                       Console.Write(_items[i]);
                else
                    Console.Write(_items[i] + ", ");
            } 
                
            Console.Write("]");
        }
        public int peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Queue is empty.");
            return _items[_front];

        }
        public void Clear()
        {
            _front = _rear = -1;
            _count = 0;
        }
    }
}
