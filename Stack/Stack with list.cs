Stack myStack = new Stack();
Console.WriteLine("Is Empty: " + myStack.IsEmpty());

Console.WriteLine("Item Added: " + myStack.Push(10));
Console.WriteLine("Item Added: " + myStack.Push(20));
Console.WriteLine("Item Added: " + myStack.Push(30));
Console.WriteLine("Item Added: " + myStack.Push(40));

Console.WriteLine("Is Empty: " + myStack.IsEmpty());
Console.Write("Printing stack: "); myStack.PrintStack();

Console.WriteLine("Peek: " + myStack.Peek());
Console.WriteLine("Pop: " + myStack.Pop());
Console.WriteLine("Pop: " + myStack.Pop());
Console.WriteLine("Pop: " + myStack.Pop());

Console.Write("Printing stack: "); myStack.PrintStack();
Console.WriteLine("Pop: " + myStack.Pop());
Console.WriteLine("Is Empty: " + myStack.IsEmpty());


/*Exception validations
Console.WriteLine("Peek: " + myStack.Peek());
Console.WriteLine("Pop: " + myStack.Pop());
myStack.PrintStack();
*/


public class Stack
{
    List<int> Elements = new();
    int Top = -1;

    //O(1)
    public bool IsEmpty()
    {
        return Elements.Count == 0;
    }

    //O(1)
    public int Push(int data)
    {
        Elements.Add(data);
        Top++;
        return data;
    }

    //O(1)
    public int Pop()
    {
        ValidateStack();
        int itemToBeRemoved = Elements[Top];
        Elements.RemoveAt(Top);
        Top--;
        return itemToBeRemoved;
    }

    //O(1)
    public int Peek()
    {
        ValidateStack();
        return Elements[Top];
    }

    //O(n)
    public void PrintStack()
    {
        ValidateStack();
        for (int i = Elements.Count-1; i >=0 ; i--)
        {
            Console.Write(Elements[i] + " ");
        }
        Console.WriteLine();
    }

    private void ValidateStack()
    {
        if (Top < 0) throw new InvalidOperationException("Stack is Empty!");
    }
}




