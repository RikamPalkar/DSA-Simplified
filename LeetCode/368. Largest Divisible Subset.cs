//Time: O(n^2)
// Space: O(n)

  public class Solution {
    public IList<int> LargestDivisibleSubset(int[] nums) {
        int len = nums.Length;

        // Step 1: Sort the array so we can ensure that if nums[r] % nums[l] == 0
        Array.Sort(nums);// Time: O(n log n)

        // Step 2: Create the DP array
        // dp[i] will store the size of the largest divisible subset that ends with nums[i]
        int[] dp = new int[len]; //Space: O(n)
        Array.Fill(dp, 1); // Initially, each number can form a subset of size 1 (just itself) Time: O(n)

        // Step 3: Build the dp array
        for (int r = 1; r < len; r++) { //Time:O(n^2)
            for (int l = 0; l < r; l++) {
                // If nums[r] is divisible by nums[l], we can extend the subset ending at l
                // dp[l] + 1 > dp[r] - If I extend the subset ending at nums[l] by adding nums[r], would I get a longer subset than what I currently have ending at nums[r]
                if (nums[r] % nums[l] == 0 && dp[l] + 1 > dp[r]) { //Time: O(n)
                    dp[r] = dp[l] + 1;
                }
            }
        }

        // Step 4: Find the size of the largest divisible subset
        int max = dp.Max(); //Time: O(n)

        // Step 5: Backtrack to build the actual subset
        // We go from right to left to keep the order aligned with how we built dp[]
        List<int> res = new List<int>();
        int previousDivisor = -1;

        for (int i = len - 1; i >= 0; i--) {
            // If:
            // - Either this is the first number we're adding (previousDivisor == -1)
            // - Or current number divides the previous number added to result
            // - And current dp[i] matches the expected length
            if ((previousDivisor == -1 || previousDivisor % nums[i] == 0) && dp[i] == max) {
                res.Add(nums[i]);
                previousDivisor = nums[i];
                max--; // We've found one element in the chain, so look for the next smaller
            }
        }
        return res;
    }
}
