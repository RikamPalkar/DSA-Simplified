//Time: O(1), Space:O(1)
public int PassThePillow(int n, int time) {
        int cycle = 2 * (n - 1); // forward and backward
        int timeToReach = time % cycle;
        bool isForward = timeToReach < n;

        return isForward ?  1 + timeToReach : n - (timeToReach - (n - 1));

    }
/**
Algorithm:

    Cycle Length:
    Think of the pillow moving from person 1 to the last person (forward) and then back to person 1 (backward). This whole trip (forward and back) is one full cycle.

    For example, if there are 4 people, the pillow goes: 1 → 2 → 3 → 4 → 3 → 2 → 1. This is one full cycle, and it takes 6 seconds (forward and backward).

    Effective Time:
    The number of seconds can be very large, but the pattern of passing the pillow repeats every cycle.
    To make things simpler, we can ignore the full cycles and just focus on the remaining time within the current cycle. We do this by finding the remainder of the given time divided by the cycle length.

    For instance, if the time is 5 seconds and the cycle length is 6 seconds, 5 seconds is already within one cycle, so we don't need to adjust it. If the time was 8 seconds, we would only need to look at the first 2 seconds after a full cycle (8 % 6 = 2).

    Determine the Position:
    If the remaining time is less than the number of people, the pillow is still moving forward.
    If the remaining time is greater or equal to the number of people, the pillow is moving backward after reaching the last person.

    For instance, in a group of 4 people, if the remaining time is 2 seconds, the pillow is at person 3 (forward). If the remaining time is 5 seconds, the pillow is at person 2 (backward).

Example 1: n = 4, time = 5
        Cycle length: 2×(4−1) = 6 seconds.
        Effective time: 5 % 6 = 5 seconds.
        Since 5 seconds is more than 4 people, 
        the pillow is moving backward.
        Position: 4−(5−3) = 2. 
        The 2nd person has the pillow after 5 seconds.

Example 2: n = 4, time = 2
        Cycle length: 2×(4−1)=6 seconds.
        Effective time: 2 % 6=2 seconds.
        Since 2 seconds is less than 4, 
        the pillow is moving forward.
        Position: 1+2=3. 
        The 3rd person has the pillow after 2 seconds.

Example 3: n = 4, time = 3
        Cycle length: 2×(4−1)=6 seconds.
        Effective time: 3 % 6=3 seconds.
        Since 3 seconds is equal to 4, 
        the pillow is at the last person.
        Position: 1+3=4, 
        The 4th person has the pillow after 3 seconds.
        
**/
