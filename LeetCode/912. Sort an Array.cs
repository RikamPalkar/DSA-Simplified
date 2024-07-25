/*
Merge Sort

    Split the array into two halves till each has single element.
    Recursively sort each half.
    Merge the two sorted halves back together.

Complexity
Time complexity: O(n log n)
    Divide : O (log n)
        At each level of the recursion tree, the merging takes O(n)
    ( log n ) levels * ( n ) elements

Space complexity: O (n)
    The recursion depth is (log ⁡n) however we use temp array for merging so O(n)

*/
public class Solution {
   public int[] SortArray(int[] nums)
    {
        if (nums == null || nums.Length == 0) return nums;
        Divide(nums, 0, nums.Length - 1);
        return nums;
    }

    private void Divide(int[] nums, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;
            Divide(nums, left, mid);
            Divide(nums, mid + 1, right);
            Conquer(nums, left, mid, right);
        }
    }

    private void Conquer(int[] nums, int left, int mid, int right)
    {
        int[] temp = new int[right - left + 1];
        int i = left, j = mid + 1, k = 0; // Starting index for temp array

        // Merge the two halves into temp array
        while (i <= mid && j <= right)
        {
            if (nums[i] <= nums[j])
                temp[k++] = nums[i++];
            else
                temp[k++] = nums[j++];
        }
        
        // Copy the remaining elements from the left subarray
        while (i <= mid)
            temp[k++] = nums[i++];

        // Copy the remaining elements from the right subarray
        while (j <= right)
            temp[k++] = nums[j++];

        // Copy the sorted elements back into the original array
        for (i = left; i <= right; i++)
            nums[i] = temp[i - left];
    }
}

/*
Max Heap
    Building the Max Heap:
        Start from the last non-leaf node and call Heapify.
        For each node, compare it with its children and swap if needed to maintain the max heap property.
    Sorting:
        Swap the root of the heap (the largest element) with the last element.
        Reduce the size of the heap by one and call Heapify on the root.
        Repeat until the heap is reduced to a single element.

Example
Build Max Heap:
Initial array: [5, 1, 1, 2, 0, 0]
After heapifying: [5, 2, 1, 1, 0, 0]

Sorting:
Swap 5 and 0: [0, 2, 1, 1, 0, 5]
Heapify [0, 2, 1, 1, 0]: [2, 1, 1, 0, 0, 5]
Swap 2 and 0: [0, 1, 1, 0, 2, 5]
Heapify [0, 1, 1, 0]: [1, 0, 1, 0, 2, 5]
Swap 1 and 0: [0, 0, 1, 1, 2, 5]
Continue until sorted: [0, 0, 1, 1, 2, 5]

Complexity
Time complexity: O(n log n)
    Heapify : O (log n)
    At each node n we heapify

Space complexity: O (1)
    Sorts in place

*/

    public int[] SortArray(int[] nums)
    {
        int n = nums.Length;

        // Build max heap
        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(nums, n, i);

        for (int i = n - 1; i > 0; i--)
        {
            int temp = nums[0];
            nums[0] = nums[i];
            nums[i] = temp;

            Heapify(nums, i, 0);
        }
        return nums;
    }

    private void Heapify(int[] nums, int n, int i)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && nums[left] > nums[largest])
            largest = left;

        if (right < n && nums[right] > nums[largest])
            largest = right;

        if (largest != i)
        {
            int swap = nums[i];
            nums[i] = nums[largest];
            nums[largest] = swap;

            Heapify(nums, n, largest);
        }
    }

/*
Sorting Using a Priority Queue (Min Heap)
    Enqueueing:
        Insert all elements into the priority queue. This ensures that the smallest element is always at the root.

    Dequeueing:
        Remove elements one by one from the priority queue.
        Since the priority queue always removes the smallest element, the array will be sorted in ascending order.

#Example
Enqueue elements into the priority queue:

Priority queue after enqueuing: [0, 0, 1, 1, 2, 5]

Dequeue elements to sort:

Dequeued elements in order: [0, 0, 1, 1, 2, 5]
Resulting sorted array: [0, 0, 1, 1, 2, 5]

Complexity
Time complexity: O(n log n)
    Enqueue : O (log n)
    At each node n we enqueue

Space complexity: O (n)
    Sorts in place
*/
   public int[] SortArray(int[] nums)
    {
        if (nums == null || nums.Length == 0)
            return nums;

        var maxHeap = new PriorityQueue<int, int>();

        foreach (var num in nums)
            maxHeap.Enqueue(num, num); 

        for (int i = 0; i < nums.Length; i++)
            nums[i] = maxHeap.Dequeue(); 

        return nums;
    }
