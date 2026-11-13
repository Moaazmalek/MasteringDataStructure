using QueueUsingArray;

ArrayQueue queue = new(5);
queue.Enqueue(1);
queue.Enqueue(2);
queue.Enqueue(3);
queue.Enqueue(4);
queue.Enqueue(5);
queue.Dequeue();
Console.WriteLine(queue.peek());

//queue.Display();