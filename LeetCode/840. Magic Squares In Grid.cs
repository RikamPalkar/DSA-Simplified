//Time, Space: O(m*n)
public class Solution {
    public int NumMagicSquaresInside(int[][] grid) {
        int result = 0;
        for(int row=0; row<grid.Length-2; row++)
        {
            for(int col=0; col<grid[row].Length-2; col++)
            {
                if(CheckMagicNumber(row, col, grid)) result++;
            }
        }
        return result;
    }

    private bool CheckMagicNumber(int row, int col, int[][] grid)
    {
        HashSet<int> set = [];

        for(int i=0; i<=2; i++)
            for(int j=0; j<=2; j++)
                if(grid[row+i][col+j] > 9 || !set.Add(grid[row+i][col+j])) 
                    return false;    


        for(int i=0; i<=2; i++)
        {
            int sum = 0;
            for(int j=0; j<=2; j++)
            {
                sum += grid[row+i][col+j];   
            }
            if(sum != 15) return false;
        }

        for(int i=0; i<=2; i++)
        {
            int sum = 0;
            for(int j=0; j<=2; j++)
            {
                sum += grid[row+j][col+i];   
            }
            if(sum != 15) return false;
        }


        if((grid[row][col] + grid[row+1][col+1] + grid[row+2][col+2]) != 15) return false;
        if((grid[row][col+2] + grid[row+1][col+1] + grid[row+2][col]) != 15) return false;

        return true;
    }
}
