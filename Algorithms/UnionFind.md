# Introduction
Hey there, folks! Today, we're going to dive into the wild world of algorithms! Yeah, I know, it sounds as exciting as watching paint dry, but stick with me because I've got a tale to tell. It's an algorithm; don't just read about it, code it out as you go, then it will make sense.

So what is it, really?

The Union-Find algorithm is used to manage disjoint sets, and that's why it's also known as the Disjoint Set algorithm. You can efficiently find which set an element belongs to. For example, in the image 2 below, element 2 belongs to the first set, and element 4 belongs to the second set.

You can also use it to find if the graph forms a cycle or not. Like in image 2, the second graph below forms a cycle, but the first one does not.

As the name suggests, the Union-Find algorithm has two main operations:

- Find: This operation determines which set a particular element belongs to. It typically returns a representative element for the set, i.e. the parent/root of that set.
- Union: This operation merges two sets into one. It takes two elements from different sets and combines them.
The example
The example we're dissecting today is this: given 6 vertices (0, 1, 2, 3, 4, 5) and 5 edges [0,1] [0,2] [3,5] [3,4] [5,4], figure out two things, first, if the graph has a cycle and second, if a path exists between 0 & 3.

So, we've got 6 vertices in total: 0, 1, 2, 3, 4, 5.

