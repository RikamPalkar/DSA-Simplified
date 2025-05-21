public class Solution {
    public void SetZeroes(int[][] matrix) {
       int rowLen = matrix.Length;
       int colLen = matrix[0].Length;
       bool isFirstRowZero = false, isFirstColZero = false;

      // Find 0's in first row 00 01 02 03
       for(int col=0; col<colLen; col++)
            if(matrix[0][col] == 0) {
                isFirstRowZero = true; break; 
            }

      // Find 0's in first col 00 10 20 30
        for(int row=0; row<rowLen; row++)
            if(matrix[row][0] == 0) {
                isFirstColZero = true; break;
            }

        // Find 0's in matrix and changing first row and/or col to 0 
        for(int row=1; row<rowLen; row++)
            for(int col=1; col<colLen; col++)
                if(matrix[row][col] == 0){
                    matrix[0][col] = 0; // row[i] = 0
                    matrix[row][0] = 0; // col[i] = 0
                }

        // Mark whole row or col to 0 if first row or first col had 0
        for(int row=1; row<rowLen; row++)
            for(int col=1; col<colLen; col++)
                if(matrix[0][col] == 0 || matrix[row][0] == 0)
                    matrix[row][col] = 0;

        //Fill first row with 0's
        if(isFirstRowZero)
            for(int col=0; col<colLen; col++)
                matrix[0][col] = 0;

        //Fill first col with 0's
        if(isFirstColZero)
            for(int row=0; row<rowLen; row++)
                matrix[row][0] = 0;
    }
}
