    public int CountConsistentStrings(string allowed, string[] words) 
    {
        int result = 0;
        HashSet<char> allowedSet = new(allowed);
        
        foreach (string word in words) 
        {
            bool isDistinct  = true;
            foreach (char ch in word) 
            {
                if (!allowedSet.Contains(ch)) 
                {
                    isDistinct = false;
                    break;
                }
            }
            if (isDistinct) result++;
        }
        
        return result;
    }
