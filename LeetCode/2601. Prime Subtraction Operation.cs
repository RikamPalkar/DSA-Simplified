public class Solution {
    public bool PrimeSubOperation(int[] nums)
    {
        int maxElement = nums.Max();
        bool[] sieve = new bool[maxElement + 1];
        Fill(sieve, true);
        sieve[1] = false;
        for (int i = 2; i <= Math.Sqrt(maxElement + 1); i++)
        {
            if (sieve[i])
            {
                for (int j = i * i; j <= maxElement; j += i)
                    sieve[j] = false;
            }
        }

        int currValue = 1;
        int index = 0;
        
        while (index < nums.Length)
        {
            int difference = nums[index] - currValue;

            if (difference < 0) return false;

            if (sieve[difference] || difference == 0)
            {
                index++;
                currValue++;
            }
            else
            {
                currValue++;
            }
        }

        return true;
    }

    private void Fill(bool[] arr, bool value)
    {
        for (int i = 0; i < arr.Length; i++)
            arr[i] = value;
    }
}
