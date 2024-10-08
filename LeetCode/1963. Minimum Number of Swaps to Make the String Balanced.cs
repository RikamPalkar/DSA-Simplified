public class Solution {
    public int MinSwaps(string s) {
        
        int closingBrackets = 0;
        int maxClosingBrackets = 0;
        foreach(char ch in s)
        {
            if(ch == ']') closingBrackets++;
            else closingBrackets--;
            maxClosingBrackets = Math.Max(maxClosingBrackets, closingBrackets);
        }

        return (maxClosingBrackets +1)/2;
    }
}
