    /*
             Time-Complexity : Space-Complexity
       Best :   O(n)         :     O(1)
       Avg  :   O(n^2)       :     O(1)
       Worst:   O(n^2)       :     O(1)
    */
    public static int[] InsertionSort(int[] array)
    {
        if (array.Length <= 1) return array;
        for (int i = 1; i < array.Length; i++)
        {
            int j = i;
            while (j > 0 && array[j] < array[j - 1])
            {
                int temp = array[j];
                array[j] = array[j - 1];
                array[j - 1] = temp;
                j--;
            }
        }
        return array;
    }
