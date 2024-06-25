# Introduction<br>
Heap is a fundamental data structure used for efficiently accessing elements with priority. Among different types of heaps, min-heap and max-heap are most famous. Min-heap ensure that the smallest element is always at the root, while max-heap ensure that the largest element is at the root.

In C#, we can implement both min-heap and max-heap using the built-in PriorityQueue class, which provides efficient priority-based operations

# Min Heap<br>
A min-heap is a binary tree where the parent node holds a value less than or equal to its children's values, ensuring that the smallest element is always at the root. Min heaps are used in solving problems where constant O(1) access to the minimum element is necessary, such as finding the k smallest elements or implementing Dijkstra's algorithm for shortest path finding.

This is how mean-heap looks in action:
```

.         1
       /     \
     3         6
   /   \      / \
  5     9   8    10
 / \   /
12  14 15


Array => level order traversal:
[1, 3, 6, 5, 9, 8, 10, 12, 14, 15]
```

The root node (1) is the smallest element.
Every parent node is smaller than its children.
In the array representation:
The root element is at index 0.
For any node at index i, its left child is at index 2i + 1, and its right child is at index 2i + 2.
Implementation of Min Heap using PriorityQueue
In C#, we can implement a min heap using the PriorityQueue class. By default, the PriorityQueue behaves as a min heap, dequeuing elements in ascending order of priority. We can enqueue elements with their associated priorities and dequeue them to efficiently retrieve the smallest element.
```
public class PriorityQueue<TElement, TPriority>
```
In the above declaration, TElement represents the actual value (element), and TPriority represents the associated priority

```
void MeapHeap()
{
    // Create min heap of <string, int>
    PriorityQueue<string, int> minHeap = new PriorityQueue<string, int>();

    minHeap.Enqueue("Task C", 3);
    minHeap.Enqueue("Task A", 1);
    minHeap.Enqueue("Task B", 2);
    minHeap.Enqueue("Task E", 5);
    minHeap.Enqueue("Task D", 4);

    // Dequeue elements from the min heap (they will be in ascending order of priority)
    while (minHeap.Count > 0)
    {
        string task = minHeap.Dequeue();
        Console.WriteLine(task);
    }
}

/* output
Task A
Task B
Task C
Task D
Task E
*/
```
Listing 1: Min heap

# Max Heap<br>

A max heap the parent node holds a value greater than or equal to its children's values, ensuring that the largest element is always at the root. Max heap is beneficial for problems where constant O(1) access to the maximum element is necessary, such as finding the k largest elements.
```
.         15
       /     \
     10       14
   /   \     /  \
  9     8   12    6
 / \   /
3   5 1

Array => level order traversal:
[15, 10, 14, 9, 8, 12, 6, 3, 5, 1]
```

The root node (15) is the largest element.
Every parent node is larger than its children.
In the array representation:
The root element is at index 0.
For any node at index i, its left child is at index 2i + 1 and its right child is at index 2i + 2.
Implementation of Max Heap using PriorityQueue
We can utilize the PriorityQueue class with a custom comparer that reverses the default ordering. By enqueuing elements with their associated priorities and using a custom comparer that compares elements in descending order, we can create a max heap.
```
void MaxHeap()
{
    // Custom comparer to create a max-heap
    var maxHeapComparer = Comparer<int>.Create((x, y) => y.CompareTo(x));

    PriorityQueue<string, int> maxheap = new(maxHeapComparer);

    maxheap.Enqueue("Task C", 3);
    maxheap.Enqueue("Task A", 1);
    maxheap.Enqueue("Task B", 2);
    maxheap.Enqueue("Task E", 5);
    maxheap.Enqueue("Task D", 4);

    while (maxheap.Count > 0)
    {
        var item = maxheap.Dequeue();
        Console.WriteLine(item);
    }
}

/* Output
Task E
Task D
Task C
Task B
Task A
*/
```
Listing 2: Max heap

# Problems Solved with Heaps

```
Problem:  Leetcode: 347. Top K Frequent Elements
Note: This problem can be solved with a min or max heap. To explain the usage of min heaps, let me use a min heap.

Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order.

Example 1:
Input: nums = [1,1,1,2,2,3], k = 2
Output: [1,2]
```

Solution
```
public int[] TopKFrequent(int[] nums, int k)
{
    Dictionary<int, int> frequencyMap = new Dictionary<int, int>();

    foreach (var num in nums) {
        frequencyMap[num] = frequencyMap.GetValueOrDefault(num)+1;
    }

    PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

    foreach (var entry in frequencyMap) {
        minHeap.Enqueue(entry.Key, entry.Value);

        if (minHeap.Count > k) {
            minHeap.Dequeue();
        }
    }

    int[] result = new int[k];
    int i = 0;
    while (minHeap.Count > 0) {
        result[i++] = minHeap.Dequeue();
    }

    return result;
}
```
Listing 3: 347. Top K Frequent Elements solution

```
Max Heap problem:  Leetcode 215. Kth Largest Element in an Array
Given an integer array nums and an integer k, return the kth largest element in the array.
Note that it is the kth largest element in the sorted order, not the kth distinct element.
Can you solve it without sorting?

Example 1:

Input: nums = [3,2,1,5,6,4], k = 2
Output: 5
```

Solution:
```
public int FindKthLargest(int[] nums, int k) {
   var maxHeapComparer = Comparer<int>.Create((x, y) => y.CompareTo(x));
    PriorityQueue<int, int> pq = new(maxHeapComparer);

    foreach (var num in nums)
    {
        pq.Enqueue(num, num);
    }

    int result = 0;
    for (int i = 0; i < k; i++)
    {
        result = pq.Dequeue();
    }

    return result;
}
```
Listing 4: 2215. Kth Largest Element in an Array solution

# Conclusion<br>
Min heap and max heap are crucial data structures for managing priority-based operations. Understanding these data structures and their implementations using priority queues can significantly enhance our ability to tackle priority-based problems in programming. I hope this helped; cheers!
