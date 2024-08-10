/* 
Approach

    Scale each cell meaning each char into 3 * 3 grid. so simply scale entire grid into 3 * 3
    Then simply perform DFS to find islands, island being empty space

Time complexity: O(n^2)
Space complexity: O(n^2)
*/

//Solution 1
public class Solution {
    public int RegionsBySlashes(string[] grid) 
    {
        int size = grid.Length;
        int scaledSize = size * 3;
        bool[,] scaledGrid = new bool[scaledSize, scaledSize];

        for(int i=0; i<size; i++)
        {
            for(int j=0; j<size; j++)
            {
                int row = i*3;
                int col = j*3;
                if(grid[i][j] == '/')
                {
                    scaledGrid[row, col+2] = true;
                    scaledGrid[row+1, col+1] = true;
                    scaledGrid[row+2, col] = true;
                }
                else if(grid[i][j] == '\\')
                {
                    scaledGrid[row, col] = true;
                    scaledGrid[row+1, col+1] = true;
                    scaledGrid[row+2, col+2] = true;
                }
            } 
        }

        int result = 0;
        for(int i=0; i<scaledSize; i++)
        {
            for(int j=0; j<scaledSize; j++)
            {
                if(scaledGrid[i, j]) continue;
                DFS(i, j, scaledGrid); 
                result++;
            }
        } 
        return result;
    }

     private void DFS(int row, int col, bool[,] grid)
     {
        if(row < 0 || col < 0 || row >= grid.GetLength(0) || col >= grid.GetLength(1) ||
            grid[row, col]) return;

            grid[row, col] = true;
            DFS(row, col-1, grid);
            DFS(row, col+1, grid);
            DFS(row+1, col, grid);
            DFS(row-1, col, grid);
    }
}

//Solution 2
public class Solution {
    public int RegionsBySlashes(string[] grid) {
        
        //Scale grid to 3*3 matrix
        /*
        00 - -  03 - -  00 01 02 03 04 05 
        - - -   - - - 
        - - -   - - - 
        30 - -  33 - - 30 31 32 33 34 35 
        - - -   - - -
        - - -   - - -
        */
        char[][] scaledGrid = new char[grid.Length*3][];
        int row = 0, col = 0;
        for(int i=0; i<scaledGrid.Length; i++)
        {
            scaledGrid[i] = new char[grid.Length*3];
        }

        for(int i=0; i<grid.Length; i++)
        {
            string currentCell = grid[i];
            for(int j=0; j<currentCell.Length; j++)
            {
                if(currentCell[j] == '/')
                {
                    scaledGrid[row][col+2] = '/';
                    scaledGrid[row+1][col+1] = '/';
                    scaledGrid[row+2][col] = '/';
                }
                else if(currentCell[j] == '\\')
                {
                    scaledGrid[row][col] = '\\';
                    scaledGrid[row+1][col+1] = '\\';
                    scaledGrid[row+2][col+2] = '\\';
                }
                col += 3;
            } 
            row += 3;  
            col = 0;  
        }

        int result = 0;
        for(int i=0; i<scaledGrid.Length; i++)
        {
            for(int j=0; j<scaledGrid[i].Length; j++)
            {
                if(scaledGrid[i][j] == '/' || scaledGrid[i][j] == '\\') continue;
                DFS(i, j, scaledGrid); 
                result++;
            }
        } 
        return result;
    }

     private void DFS(int row, int col, char[][] grid)
     {
        if(row < 0 || col < 0 || row >= grid.Length || col >= grid[row].Length ||
            grid[row][col] == '/' || grid[row][col] == '\\') return;

            grid[row][col] = '/';
            DFS(row, col-1, grid);
            DFS(row, col+1, grid);
            DFS(row+1, col, grid);
            DFS(row-1, col, grid);
    }
}
