public class Solution {
    public bool AreSentencesSimilar(string sentence1, string sentence2) 
    {
        string[] s1 = sentence1.Split(" ");
        string[] s2 = sentence2.Split(" ");
        int len1 = s1.Length;
        int len2 = s2.Length;
        int l = 0, r = 0;

        while(l < len1 && l < len2 && s1[l] == s2[l])
            l++;

        while(r < len1 - l && r < len2 - l &&
             s1[len1 - r-1] == s2[len2 - r-1])
            r++; 
        
        return l+r == Math.Min(len1, len2);
    }
}
