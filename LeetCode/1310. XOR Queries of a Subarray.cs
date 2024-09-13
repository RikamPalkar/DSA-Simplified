    public int[] XorQueries(int[] arr, int[][] queries) 
    {
        int[] prefixXOR = new int [arr.Length];
        int[] result = new int [queries.Length];

        prefixXOR[0] = arr[0];
        for(int i=1; i<arr.Length; i++)
        {
            prefixXOR[i] = prefixXOR[i-1] ^ arr[i];
        }

        for(int i=0; i<queries.Length; i++)
        {
            int start = queries[i][0];
            int end = queries[i][1];

            if(start == 0)
            {
                result[i] = prefixXOR[end];
            }
            else
            {
                result[i] = prefixXOR[end] ^ prefixXOR[start - 1];
            }
        }
        return result;
    }
