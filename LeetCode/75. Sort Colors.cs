
    public void SortColors(int[] nums) {

        int l = 0; //sort zeros from left
        int r = nums.Length-1; //sort 2's from right
        int mid = 0; //iterate through nums

        while(mid <= r) //Time:O(n)
        {
            if(nums[mid] == 0){
                (nums[mid], nums[l]) = (nums[l], nums[mid]);
                l++;
                mid++;
            }
            else if(nums[mid] == 1){
                mid++;
            }
            else{ // mid is 2
                (nums[mid], nums[r]) = (nums[r], nums[mid]);
                r--; 
                /* After the swap, we do not know what value came 
                   from nums[r] into nums[mid]. 
                   It could be: 0 (needs to swap again), 
                   1 or 2 hence do not mid++
                */
            }
        }
    }
