   // Time: O(log 10 ​x) for n:  O(n log n), 
  // Space: O(log n)
   public int CountLargestGroup(int n) 
    {       
        Dictionary<int, int> map = [];
        int max = 0;

        for(int i=1; i<=n; i++)
        {
            int num = i;
            int rem = 0;

            while(num > 0)
            {
                rem += num%10;
                num /= 10;
            }

            map[rem] = map.GetValueOrDefault(rem)+1;
            max = Math.Max(max, map[rem]);
        }

        return map.Values.Count(_ => _ == max);
    }
