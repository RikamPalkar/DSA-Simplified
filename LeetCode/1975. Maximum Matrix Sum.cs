    public long MaxMatrixSum(int[][] matrix) 
    {
        int numOfNegatives = 0;
        long sum = 0;
        int smallestValue = Int32.MaxValue;
        for(int row=0; row < matrix.Length; row++)
        {
            for(int col=0; col < matrix[0].Length; col++)
            {
                int currNum = matrix[row][col];
                if(currNum < 0) numOfNegatives++;
                sum += Math.Abs(currNum);
                smallestValue = Math.Min(smallestValue, Math.Abs(currNum));
            }
        }
        return numOfNegatives % 2 == 0 ? sum : sum - (smallestValue*2);
    }
