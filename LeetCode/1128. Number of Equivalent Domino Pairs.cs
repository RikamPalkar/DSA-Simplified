//Time: O(n), Space: O(n)

    public int NumEquivDominoPairs(int[][] dominoes)
    {
        Dictionary<int, int> map = [];
        int count = 0;

        for(int i=0; i<dominoes.Length; i++)
        {
            int a = dominoes[i][0];
            int b = dominoes[i][1];
            int key = 0;

            if(a < b)
            {
                key += a * 10 + b;
            }
            else
            {
                key += b * 10 + a;
            }

            if(map.ContainsKey(key))
            {
                count += map[key];
                map[key]++;
            }
            else
            {
                map[key] = 1;
            }
        }
        return count;
    }



