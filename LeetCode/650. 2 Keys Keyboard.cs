
//Time: O(n log n), Space: O(1)
public int MinSteps(int n) {
        if (n == 1) return 0;
        
        int[] dp = new int[n + 1];
        for (int i = 2; i <= n; i++) {
            dp[i] = i;
            for (int j = i / 2; j > 1; j--) {
                if (i % j == 0) {
                    dp[i] = dp[j] + (i / j);
                    break;
                }
            }
        }
        
        return dp[n];
    }
/*
Approach

In this problem you can copy and paste A till nth number:

Let's say for n = 6 how many minimum number of opertaions you need considering copy is one and paste is another one operation.
You can copy A then paste it 5 times that will give you total of 6 operations.
But there is faster way.

Copy A once then paste twice, so in order for n to reach at 3,, total operation so far is 3
A A A

Now make smart move

Just copy all A's and paste it which is 2 operations

So overall operations are 3+2 = 5.
in code if there is only 1 A then simply return 0
if (n == 1) return 0;
for more than 1
we create dp array to keep track of number of operations:
int[] dp = new int[n + 1];
Loop from second operation and first simply update dp array with worst possible operation, that is copying single A and pasting 5 times will give us.
for (int i = 2; i <= n; i++) { dp[i] = i; }
then we find a shortcut, we find best possible factor of 6, in this case which is 6/2 = 3.
make sure you can fit 3's into 6 meaning by checking mode i%j == 0. then simply get value from dp[3] if you remember from example, and plus total number of operation from here to copy and paste 3 once will give 2, which is i/j then add3+2and return 5
            for (int j = i / 2; j > 1; j--) 
            {
                if (i % j == 0) {
                    dp[i] = dp[j] + (i / j);
                    break;
                }
            }
            */
