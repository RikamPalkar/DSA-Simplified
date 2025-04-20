public class Solution 
{
    public int NumRabbits(int[] answers) 
    {
        Dictionary<int, int> map = [];

        for(int i=0; i<answers.Length; i++)
            map[answers[i]] = map.GetValueOrDefault(answers[i])+1;
        
        int res = 0;
        foreach(var pair in map)
        {
            int animal = pair.Key;                  
            int count = pair.Value;          
            int groupSize = animal + 1;       

            int toalGroups = count / groupSize;
            int remainingRabbits = count % groupSize;

            if (remainingRabbits != 0) toalGroups++;
            
            res += groupSize * toalGroups;
        }
        return res;
    }
}
