//Time: O(n), Space: O(1)
  public int MinChanges(string s)
    {
        int len = s.Length;
        if(len % 2 != 0) return 0;

        int result = 0;
        for(int i=1; i<len; i+=2)
        {
            if(s[i-1] != s[i]) {  result++; }
        }
        return result;
    }
