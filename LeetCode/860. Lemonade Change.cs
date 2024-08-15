//Solution 1
    public bool LemonadeChange(int[] bills) 
    {
        //Time: O(n), Space: O(1)
        int five = 0;
        int ten = 0;
        
        foreach(int bill in bills)
        {
            if(bill == 5)
            {
                five++;
            }
            else if(bill == 10)
            {
                if(five == 0) return false;
                five--;
                ten++;
            }
            else
            {
                if(ten > 0 && five > 0)
                {
                   ten--;
                   five--;
                }
                else if(five >= 3) five -= 3;
                else return false;
            }
        }
        return true;
    }

//Solution 2
    public bool LemonadeChange(int[] bills) 
    {
       //Time: O(n), Space: O(1)
        Dictionary<int, int> balance = [];    
        foreach (int bill in bills) 
        {
            balance[bill] = balance.GetValueOrDefault(bill) +1;
            int change = bill - 5;
   
            foreach (int denomination in new int[]{20, 10, 5}) 
            {
                while (change >= denomination && balance.ContainsKey(denomination) && balance[denomination] > 0) 
                {
                    change -= denomination;
                    balance[denomination]--;
                }
            }
            
            if (change != 0) return false;
        }
        return true;
    }
