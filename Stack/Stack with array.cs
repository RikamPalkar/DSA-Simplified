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


//Note: Use List implementation rather than this one, as we always have to define size of stack in advance.
public class Stack
{
    static readonly int MAX = 5000;
    int Top = -1;
    int[] Elements = new int[MAX];

    //O(1)
    public bool IsEmpty()
    {
        return Top < 0;
    }

    //O(1)
    public int Push(int data)
    {
        if (Top > MAX)
        {
            throw new InvalidOperationException("Stack Overflow!");
        }
        else
        {
            Elements[++Top] = data;
            return data;
        }
    }

    //O(1)
    public int Pop()
    {
        ValidateStack();
        int value = Elements[Top];
        Top--;
        return value;
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
        for (int i = Top; i >= 0; i--)
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
