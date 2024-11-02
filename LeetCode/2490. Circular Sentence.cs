    public bool IsCircularSentence(string sentence) 
    {
        string[] words = sentence.Split(" ");
        char preFirst = words[0][0];
        char preLast = words[0][words[0].Length-1];

        for(int i = 1; i < words.Length; i++)
        {
            if(words[i][0] != preLast) 
                return false;
            preLast = words[i][words[i].Length-1];
        }
        return preFirst == preLast;
    }
