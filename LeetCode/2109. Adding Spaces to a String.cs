public class Solution 
{
    public string AddSpaces(string s, int[] spaces) 
    {
        StringBuilder sb = new();
        int l = 0;

        for(int i=0; i<spaces.Length; i++)
        {
            while(l < spaces[i])
            {
                sb.Append(s[l]);
                l++;
            }
            sb.Append(" ");
        }
        while(l < s.Length) sb.Append(s[l++]);
        return sb.ToString();
    }
}
