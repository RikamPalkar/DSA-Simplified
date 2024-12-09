   //Time: O(m+n), Space: O(n)
    public bool[] IsArraySpecial(int[] nums, int[][] queries) 
    {
        int[] prefixParity = new int[nums.Length];
        bool[] res = new bool[queries.Length];
        
        for(int i=1; i<nums.Length; i++)
        {
            prefixParity[i] = prefixParity[i-1];
            if((nums[i-1] + nums[i]) % 2 != 0)
            {
                prefixParity[i]++;
            }
        }

        for(int i=0; i<queries.Length; i++)
        {
            int from = queries[i][0];
            int to = queries[i][1];
            int numOfParity = prefixParity[to] 
                            - prefixParity[from];
            res[i] = numOfParity == (to - from);
        }
        return res;
    }

