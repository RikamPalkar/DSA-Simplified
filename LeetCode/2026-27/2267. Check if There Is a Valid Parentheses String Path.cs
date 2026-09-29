public class Solution {
    public bool HasValidPath(char[][] grid)
    {
        int rowLen = grid.Length;
        int colLen = grid[0].Length;
        int len = rowLen + colLen - 1;

        // Odd length can't k; start must be '(' and end must be ')'
        if (len % 2 == 1 || grid[0][0] == ')' || grid[rowLen - 1][colLen - 1] == '(')
            return false;

        int maxk = len / 2;

        // canReach[r, c, b] = true if some path to (r, c) has k b
        bool[,,] canReach = new bool[rowLen, colLen, maxk + 1];

        // First cell is '(' so k starts at 1
        canReach[0, 0, 1] = true;

        for (int r = 0; r < rowLen; r++)
        {
            for (int c = 0; c < colLen; c++)
            {
                if (r == 0 && c == 0) continue;

                int change = grid[r][c] == '(' ? 1 : -1;

                for (int k = 0; k <= maxk; k++)
                {
                    int prev = k - change;

                    if (prev < 0 || prev > maxk)
                        continue;

                    bool reachableFromAbove = r > 0 && canReach[r - 1, c, prev];
                    bool reachableFromLeft = c > 0 && canReach[r, c - 1, prev];

                    if (reachableFromAbove || reachableFromLeft)
                        canReach[r, c, k] = true;
                }
            }
        }

        return canReach[rowLen - 1, colLen - 1, 0];
    }
}