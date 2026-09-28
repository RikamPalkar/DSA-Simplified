/*
# Solution 1: Stack + In-place Reversal

## Intuition
Store the index of every `(` on a stack. On each `)`, pop the matching `(` and reverse the characters between them. Inner groups are reversed first, so outer reversals flip them back into the right order. At the end, drop all brackets.

## Time & Space
- Time: O(n²). Nested brackets can reverse the same characters many times.
- Space: O(n) for the stack and the StringBuilder.
*/
public class Solution {
    public string ReverseParentheses(string s) {

        Stack<int> openingBraces = [];
        StringBuilder revSb = new(s);
        StringBuilder res = new("");

        for (int i = 0; i < s.Length; i++) {

            if (s[i] == '(') {
                openingBraces.Push(i);
            }
            else if (s[i] == ')') {
                ReverseString(openingBraces.Pop() + 1, i - 1, revSb);
            }
        }

        for (int i = 0; i < revSb.Length; i++) {
            if (revSb[i] != '(' && revSb[i] != ')')
                res.Append(revSb[i]);
        }
        return res.ToString();
    }

    private void ReverseString(int l, int r, StringBuilder s) {

        while (l < r) {
            char temp = s[l];
            s[l] = s[r];
            s[r] = temp;
            r--;
            l++;
        }
    }
}


/*

# Solution 2: Pair Matching + Direction Flip

## Intuition
Never reverse anything. First, record each bracket's matching partner in a `pair[]` array. Then walk the string once. When you hit a bracket, jump to its partner and flip the walking direction. The characters stay where they are; only the reading direction changes.

## Time & Space
- Time: O(n). Each index is visited a constant number of times.
- Space: O(n) for `pair[]`, the stack, and the result.
*/
public class Solution {
    public string ReverseParentheses(string s) {
        int n = s.Length;
        int[] pair = new int[n];
        Stack<int> stack = new();

        for (int i = 0; i < n; i++) {
            if (s[i] == '(') stack.Push(i);
            else if (s[i] == ')') {
                int j = stack.Pop();
                pair[i] = j;
                pair[j] = i;
            }
        }

        StringBuilder res = new();
        int cur = 0;
        int dir = 1;

        while (cur >= 0 && cur < n) {
            if (s[cur] == '(' || s[cur] == ')') {
                cur = pair[cur];   // jump to matching bracket
                dir = -dir;        // flip direction
            } else {
                res.Append(s[cur]);
            }
            cur += dir;            // always move one step
        }

        return res.ToString();
    }
}
