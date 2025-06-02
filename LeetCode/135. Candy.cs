
    public int Candy(int[] ratings) 
    {
        int len = ratings.Length;
        int[] candies = new int[len];
        Array.Fill(candies, 1); 

        for(int i=1; i<len; i++)
            if(ratings[i] > ratings[i-1])
                 candies[i] = candies[i-1]+1;
        
        for(int i=len-2; i>=0; i--)
            if(ratings[i] > ratings[i+1])
                candies[i] = 
                    Math.Max(candies[i], candies[i+1]+1);
            
        return candies.Sum();
    }
