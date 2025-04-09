    //Solution 1
    public int MinOperations(int[] nums, int k) 
    {
       int min = nums.Min();//Time: O(n)
       if(min < k) return -1;
       
       HashSet<int> unique = new(nums);//Time & Space : O(n)

       int res = unique.Count;
       return unique.Contains(k) ? res-1 : res;
    }

    //Solution 2
    public int MinOperations(int[] nums, int k) 
    {
       HashSet<int> unique = []; //Space : O(n)

        for(int i=0; i<nums.Length; i++) //Time : O(n)
        {
            if(nums[i] < k) return -1;
            else if(nums[i] > k) unique.Add(nums[i]);
        }

       return unique.Count;
    }
