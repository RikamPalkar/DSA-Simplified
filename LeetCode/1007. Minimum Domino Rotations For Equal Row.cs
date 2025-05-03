//Time:O(n), Space:O(1)
public class Solution 
{
    public int MinDominoRotations(int[] tops, int[] bottoms) 
    {
        int result = Helper(tops[0], tops, bottoms);

        if (result != -1) return result;     
        return Helper(bottoms[0], tops, bottoms);
    }


    private int Helper(int target, int[] tops, int[] bottoms)
    {
        int rotateTop = 0;
        int rotateBottom = 0;
        
        for (int i = 0; i < tops.Length; i++)
        {
            if (tops[i] != target && bottoms[i] != target)
                return -1;

            else if (tops[i] != target)
                rotateTop++;

            else if (bottoms[i] != target)
                rotateBottom++;
        }
        
        return Math.Min(rotateTop, rotateBottom);
    }
}
