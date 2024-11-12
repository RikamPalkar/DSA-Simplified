   public int[] MaximumBeauty(int[][] items, int[] queries)
    {
        int max = 0;
        Array.Sort(items, (a, b) => a[0] - b[0]);

        for(int i=0; i<items.Length; i++)
        {
            max = Math.Max(max, items[i][1]);
            items[i][1] = max;
        }

        int[] res =  new int[queries.Length];

        for(int i=0; i<queries.Length; i++)
        {
           res[i] = BinarySearch(items, queries[i]);
        }
        return res;
    }

    private int BinarySearch(int[][] items, int target)
    {
        int l = 0;
        int r = items.Length -1;
        int max = 0;
        while(l <= r)
        {
            int mid = (l + r) /2;

            if(target < items[mid][0])
                r = mid - 1;
            else
            {
                max = Math.Max(max, items[mid][1]);
                l = mid + 1;
            }
        }
        return max;
    }
}
