    public bool CheckIfExist(int[] arr) 
    {
        HashSet<int> set = [];
        for(int i=0; i<arr.Length; i++)
        {
            if(set.Contains(arr[i]*2) ||
            (arr[i]%2 == 0 && 
            set.Contains(arr[i]/2)))
            {
                return true;
            }
            set.Add(arr[i]);     
        }
        return false;
    }
