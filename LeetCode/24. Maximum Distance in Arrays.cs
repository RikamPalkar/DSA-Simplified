public class Solution {
    public int MaxDistance(IList<IList<int>> arrays) {
        int min = arrays[0][0];//1
        int max = arrays[0][arrays[0].Count - 1];//3
        int maxDistance = 0;

        for (int i = 1; i < arrays.Count; i++) 
        {
            int currMin = arrays[i][0];//4
            int currMax = arrays[i][arrays[i].Count - 1];//5

            int distance1 = Math.Abs(currMax - min);// 5-1= 4
            int distance2 = Math.Abs(max - currMin);//3-4 |-1| = 1

            maxDistance = Math.Max(maxDistance, Math.Max(distance1, distance2));//4

            min = Math.Min(min, currMin);//1
            max = Math.Max(max, currMax);//5
        }

        return maxDistance;
    }
}
