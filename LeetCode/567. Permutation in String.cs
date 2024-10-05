
    public bool CheckInclusion(string s1, string s2) 
    {
        if(s1.Length > s2.Length) return false;

        int left = 0, right = 0;
        int rem = s1.Length;
        int[] lookup = new int[26];

        foreach(char ch in s1)
        {
            lookup[ch - 'a']++;
        }

        while(right < s2.Length)
        {
            if(lookup[s2[right++] - 'a']-- >= 1 )
            {
                rem--;
            }
            if(rem == 0) return true;
            if(right - left == s1.Length  && 
               lookup[s2[left++] - 'a']++ >= 0 )
            {
                rem++;
            }
        }
        return false;
    }

