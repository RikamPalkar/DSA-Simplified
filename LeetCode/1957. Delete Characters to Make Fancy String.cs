public class Solution {
    public string MakeFancyString(string s) 
    {
        if(s.Length < 3) return s;

        StringBuilder sb = new();
        sb.Append(s[0]);
        sb.Append(s[1]);
        for(int i=2; i<s.Length; i++)
        {
            if(s[i-1] == s[i] && s[i-2] == s[i]) continue;
            sb.Append(s[i]);
        }
        return sb.ToString();
    }
}