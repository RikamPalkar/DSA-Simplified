/**
    Time complexity:
    O(n)
    Space complexity:
    O(1)
**/

public class Solution {
    public int[] NodesBetweenCriticalPoints(ListNode head) {

        ListNode prev = head;
        ListNode curr = head.next;
        int firstCriticalIndex = -1;
        int lastCriticalIndex = -1;
        int currentIndex = 1; // Start at 1 since curr is head.next
        int[] result = {-1, -1};

        while (curr.next != null) {
            if (IsNodeCriticalPoint(prev, curr, curr.next)) {
                if (firstCriticalIndex == -1) {
                    firstCriticalIndex = currentIndex;
                }

                if (lastCriticalIndex != -1) {
                    int distance = currentIndex - lastCriticalIndex;
                    if (result[0] == -1 || distance < result[0]) {
                        result[0] = distance; // Update min distance
                    }
                    result[1] = currentIndex - firstCriticalIndex; // Update max distance
                }

                lastCriticalIndex = currentIndex;
            }
            prev = curr;
            curr = curr.next;
            currentIndex++;
        }

        return result;
    }

    private bool IsNodeCriticalPoint(ListNode prev, ListNode curr, ListNode next) {
        return (prev.val > curr.val && next.val > curr.val) || 
               (prev.val < curr.val && next.val < curr.val);
    }
}

/**
Initialization

    Node Pointers: prev points to the current node's previous node, and curr points to the current node.
    Index Tracking: firstCriticalIndex and lastCriticalIndex track the indices of the first and last critical points. currentIndex starts at 1 because curr starts at head.next.
    Result Array: result is initialized to [-1, -1] to hold the minimum and maximum distances between critical points, because if there are fewer than two critical points, we need to return [-1, -1].

Loop

    The loop runs as long as curr has a next node. This ensures we have three nodes (prev, curr, and curr.next) to check for critical points.
    We keep track of currentIndex with each iteration.
    And update the pointers with each iteration.

Conditions

1. if (IsNodeCriticalPoint(prev, curr, curr.next)):
    It calls the function to check if the current node (curr) is either a local maxima (greater than both prev and next) or a local minima (less than both prev and next)

2. if (firstCriticalIndex == -1) {
    firstCriticalIndex = currentIndex;
}:
    First Critical Point: If firstCriticalIndex is -1, it means this is the first critical point, so we set firstCriticalIndex to currentIndex.

3. if (lastCriticalIndex != -1) {
    int distance = currentIndex - lastCriticalIndex;
    if (result[0] == -1 || distance < result[0]) {
        result[0] = distance; 
    }
    result[1] = currentIndex - firstCriticalIndex;
}
lastCriticalIndex = currentIndex;
:
    Subsequent Critical Points: If lastCriticalIndex is not -1, meaning we've found second critical point, calculate the distance between the current critical point and the previous critical point.
    Update result[0] with the minimum distance found so far.
    Update result[1] with the maximum distance from the first critical point.
    Update Last Critical Point: Set lastCriticalIndex to currentIndex.

Example Walkthrough: head = [5, 3, 1, 2, 5, 1, 2]

    Initialization:

    prev = 5, curr = 3, 
    firstCriticalIndex = -1,
    lastCriticalIndex = -1, 
    currentIndex = 1, 
    result = [-1, -1]

    First Loop Iteration (currentIndex = 1):

    prev = 5, 
    curr = 3, 
    curr.next = 1
    IsNodeCriticalPoint(5, 3, 1) returns false 
    Move to next node: prev = 3, curr = 1, currentIndex = 2

    Second Loop Iteration (currentIndex = 2):

    prev = 3, curr = 1, curr.next = 2
    IsNodeCriticalPoint(3, 1, 2) returns true (local minima).
    firstCriticalIndex = 2, (first critical point found)
    lastCriticalIndex = 2.
    Move to next node: prev = 1, curr = 2, currentIndex = 3

    Third Loop Iteration (currentIndex = 3):

    prev = 1, curr = 2, curr.next = 5
    IsNodeCriticalPoint(1, 2, 5) returns false 
    Move to next node: prev = 2, curr = 5, currentIndex = 4

    Fourth Loop Iteration (currentIndex = 4):

    prev = 2, curr = 5, curr.next = 1
    IsNodeCriticalPoint(2, 5, 1) returns true (local maxima).
    distance = 4 - 2 = 2
    result[0] = 2 (min distance updated), 
    result[1] = 4 - 2 = 2 (max distance updated)
    lastCriticalIndex = 4
    Move to next node: prev = 5, curr = 1, currentIndex = 5

    Fifth Loop Iteration (currentIndex = 5):

    prev = 5, curr = 1, curr.next = 2
    IsNodeCriticalPoint(5, 1, 2) returns true (local minima).
    distance = 5 - 4 = 1
    result[0] = 1 (min distance updated), 
    result[1] = 5 - 2 = 3 (max distance updated)
    lastCriticalIndex = 5
    Move to next node: prev = 1, curr = 2, currentIndex = 6

    Sixth Loop Iteration (currentIndex = 6):

        prev = 1, curr = 2, curr.next = null
        Loop ends as curr.next is null.

**/
