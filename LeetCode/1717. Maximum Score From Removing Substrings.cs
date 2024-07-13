
    public int MaximumGain(string s, int x, int y) 
    {
        if(y > x)
        {
            s = new(s.Reverse().ToArray());
        }

        //find ab, if s is reversed then this will find ba
        Stack<char> stack = [];
        int result = 0;
        foreach(char ch in s)
        {
            if(ch == 'b' && stack.Count > 0 && stack.Peek() == 'a' ){
                stack.Pop();
                result += Math.Max(x, y);
            }
            else stack.Push(ch);
        }

         char[] remaining = stack.ToArray();
         Array.Reverse(remaining); // Reverse to maintain the original order

         // Reset the stack for the second pass else it will add more elements in previous chars
        stack.Clear();

        //find ba, if s is reversed then this will find ab      
        foreach(char ch in remaining){
            if(ch == 'a' && stack.Count > 0 && stack.Peek() == 'b' ){
                stack.Pop();
                result += Math.Min(x, y);
            }
            else stack.Push(ch);
        }
        return result;
    }

/**
Algorithm

    Check Priority and Reverse if Necessary:

    If y > x, reverse the string. If "ba" has high priority we first remove all "ba" hence reversing the string.

    First Pass to Remove "ab":
        Use a stack to scan through the string.
        If the current character is 'b' and the top of the stack is 'a', we have found "ab".
        Pop 'a' from the stack, add the points Math.Max(x, y) to the result.
        Else, Push the current character onto the stack.
        This pass effectively removes all "ab" substrings (or "ba" if the string was reversed).

    Reverse stack to maintain the original order and create new string, to use stack again clear its values.

    Second Pass to Remove "ba":
        Loop through new string.
        If the current character is 'a' and the top of the stack is 'b', we have found "ba".
        Pop 'b' from the stack, add the points Math.Min(x, y) to the result.
        Else, push the current character onto the stack.
        This pass removes all "ba" substrings (or "ab" if the string was reversed).

    Return the Total Points:

Complexity

    Time complexity: O(n)

    Space complexity: O(n)

**/
