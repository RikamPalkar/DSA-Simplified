/*
Time: O(m +n), Space: O(1)

#Algorithm:
1. Count how many zeros are in both arrays.
2. Calculate the sum of non-zero elements in both arrays.
3. Add the number of zeros to each sum.
- Assume replacing each 0 with the smallest value 1, this will give the minimum possible sum for each array.
4. Set your target as the maximum of the two sums from step 3.
- This is the smallest equal sum both arrays could potentially reach.
Check for impossibility:
If either array has 0 zeros and its current sum is less than the target,
 Then it's impossible to match the other array.
 - In that case, return -1.
- Otherwise, return the target sum from step 4.
*/
    public long MinSum(int[] nums1, int[] nums2) {
        long nums1Sum = 0, nums2Sum = 0;
        long num1Zeros = 0, num2Zeros = 0;

        foreach (int num in nums1) {
            if (num == 0) num1Zeros++;
            else nums1Sum += num;
        }

        foreach (int num in nums2) {
            if (num == 0) num2Zeros++;
            else nums2Sum += num;
        }

        long sum1 = nums1Sum + num1Zeros;
        long sum2 = nums2Sum + num2Zeros;
        long target = Math.Max(sum1, sum2);

        if(num1Zeros == 0 && sum2 > sum1) return -1;
        if(num2Zeros == 0 && sum1 > sum2) return -1;

        return target;
    }
