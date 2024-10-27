
//Time:O(row * col), Space:O(row * col)
    public int CountSquares(int[][] matrix)
    {
        int result = 0;
        int rowLen = matrix.Length;
        int colLen = matrix[0].Length;
        int[][] dp = new int[rowLen][];

        for(int row = 0; row < rowLen; row++)
        {
            dp[row] = new int[colLen];
            for(int col = 0; col < colLen; col++)
            {     
                if(matrix[row][col] == 1)
                {
                    if(row == 0 || col == 0) 
                    {
                        dp[row][col] = 1;
                    }
                    else
                    {
                            dp[row][col] =  Math.Min(dp[row-1][col-1], Math.Min(dp[row][col-1], dp[row-1][col])) +1;
                    }
                     result += dp[row][col];
                  }
              }
        }
        return result;
        }
    }


