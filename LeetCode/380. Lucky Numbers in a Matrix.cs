//Time :O(m * n), Space: O(m + n)
/**
 - Find row minimum and rowMin
 - Find col maximum and colMax
 - Find intersection of rowMin & colMax and return.
**/
    public IList<int> LuckyNumbers (int[][] matrix) 
    {
        int rows = matrix.Length;
        int cols = matrix[0].Length;
        
        HashSet<int> rowMin = new();
        HashSet<int> colMax = new();

        // Find the minimum value in each row
        for (int i = 0; i < rows; i++) 
        {
            int min = int.MaxValue;
            for (int j = 0; j < cols; j++) 
            {
                if (matrix[i][j] < min) min = matrix[i][j];   
            }
            rowMin.Add(min);
        }
        
        // Find the maximum value in each column
        for (int j = 0; j < cols; j++) 
        {
            int max = int.MinValue;
            for (int i = 0; i < rows; i++) 
            {
                if (matrix[i][j] > max) max = matrix[i][j];
            }
            colMax.Add(max);
        }
        
        // Find intersection
        List<int> result = [];
        foreach (int num in rowMin) 
        {
            if (colMax.Contains(num)) result.Add(num);
        }
        
        return result;
    }
