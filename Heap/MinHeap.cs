List<int> input = new() { 35, 33, 42, 10, 14, 19, 27, 44, 26, 31 };
MinHeap minHeap = new(input);
minHeap.PrintHeap();

Console.WriteLine("Insert -55");
minHeap.Insert(-55);
minHeap.PrintHeap();

Console.WriteLine("Peek " + minHeap.Peek());
Console.WriteLine("Item removed");
minHeap.Remove();

minHeap.PrintHeap();

public class MinHeap
{
    public List<int> heap = new();

    public MinHeap(List<int> array)
    {
        heap = BuildHeap(array);
    }

    //Time: O(n log(n)), Space: O(1)
    public List<int> BuildHeap(List<int> array)
    {
        //Find last parent
        int lastChild = array.Count - 1;
        int lastParent = (lastChild - 1) / 2;

        //shift down for for all parents
        for (int i = lastParent; i >= 0; i--)
        {
            SiftDown(i, lastChild, array);
        }
        return array;
    }

    //Time: O(log n), Space: O(1)
    public void SiftDown(int currentIdx, int endIdx, List<int> heap)
    {
        int firstChild = (2 * currentIdx) + 1;
        while (firstChild <= endIdx) //while there is at least one child node,
        {
            //Second child is only considered if it is part of array, i.e. node doesn't have second child
            int secondChild = ((2 * currentIdx) + 2) <= endIdx ? ((2 * currentIdx) + 2) : -1;
            int indexToSwap;
            if (secondChild != -1 && heap[secondChild] < heap[firstChild])
            {
                indexToSwap = secondChild; //if second child is smaller than first child 
            }
            else
            {
                indexToSwap = firstChild; //if first child is smaller than second child 
            }
			
            if (heap[indexToSwap] < heap[currentIdx])
            {
                Swap(indexToSwap, currentIdx, heap); //if parent  is smaller than any of child 
                currentIdx = indexToSwap; //updating current index to next child subtree
                firstChild = (2 * currentIdx) + 1; // calculating first child for new parent idx
            }
            else return;
        }
    }

    //Time: O(log n), Space: O(1)
    private void SiftUp(int currentIdx, List<int> heap)
    {
        int parentIdx = (currentIdx - 1) / 2; // get parent index
        while (currentIdx > 0 && heap[currentIdx] < heap[parentIdx]) //Shift up till you reach at the top of the heap
        {
            Swap(currentIdx, parentIdx, heap); // swap currentNode with parentNode if it is less < parent node
            currentIdx = parentIdx; // once swap has been performed move one step upwards
            parentIdx = (currentIdx - 1) / 2; // calculating parent for current idx
        }
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
        SiftDown(0, heap.Count - 1, heap);//shift down new head to right position
        return removedValue;
    }

    //Time: O(log n)
    public void Insert(int value)
    {
        heap.Add(value);
        SiftUp(heap.Count - 1, heap);
    }

    public void PrintHeap()
    {
        for (int i = 0; i < heap.Count; ++i)
            Console.Write(heap[i] + " ");

        Console.WriteLine();
    }

    private void Swap(int i, int j, List<int> array)
    {
        (array[j], array[i]) = (array[i], array[j]);
    }
}

