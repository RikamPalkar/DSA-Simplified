//Solution 1
    public int GetLucky(string s, int k) 
    {
        int result = 0;
        foreach(char ch in s)
        {
            int currentNum = (int)ch - 'a' +1;
            result += currentNum%10 + currentNum/10;
        }

        while (k > 1)
        {
            int newResult = 0;
            while (result > 0)
            {
                newResult += result % 10;
                result /= 10;
            }
            result = newResult;
            k--;
        }
        return result;
    }

//Solution 2
public class Solution 
{
    public int GetLucky(string s, int k) 
    {
        string num = "";
        foreach(char ch in s)
        {
            int currentNum = (int)ch - 'a' +1;
            num += currentNum;
        }

        while(k > 0)
        {
            int result = 0;
            foreach(char ch in num)
            {
                int currentNum = (int)ch - '0';
                result+=currentNum;
            }
            k--;
            if(k == 0) return result;
            else num = result.ToString();
        }
        return -1;
    }
}
