	// Iterative solution | Time: O(n) | Space: O(1)
    public int FindTheWinner(int n, int k) 
    {
        int player = 0;
        for (int i = 1; i <= n; i++) 
        {
            player = (player + k) % i;
        }
        return player + 1;
    }

------------------------------------------------------------------------------

	// Recursive solution | Time: O(n) | Space: O(n)
    public int FindTheWinner(int n, int k) 
	{
        return Josephus(n, k) + 1;
    }

    private int Josephus(int n, int k) 
    {
        // Base case: only one person left
        if (n == 1) 
            return 0;
        else 
            return (Josephus(n - 1, k) + k) % n;
    }

------------------------------------------------------------------------------
    
    // Time: O(n) | Space: O(n)
    public int FindTheWinner(int n, int k) 
	{
        List<int> players = [];

        for(int i = 1; i <= n; i++)
			players.Add(i);

        int currentIndex = 0;
        while (players.Count > 1) 
        {
            currentIndex = (currentIndex + k - 1) % players.Count;
            players.RemoveAt(currentIndex);
        }

        return players[0];
    }

------------------------------------------------------------------------------
