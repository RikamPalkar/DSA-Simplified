
    public int MinMaxDifference(int num) 
    {
        StringBuilder maxSb = new(num.ToString());
        for(int i=0; i<maxSb.Length; i++)
        {
            if(maxSb[i] != '9')
            {
                maxSb.Replace(maxSb[i], '9');
                break;
            }
        }

        StringBuilder minSb = new(num.ToString());
        minSb.Replace(minSb[0], '0');

        int maxNum = int.Parse(maxSb.ToString());
        int minNum = int.Parse(minSb.ToString());
        return maxNum - minNum;
    }
