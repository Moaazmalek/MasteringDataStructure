namespace StackUsingArray
{
    public class ArrayStack
    {
        private readonly int[] _items;
        private int _top;
        public int Count => _top + 1;
        public bool IsEmpty => _top == -1;
        public bool IsFull => _top == _items.Length -1;

        public ArrayStack(int capacity)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(capacity);

            _items = new int[capacity];
            _top = -1; 
        }
        public void Push(int value)
        {
            if (IsFull)
            {
                throw new InvalidOperationException("The stack is full.");
            }
            else
            {
                _items[++_top] = value;
            }

        }
        public int Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The stack is emtpy.");
            }
                int item = _items[_top--];
                return item;
            
        }
        public int Peek()
        {
            if (IsEmpty) throw new ArgumentOutOfRangeException();
            else
            {
                return _items[_top];
            }
        }
        public void Display()
        {
            for (int i = _top; i >= 0; i--)
            {
                Console.WriteLine(_items[i]);
            }

        }
        public void Clear()
        {
            _top = -1;
        }
        public bool Contains(int value)
        {
            for(int i = _top; i >= 0; i--)
            {
                if (_items[i] == value) return true;
            }
            return false;
        }
    }
}
