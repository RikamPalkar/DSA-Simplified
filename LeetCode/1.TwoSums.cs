public class Solution 
{
    /*
        BruteForce:
        Time-Complexity  : O(n^2)
        Space-Complexity : O(1)  
    */
    public int[] TwoSum(int[] nums, int target) 
    {
        for (int i = 0; i < nums.Length; i++) 
        {
            for (int j = i + 1; j < nums.Length; j++) 
            {
                if (nums[i] + nums[j] == target) 
                {
                    return new int[] { i, j };
                }
            }
        }
        throw new ArgumentException("No two elements add up to the target.");
    }


    /*
        Optimal:
        Time-Complexity  : O(n) 
        Space-Complexity : O(n) 
    */
    public int[] TwoSum(int[] nums, int target) 
    {
        //Validations
        if (nums == null || nums.Length < 2)
        {
            return Array.Empty<int>();
        }

        Dictionary<int, int> numToIndexMap = new();
        for (int i = 0; i < nums.Length; i++) 
        {
            int complement = target - nums[i];
            if (numToIndexMap.TryGetValue(complement, out int seen)) 
            {
                return new int[] { seen, i };
            }
            numToIndexMap[nums[i]] = i;
        }
        return Array.Empty<int>();
    }

}