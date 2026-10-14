public class Solution {

    // Time: O(n) || Space: O(n)
    public string MaxSumOfSquares(int num, int sum) {

        if(sum > 9*num) return string.Empty;

        StringBuilder sb = new();

        while(num > 0){
            int n = Math.Min(9, sum);
            sb.Append(n);
            sum -= n;
            num--;
        }

        return sb.ToString();
    }
}