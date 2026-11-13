 namespace StackUsingLinkedList
{
    public class LinkedListStack
    {
        private Node? _top;
        public int Count { get; private set; }
        public bool IsEmpty => _top is null;
        
        private class Node
        {
            public int Data;
            public Node? Next;

            public Node(int data )
            {
                Data = data; 
            }
        }


        public void Push(int value)
        {
            Node newNode = new(value);
            newNode.Next = _top; //maybe null here 
            _top = newNode;
            Count++;
        }

        public int Pop()
        {
            if (_top == null) throw new InvalidOperationException("Stack is empty");
            Node temp = _top;
            _top = _top.Next;
            Count--;
            return temp.Data;
        }
        public void Display()
        {  //[10][3][2] 
                Node Current = _top;
                while(Current!= null)
                {
                    Console.WriteLine($"[{Current.Data}]");
                    Current = Current.Next;
                } 
        }
        public int Peek()
        {
            if (_top == null) throw new InvalidOperationException("Stack is empty");
            return _top.Data;
        }

    }
}
