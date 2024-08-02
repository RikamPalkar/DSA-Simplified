/*
Algorithm

Count the Total Number of 1's:

    Find how many 1's are in the entire array (numberOfOnes).

Handle Special Cases:

    If there are no 1's or all elements are 1's, no swaps are needed, so return 0.

Initial Window Setup:

    Set up a window of size equal to the number of 1's and count how many 1's are in this initial window (onesInWindow).

Slide the Window Across the Array:

    Move the window one position at a time across the circular array:
        Remove the value that is sliding out of the window.
        Add the value that is sliding into the window.
        Update the count of 1's in the current window (onesInWindow).
        Track the maximum number of 1's found in any window (maxOnesInWindow).

Calculate the Minimum Swaps:

    The minimum number of swaps needed to group all 1's together is the total number of 1's minus the maximum number of 1's found in any window.

Examples:
Example 1
Input: nums = [0,1,0,1,1,0,0]
Output: 1
numberOfOnes = 3
maxOnesInWindow = 2
Answer: 3-2 = 1 
  
Example 2
Input: nums = [0,1,1,1,0,0,1,1,0]
Output: 2
numberOfOnes = 5 
maxOnesInWindow = 3
Answer: 5-3 = 2

Example 3
Input: nums = [1,1,0,0,1]
Output: 0
numberOfOnes = 3 
maxOnesInWindow = 3
Answer: 3-3 = 0

Complexity

    Time complexity: O(n)
    Space complexity: O(1)

*/

public class Solution {
    public int MinSwaps(int[] nums) 
    {
        int len = nums.Length;
        int numberOfOnes = nums.Count(x => x == 1);
        if (numberOfOnes == 0 || numberOfOnes == len) return 0;

        int r=numberOfOnes;
        int onesInWindow = 0;
        int maxOnesInWindow = 0;

        for(int i=0; i<r; i++)//Number of ones in first window
            if(nums[i] == 1) onesInWindow++;

        maxOnesInWindow = onesInWindow;
        
        // Slide the window across the array
        for(int l=1; l<len; l++)
        {    
            //Count number of ones for each window in array
            if(nums[l-1] == 1) onesInWindow--;
            if(nums[r%len] == 1) onesInWindow++;       
            maxOnesInWindow = Math.Max(onesInWindow, maxOnesInWindow);
            r++;      
        }
        return numberOfOnes - maxOnesInWindow;
    }
}
