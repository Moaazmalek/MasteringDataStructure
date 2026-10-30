using CircularSinglyLinkedList;

CSLL csll = new();
csll.AddFirst(1);
csll.AddFirst(0);
csll.AddLast(2);
csll.AddLast(3);
csll.Print();
Console.WriteLine(csll.Count);