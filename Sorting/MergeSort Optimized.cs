
public class Program
{
    /*
            Time-Complexity : Space-Complexity
      Best :   O(nlog(n))   :      O(n)
      Avg  :   O(nlog(n))   :      O(n)
      Worst:   O(nlog(n))   :      O(n)
    */
    public static int[] MergeSort(int[] array) 
    {
        if (array.Length <= 1) return array;

        int[] auxiliaryArray = (int[])array.Clone();
        MergeSort(array, 0, array.Length - 1, auxiliaryArray);
        return array;
    }

    private static void MergeSort(int[] array, int l, int r, int[] auxArray)
    {
        if (l == r) return;
        int mid = (l + r) / 2;
        MergeSort(auxArray, l, mid, array);
        MergeSort(auxArray, mid + 1, r, array);
        SortSplittedArrays(array, l, mid, r, auxArray);
    }

    private static void SortSplittedArrays(int[] array, int start, int mid, int end, int[] auxArray)
    {
        int l = start;
        int r = mid + 1;
        int k = start;

        while (l <= mid && r <= end)
        {
            if (auxArray[l] < auxArray[r])
{
                array[k++] = auxArray[l++];
            }
            else
            {
                array[k++] = auxArray[r++];
            }
        }

        //Left outliers
        while (l <= mid)
        {
            array[k++] = auxArray[l++];
        }

        //Right outliers
        while (r <= end)
        {
            array[k++] = auxArray[r++];
        }
    }
}
