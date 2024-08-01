//Solution 1
    public int CountSeniors(string[] details) {
        int count = 0;
        foreach(string detail in details)
        {
            int age = Convert.ToInt32(detail[11..13]);
            if(age > 60) count++;

        }
        return count;
    }

//One liner
    public int CountSeniors(string[] details) {
        return details.Count(x => int.Parse(x[11..13]) > 60);
    }
