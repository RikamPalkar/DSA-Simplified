
Queue myQueue = new Queue();
Console.WriteLine("Is Empty: " + myQueue.IsEmpty());

Console.WriteLine("Item Added: " + myQueue.Enqueue(10));
Console.WriteLine("Item Added: " + myQueue.Enqueue(20));
Console.WriteLine("Item Added: " + myQueue.Enqueue(30));
Console.WriteLine("Item Added: " + myQueue.Enqueue(40));

Console.WriteLine("Is Empty: " + myQueue.IsEmpty());
Console.Write("Printing Queue: "); myQueue.PrintQueue();

Console.WriteLine("Peek: " + myQueue.Peek());
Console.WriteLine("Dequque: " + myQueue.Dequque());
Console.WriteLine("Dequque: " + myQueue.Dequque());
Console.WriteLine("Dequque: " + myQueue.Dequque());

Console.Write("Printing Queue: "); myQueue.PrintQueue();
Console.WriteLine("Dequque: " + myQueue.Dequque());
Console.WriteLine("Is Empty: " + myQueue.IsEmpty());


/*Exception validations
Console.WriteLine("Peek: " + myQueue.Peek());
Console.WriteLine("Dequque: " + myQueue.Dequque());
myQueue.PrintQueue();
*/

public class Queue
{
    List<int> Elements = new();

    //O(1)
    public int Enqueue(int data)
    {
        Elements.Add(data);
        return data;
    }

    //O(1)
    public int Dequque()
    {
        Validate();
        int dataToBeRemoved = Elements[0];
        Elements.RemoveAt(0);
        return dataToBeRemoved;
    }

    //O(1)
    public bool IsEmpty()
    {
        return Elements.Count == 0;
    }

    //O(1)
    public int Peek()
    {
        Validate();
        return Elements[0];
    }

    //O(n)
    public void PrintQueue()
    {
        Validate();
        for (int i = 0; i < Elements.Count; i++)
        {
            Console.Write(Elements[i] +" ");
        }
        Console.WriteLine();
    }

    private void Validate()
    {
        if (Elements.Count < 0) throw new InvalidOperationException("Queue is empty!");
    }
}