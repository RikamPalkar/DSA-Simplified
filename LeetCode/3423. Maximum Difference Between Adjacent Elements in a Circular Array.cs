public class Solution {
    public int MaxAdjacentDistance(int[] nums) {

        //Space: O(1)
        int len = nums.Length;
        int max = Int32.MinValue;

        //Time: O(n)
        for(int i=1; i<len; i++)
            max = Math.Max(max, Math.Abs(nums[i] - nums[i-1]));
        
        max = Math.Max(max, Math.Abs(nums[len-1] - nums[0]));
        return max;
    }
}
