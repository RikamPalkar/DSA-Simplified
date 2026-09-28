public class Solution 
{
    public int MaxDepth(string s) {

        int depth = 0;
        int count = 0;

        for(int i=0; i<s.Length; i++){

            if(s[i] == '(') count++;
            else if (s[i] == ')') count--;

            depth = Math.Max(depth, count);
        }

        return depth;
    }
}