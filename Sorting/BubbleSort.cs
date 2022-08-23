Program bubbleSort = new();
bubbleSort.BubbleSort(new int[] { 8, 5, 2, 9, 5, 6, 3 });

public partial class Program
{
    public int[] BubbleSort(int[] array)
    {

        /*
                 Time-Complexity : Space-Complexity
           Best :   O(n^2)       :     O(1)
           Avg  :   O(n^2)       :     O(1)
           Worst:   O(n^2)       :     O(1)
         */
        if (array.Length == 0)
        {
            return Array.Empty<int>();
        }
        if (array.Length == 1)
        {
            return array;
        }
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - 1 - i; j++)
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
    public int[] BubbleSortApproach2(int[] array)
    {

        /*
                 Time-Complexity : Space-Complexity
           Best :   O(n)         :     O(1)//In place
           Avg  :   O(n^2)       :     O(1)
           Worst:   O(n^2)       :     O(1)
         */
        if (array.Length == 0)
        {
            return Array.Empty<int>();
        }
        if (array.Length == 1)
        {
            return array;
        }
        int i = 0;
        bool isSorted = false;
        while (!isSorted)
        {
            isSorted = true;
            for (int j = 0; j < array.Length - 1 - i; j++)
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
}
