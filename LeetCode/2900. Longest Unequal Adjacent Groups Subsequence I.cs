/*
Time: O(n), Space: O(n)
- A variable to keep track of the previous bit:

- For each index i:
If current bit != previous bit:
Add words[i] to the result list.

Update previous bit = current bit.
*/


    IList<string> GetSubsequence(string[] words, int[] groups) 
    {
        List<string> subsequence = [];
        int previousBit = -1;

        for(int i=0; i<groups.Length; i++)
        {
            int currBit = groups[i];
            if(currBit != previousBit)
            {
                subsequence.Add(words[i]);
                previousBit = currBit;
            }
        }
        return subsequence;     
    }
