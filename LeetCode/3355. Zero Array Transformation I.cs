public class Solution {
    public bool IsZeroArray(int[] nums, int[][] queries) {
        int len = nums.Length;
        int[] diffArray = new int[len+1];

        for(int i=0; i<queries.Length; i++){
            int l = queries[i][0];
            int r = queries[i][1];
            diffArray[l]++; // start adding +1 from here on.
            diffArray[r+1]--; // stop adding +1 from here on, as ragne is finished
        }

        int prefixSum = 0;
        for(int i=0; i<nums.Length; i++){       
            prefixSum += diffArray[i];
            if (nums[i] - prefixSum > 0) return false;
        }
        return true;
    }

    // If its range sum go for diff array + prefix sum
    // Example 1
    // [1, 1, 1, 1] nums
    // [0, 0, 0, 0, 0] diff
    // [1, 0, 0, 0, -1] 0-3 // +1 at l means: start adding +1 from here on. -1 at r+1 means: stop adding +1 from here on (cancel it out)
    // [1, 1, 1, 1] prefix sum // how many times each index is affected
    // [0, 0, 0, 0] nums - prefix sum //what's left after applying all those operations

    // Example 2
    // [4, 3, 2, 1] nums
    // [0, 0, 0, 0, 0] diff
    // [0, 1, 0, 0, -1] 1-3
    // [1, 1, 0, -1, -1] 0-2
    // [1, 2, 2, 1] prefix sum
    // [3, 1, 0, 0] nums - prefix sum
}

//Solution 2 bruteforce TLE
public class Solution {
    public bool IsZeroArray(int[] nums, int[][] queries) {
        int len = nums.Length;
        int[] subArray = new int[len];

        for(int i=0; i<queries.Length; i++){
            for(int j=queries[i][0]; j<= queries[i][1]; j++){
                subArray[j]++;
            }
        }

        for(int i=0; i<nums.Length; i++){
            nums[i] -= subArray[i];
            if(nums[i] > 0) return false;
        }
        return true;
    }
}
