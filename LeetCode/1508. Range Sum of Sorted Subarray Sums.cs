    public int RangeSum(int[] nums, int n, int left, int right) {
        int modulo = 1_000_000_007;
        List<int> sumsOfSubArrays = [];

        for(int i=0; i<nums.Length; i++)
        {
            int sum = 0;
            for(int j=i; j<nums.Length; j++)
            {
                sum += nums[j];
                sumsOfSubArrays.Add(sum);
            }
        }
        sumsOfSubArrays.Sort();

        int sumOfLimits = 0;
        for(int i=left-1; i<right; i++)
            sumOfLimits = (sumOfLimits + sumsOfSubArrays[i]) % modulo;
        
        return sumOfLimits;
    }

/*
Approach

Generate subarray sum by looping twice
Sort the result
Loop from left to right and generate sum and % each step as incremented sum could exceed the limits
Time complexity:

Subarray sum: O(n^2)
Sorting subarray sum: O(n^2 log n)
Dominator: O(n^2 log n)
Space complexity:

Subarray sum: O(n^2)
*/
