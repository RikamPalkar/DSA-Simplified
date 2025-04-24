//Solution 1

    public int CountCompleteSubarrays(int[] nums) {

        int res = 0;
        int len = nums.Length;
        int r = 0;
        int unique = new HashSet<int>(nums).Count;
        Dictionary<int, int> map = [];
        
        for(int l=0; l<len; l++)
        {
            if(l > 0){
                map[nums[l-1]]--;
                if(map[nums[l-1]] == 0) map.Remove(nums[l-1]);
            }

            while(r < len && map.Count < unique)
            {
                map[nums[r]] = map.GetValueOrDefault(nums[r])+1;               
                r++;
            }

            if(map.Count == unique)
                res += (len - (r-1));       
        }
        return res;
    }


//Solution 2: Bruteforce
    public int CountCompleteSubarrays(int[] nums) {
        int res = 0;
        int len = nums.Length;
        HashSet<int> unique = new(nums);

        for(int i=0; i<len; i++)
        {
            HashSet<int> currUnique = [];
            for(int j=i; j<len; j++)
            {
                currUnique.Add(nums[j]);
                if(currUnique.Count == unique.Count){ 
                    res += (len - j);
                    break;
                 }
            }
        }
        return res;
    }
