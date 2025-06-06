public class Solution {
    public string RobotWithString(string s) {
        int[] freq = new int[26];
        foreach (char ch in s) 
            freq[ch - 'a']++;

        Stack<char> stack = [];
        StringBuilder sb = new();
        char smallestChar = 'a';

        for (int i = 0; i < s.Length; i++) {
            stack.Push(s[i]);

            freq[s[i] - 'a']--;

            while (freq[smallestChar - 'a'] == 0) {
                smallestChar++;
                // ASCII: if smallestChar > 'z' (122), 
                // we’ve checked all letters
                if (smallestChar > 'z') break;
            }

            while (stack.Count > 0 && 
                   stack.Peek() <= smallestChar) {
                sb.Append(stack.Pop());
            }
        }
        return sb.ToString();
    }
}
