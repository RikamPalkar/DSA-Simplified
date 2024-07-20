    public int[][] RestoreMatrix(int[] rowSum, int[] colSum) 
    {
        int[][] result = new int [rowSum.Length][];
    
        for (int i = 0; i < rowSum.Length; i++) 
        {
            result[i] = new int[colSum.Length];
    
            for (int j = 0; j < colSum.Length; j++) 
            {
                int value = Math.Min(rowSum[i], colSum[j]);
            
                result[i][j] = value;
                rowSum[i] -= value;
                colSum[j] -= value;
            }
    	}
    
        return result;
    
    }
/**
Time Complexity: O(m * n)
Space Complexity: O(m * n)

1. Create an empty matrix of the right size.

2. Fill each cell:
   - For each cell, put the smaller number between the rowSum & colSum.
   - Update the row and column sums by deducting the smaller number.

# Example 1

- Input: `rowSum = [3, 8]`, `colSum = [4, 7]`
- Output: `[[3, 0], [1, 7]]`

#Process
- Cell (0,0): Put `3` (fits both row and column).
- Cell (0,1): Put `0` (row is satisfied).
- Cell (1,0): Put `1` (fits remaining column sum).
- Cell (1,1): Put `7` (fits remaining sums).


# Example 2

- Input: `rowSum = [5, 7, 10]`, `colSum = [8, 6, 8]`
- Output: `[[5, 0, 0], [3, 4, 0], [0, 2, 8]]`

### Process

- Cell (0,0): 
  - `rowSum[0] = 5`, `colSum[0] = 8`
  - Place `5` (fits both sums).
  - Update sums: `rowSum[0] = 0`, `colSum[0] = 3`
  - Matrix: `[[5, 0, 0], [0, 0, 0], [0, 0, 0]]`

- Cell (0,1): 
  - `rowSum[0] = 0`, `colSum[1] = 6`
  - Place `0` (row is satisfied).
  - Update sums: `colSum[1] = 6`
  - Matrix: `[[5, 0, 0], [0, 0, 0], [0, 0, 0]]`

- **Cell (0,2)**:
  - `rowSum[0] = 0`, `colSum[2] = 8`
  - Place `0` (row is satisfied).
  - Update sums: `colSum[2] = 8`
  - Matrix: `[[5, 0, 0], [0, 0, 0], [0, 0, 0]]`

- Cell (1,0):
  - `rowSum[1] = 7`, `colSum[0] = 3`
  - Place `3` (fits both sums).
  - Update sums: `rowSum[1] = 4`, `colSum[0] = 0`
  - Matrix: `[[5, 0, 0], [3, 0, 0], [0, 0, 0]]`

- Cell (1,1):
  - `rowSum[1] = 4`, `colSum[1] = 6`
  - Place `4` (fits both sums).
  - Update sums: `rowSum[1] = 0`, `colSum[1] = 2`
  - Matrix: `[[5, 0, 0], [3, 4, 0], [0, 0, 0]]`

- Cell (1,2):
  - `rowSum[1] = 0`, `colSum[2] = 8`
  - Place `0` (row is satisfied).
  - Update sums: `colSum[2] = 8`
  - Matrix: `[[5, 0, 0], [3, 4, 0], [0, 0, 0]]`

- **Cell (2,0)**:
  - `rowSum[2] = 10`, `colSum[0] = 0`
  - Place `0` (column is satisfied).
  - Update sums: `rowSum[2] = 10`, `colSum[0] = 0`
  - Matrix: `[[5, 0, 0], [3, 4, 0], [0, 0, 0]]`

- **Cell (2,1)**:
  - `rowSum[2] = 10`, `colSum[1] = 2`
  - Place `2` (fits both sums).
  - Update sums: `rowSum[2] = 8`, `colSum[1] = 0`
  - Matrix: `[[5, 0, 0], [3, 4, 0], [0, 2, 0]]`

- Cell (2,2):
  - `rowSum[2] = 8`, `colSum[2] = 8`
  - Place `8` (fits both sums).
  - Update sums: `rowSum[2] = 0`, `colSum[2] = 0`
  - Matrix: `[[5, 0, 0], [3, 4, 0], [0, 2, 8]]`

#Summary
- Matrix: `[[5, 0, 0], [3, 4, 0], [0, 2, 8]]`   
**/
