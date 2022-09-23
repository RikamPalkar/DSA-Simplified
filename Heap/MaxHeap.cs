
List<int> input = new() { 1, 3, 5, 4, 6, 13, 10, 9, 8, 15, 17 };
MaxHeap maxHeap = new(input);
maxHeap.PrintHeap();

Console.WriteLine("Insert 25");
maxHeap.Insert(25);
maxHeap.PrintHeap();

Console.WriteLine("Peek " + maxHeap.Peek());
Console.WriteLine("Item removed");

maxHeap.Remove();
maxHeap.PrintHeap();

public class MaxHeap
{
    List<int> heap = new();

    public MaxHeap(List<int> heap)
    {
        this.heap = heap;
        BuildHeap();
    }

    public void BuildHeap()
    {
        //Find last parent
        int lastChild = heap.Count - 1;
        int lastParent = (lastChild - 1) / 2;

        for (int i = lastParent; i >= 0; i--)
        {
            Heapify(i);
        }
    }

    //Time: O(n log(n)), Space: O(n)
    private void Heapify(int i)
    {
        int max = i;
        int l = 2 * i + 1; // left child = 2*i + 1
        int r = 2 * i + 2; // right child = 2*i + 2

        if (l < heap.Count && heap[l] > heap[max]) //Left child is larger than root
            max = l;
        
        if (r < heap.Count && heap[r] > heap[max])//Right child is larger than largest so far
            max = r;

        if (max != i) 
        {
            Swap(i, max, heap);
            Heapify(max);
        }
    }

    //Time: O(n)
    public void PrintHeap()
    {
        for (int i = 0; i < heap.Count; ++i)
            Console.Write(heap[i] + " ");

        Console.WriteLine();
    }

    //Time: O(1)
    public int Peek()
    {
        return heap[0];
    }

    //Time: O(log n)
    public int Remove()
    {
        int count = heap.Count - 1;
        Swap(0, count, heap);//Swap root with last node
        int removedValue = heap[count];//romoves head;
        heap.RemoveAt(count);
        BuildHeap();
        return removedValue;
    }

    //Time: O(log n)
    public void Insert(int value)
    {
        heap.Add(value);
        BuildHeap();
    }

    private void Swap(int i, int j, List<int> array)
    {
        (array[j], array[i]) = (array[i], array[j]);
    }
}

