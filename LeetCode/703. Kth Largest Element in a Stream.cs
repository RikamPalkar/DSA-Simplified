/*
I got 99% success but that last 1% is still a long run

Intuition

    Initialize a Min Heap: Start by adding elements to the min heap one by one.
    Maintain Heap Size: Continuously remove elements from the heap until only k elements remain.
    Retrieve kth Largest: The top element of the heap will be the kth largest element, which you return.

Example

Input
["KthLargest", "add", "add", "add", "add", "add"]
[[3, [4, 5, 8, 2]], [3], [5], [10], [9], [4]]

PriorityQueue: [2, 4, 5, 8]

Add(3):
    Enqueue: [2 3 4 5 8]
    Dequeue: Dequeue(2 & 3)
    PriorityQueue after Dequeue: [4, 5, 8]
    Largest: 4

Add(5):
    Enqueue: [4 5 5 8 ]
    Dequeue: Dequeue(4)
    PriorityQueue after Dequeue: [ 5, 5, 8]
    Largest: 5

Add(10):
    Enqueue: [4 5 5 8 10]
    Dequeue: Dequeue(4 & 5)
    PriorityQueue after Dequeue: [5, 8, 10]
    Largest: 5

Add(9):
    Enqueue: [5 8 9 10 ]
    Dequeue: Dequeue(5)
    PriorityQueue after Dequeue: [8, 9, 10]
    Largest: 8

Add(4):
    Enqueue: [4 8 9 10]
    Dequeue: Dequeue(4)
    PriorityQueue after Dequeue: [8, 9, 10]
    Largest: 8

Time Complexity: O(n log k)

    Constructor: O(n log k)
    Add: O(log k)

Space complexity: O(n)

*/
public class KthLargest 
{
    PriorityQueue<int, int> stream = new();
    int k = 0;

    public KthLargest(int k, int[] nums) {
        this.k = k;
        foreach(int num in nums)
            stream.Enqueue(num, num);       
    }
    
    public int Add(int val) 
    {
        stream.Enqueue(val, val);

        while (stream.Count > k)
            stream.Dequeue();

        return stream.Peek();
    }
}
