    public int MinLength(string s) 
    {
        Stack<char> stack = [];
        foreach(char ch in s)
        {
            if(stack.Count >= 1 &&
               (ch == 'B' && stack.Peek() == 'A' || 
               ch == 'D' && stack.Peek() == 'C'))
            {
                stack.Pop();
            }
            else stack.Push(ch);
        }
        return stack.Count;
    }
