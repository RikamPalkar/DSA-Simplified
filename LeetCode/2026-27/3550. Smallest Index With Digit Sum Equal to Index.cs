/*
Intuition:

For every index i, we need to check whether the digit sum of nums[i]
is equal to i.

For single-digit numbers (0-9), the digit sum is the number itself,
so we can return it directly without calculating the digits.

Since we need the smallest index, we simply check the array from left
to right and return the first matching index.

Approach:

1. Loop through the array from index 0.
2. Calculate the digit sum of nums[i].
3. If the digit sum equals i, return i.
4. If no index matches, return -1.

Complexity:

Time: O(n * d)
- n = number of elements
- d = number of digits in each number
- Since nums[i] <= 1000, d <= 4, so this is effectively O(n).

Space: O(1)
*/

public class Solution
{
    public int SmallestIndex(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            if (GetSum(nums[i]) == i)
                return i;
        }

        return -1;
    }

    private int GetSum(int num)
    {
        if (num < 10)
            return num;

        int sum = 0;

        while (num > 0)
        {
            sum += num % 10;
            num /= 10;
        }

        return sum;
    }
}