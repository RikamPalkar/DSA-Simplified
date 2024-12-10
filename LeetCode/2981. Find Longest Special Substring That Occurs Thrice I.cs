    public int MaximumLength(string s) 
    {     
        Dictionary<string, int> freq = [];
        for(int i=0; i<s.Length; i++)
        {
            StringBuilder sb = new();
            for(int j=i; j<s.Length; j++)
            {
                if(sb.Length == 0 || 
                        sb[^1] == s[j])
                {
                    sb.Append(s[j]);
                    string currStr = sb.ToString();
                    freq[currStr] = 
                        freq.GetValueOrDefault(currStr)+1;
                }
                else break;
            }
        }

        int res = 0;
        foreach (var kvp in freq)
        {
            if (kvp.Value >= 3 && 
                kvp.Key.Length > res)
                res = kvp.Key.Length;
        }
        return res == 0 ? -1 : res;
    }
