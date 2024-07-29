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

Code
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
