/* 
Solution 1:
Algorithm:
1. Sort the array → so we can use the two-pointer trick
2. Count pairs with sum ≤ upper
3. Count pairs with sum < lower
4. Subtract those to get the number of fair pairs
#Time: O(n log n)
#Space: O(1)
  */
public class Solution {
    public long CountFairPairs(int[] nums, int lower, int upper) {
       Array.Sort(nums);
       long upperSumOfPairs = SlidingWindow(nums, upper);
       long lowerSumOfPairs = SlidingWindow(nums, lower-1); //To count strictly less than lower
       return upperSumOfPairs - lowerSumOfPairs;
    }

    private long SlidingWindow(int[] nums, int limit)
    {
        int l = 0;
        int r = nums.Length-1;
        long pairs = 0;
        while(l<r)
        {
            if((nums[l] + nums[r]) > limit)
            {
                r--;
            }
            else
            {
                pairs += (r-l);
                l++;
            }
        }
        return pairs;
    }
}

//Solution 2: Recrusion
public class Solution {
    public long CountFairPairs(int[] nums, int lower, int upper) {
        int totalPairs = 0;
        for(int i=0; i<nums.Length; i++){
            totalPairs += Helper(nums, i, i+1, 0, lower, upper);
        }
        return totalPairs;
    }

    private int Helper(int[] nums, int i, int nextIndex, int pairs, int lower, int upper)
    {
        if(nextIndex >= nums.Length) return pairs;
        int sum = nums[i] + nums[nextIndex];
        if(lower <= sum  && upper >= sum) pairs += 1;
        return Helper(nums, i, nextIndex+1, pairs, lower, upper);
    }
}

//Solution 3: Iteration
public class Solution {
    public long CountFairPairs(int[] nums, int lower, int upper) {
        int totalPairs = 0;
        for(int i=0; i<nums.Length; i++){
            totalPairs += Helper(nums, i, lower, upper);
        }
        return totalPairs;
    }

    private int Helper(int[] nums, int currentIndex, int lower, int upper)
    {
        int validPairs = 0;

        for (int j = currentIndex + 1; j < nums.Length; j++)
        {
            int sum = nums[currentIndex] + nums[j];
            if (sum >= lower && sum <= upper)
            {
                validPairs++;
            }
        }

        return validPairs;
    }
}
