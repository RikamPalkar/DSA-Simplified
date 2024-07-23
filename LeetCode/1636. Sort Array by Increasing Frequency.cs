
/**
Algorithm

    Find Frequencies of Each Number
    Order Elements by Frequencies
    Order Descendingly for Numbers with the Same Frequencies

Complexity

    Time complexity: O(n log n)
    Space complexity: O(n)

**/
	public int[] FrequencySort(int[] nums) 
  {
        Dictionary<int, int> freq = []; //Space: O(n)

        foreach(int i in nums) //Time: O(n)
            freq[i] = freq.GetValueOrDefault(i)+1;

        //Time: 2 * O(n log n) + O(n)
        var sortedNums = nums.OrderBy(num => freq[num]) 
                             .ThenByDescending(num => num)
                             .ToArray();

        return sortedNums;
    }


