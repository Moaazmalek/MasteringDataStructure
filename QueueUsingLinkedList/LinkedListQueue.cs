namespace QueueUsingLinkedList
{
    internal class LinkedListQueue
    {
        private Node? _front;
        private Node? _rear;

       

        private class Node
        {
            public int Data;
            public Node? Next;
            public Node(int data)
            {
                Data = data;
                Next = null;
            }
        }
        internal void Enqueue(int value)
        {
            Node newNode = new(value);
            if(_front==null && _rear == null) 
                _front = _rear = newNode;
            else
            {
                _rear!.Next = newNode;
                _rear = newNode;
            }

        }
        internal int Dequeue()
        {
            if (_front == null) throw new InvalidOperationException("Queue is empty");
            int value = _front.Data;
            _front = _front.Next;
            return value;
        }
        internal int Peek()
        {
            if (_front == null) throw new InvalidOperationException("Queue is empty.");
            return _front.Data;
        }
        internal void Display()
        {
            if(_front==null && _rear==null)
                Console.WriteLine("Queue is empty.");
            else
            {
                Node current = _front!;
                Console.Write("[");
                
              
                while (current != null)
                {
                    if (current == _rear)
                        Console.Write(current.Data);
                    else 
                       Console.Write(current.Data + ",");
                    current = current.Next!;
                }

            }
            Console.Write("]");
        }
    }
}
