
public int MaxWidthRamp(int[] nums) 
{
    Stack<int> monoStack = [];
    int maxRamp = 0;
    for(int i=0; i<nums.Length; i++)
    {
        if(monoStack.Count == 0 || 
           nums[monoStack.Peek()] > nums[i])
        {
                monoStack.Push(i);
        }
    }

    for(int i=nums.Length-1; i>=0; i--)
    {
        while(monoStack.Count > 0 && 
              nums[monoStack.Peek()] <= nums[i])
        {
            maxRamp = Math.Max(maxRamp, i - monoStack.Pop());
        }
    }

        return maxRamp;
    }
}
