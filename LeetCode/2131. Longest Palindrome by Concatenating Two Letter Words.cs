
    public int LongestPalindrome(string[] words) 
    {
        //Space: O(n)
        Dictionary<string, int> map = [];
        int res = 0;
        
        //Time: O(n)
        foreach(string word in words){

            string rev = $"{word[1]}{word[0]}";

            if(map.ContainsKey(rev)){
                res += 4;
                map[rev]--;
                if(map[rev] == 0) map.Remove(rev);
            }
            else{
                map[word] = map.GetValueOrDefault(word)+1;
            }
        }

        foreach(var kvp in map)
            if(kvp.Key[0] == kvp.Key[1]){
                res += 2;
                break; 
            }

        return res;
    }
