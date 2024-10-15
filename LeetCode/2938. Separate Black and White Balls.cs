    public long MinimumSteps(string s) 
    {
        long ones = 0;
        long sumOfJumps = 0;
        for(int i=0; i<s.Length; i++)
        {
            if(s[i] == '1') ones++;
            else sumOfJumps += ones;
        }
        return sumOfJumps;
    }
