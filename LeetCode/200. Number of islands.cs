/* 
DFS with backtracking. 

# Complexity
- Time complexity:
O(m*n): The algorithm traverses each cell in the m x n grid once

- Space complexity:
O(m*n): The recursive DFS call can reach a maximum depth proportional to the grid size.
*/
  
public class Solution {
    public int NumIslands(char[][] grid) {
        int count = 0;
        for(int row =0; row < grid.Length; row++)
        {
            for(int col =0; col < grid[row].Length; col++)
            {
                if(grid[row][col] == '1')
                {
                    DFS(row, col, grid);
                    count++;
                }
            }
        }
        return count;
    }
    
    private void DFS(int row, int col, char[][] grid)
    {
        if( row < 0 || row > grid.Length-1 || col < 0 || col > grid[row].Length -1 || grid[row][col] == '0')
        {
            return;
        }
        
        grid[row][col] = '0';
        DFS(row+1, col, grid);
        DFS(row, col+1, grid);
        DFS(row-1, col, grid);
        DFS(row, col-1, grid);
    }
}
