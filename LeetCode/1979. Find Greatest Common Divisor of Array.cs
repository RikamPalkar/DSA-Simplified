//Euclid's algorithm
    public int FindGCD(int[] nums) 
    {
        int min = nums.Min();
        int max = nums.Max();

        while(min > 0)
        {
           
            int temp = min;
            int rem = max%min;
            if(rem == 0) return min;
            min = rem;
            max = temp;
        }
        return 1;
    }

//Brute force

    public int FindGCD(int[] nums) {
        int min = Int32.MaxValue, max = Int32.MinValue;

        for(int i=0; i<nums.Length; i++)
        {
            min = Math.Min(nums[i], min);
            max = Math.Max(nums[i], max);
        }
        int result = 1;
        for(int i=1; i<=max; i++)
        {
            if(min % i == 0 && max % i == 0)
            {
                result = Math.Max(i, result);
            }
        }
        return result;
    }
