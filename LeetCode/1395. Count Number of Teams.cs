/*
Solution 1 : O(n^3)
*/
public class Solution {
    public int NumTeams(int[] rating) 
    {
        int count = 0;
        for (int i = 0; i < rating.Length - 2; i++) 
        {
            for (int j = i + 1; j < rating.Length - 1; j++) 
            {
                for (int k = j + 1; k < rating.Length; k++) 
                {
                    if ((rating[i] < rating[j] && rating[j] < rating[k]) || 
                        (rating[i] > rating[j] && rating[j] > rating[k])) 
                    {
                        count++;
                    }
                }
            }
        }
        return count;
    }
}
/*
Solution 2: O(n^2)
Algorithm

    Imagine each soldier as a point on a line:
        You have a list of soldiers, each with a unique skill rating.

    Choose a middle soldier:
        For each soldier, think of them as the middle point of a possible team of three soldiers.

    Count soldiers before the middle one:
        Look at all the soldiers before the chosen middle soldier.
        Count how many of these soldiers have a lower rating than the middle soldier.
        Count how many of these soldiers have a higher rating than the middle soldier.

    Count soldiers after the middle one:
        Look at all the soldiers after the chosen middle soldier.
        Count how many of these soldiers have a lower rating than the middle soldier.
        Count how many of these soldiers have a higher rating than the middle soldier.

    Form valid teams:
        Multiply the number of lower-rated soldiers before the middle one by the

Complexity

    Time complexity: O(n^2)
    Space complexity: O(1)

Here’s the simplified breakdown for the example `rating = [2, 5, 3, 4, 1]`:

1. Middle `2`:
   - Before: None
   - After: `[5, 3, 4, 1]` → 3 less, 1 more
   - Teams: 0 × 1 + 0 × 3 = 0

2. Middle `5`:
   - Before: `[2]` → 1 less
   - After: `[3, 4, 1]` → 2 less, 1 more
   - Teams: 1 × 1 + 0 × 2 = 1

3. Middle `3`:
   - Before: `[2, 5]` → 1 less, 1 more
   - After: `[4, 1]` → 1 less, 1 more
   - Teams: 1 × 1 + 1 × 1 = 2

4. Middle `4`:
   - Before: `[2, 5, 3]` → 2 less, 1 more
   - After: `[1]` → 1 less
   - Teams: 2 × 0 + 1 × 1 = 1

5. Middle `1`:
   - Before: `[2, 5, 3, 4]` → 0 less, 4 more
   - After: None
   - Teams: 0 × 0 + 4 × 0 = 0

Total Teams: 0 + 1 + 2 + 1 + 0 = 4
*/
public class Solution {
    public int NumTeams(int[] rating) 
    {
        int count = 0;
        for (int i = 1; i < rating.Length-1; i++) 
        {
            int lessThanCurrentNumFromLeft = 0, greaterThanCurrentNumFromLeft = 0,
                lessThanCurrentNumFromRight = 0, greaterThanCurrentNumFromRight = 0;

            for (int j = i-1; j >= 0; j--) 
            {
                if(rating[j] < rating[i]) lessThanCurrentNumFromLeft++;
                else if(rating[j] > rating[i]) greaterThanCurrentNumFromLeft++;
            }

            for (int k = i+1; k < rating.Length; k++) 
            {
                if(rating[i] < rating[k]) greaterThanCurrentNumFromRight++;
                else if(rating[i] > rating[k]) lessThanCurrentNumFromRight++;
            }

            count += (lessThanCurrentNumFromLeft * greaterThanCurrentNumFromRight) +
                     (greaterThanCurrentNumFromLeft * lessThanCurrentNumFromRight);

        }
        return count;
    }
}
