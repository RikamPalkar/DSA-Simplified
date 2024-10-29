/*
    Time complexity: O(n*log^2)
    Space complexity:O(n)
*/
    public int LongestSquareStreak(int[] nums) 
    {
        HashSet<int> set = new(nums);
        int maxStreak = 0;

        foreach(int num in nums)
        {
            int currStreak = 0;
            int square =  num;
            while(set.Contains(square))
            {
                currStreak++;
                square = (int)Math.Pow(square, 2);     
            }
            maxStreak = Math.Max(maxStreak, 
                      currStreak);
        }
        return maxStreak == 1 ? -1 : maxStreak;
    }
