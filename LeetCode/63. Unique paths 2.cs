public class Solution {
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {
        //Time: O(m*n)
        //Space: O(m*n)
    int rowLen = obstacleGrid.Length;
    int colLen = obstacleGrid[0].Length;
    int[][] dp = new int[rowLen][];
    if(obstacleGrid[0][0] == 1 || obstacleGrid[rowLen-1][colLen-1]==1)
    return 0;

    for(int row=0; row<rowLen; row++)
    {
        dp[row] = new int[colLen];
        for(int col=0; col<colLen; col++)
        {
            if(obstacleGrid[row][col] == 1) continue;
            if(row==0 && col==0)
            {
                dp[row][col] = 1;
                continue;
            }
            if(row==0 && obstacleGrid[0][col]==0)//First row
            {
                dp[0][col] = dp[0][col-1];
                continue;
            }

            if(col==0 && obstacleGrid[row][0]==0)//First col
            {
                dp[row][0] = dp[row-1][0];
                continue;
            }

            dp[row][col] = dp[row-1][col]+dp[row][col-1];

        }
    }
    return dp[rowLen-1][colLen-1];
    }
}
