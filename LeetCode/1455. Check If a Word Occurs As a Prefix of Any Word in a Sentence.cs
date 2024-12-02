// From Scratch
    public int IsPrefixOfWord(string sentence, string searchWord) {
       
      int wordIndex = 1;
       for(int i=0; i<sentence.Length; i++)
       {
            if(sentence[i] == ' ') wordIndex++;
            if(i == 0 || ((sentence[i-1] == ' ')))
            {
                int j = 0;
                while(sentence[i] == searchWord[j])
                {
                    i++;
                    j++;        
                    if(j == searchWord.Length) return wordIndex;
                    if(i == sentence.Length) return -1;
                    if(sentence[i] == ' ') wordIndex++;
                }
            }
       }
       return -1;
    }

// Built in function
    public int IsPrefixOfWord(string sentence, string searchWord) 
    {      
       int searchWordIndex = 0;
       string[] words = sentence.Split(" ");
       for(int i=0; i<words.Length; i++)
       {
            if(words[i].StartsWith(searchWord)) return i+1;
       }
       return -1;
    }
