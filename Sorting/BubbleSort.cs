    /*
             Time-Complexity : Space-Complexity
       Best :   O(n^2)       :     O(1)
       Avg  :   O(n^2)       :     O(1)
       Worst:   O(n^2)       :     O(1)
    */
    public int[] BubbleSort(int[] array)
    {
        int arrLength = array.Length;
        if (arrLength <= 1) return array;
         
        for (int i = 0; i < arrLength - 1; i++)
        {
            for (int j = 0; j < arrLength - 1 - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    Swap(j, j + 1, array);
                }
            }
        }
        return array;
    }

    //Helper swap method
    private void Swap(int i, int j, int[] nums)
    {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }

    //2nd Approach
    /*
             Time-Complexity : Space-Complexity
       Best :   O(n)         :     O(1)//In place
       Avg  :   O(n^2)       :     O(1)
       Worst:   O(n^2)       :     O(1)
    */
    public int[] BubbleSortApproach2(int[] array)
    {
        int arrLength = array.Length;
        if (arrLength <= 1) return array;

        int i = 0;
        bool isSorted = false;
        while (!isSorted)
        {
            isSorted = true;
            for (int j = 0; j < arrLength - 1 - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    Swap(j, j + 1, array);
                    isSorted = false;
                }
            }
            i++;
        }
        return array;
    }
