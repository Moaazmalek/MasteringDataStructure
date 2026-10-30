using StackUsingArray;

ArrayStack stack = new(5);
stack.Push(1);
stack.Push(2);
stack.Push(3);
stack.Push(4);
stack.Push(5);

try
{
    stack.Pop();
    Console.WriteLine(stack.Peek());
    Console.WriteLine(stack.Count);
//stack.Display();
//stack.Push(6);
//stack.Display();
}catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

