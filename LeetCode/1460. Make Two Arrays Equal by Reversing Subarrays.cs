/*Solution 1 Sort and Compare
Complexity

    Time complexity: O(n log n)

    Space complexity: O(1)

*/

    public bool CanBeEqual(int[] target, int[] arr) 
    { 
        Array.Sort(target);
        Array.Sort(arr);
        return target.SequenceEqual(arr);
    }
/*
Solution 2 Using 3 loops
Complexity

    Time complexity: O(3n)

    Space complexity: O(n)
*/

    public bool CanBeEqual(int[] target, int[] arr) 
    {
        
        Dictionary<int, int> targetDict = [];
        Dictionary<int, int> arrDict = [];

        foreach(int i in target)
            targetDict[i] = targetDict.GetValueOrDefault(i)+1;

        foreach(int i in arr)
            arrDict[i] = arrDict.GetValueOrDefault(i)+1;

        foreach(var item in targetDict)
            if(!arrDict.TryGetValue(item.Key, out int value) || value != item.Value)
            return false; 

        return true;
    }
/*
Solution 3 Using 2 loops
Complexity

    Time complexity: O(2n)

    Space complexity: O(n)

*/

    public bool CanBeEqual(int[] target, int[] arr) 
    {
        
        Dictionary<int, int> targetDict = [];
        Dictionary<int, int> arrDict = [];

        for(int i=0; i<target.Length; i++)
        {
            targetDict[target[i]] = targetDict.GetValueOrDefault(target[i])+1;
            arrDict[arr[i]] = arrDict.GetValueOrDefault(arr[i])+1;
        }

        foreach(var item in targetDict)
            if(!arrDict.TryGetValue(item.Key, out int value) || value != item.Value)
            return false; 

        return true;
    }
