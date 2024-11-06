class Solution
{
    public bool CanSortArray(int[] nums)
    {
        int numOfSetBits = CountBits(nums[0]);
        int maxOfSegment = nums[0];
        int minOfSegment = nums[0];

        // Initialize max of the previous segment to the smallest possible integer
        int maxOfPrevSegment = int.MinValue;

        for (int i = 1; i < nums.Length; i++)
        {
            if (CountBits(nums[i]) == numOfSetBits)
            {
                // Element belongs to the group with same number of 1s
                maxOfSegment = Math.Max(maxOfSegment, nums[i]);
                minOfSegment = Math.Min(minOfSegment, nums[i]);
            }
            else
            {
                // Element belongs to a new group
                if (minOfSegment < maxOfPrevSegment) return false;

                // Update the previous group's max
                maxOfPrevSegment = maxOfSegment;

                // Start a new group with the current element
                maxOfSegment = nums[i];
                minOfSegment = nums[i];
                numOfSetBits = CountBits(nums[i]);
            }
        }

        // Final check for proper group arrangement
        if (minOfSegment < maxOfPrevSegment) return false;
        
        return true;
    }

    private int CountBits(int num)
    {
        int numberOfOnes = 0;
        while(num > 0)
        {
            numberOfOnes += num & 1;
            num >>= 1;
        }
        return numberOfOnes;
    }
}
