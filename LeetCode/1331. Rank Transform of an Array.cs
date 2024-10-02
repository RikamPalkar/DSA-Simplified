//Time : O(n log n), Space : O(n)

public class Solution {
    public int[] ArrayRankTransform(int[] arr) 
    {
        int[] sortedArr = arr[..];
        Array.Sort(sortedArr);

        Dictionary<int, int> ranks = [];
        int currRank = 1;

        for(int i=0; i<sortedArr.Length; i++)
        {
            if(!ranks.ContainsKey(sortedArr[i]))
            { 
                ranks[sortedArr[i]] = currRank++;
            } 
        }
        int[] result =  new int[arr.Length];
        for(int i=0; i<arr.Length; i++)
        {
            result[i] = ranks[arr[i]];
        }
        return result;
    }
}
