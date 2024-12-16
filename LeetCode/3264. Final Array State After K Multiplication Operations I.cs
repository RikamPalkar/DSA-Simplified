    public int[] GetFinalState(int[] nums, int k, int multiplier) {
        PriorityQueue<int, (int, int)> pq = new  PriorityQueue<int, (int Index, int Value)>();
        for(int i=0; i<nums.Length; i++)
        {
            pq.Enqueue(i, (nums[i], i));
        }

        while(k > 0)
        {
            int index = pq.Dequeue();
            nums[index] *= multiplier;
            pq.Enqueue(index, (nums[index], index));
            k--;
        }
        return nums;
    }
