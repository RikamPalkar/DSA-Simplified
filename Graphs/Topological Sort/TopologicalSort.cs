IList<int[]> graph = new List<int[]>()
{
     new int[]{ 0, 1 },
     new int[]{ 0, 2 },
     new int[]{ 2, 1 },
     new int[]{ 3, 2 },
     new int[]{ 3, 1 }
};

DAG_Sort tSort = new();
tSort.TopologicalSort(graph);
/*
 Result:  Any of follows
	• 0 3 2 1
    • 3 0 2 1
 */

public class DAG_Sort
{
    Stack<int> Result = new();
    Dictionary<int, List<int>> AdjacencyList = new();
    HashSet<int> Visited = new();
    HashSet<int> InProgress = new();

    public List<int> TopologicalSort(IList<int[]> graph)
    {
        int numberOfEdges = graph.Count;
        CreateAdjacencyList(numberOfEdges, graph);

        foreach (int vertex in AdjacencyList.Keys)
        {
            if (Visited.Contains(vertex)) continue;
            if (!DFS(vertex)) return new List<int>(); //Cycle found
        }
        return Result.ToList();
    }

    private bool DFS(int vertex)
    {
        if (InProgress.Contains(vertex)) return false; //Cycle found
        if (Visited.Contains(vertex)) return true; //If vertex already been visited, then We don't want traverse it again.
        InProgress.Add(vertex);

        foreach (int nextVertex in AdjacencyList[vertex])
        {
            if (!DFS(nextVertex)) return false;
        }

        //Backtrack =>
        InProgress.Remove(vertex); // Done with one path so remove it from InProgress
        Visited.Add(vertex); // Add it to the visited set
        Result.Push(vertex); //Add it to result
        return true;
    }

    private void CreateAdjacencyList(int numberOfEdges, IList<int[]> graph)
    {
        for (int i = 0; i < numberOfEdges; i++)
        {
            int vertex = graph[i][0];
            int edge = graph[i][1];
            if (!AdjacencyList.ContainsKey(vertex)) AdjacencyList[vertex] = new List<int>();
            if (!AdjacencyList.ContainsKey(edge)) AdjacencyList[edge] = new List<int>();
            AdjacencyList[vertex].Add(edge);
        }
    }
}