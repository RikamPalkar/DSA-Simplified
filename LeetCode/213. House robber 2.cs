public class Solution {
    public int Rob(int[] nums) 
    {
        if (nums.Length == 1) 
        return nums[0];

        if (nums.Length == 2) 
        return Math.Max(nums[0], nums[1]);

        int sliceOne = Helper(0, nums.Length-1, nums);
        int sliceTwo = Helper(1, nums.Length, nums);
        
        return Math.Max(sliceOne, sliceTwo);
    }
    
   
    private int Helper(int l, int r, int[] nums)
    {
        int first = nums[l];
        int second = Math.Max(nums[l], nums[l+1]);
        /*
            1 3 5 7 4 2
            1 3 6 7 4 2
            1 3 6 10 4 2
            1 3 6 10 10 2
            1 3 6 10 10 12
        */
        for(int i = l+2; i < r; i++)
        {
            int money = Math.Max(first + nums[i], second);
            first = second;
            second = money;
        }    
        return second;
    }
}
