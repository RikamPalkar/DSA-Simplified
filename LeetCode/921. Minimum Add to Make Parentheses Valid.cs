//Solution 1
// Time : O(2n) Space :(1)
    public int MinAddToMakeValid(string s) {
       int closingBraces = 0;
       int maxClosingBraces = 0;
       foreach(char ch in s) 
       {
            if(ch == ')') closingBraces++;
            else closingBraces--;
            maxClosingBraces = Math.Max(maxClosingBraces, closingBraces);
       }

       int openingBraces = 0;
       int maxOpeningBraces = 0;
        for(int i = s.Length-1; i>=0; i--)
       {
            if(s[i] == '(') openingBraces++;
            else openingBraces--;
            maxOpeningBraces = Math.Max(maxOpeningBraces, openingBraces);
       }

       return maxClosingBraces + maxOpeningBraces;
    }

//Solution 2
// Time : O(n) Space :(1)

    public int MinAddToMakeValid(string s) {
       int braces = 0;
       int closingBraces = 0;

       foreach(char ch in s) 
       {
            if(ch == '(') braces++;
            else braces--;
            if(braces < 0)
            {
                closingBraces++;
                braces = 0;
            }
       }
      return closingBraces + braces;
    }

