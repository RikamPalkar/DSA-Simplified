//Time: O(n) | Space: O(n)
    public string CompressedString(string word) 
    {
        StringBuilder sb = new();

        for(int i=0; i<word.Length; i++)
        {
            int count = 1;
            while(i < word.Length-1 && word[i] == word[i+1])
            {         
                if(count == 9) break;
                count++;
                i++;
            }

            sb.Append(count);
            sb.Append(word[i]);
        }
        return sb.ToString();

    }
