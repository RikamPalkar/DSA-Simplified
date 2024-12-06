public class Solution {
    public int MaxCount(int[] banned, int n, int maxSum) 
    {
        HashSet<int> set = new(banned);   
        int count = 0;
        int sum = 0;     
        for(int i=1; i<=n; i++)
        {
            if(!set.Contains(i)) 
            {
                sum += i;
                if(sum <= maxSum) count++;
                else break;
            }
        }
        return count;
    }
}
