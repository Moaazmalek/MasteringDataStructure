 

namespace CircularQueueUsingArray
{
    public class CircularQueueArray
    {
        private readonly int[] _items;
        private int _front, _rear;
        public CircularQueueArray(int capacity)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(capacity);
            _items = new int[capacity];
            _front = -1;
            _rear = -1;
        }
        public void Enqueue(int value)
        {
            if(_front== -1 && _rear==-1)
            {
                _front = _rear = 0;
                _items[_rear] = value;
            } else if((_rear + 1) % _items.Length == _front)
            {
                throw new InvalidOperationException("Queue is full.");
            }else
            {
                _rear = (_rear + 1) % _items.Length;
                _items[_rear] = value;
            }
        }
        public int Dequeue()
        {
            int value;
            if (_front == -1 && _rear == -1)
                throw new InvalidOperationException("Queue is empty");
            
            else if (_front == _rear)
            {
                value = _items[_front];
                _front = _rear = -1;
            }else
            {
                value = _items[_front];
                _front = (_front + 1) % _items.Length;

            }
            return value;
        }
        public void Display()
        {
            if(_front== -1 && _rear==-1) Console.WriteLine("Queue is empty");

            int i = _front;
            while(i != _rear){
                Console.WriteLine(_items[i]);
                i = (i + 1) % _items.Length;
            }

        }

    }
}
