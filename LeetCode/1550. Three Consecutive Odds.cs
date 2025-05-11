    //Solution 1
    public bool ThreeConsecutiveOdds(int[] arr) {
        int len = arr.Length;
        if(len < 3 ) return false;

        for(int i = 0; i<len-2; i++){ //Time :O(n)
            if(arr[i] %2 != 0 &&
               arr[i+1] %2 != 0 && 
               arr[i+2] %2 != 0) 
                    return true;
        }
        return false;
    }

    //Solution 2
    public bool ThreeConsecutiveOdds(int[] arr) {
        int len = arr.Length;
        if(len < 3 ) return false;
        int odds = 0; //Space :O(1)

        for(int i = 0; i<len; i++){   //Time :O(n)
            if(arr[i] %2 != 0) {
                odds++;
                if(odds == 3) return true;
            }
            else odds = 0;
        }
        return false;
    }
