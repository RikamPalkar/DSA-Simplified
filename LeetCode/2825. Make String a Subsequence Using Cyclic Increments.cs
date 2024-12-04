    public bool CanMakeSubsequence(string str1, string str2) 
    {
        int j = 0;
        for(int i=0; i<str1.Length && j < str2.Length; i++)
        {
            if(str1[i] != str2[j])
            {
                char ch = (char)('a' + (str1[i] - 'a' + 1)%26);
                if(ch == str2[j]) j++;
            }
            else j++;
        }
        return j == str2.Length;
    }
