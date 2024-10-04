public class Solution {
    public long DividePlayers(int[] skill) 
    {
        Array.Sort(skill);
        int len = skill.Length;
        int sum = skill[0] + skill[len-1];
        long result = 0;

        for(int i=0; i<len/2; i++)
        {
            int currSum = skill[i] + skill[len-i-1];
            if(sum != currSum) return -1;

            int currMul = skill[i] * skill[len-i-1];
            result += currMul;
        }
        return result;
    }
}
