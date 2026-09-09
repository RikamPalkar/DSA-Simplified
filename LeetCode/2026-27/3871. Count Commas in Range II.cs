public class Solution {

    // Time: O(log₁₀ n) — the loop runs once for every power of 1,000
    // Space: O(1) — only a few variables are used
    public long CountCommas(long n) {
        long result = 0;

        for (long start = 1_000; start <= n; start *= 1_000)
        {
            result += n - start + 1;
        }
        return result;
    }
}