 
namespace CircularQueueUsingLinkedlist
{
    public class CircularQueueLinkedList
    {
        Node _front;
        Node _rear;
        int _count;

        public int Count => _count;
        public bool IsEmpty => _count == 0;
        
        class Node
        {
           public int Data;
           public Node Next;

            public Node(int data)
            {
                Data = data;
            }
        }

        public void Enqueue(int value)
        {
            Node newNode = new(value);
            if (IsEmpty)
            {
                _front = _rear = newNode;
            }else
            {
                _rear.Next = newNode;
                _rear = newNode;
            }
            _rear.Next = _front; 
            _count++;
        }
        public int Dequeue()
        {
            if (IsEmpty) throw new InvalidOperationException("Queue is empty.");
           
            int value = _front.Data;
            if (_front == _rear)
                _front = _rear = null;
            else
            {
                _front = _front.Next;
                _rear.Next = _front;
            }
            _count--;
            return value;

        }
        public int Peek()
        {
            if (IsEmpty) throw new InvalidOperationException("Queue is empty.");
            return _front.Data; 
        }
        public void Display()
        {
            if(IsEmpty) Console.WriteLine("Queue is empty.");
           else
            {
                //First solution
                //Node current = _front;
                //while (current.Next != _front)
                //{
                //    Console.WriteLine(current.Data);
                //    current = current.Next;
                //}
                //Console.WriteLine(current.Data);
                Node current = _front;
                for(int i = 0; i < _count; i++)
                {
                    Console.WriteLine(current.Data);
                    current = current.Next;
                }
            }
        }
    }
}
