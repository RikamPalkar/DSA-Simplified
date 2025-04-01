public class Solution {
    public long MostPoints(int[][] questions) {

        int n = questions.Length;
        long[] dp = new long[n]; //Space:O(n)

        for (int i = n - 1; i >= 0; i--) { //Time O(n)

            int points = questions[i][0];
            int brainpower = questions[i][1];

            int nextIndex = i + brainpower + 1;
            long solveCurrent = points + (nextIndex < n ? dp[nextIndex] : 0);

            long skipCurrent = (i == n - 1) ? 0 : dp[i + 1];
            dp[i] = Math.Max(solveCurrent, skipCurrent);
        }

        return dp[0];
    }
}
