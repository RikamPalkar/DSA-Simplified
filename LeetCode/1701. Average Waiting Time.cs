//Time: O(n), Space: O(1)

public double AverageWaitingTime(int[][] customers) {
    int currentTime = 0;
    double totalWaitingTime = 0.0;
    
    for (int i = 0; i < customers.Length; i++) {
        int arrivalTime = customers[i][0];
        int prepTime = customers[i][1];
        
        if (currentTime < arrivalTime) {
            currentTime = arrivalTime;
        }
        
        currentTime += prepTime;
        int waitingTime = currentTime - arrivalTime;
        totalWaitingTime += waitingTime;
    }
    
    return totalWaitingTime / customers.Length;
    }

/**
Algorithm Steps

    currentTime : Is set to 0. When the chef will be available to start preparing the next order.
    totalWaitingTime : Is set to 0.0. The total waiting time for all customers.

Iterate Over Each Customer:

    Update currentTime:
    If (currentTime < arrivalTime) : Chef is ready when the customer arrives.

    currentTime = arrivalTime This ensures that the chef starts preparing the order as soon as the customer arrives if the chef is idle. If the chef is busy, currentTime remains unchanged.

    Prepare the Order:

    currentTime += prepTime : When the chef finishes preparing the current order.

    currentTime - arrivalTime : Calculate the waiting time for the current customer as .

    totalWaitingTime += waitingTime : Accumulate the Waiting Time:

    Return Average Waiting Time.

**/

/** Examples
Example 1: customers = [[1, 2], [2, 5], [4, 3]]

    Initialization:
        currentTime = 0
        totalWaitingTime = 0.0

    First customer [1, 2]:
        arrivalTime = 1, prepTime = 2
        Since currentTime (0) < arrivalTime (1), update currentTime = 1
        The chef starts at 1 and finishes at 1 + 2 = 3
        Waiting time = 3 - 1 = 2
        totalWaitingTime = 0.0 + 2 = 2.0

    Second customer [2, 5]:
        arrivalTime = 2, prepTime = 5
        Since currentTime (3) >= arrivalTime (2), no update to currentTime
        The chef starts at 3 and finishes at 3 + 5 = 8
        Waiting time = 8 - 2 = 6
        totalWaitingTime = 2.0 + 6 = 8.0

    Third customer [4, 3]:
        arrivalTime = 4, prepTime = 3
        Since currentTime (8) >= arrivalTime (4), no update to currentTime
        The chef starts at 8 and finishes at 8 + 3 = 11
        Waiting time = 11 - 4 = 7
        totalWaitingTime = 8.0 + 7 = 15.0

    Average Waiting Time:
        totalWaitingTime = 15.0
        Number of customers = 3
        Average waiting time = 15.0 / 3 = 5.00000

Example 2: customers = [[5, 2], [5, 4], [10, 3], [20, 1]]

    Initialization:
        currentTime = 0
        totalWaitingTime = 0.0

    First customer [5, 2]:
        arrivalTime = 5, prepTime = 2
        Since currentTime (0) < arrivalTime (5), update currentTime = 5
        The chef starts at 5 and finishes at 5 + 2 = 7
        Waiting time = 7 - 5 = 2
        totalWaitingTime = 0.0 + 2 = 2.0

    Second customer [5, 4]:
        arrivalTime = 5, prepTime = 4
        Since currentTime (7) >= arrivalTime (5), no update to currentTime
        The chef starts at 7 and finishes at 7 + 4 = 11
        Waiting time = 11 - 5 = 6
        totalWaitingTime = 2.0 + 6 = 8.0

    Third customer [10, 3]:
        arrivalTime = 10, prepTime = 3
        Since currentTime (11) >= arrivalTime (10), no update to currentTime
        The chef starts at 11 and finishes at 11 + 3 = 14
        Waiting time = 14 - 10 = 4
        totalWaitingTime = 8.0 + 4 = 12.0

    Fourth customer [20, 1]:
        arrivalTime = 20, prepTime = 1
        Since currentTime (14) < arrivalTime (20), update currentTime = 20
        The chef starts at 20 and finishes at 20 + 1 = 21
        Waiting time = 21 - 20 = 1
        totalWaitingTime = 12.0 + 1 = 13.0

    Average Waiting Time:
        totalWaitingTime = 13.0
        Number of customers = 4
        Average waiting time = 13.0 / 4 = 3.25000
**/
