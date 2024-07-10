

//Approch 1

    public int MinOperations(string[] logs) {
      int count = 0;
      foreach(string log in logs) {
        if(log == "../" && count > 0) count--;
        else if(log[^2] != '.') count++;
      } 
      return count;
    }

//Approch 2
    public int MinOperations(string[] logs) {
      int count = 0;
      foreach(string log in logs) 
      {
        if(log == "../") {  if( count > 0 )  count--;
        }
        else if(log != "./") count++;
      } 
      return count;
    }
