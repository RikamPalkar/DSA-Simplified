//Time: O(m * n), Space:O(m * n)
    public int MaxMoves(int[][] grid) {
        int result = 0;
        int[][] memo = new int[grid.Length][];

        for(int row = 0; row < grid.Length; row++)
            memo[row] = new int[grid[0].Length];

        for(int row = 0; row < grid.Length; row++)
            result = Math.Max(result, DFS(row, 0, grid, memo));
        
        return result;
    }

    private int DFS(int row, int col, int[][] grid, int[][] memo)
    {
        if(row < 0 || row >= grid.Length || col >= grid[0].Length) return 0;

        if(memo[row][col] != 0) return memo[row][col];

        int maxMoves = 0;
        int curr = grid[row][col];

        if(col+1 < grid[0].Length)
        {
            if(row -1 >= 0 && grid[row -1][col+1] > curr) // up

                maxMoves = Math.Max(maxMoves, 1+DFS(row-1, col+1, grid, memo));
            }

            if(grid[row][col+1] > curr) // right
            {
                maxMoves = Math.Max(maxMoves, 1+DFS(row, col+1, grid, memo));
            }

            if(row +1 < grid.Length && grid[row+1][col+1] > curr) // down
            {
                maxMoves = Math.Max(maxMoves, 1+DFS(row+1, col+1, grid, memo));
            }
        }

        memo[row][col] = maxMoves;
        return maxMoves;
    }
}
