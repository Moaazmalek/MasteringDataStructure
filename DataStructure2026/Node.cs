using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure2026
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T>?  Next { get; set; }

        public Node(T value)
        {
            Value = value;
        }

    }
}
