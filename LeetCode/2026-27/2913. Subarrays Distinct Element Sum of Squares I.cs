    // Time: O(n^2) || Space: O(n)
    int SumCounts(IList<int> nums) {
        
        int len = nums.Count;
        int res = 0;
        HashSet<int> set = [];

        for(int i=0; i<len; i++){

            for(int j=i; j<len; j++){

                set.Add(nums[j]);
                res += set.Count * set.Count;
            }

            set.Clear();
        }
        return res;
    }
