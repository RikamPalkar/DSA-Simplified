    public string[] SortPeople(string[] names, int[] heights) 
    {  
      var people = new List<(string name, int height)>();

      for (int i = 0; i < names.Length; i++) //Time: O(n)
            people.Add((names[i], heights[i]));

      people.Sort((a, b) => b.height.CompareTo(a.height)); //Time: O(n log(n))

      string[] sortedNames = new string[names.Length]; //Space: O(n)
        
      for (int i = 0; i < people.Count; i++) //Time: O(n)
            sortedNames[i] = people[i].name;

        return sortedNames;
    }

//**
*********************************************************************************
    Time complexity: O(n log n)
    Space complexity: O(n)
      
    Solution 1:

    Store sorted heights in a list of tuples.
    Sort the tuples in descending order.
    Iterate through the tuples and add them to the result.

    Solution 2:

    Store sorted heights in a Sorted Map.
    Loop through Map in reverse and add it to the result.

*********************************************************************************
**//

    public string[] SortPeople(string[] names, int[] heights) 
    {      
        SortedDictionary<int, string> heightNameMap = [];

        for(int i=0; i<heights.Length; i++) //Time: O(n)
            heightNameMap[heights[i]] = names[i]; //Time: O(log(n))
        
        int index = 0;
        string[] result = new string[heightNameMap.Count]; //Space: O(n)

        foreach (var kvp in heightNameMap.Reverse()) //Time: O(n)
                result[index++] = kvp.Value; 

        return result;
    }
