public class Solution {
      //Solution #1
      //Time: O(n), Space: O(1) In Place
      public int Rob(int[] nums) {
        if(nums.Length == 0) return 0;
        if(nums.Length == 1) return nums[0];
        
        nums[1] = Math.Max(nums[0], nums[1]);
        
        for(int i=2; i<nums.Length; i++)
        {
            nums[i] = Math.Max(nums[i-2] + nums[i], nums[i-1]);
        }
        return nums[nums.Length-1];
    }
}

   //Solution #2
   //Time: O(n), Space: O(1) two variables
    public int Rob(int[] nums) {
        if(nums.Length == 0) return 0;
        if(nums.Length == 1) return nums[0];
        
        int first = nums[0];
        int second = Math.Max(nums[0], nums[1]); 
        
        for(int i=2; i<nums.Length; i++)
        {
            int sum = Math.Max(first + nums[i], second);
            first = second;
            second = sum;
        }
        return second;
    }

   //Solution #3
   //Time: O(n), Space: O(n)
    public int Rob(int[] nums) {
        if(nums.Length == 0) return 0;
        if(nums.Length == 1) return nums[0];
        
        int[] dp = new int[nums.Length];
        dp = nums;
        dp[0] = nums[0];
        dp[1] = Math.Max(nums[0], nums[1]);
        
        for(int i=2; i<nums.Length; i++)
        {
            dp[i] = Math.Max(nums[i-2] + nums[i], nums[i-1]);
        }
        return dp[dp.Length-1];
    }
