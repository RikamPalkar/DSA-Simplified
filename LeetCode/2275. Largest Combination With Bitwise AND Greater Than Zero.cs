    public int LargestCombination(int[] candidates) {
        int maxCombinationSize = 0;
        for (int i=0; i<32; i++) 
        {
            int bitCount = 0;
            foreach (int candidate in candidates) {
                if ((candidate & (1 << i)) != 0) 
                    bitCount++;
            }
            maxCombinationSize = Math.Max(maxCombinationSize, bitCount);
        }
        return maxCombinationSize;
    }
