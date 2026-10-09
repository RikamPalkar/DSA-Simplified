
/*******************************
 * Intuition
    Each ( requires two ) to balance it. Track unmatched opening parentheses and count the insertions needed to fix invalid pairs.

 *******************************/

/*******************************
 * Explanation
    For (, increment leftCount.
    For ), check whether the next character is also ).
    Match valid )) pairs with an unmatched (.
    Count insertions when a matching parenthesis is missing.
    Add two insertions for each unmatched ( at the end.
 *******************************/

public class Solution
{
    // Time: O(n) | Space: O(1)
    public int MinInsertions(string s)
    {
        int res = 0;
        int leftCount = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                leftCount++;
            }
            else
            {
                if (leftCount > 0)
                    leftCount--;
                else
                    res++;

                if (i + 1 < s.Length && s[i + 1] == ')')
                    i++;
                else
                    res++;
            }
        }

        return res + leftCount * 2;
    }
}