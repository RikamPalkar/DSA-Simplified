

public class Solution 
{
    public int MaxUniqueSplit(string s) 
    {
       return Backtrack(0, s, []);
    }

    private int Backtrack(int idx, string s, HashSet<string> set)
    {
        if(idx == s.Length) return set.Count;

        int maxCount = 0;
        for(int i = idx+1; i <= s.Length; i++)
        {
            string subStr = s[idx..i];
            if(!set.Contains(subStr))
            {
                set.Add(subStr);

                maxCount = Math.Max(maxCount, Backtrack(i, s, set));
                set.Remove(subStr);
            }
        }
        return maxCount;
    }
}

/*
The time complexity of the solution mainly comes from exploring all possible ways to split the string into unique substrings. For each character in the string, you can either start a new substring or continue with the current one, leading to \( 2^N \) possible combinations (where \( N \) is the length of the string). For each combination, you're checking substrings, which takes \( O(N) \) time. So, the total time complexity is \( O(N \cdot 2^N) \).

The space complexity is \( O(N) \) because the recursion depth can go up to \( N \), and the `HashSet` can store up to \( N \) unique substrings at any point. 

In short:
- Time complexity: \( O(N \cdot 2^N) \)
- Space complexity: \( O(N) \)
*/
