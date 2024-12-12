   public long PickGifts(int[] gifts, int k) 
    {
        PriorityQueue<int, int> pq = 
        new(Comparer<int>.Create((x,y) => 
                        y.CompareTo(x)));
        
        for(int i=0; i<gifts.Length; i++)
        {
            pq.Enqueue(gifts[i], gifts[i]);          
        }

    while(k > 0)
    {
        int pile = pq.Dequeue();
        int reducePile = (int)(Math.Sqrt(pile));
        pq.Enqueue(reducePile, reducePile); 
        k--;
    }

        long res = 0;
        while(pq.Count > 0)
        {
            res += pq.Dequeue();
        } 
        return res; 
    }
}
