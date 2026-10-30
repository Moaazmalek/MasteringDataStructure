 

CircularDoublyLinkedList.CircularDoublyLinkedList list = new();
list.AddFirst(3);
list.AddFirst(2);
list.AddFirst(1);
list.AddLast(4);
list.AddLast(5);

list.DisplayForward();
Console.WriteLine(list.Count);


list.RemoveLast();
list.DisplayForward();
Console.WriteLine(list.Count);