/*
Time | O(n * L)
Space | O(n + L)
L = length of final string countAndSay(n)
*/
public class Solution {
    public string CountAndSay(int n) {
        return Helper(n, "1");
    }

    private string Helper(int n, string str){
        if(n <= 1) return str;
        StringBuilder sb = new();
        
        for(int i=0; i<str.Length; i++){
            int count = 1;
            char digit = str[i];

            while(i+1 < str.Length && str[i] == str[i+1]){
                count++;
                i++;
            }

            sb.Append(count).Append(digit);
        }
        return Helper(n-1, sb.ToString());
    }
}
