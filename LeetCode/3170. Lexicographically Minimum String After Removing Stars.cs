//Time: O(n), Space: O(n)
public class Solution {
    public string ClearStars(string s) {
        // Create an array of 26 stacks (one for each letter a-z)
        Stack<int>[] freq = new Stack<int>[26];

        // Initialize each stack
        for (int i = 0; i < 26; i++)
            freq[i] = [];  // (Note: [] is C# 12+ shorthand for new Stack<int>())

        // Convert input string to a char array for easy modification
        char[] sArr = s.ToCharArray();

        // First pass: iterate through each character in the array
        for (int i = 0; i < sArr.Length; i++) {
            if (sArr[i] == '*') {
                // If we see a '*', we need to remove the smallest character to its left
                for (int j = 0; j < 26; j++) {
                    if (freq[j].Count > 0) {
                        // Pop the most recent index of the smallest available character
                        int charToBeRemoved = freq[j].Pop();

                        // Mark it as removed by replacing with '0' (a placeholder)
                        sArr[charToBeRemoved] = '0';
                        break; // Only remove one smallest char per '*'
                    }
                }
            } else {
                // For normal letters, store their index in the corresponding stack
                int pos = sArr[i] - 'a';  // Map character to 0..25
                freq[pos].Push(i);        // Push index into stack for that letter
            }
        }

        // Second pass: build the final result without any removed ('*' or '0') characters
        StringBuilder sb = new();
        for (int i = 0; i < sArr.Length; i++) {
            // Skip '*' and marked '0' characters
            if (sArr[i] == '*' || sArr[i] == '0')
                continue;

            // Append valid characters to the final string
            sb.Append(sArr[i]);
        }

        // Return the cleaned-up final string
        return sb.ToString();
    }
}
