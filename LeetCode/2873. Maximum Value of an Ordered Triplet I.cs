    public long MaximumTripletValue(int[] nums) //Solution 1
    {
        int len = nums.Length;
        long res = 0;

        for(int i=0; i<len-2; i++) //Time: O(n^3)
        {
            for(int j=i+1; j<len-1; j++)
            {
                long sub = nums[i] - nums[j];

                for(int k=j+1; k<len; k++)
                {
                    if(sub > 0){
                        long mul = sub*nums[k];
                        res = Math.Max(res, mul);
                    }
                }
            }           
        }
        return res;
    }

    public long MaximumTripletValue(int[] nums) { //Solution 2
       int len = nums.Length;
       int[] leftMax = new int[len]; //Space: O(n)
       int[] rightMax = new int[len]; //Space: O(n)
       long res = 0;

       for(int i=1; i<len; i++){  //Time: O(n)    
            leftMax[i] = Math.Max(leftMax[i-1], nums[i-1]);
            rightMax[len - i - 1] = Math.Max(rightMax[len-i], nums[len-i]);
       }

       for(int i=1; i<len-1; i++)  //Time: O(n)
            res = Math.Max(res, (long)(leftMax[i]-nums[i])*rightMax[i]);
        
        return res;
    }
