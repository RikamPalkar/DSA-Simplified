
    /*
        DP Top Down Memoization:
        Time-Complexity  : O(m*n)
        Space-Complexity : O(m*n) 
    */
    public int MinPathSum(int[][] grid) {
        return HelperSum(grid, 0, 0, new Dictionary<string,int>());
    }

    private int HelperSum(int[][] grid, int row, int col, Dictionary<string, int> memo)
    {
	   int numberOfRows = grid.Length;
       int numberOfCols = grid[0].Length;
      
        string key = row + "-" +col;
        if(memo.ContainsKey(key))
        {
            return memo[key];
        }
        else if(row == numberOfRows-1 && col == numberOfCols-1)
        {
            memo[key] = grid[row][col];
        }
        else if(row == numberOfRows-1)
        {
            memo[key] = grid[row][col] + HelperSum(grid, row, col+1, memo);
        }
        else if (col == numberOfCols-1)
        {
            memo[key] = grid[row][col] + HelperSum(grid, row+1, col, memo);
        }
        else
        {
            memo[key] = grid[row][col] + 
              Math.Min(HelperSum(grid, row, col+1, memo), HelperSum(grid, row+1, col, memo));
        }
        return memo[key];
    }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
   /*
        DP Bottom Up:
        Time-Complexity  : O(m*n)
        Space-Complexity : O(1) 
    */
   public int MinPathSum(int[][] grid) 
   {
       int numberOfRows = grid.Length;
       int numberOfCols = grid[0].Length;
     
        for(int row = 0; row < numberOfRows; row++) 
        {
            for (int col = 0; col < numberOfCols; col++) 
            {
                if (row == 0 && col == 0) continue;

                if (row == 0) 
                {
                    grid[row][col] += grid[row][col - 1]; continue;
                }

                if (col == 0) 
                {
                    grid[row][col] += grid[row - 1][col]; continue;
                }

                grid[row][col] += Math.Min(grid[row][col - 1], grid[row - 1][col]);
            }
        }

        return grid[numberOfRows- 1][numberOfCols - 1];
    }
