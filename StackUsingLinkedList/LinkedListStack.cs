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
        }
        public void Display()
        {
            if (_top == null) return;
            else
            {
                //[10][3][2] 
                Node Current = _top;
                while(Current!= null)
                {
                    Console.WriteLine($"[{Current.Data}]");
                    Current = Current.Next;
                }

            }
            
        }

    }
}
