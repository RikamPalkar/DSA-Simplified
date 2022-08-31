public class Program
{
    public static int[] QuickSort(int[] array)
    {
        if (array.Length <= 1) return array;

        QuickSortRecursion(array, 0, array.Length - 1);
        return array;
    }

    private static void QuickSortRecursion(int[] array, int start, int end)
    {
        //Base condition: array with length <= 1
        if (end < start)
        {
            return;
        }

        int pivot = start;
        int left = start + 1;
        int right = end;

        while (right >= left)
        {
            if (array[left] > array[pivot] && array[right] < array[pivot])
            {
                Swap(array, left, right);
            }
            if (array[left] <= array[pivot])
            {
                left++;
            }
            if (array[right] >= array[pivot])
            {
                right--;
            }
        }
        //Now you can swap array[right]  with array[pivot]
        Swap(array, pivot, right);

        //Needs to call quickSort recursiverly, for rest of the unsorted arrays
        QuickSortRecursion(array, right + 1, end);
        QuickSortRecursion(array, start, right - 1);
    }

    private static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}
