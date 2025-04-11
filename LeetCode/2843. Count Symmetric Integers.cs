    public int CountSymmetricIntegers(int low, int high) { 
        int res = 0;
        for(int i=low; i<=high; i++)
        {
            if(i<100 && i % 11 == 0) res++; // 11, 22, 33 
            else if(i > 1000) //1234
            {
                int firstDigit = i/1000; // 1
                int secondDigit = (i%1000)/100; // 2
                int thirdDigit = (i%100)/10;// 3
                int fourthDigit = i%10;// 4

                if(firstDigit + secondDigit == thirdDigit + fourthDigit) res++;
            }
        }
        return res;
    }

    public int CountSymmetricIntegers(int low, int high) {   
        int res = 0; StringBuilder num = new();
        for(int i=low; i<=high; i++)
        {
            num.Clear(); num.Append(i);
            int len = num.Length;
            if(len % 2 != 0) continue;
            int mid = len/2, firstSum = 0, secondSum = 0;
            
            for(int j=0; j<mid; j++)
            {
                firstSum += num[j] - '0';
                secondSum +=  num[mid+j] - '0';
            }
            if(firstSum == secondSum) res++;
        }
        return res;
    }

