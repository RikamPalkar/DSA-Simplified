    public int MinimizeMax(int[] nums, int p) {
        Array.Sort(nums);
        int len = nums.Length;
        int l = 0;
        int r = nums[len-1] - nums[0];

        while(l <= r){
            int mid = l+(r-l)/2;
            if(IsPossibleOnLeft(nums, p, mid))
                r = mid-1;
            else
                l = mid+1;
        }
        return l;
    }

    private bool IsPossibleOnLeft(int[] nums, int p, int mid){
        int count = 0;
        for(int i=0; i<nums.Length-1;){
            int diff = nums[i+1] - nums[i];
            
            if(diff <= mid){
                count++;
                i += 2;
            }
            else i++;
        }
        return count >= p;
    }

    // nums = [1, 1, 2, 3, 7, 10]

    // 1 - 10: l = 0, r = 9, mid = 4
    // Can we find 2 pairs with diff ≤ 4? YES → r = 4

    // 1 - 10: l = 0, r = 4, mid = 2
    // Can we find 2 pairs with diff ≤ 2? YES → r = 2

    // 1 - 10: l = 0, r = 2, mid = 1
    // Can we find 2 pairs with diff ≤ 1? YES → r = 1

    // 1 - 10: l = 0, r = 1, mid = 0
    // Can we find 2 pairs with diff ≤ 0? NO → l = 1

    // 1 - 10: l = 1, r = 1 → done
    // Answer = 1