6 vertices <br>
[image](https://github.com/RikamPalkar/DSA-Simplified/assets/36474843/a61e0630-b028-489f-bd38-afcb3a059fe0)
Image 1: 6 vertices

And we also have edges = [0,1] [0,2] [3,5] [3,4] [5,4], which makes our final graph look like this:

The final graph <br>
https://www.c-sharpcorner.com/article/the-union-find-algorithm/Images/2.png![image](https://github.com/RikamPalkar/DSA-Simplified/assets/36474843/7a8d76fb-70d3-40b9-8096-c84910d2240d)
Image 2: The final graph

That's good for visual understanding, but how do we <code> it out to make it actually work right?
# Class UnionFind
Let's start by simply creating a UnionFind Class with a parent[ ] array. Now, the index of the parent array represents the vertices (0,1,2,3,4,5), and the value of the array represents the parent each vertex belongs to.
```
public class UnionFind {
    private int[] parent;
}
```
Listing 1. Class UnionFind

When we start, we have no idea which vertex belongs to which set. Hence, initially, each vertex is its own parent. This means the index of an array will be the value of the array, too. We can initialize the array in a constructor, which takes n (the number of vertices), 6 in our example, as a parameter. To set each vertex to be its own parent initially, just run through a for loop as follows:
```
// Parent[6] array with 6 elements
// Values [0 1 2 3 4 5]
// Index   0 1 2 3 4 5

public UnionFind(int n)
{
    parent = new int[n];
    for (int i = 0; i < n; i++)
         parent[i] = i;
}
```
Listing 2. The constructor of the class UnionFind

Now your set, or should I call them {sets}, looks like this:

Each vertex belongs in a separate set <br>
https://www.c-sharpcorner.com/article/the-union-find-algorithm/Images/3.png![image](https://github.com/RikamPalkar/DSA-Simplified/assets/36474843/696dfb3e-126f-4560-bc27-1a8951306057)
Image 3: Each vertex belongs to a separate set

# The Find Operation
To demonstrate the workings of the Find operation, let's consider the following example. It is in different color blue than other images because this is not same as our original example.

Alternate example to explain the workings of the find operation<br>
https://www.c-sharpcorner.com/article/the-union-find-algorithm/Images/4.png![image](https://github.com/RikamPalkar/DSA-Simplified/assets/36474843/ddf5628a-9284-47a3-8ff2-61f90448871e)

Image 4: Alternate example to explain the workings of the find operation

This is what the code for the Find operation looks like:
```
public int Find(int x)
{
   if (parent[x] == x)
       return x;
   return parent[x] = Find(parent[x]);
}
```
Listing 3: The Find method

Explanation: We recursively find the root of each vertex. In the above image 4, if you pass vertex 3, it recursively calls vertex 2, then it calls its parent i.e. vertex 0. Now, once you reach the root, you hit the base condition where we realize vertex 0 is the parent of itself, so we return that.

# The Union Operation
The Union(int x, int y) method is used to merge the sets containing vertices x and y. First, it finds the root of x, then finds the root of y using the Find operation. If the parent of both of these vertices are not the same, meaning these 2 vertices (x and y) belong to a different set, so we go ahead and merge them together.

Note. You can either assign x to be the parent of y or y to be the parent of x. It doesn't matter since this is an undirected graph. Don't worry; this will get clear once I give you a rundown of the example.
```
public void Union(int x, int y)
{
    int rootX = Find(x);
    int rootY = Find(y);
    if (rootX != rootY)
        parent[rootY] = rootX;
}
```
Listing 4: The Union method

We have given edges = [0,1] [0,2] [3,5] [3,4] [5,4]. Now remember, before we run Union for all of these edges and start creating a graph, know that at the beginning, all vertices belong to their own set.
```
UnionFind uf = new UnionFind(n);
foreach (var edge in edges)
     uf.Union(edge[0], edge[1]);
```
Listing 5: Looping through each edge

Vertices<br>
https://www.c-sharpcorner.com/article/the-union-find-algorithm/Images/5.png![image](https://github.com/RikamPalkar/DSA-Simplified/assets/36474843/09e9e161-bad5-4a23-a55f-7fd7430368ec)

Image 5: Vertices

Let's take the first edge: [0,1] and run through the union function. x = 0 and y = 1; for x, the parent of 0 is 0, and for y, the parent of 1 is 1, meaning they are disjoint, so let's go ahead and merge them. Once you're done with their union, your graph and array will look like this.

Union of edge [0, 1]<br>
https://www.c-sharpcorner.com/article/the-union-find-algorithm/Images/6.png![image](https://github.com/RikamPalkar/DSA-Simplified/assets/36474843/19cce97b-2f65-4569-879e-0e94b6c4aed6)

Image 6: Union of edge [0, 1]

Edge [0, 2], the parent of 0 is 0, and the parent of 2 is 2, meaning they are disjoint, so let's go ahead and merge them.

Union of edge [0, 2]<br>
https://www.c-sharpcorner.com/article/the-union-find-algorithm/Images/7.png![image](https://github.com/RikamPalkar/DSA-Simplified/assets/36474843/0a350740-a451-4f04-a22a-75fb338b6708)

Image 7: Union of edge [0, 2]

Edge [3, 5], the parent of 3 is 3, and the parent of 5 is 5, they are disjoint, so let's go ahead and merge them.

Union of edge [3, 5]<br>
https://www.c-sharpcorner.com/article/the-union-find-algorithm/Images/8.png![image](https://github.com/RikamPalkar/DSA-Simplified/assets/36474843/b090281f-8ff0-4b63-aa65-85addca2ae04)

Image 8: Union of edge [3, 5]

Edge [3, 4], the parent of 3 is 3, and the parent of 4 is 4. They are disjoint, so let's go ahead and merge them.

Union of edge [3, 4]<br>
https://www.c-sharpcorner.com/article/the-union-find-algorithm/Images/9.png![image](https://github.com/RikamPalkar/DSA-Simplified/assets/36474843/8398a755-3835-4a9e-b22c-b44c703be228)

Image 9: Union of edge [3, 4]

Question 1. Detecting a cycle: If the parent of both nodes is the same, meaning connecting them together will form a cycle
Edge [5, 4], the parent of 5 is 3, and the parent of 4 is 3, they have the same parent, meaning they belong to the same set, so if you were to merge them, it would form a cycle, and this is how you can find out if the graph has a cycle or not.

<br>
https://www.c-sharpcorner.com/article/the-union-find-algorithm/Images/10.png![image](https://github.com/RikamPalkar/DSA-Simplified/assets/36474843/44d06ceb-339f-46d5-9587-d69ffff44371)

Image 10: Union of edge [5, 4]

Now we're done running across all the edges. So Image 10 is final representation of our graph: now let's answer question 2.

i.e. Find if a path exists between 0 & 3 or not. This will tell us if this graph is connected or not.
```
return uf.Find(0) == uf.Find(3);
```
Listing 6: Check if sets are disjoint

The parent of 0 is 0, and the parent of 3 is 3, meaning these 2 vertices belong to different sets; hence, this graph is disjoint.

Let me give you the entire source code of the problem:
```
public class UnionFind {
    private int[] parent;

    public UnionFind(int n) {
        parent = new int[n];
        for (int i = 0; i < n; i++)
            parent[i] = i;
    }

    public int Find(int x) {
        if (parent[x] == x)
            return x;
        return parent[x] = Find(parent[x]);
    }

    public void Union(int x, int y) {
        int rootX = Find(x);
        int rootY = Find(y);
        if (rootX != rootY)
            parent[rootY] = rootX;
    }
}

public class Solution {
    public bool ValidPath(int n, int[][] edges, int source, int destination) {
        UnionFind uf = new UnionFind(n);
        foreach (var edge in edges)
            uf.Union(edge[0], edge[1]);

        return uf.Find(source) == uf.Find(destination);
    }
}
```
Listing 7: Entire Union Find Algorithm

Here is a list of questions for you to practice: https://leetcode.com/tag/union-find

# Conclusion
The Union-Find algorithm is a fundamental tool in computer science, used in various applications like graph theory, network analysis etc. By understanding its operations and implementing them, you can efficiently manage sets and solve complex problems like cycle detection and connectivity in graph, figure out connections in networks or to find the minimum spanning tree in a graph.
