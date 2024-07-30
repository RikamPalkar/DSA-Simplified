//Time: O(n), Space: O(n)
  public int MinimumDeletions(string s) 
    {
        Stack<char> stack = new();
        int count = 0;
        
        foreach (char c in s) 
        {
            if (c == 'b') stack.Push(c);
            else if (stack.Count > 0)
            {
                stack.Pop();
                count++;
            }
        }
        
        return count;
    }

/*
Algorithm

    Use a Stack: We use a stack to keep track of 'b' characters in the string. A stack is a data structure that allows adding and removing elements in a LIFO order.

    Traverse the String: Go through each character in the string one by one.
        If the character is 'b', push it onto the stack. This means we have an extra 'b' that might need to be balanced by an 'a' later.
        If the character is 'a' and there's at least one 'b' on the stack, pop the stack (remove one 'b') and increase the count. This simulates deleting the 'b' to balance the 'a'.

    Count: The count keeps track of how many 'b' characters we need to remove to make sure there are no 'b' characters to the left of an 'a'.

Step-by-Step Example

Let's take the string "aababbab" as an example:

    Start with an empty stack and deletion count = 0.

    Traverse each character:
        'a': The stack is empty, so do nothing.
        'a': The stack is still empty, so do nothing.
        'b': Push 'b' onto the stack. Stack: ['b']
        'a': Pop 'b' from the stack and increase deletion count. Stack: [], count: 1
        'b': Push 'b' onto the stack. Stack: ['b']
        'b': Push another 'b' onto the stack. Stack: ['b', 'b']
        'a': Pop 'b' from the stack and increase deletion count. Stack: ['b'], count: 2
        'b': Push 'b' onto the stack. Stack: ['b', 'b']

    The total count is 2, which means we need to delete 2 'b' characters to make the string balanced.
/*
