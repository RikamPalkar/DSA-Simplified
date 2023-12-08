public class Solution {
    public int GetMaximumGold(int[][] grid) {
        int result = 0; 
         for(int i=0; i<grid.Length; i++)
         {
             for(int j=0; j<grid[i].Length; j++)
             {                 
                  if(grid[i][j] == 0){
                    continue;
                }
                result = Math.Max(result, DFS(grid, i, j));
             }
         }
         return result;
    }
  
    private int DFS(int[][] grid, int row, int col)
    {
        if(row < 0 || row > grid.Length-1 || 
           col < 0 || col > grid[row].Length -1 || 
           grid[row][col] == 0){
            return 0;
        }
        
        int cellValue = grid[row][col];     
        grid[row][col] = 0;//Visited
      
        int down = DFS(grid, row+1, col);
        int up = DFS(grid, row-1, col);
        int right = DFS(grid, row, col+1);
        int left = DFS(grid, row, col-1);
      
        int maxValue = Math.Max(Math.Max(down, up), Math.Max(right, left));

        grid[row][col] = cellValue;//Restoring value for backtracking
        return cellValue + maxValue;   
    }
}
