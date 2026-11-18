 

namespace BinaryTreeUsingLinkedlist
{
    public class BinaryTree
    {
        private Node _root;
        public Node Root { get { return _root; } }
        //private int _count;
        //public int Count => _count;
        public bool IsEmpty => _root == null;
        public class Node
        {
            public int Data;
            public Node? Left;
            public Node? Right;
            public Node(int data) => Data = data;
        }

        public void Insert(int data)
        {
            Node newNode = new(data);
            if(IsEmpty)
            {
                _root = newNode;
            }else
            {
                InsertRecursively(_root, newNode);
            }
        }
      
        private void InsertRecursively(Node current, Node newNode)
        {
            if(newNode.Data < current.Data)
            {
                if (current.Left == null)
                    current.Left = newNode;
                else
                    InsertRecursively(current.Left, newNode);
            }else
            {
                if (current.Right == null)
                    current.Right = newNode;
                else
                    InsertRecursively(current.Right, newNode);
            }
        }
        public void PreorderTraversal(Node current)
        {
            if(current != null)
            {
                 Console.WriteLine($"[{current.Data}]" );
                 PreorderTraversal(current.Left);
                PreorderTraversal(current.Right);
            }
           
        }   
        public void InorderTraversal(Node current)
        {
            if (current != null)
            {
                InorderTraversal(current.Left);
                Console.WriteLine($"[{current.Data}]");
                InorderTraversal(current.Right);
            }
        }
        public void PostorderTraversal(Node current)
        {
            if(current != null)
            {
                PostorderTraversal(current.Left);
                PostorderTraversal(current.Right);
                Console.WriteLine($"[{current.Data }]");
            }
        }
    }
}
