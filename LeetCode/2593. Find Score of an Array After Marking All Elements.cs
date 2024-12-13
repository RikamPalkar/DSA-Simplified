public class Solution {
    public long FindScore(int[] nums) {
        int len = nums.Length;
        long res = 0;
        var pq = new PriorityQueue<int, (int Value, int Index)>();

        for (int i = 0; i < len; i++)
        {
            pq.Enqueue(i, (nums[i], i));
        }

        while (pq.Count > 0)
        {
            int index = pq.Dequeue();
            if (nums[index] == -1) continue;

            res += nums[index];
            if (index > 0) nums[index - 1] =  -1;
            if (index < len - 1) nums[index + 1] = -1;
        }
        return res;
    }
}
