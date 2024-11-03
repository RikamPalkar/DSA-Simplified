    //Optimized: Solution 1
    public bool RotateString(string s, string goal) 
    {

      if(s.Length != goal.Length) return false;
      return (s + s).Contains(goal);

    }

    //Brute force: Solution 1
    public bool RotateString(string s, string goal) 
    {

      if(s.Length != goal.Length) return false;
      
      for(int i = 0; i < s.Length; i++)
      {
            if(s[i..] + s[..i] == goal) return true;
      }
      return false;

    }
