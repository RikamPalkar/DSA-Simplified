/*
 * LeetCode: Rectangle Overlap
 *
 * Intuition:
 * Two rectangles overlap only when their intersection has:
 * 1. Positive width
 * 2. Positive height
 *
 * There are two ways to check this.
 */


public class Solution
{
    /*
     * Approach 1: Calculate Intersection
     *
     * Find the width and height of the overlapping region.
     * If both are greater than 0, the rectangles overlap.
     *
     * Time: O(1)
     * Space: O(1)
     */
    public bool IsRectangleOverlap(int[] rec1, int[] rec2)
    {
        // Calculate the overlapping width.
        int intersectX =
            Math.Min(rec1[2], rec2[2]) -
            Math.Max(rec1[0], rec2[0]);

        // Calculate the overlapping height.
        int intersectY =
            Math.Min(rec1[3], rec2[3]) -
            Math.Max(rec1[1], rec2[1]);

        // Both dimensions must be positive for a valid overlap.
        return intersectX > 0 && intersectY > 0;
    }


    /*
     * Approach 2: Check All 4 Directions
     *
     * Check whether one rectangle is completely outside
     * the other from the left, right, top, or bottom.
     *
     * If none of these conditions is true, the rectangles overlap.
     *
     * Time: O(1)
     * Space: O(1)
     */
    public bool IsRectangleOverlap2(int[] rec1, int[] rec2)
    {
        // If either rectangle has zero width or height,
        // it does not form a valid overlapping area.
        if (rec1[0] == rec1[2] || rec1[1] == rec1[3] ||
            rec2[0] == rec2[2] || rec2[1] == rec2[3])
        {
            return false;
        }

        // Check overlap on both X-axis and Y-axis.
        return rec1[0] < rec2[2] && rec2[0] < rec1[2] &&
               rec1[1] < rec2[3] && rec2[1] < rec1[3];
    }
}

/*
 * Key Takeaway:
 *
 * Solution 1 calculates the actual intersection.
 *
 * Solution 2 checks whether the rectangles overlap
 * on both the X-axis and Y-axis.
 */