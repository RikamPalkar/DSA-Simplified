# DSA
Here you will find implementation of all sorts of data structures and algorithms in C#. I come back and improve my code again and again. Feel free to fork and collaborate.

## Sorting
|                 | Best        | Avg         | Worst       | Space       |
| ----------------|:-----------:|:-----------:|:-----------:|:-----------:|
| [Bubble Sort](https://github.com/RikamPalkar/DSA/blob/main/Sorting/BubbleSort.cs)     | O(n)        | O(n^2)      | O(n^2)      | O(1)        |
| [Insertion Sort](https://github.com/RikamPalkar/DSA/blob/main/Sorting/InsertionSort.cs)  | O(n)        | O(n^2)      | O(n^2)      | O(1)        |
| [Selection Sort](https://github.com/RikamPalkar/DSA/blob/main/Sorting/SelectionSort.cs)  | O(n^2)      | O(n^2)      | O(n^2)      | O(1)        |
| [Quick Sort](https://github.com/RikamPalkar/DSA/blob/main/Sorting/QuickSort.cs)      | O(n Log(n)) | O(n Log(n)) | O(n^2)      | O(n Log(n)) |
| [Heap Sort](https://github.com/RikamPalkar/DSA/blob/main/Sorting/HeapSort.cs)       | O(n Log(n)) | O(n Log(n)) | O(n Log(n)) | O(1)        |
| [Merge Sort](https://github.com/RikamPalkar/DSA/blob/main/Sorting/MergeSort%20Optimized.cs)      | O(n Log(n)) | O(n Log(n)) | O(n Log(n)) | O(n)        |

## Trie
|                 | Time        | Space       |
| ----------------|:-----------:|:-----------:|
| [Build Trie](https://github.com/RikamPalkar/DSA/blob/main/Trie/SuffixTrie.cs)      | O(n^2)      | O(n^2)      |
| [Lookup](https://github.com/RikamPalkar/DSA/blob/main/Trie/SuffixTrie.cs)          | O(n)        | O(1)        |


## Graph ||  v = vertices, e = edges in graph
### Graph Traversal Algorithms
1. **DFS**: Depth First Search

|                 | Time        | Space       |
| ----------------|:-----------:|:-----------:|
| [DFS with Recursion](https://github.com/RikamPalkar/DSA/blob/main/Graphs/Graph%20Traversal%20Algorithms/DFS%20Recursion.cs)   |O(v + e)   | O(v)        |
| [DFS with Stack](https://github.com/RikamPalkar/DSA/blob/main/Graphs/Graph%20Traversal%20Algorithms/DFS%20Stack.cs)   |O(v + e)   | O(v)        |

2. **BFS**: Breadth First Search

|                 | Time        | Space       |
| ----------------|:-----------:|:-----------:|
| [BFS with Recursion](https://github.com/RikamPalkar/DSA/blob/main/Graphs/Graph%20Traversal%20Algorithms/BFS/BFS%20Recursion.cs)   |O(v + e)   | O(v)        |
| [BFS with Queue](https://github.com/RikamPalkar/DSA/blob/main/Graphs/Graph%20Traversal%20Algorithms/BFS/BFS%20Queue.cs)   |O(v + e)   | O(v)        |


### Dijkstra’s Shortest Path Algorithm


|                 | Time        | Space       |
| ----------------|:-----------:|:-----------:|
| [Shortest Path](https://github.com/RikamPalkar/DSA/blob/main/Graphs/Dijkstra%20Algorithm/Dijkstra's%20Algorithm.cs)   |O(v^2 + e)   | O(v)        |
