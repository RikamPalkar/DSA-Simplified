//Time: O(m * n), Space: O(m * n)
public int[][] Construct2DArray(int[] original, int m, int n)
{
        int i = 0;
        if (original.Length != m * n)
        {
            return new int[0][];
        }
        int[][] result = new int[m][];
        for(int row=0; row<m; row++)
        {
            result[row] = new int[n];
            for(int col=0; col<n; col++)
            {
                result[row][col] = original[i++];
            }
        }
        return result;
    }
}

public int[][] Construct2DArray(int[] original, int m, int n) 
{
        if (original.Length != m * n)
        {
            return new int[0][];
        }
        
        int[][] result = new int[m][];
        
        for (int i = 0; i < m; i++)
        {
            result[i] = original.Skip(i * n).Take(n).ToArray();
        }
        return result;
    }
}
