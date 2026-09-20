public class Solution {

    // Time: O(n) || Space: O(1)
    public int ReverseDegree(string s) {

        int sum = 0;

        for(int i=0; i<s.Length; i++){
            int revNum = 'z' - s[i] + 1;
            sum += revNum*(i+1);
        }

        return sum;
    }
}
/*
    'a' = 97
    'z' = 122
    122-97 = 25 +1 = 26
*/