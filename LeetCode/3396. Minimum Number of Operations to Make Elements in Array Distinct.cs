    public int MinimumOperations(int[] nums) 
    {
        HashSet<int> unique = [];
        for(int i=nums.Length-1; i>=0; i--)
            if(!unique.Add(nums[i]))
                return (i/3)+1;

        return 0;
    }
