// Problem: https://leetcode.com/problems/distribute-elements-into-two-arrays-i/description/

public class Solution {

    // Time: O(n) - Space: O(n)
    public int[] ResultArray(int[] nums){
        List<int> list1 = [nums[0]];
        List<int> list2 = [nums[1]];

        for (int i = 2; i < nums.Length; i++){

            if (list1[^1] > list2[^1])
                list1.Add(nums[i]);
            else
                list2.Add(nums[i]);
        }

        list1.AddRange(list2);
        return list1.ToArray();
    }

    // Time: O(n^2) - Space: O(n)
    public int[] ResultArray(int[] nums){
        HashSet<int> set1 = [nums[0]];
        HashSet<int> set2 = [nums[1]];

        for (int i = 2; i < nums.Length; i++){

            if (set1.Last() > set2.Last())
                set1.Add(nums[i]);
            else
                set2.Add(nums[i]); 
        }

        set1.UnionWith(set2);
        return set1.ToArray();
    }
}