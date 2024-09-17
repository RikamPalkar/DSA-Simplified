/* Solution 1
# Approach
- Loop through split string s1 and s2
- Add unique words to hashmap, and keep the count of each word
- Filter hashmap based on word `count == 1` and return the array.
# Complexity
- Time complexity: O(2n)
- Space complexity: O(len(s1 + s2)
*/

    public string[] UncommonFromSentences(string s1, string s2) 
    {
        Dictionary<string, int> uniqueWords = [];
        foreach(string word in s1.Split(" "))
        {
            uniqueWords[word] = uniqueWords.GetValueOrDefault(word) +1;
        }
        foreach(string word in s2.Split(" "))
        {
            uniqueWords[word] = uniqueWords.GetValueOrDefault(word) +1;
        }
        return uniqueWords.Where(x => x.Value == 1).Select(y => y.Key).ToArray();
    }

/* Solution 2
# Simply loop through s1 and s2 in one go
# Time: O(n)
*/

    public string[] UncommonFromSentences(string s1, string s2) 
    {
        Dictionary<string, int> uniqueWords = [];
        foreach(string word in (s1 + " " + s2).Split(" "))
        {
            uniqueWords[word] = uniqueWords.GetValueOrDefault(word) +1;
        }
        return uniqueWords.Where(x => x.Value == 1).Select(y => y.Key).ToArray();
    }
