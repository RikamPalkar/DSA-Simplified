//Time: O(m*n)
public class Solution 
{
    public int MaxEqualRowsAfterFlips(int[][] matrix) 
    {
        int max = 0;
        Dictionary<string, int> dict = [];
        for(int row=0; row<matrix.Length; row++)
        {
            StringBuilder sb = new();
            bool isInvert = matrix[row][0] == 1;
            for(int col=0; col < matrix[row].Length; col++)
            {
                if(isInvert)
                {
                    sb.Append(matrix[row][col] == 1 ? '0' : '1');
                }
                else
                {
                    sb.Append(matrix[row][col]);
                }
            }
            string key = sb.ToString();
            dict[key] = dict.GetValueOrDefault(key) +1;
        }
        foreach(var kvp in dict)
        {
            max = Math.Max(max, kvp.Value);
        }
        return max;
    }
}
