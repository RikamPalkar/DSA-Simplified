//Time: O(3n), Space: O(3n)
public class Solution {
    public string ReverseParentheses(string s) 
    {
        Stack<int> braces = new();  // Space: O(n)
        char[] sArray = s.ToCharArray(); // Space: O(n)
        
        for (int i = 0; i < sArray.Length; i++)// Time:O(n)
        {
            if (sArray[i] == '(') 
                braces.Push(i);
            else if (sArray[i] == ')') 
                ReverseString(sArray, braces.Pop() + 1, i - 1);
        }
        
        StringBuilder sb = new(); // Space: O(n)
        foreach (char c in sArray) // Time:O(n)
        {
            if (c != '(' && c != ')')
                sb.Append(c);
        }
        return sb.ToString();
    }

    // Time:O(n)
    private void ReverseString(char[] input, int start, int end)
    {
        while (start < end)
        {
            char temp = input[start];
            input[start] = input[end];
            input[end] = temp;
            start++;
            end--;
        }
    }
}

/**
 why the total time complexity remains linear, consider the cumulative effect of all reversals:

    First Reversal: When we reverse "test" within the innermost parentheses, we reverse 4 characters.
    Second Reversal: When we reverse the next level containing "tset", we reverse 4 characters again.
    Third Reversal: When we reverse the entire portion including the already reversed part "tset", we reverse 4 characters again.

Thus, although we reverse multiple times, the total number of operations per character is constant. Each character is involved in at most one reversal per nesting level.
Correct Interpretation

Given the nesting, the sum of the lengths of all reversed substrings over the entire string is still O(n).
Final Complexity Analysis

    Total Time Complexity: O(n)
    Space Complexity: O(n)



  Algorithm

    Use a stack to keep track of the indices of the opening parentheses.

    Iterate through the String:
    - When encountering an opening parenthesis '(', push its index onto the stack.
    - When encountering a closing parenthesis ')', pop the index of the corresponding opening parenthesis from the stack, and reverse the substring between these indices.

    Reverse Substring: A helper method ReverseString reverses the characters in the array between the specified start and end indices.

    Iterate through the modified character array by skipping parentheses and return the result.

Example Walkthrough: (ed(et(oc))el)

    First Pass through the String:
    - Index 0: '(' is encountered, push 0 onto the stack.
    Stack: [0]
    - Index 1-2: Characters 'e' and 'd' are ignored.
    - Index 3: '(' is encountered, push 3 onto the stack.
    Stack: [0, 3]
    - Index 4-5: Characters 'e' and 't' are ignored.
    - Index 6: '(' is encountered, push 6 onto the stack.
    Stack: [0, 3, 6]
    - Index 7-8: Characters 'o' and 'c' are ignored.
    - Index 9: ')' is encountered, pop 6 from the stack and reverse the substring from index 7 to 8.
    ReverseString(sArray, 7, 8): ['(', 'e', 'd', '(', 'e', 't', '(', 'c', 'o', ')', ')', 'e', 'l', ')']
    Stack: [0, 3]
    - Index 10: ')' is encountered, pop 3 from the stack and reverse the substring from index 4 to 9.
    ReverseString(sArray, 4, 9): ['(', 'e', 'd', '(', ')', 'o', 'c', 't', 'e', '(', ')', 'e', 'l', ')']
    Stack: [0]
    - Index 11-12: Characters 'e' and 'l' are ignored.
    - Index 13: ')' is encountered, pop 0 from the stack and reverse the substring from index 1 to 12.
    ReverseString(sArray, 1, 12): ['(', 'l', 'e', 'e', 't', 'c', 'o', 'd', '(', ')', '(', 'e', ')', ')']
    Stack: []

    Iterate through sArray and append characters to StringBuilder while skipping parentheses.
    sArray: ['(', 'l', 'e', 'e', 't', 'c', 'o', 'd', '(', ')', '(', 'e', ')', ')']
    Result: "leetcode"

**/
