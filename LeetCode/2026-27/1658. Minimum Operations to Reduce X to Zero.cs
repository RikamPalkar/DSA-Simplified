/*
    Intuition

    Instead of finding which elements to remove, we can find which elements to keep.

    If the total sum is nums.Sum() and we need to remove elements with sum x:

        sum of kept elements = nums.Sum() - x

    The kept elements must be a contiguous subarray,
    because we can only remove elements from the left or right.

    To minimize the number of operations, we need to find the longest window
    whose sum equals nums.Sum() - x.

    Since all numbers are positive, we can use a sliding window.
*/

/*
    Approach

    1. Calculate the target sum:
           diff = nums.Sum() - x

    2. If diff < 0, it is impossible.

    3. If diff == 0, we need to remove the entire array.

    4. Use l and r as the sliding-window boundaries.

    5. Add nums[r] to sum.

    6. If sum > diff, move l forward and subtract elements.

    7. When sum == diff, calculate the window length
       and update longestWindow.

    8. The answer is:
           nums.Length - longestWindow
*/

/*
    Complexity

    Time: O(n)
    Space: O(1)
*/
public class Solution
{
    public int MinOperations(int[] nums, int x)
    {
        int l = 0, len = nums.Length;
        int sum = 0, longestWindow = -1;
        int diff = nums.Sum() - x;

        if (diff < 0)
            return -1;

        if (diff == 0)
            return len;

        for (int r = 0; r < len; r++)
        {
            sum += nums[r];

            while (sum > diff)
            {
                sum -= nums[l];
                l++;
            }

            if (sum == diff)
            {
                int windowLen = r - l + 1;
                longestWindow = Math.Max(longestWindow, windowLen);
            }
        }

        return longestWindow == -1 ? -1 : len - longestWindow;
    }
}