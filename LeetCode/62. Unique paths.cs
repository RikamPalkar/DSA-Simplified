public class Solution {
    public int UniquePaths(int m, int n) {
        //Time: O(m*n)
        //Space: O(m*n)
        int[][] dp = new int[m][];
        for(int row=0; row<m; row++){
            dp[row] = new int[n];
            for(int col=0; col<n; col++){
                if(row==0 || col ==0){
                    dp[row][col] = 1;
                }
                else
                {
                    dp[row][col] = dp[row-1][col]+dp[row][col-1];
                }
            }
        }
        return dp[m-1][n-1];
    }
}
