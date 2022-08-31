using System;
using System.Collections.Generic;

IList<int[][]> edges = new List<int[][]>()
{
    new int[1][]{ new int[]{ 1, 7 }},//0 Vertex
    new int[3][]{ new int[]{ 2, 6 }, new int[] { 3,20 }, new int[] { 4,3 } },//1 Vertex
    new int[1][]{ new int[]{ 3, 14}},//2 Vertex
    new int[1][]{ new int[]{ 4, 2 }},//3 Vertex
    new int[0][]{},//4 Vertex
    new int[0][]{}//5 Vertex
};

Program obj = new();

int[] ShortestPath = obj.DijkstrasAlgorithm(0, edges);

public partial class Program
{
    /*
             Time-Complexity : Space-Complexity
                O(v^2 + e)   :     O(v)
             v = vertices, e = edges in graph
    */
    public int[] DijkstrasAlgorithm(int start, IList<int[][]> edges)
    {
        //Get number of vertices
        int numberOfVertices = edges.Count;

        //Create array and fill with infinity and start value as object
        int[] minDistances = new int[numberOfVertices];
        Array.Fill(minDistances, Int32.MaxValue);
        minDistances[start] = 0;

        //We need a hashset to keep track of visited vertex
        HashSet<int> visited = new();

        //Loop through till all vertices are visited
        while (visited.Count <= numberOfVertices)
        {
            //for each vertex we have to find minimum distance from its outgoing edges
            //In result we are getting which outgoing vertex and minimum distance to reach to that vertex
            //i.e. outgoing vertex and egde.
            int[] vertexOutgoingEdgeDistances = GetVertexOutgoingEdgesDistances(minDistances, visited);
            int vertex = vertexOutgoingEdgeDistances[0];
            int minDistance = vertexOutgoingEdgeDistances[1];

            //if value is infinity means node is disconnected, break 
            if (minDistance == Int32.MaxValue) break;

            //Found a minimum distance add that into visited set
            visited.Add(vertex);

            //looping through all the edges that goes through this vertex
            foreach (int[] edge in edges[vertex])
            {
                int destination = edge[0];
                int distanceToDestination = edge[1];

                //From rule number 1
                if (visited.Contains(destination)) continue;

                //updating list with newly found shorter distance, updating minimum distance in minDistances
                int newPathDistance = minDistance + distanceToDestination;
                int currentDestinationDistance = minDistances[destination];
                if (newPathDistance < currentDestinationDistance)
                {
                    minDistances[destination] = newPathDistance;
                }
            }
        }

        int[] finalDistances = new int[numberOfVertices];
        for (int i = 0; i < minDistances.Length; i++)
        {
            int distance = minDistances[i];
            finalDistances[i] = distance;
            if (distance == Int32.MaxValue) finalDistances[i] = -1;
        }
        return finalDistances;
    }

    /// <summary>
    /// This function takes determines from calling vertex what is the distance
    /// </summary>
    /// <param name="distances"></param>
    /// <param name="visited"></param>
    /// <returns>returns the to be reached vertex and its distance from calling vertex</returns>
    private int[] GetVertexOutgoingEdgesDistances(int[] distances, HashSet<int> visited)
    {
        //placeholder, if we didn't find a distance then value stays infinity.
        //this is for minDistance
        int currentMinDistance = Int32.MaxValue;
        //placeholder, if we didn't find a way to reach the vertex then value goes -1.
        //this is for hashset.
        int vertex = -1;

        for (int i = 0; i < distances.Length; i++)
        {
            int distance = distances[i];
            //if we find the vertex that has alrady been visited means we already have a minimum ditance 
            //to reach that vertex. As per the rule number 1
            //Rule: if vertex has >1 outgoing egdes, then it first prefers the short distance edge and then next greater, 
            //in below e.g. vertex 1 will first go to 4 then 2 then 3.
            if (visited.Contains(i)) continue;

            //<= because if node is disconnected we have to return that node
            if (distance <= currentMinDistance)
            {
                vertex = i;
                currentMinDistance = distance;
            }
        }
        return new int[] { vertex, currentMinDistance }; 
    }
}

