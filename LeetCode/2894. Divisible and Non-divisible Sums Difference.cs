    //Solution 1: Math
    public int DifferenceOfSums(int n, int m) { 

        //Time: O(1), Space: O(1)
        int totalSum = n * (n + 1) / 2;
        int countOfMultiples = n / m;

        int totalCountSum = countOfMultiples * 
                            (countOfMultiples + 1) / 2;

        int divisibleSum = m * totalCountSum;

        int inDivisibleSum = totalSum - divisibleSum;
        int difference = inDivisibleSum - divisibleSum;

        return difference;
    }

    //Solution 2
    public int DifferenceOfSums(int n, int m) {
        
        int divisibleSum = 0;
        int nonDivisibleSum = 0;

        //Time:O(n)
        for(int i=1; i<=n; i++){
            if(i % m == 0) divisibleSum += i;
            else nonDivisibleSum += i;
        }

        return nonDivisibleSum - divisibleSum;
    }
