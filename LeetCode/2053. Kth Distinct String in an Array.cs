
    public string KthDistinct(string[] arr, int k) 
    { 
        Dictionary<string, int> dict = [];

        foreach(string str in arr)
           dict[str] = dict.GetValueOrDefault(str)+1;

        foreach(var str in dict)     
            if(str.Value == 1 && --k == 0) return str.Key;

        return string.Empty;
    }
/*
Algorithm

    Count all strings with their frequencies in first loop.
    In second loop, check if frequency is 1 indicating that string is a distinct element and if k has reached 0 then return that string.
    else return empty string.

Time complexity: O(2 n) => O(n)
Space complexity: O(n)
*/
