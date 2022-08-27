
public class Program
{
     /*
             Time-Complexity : Space-Complexity
       Best :   O(nlog(n))   :    O(nlog(n))
       Avg  :   O(nlog(n))   :    O(nlog(n))
       Worst:   O(nlog(n))   :    O(nlog(n))
     */
    public static int[] MergeSort(int[] array)
    {       
        if (array.Length <= 1) return array;

        int mid = array.Length / 2;
        int[] leftArray = array.Take(mid).ToArray();
        int[] rightArray = array.Skip(mid).ToArray();

        return SortSplittedArrays(MergeSort(leftArray), MergeSort(rightArray));
    }

    private static int[] SortSplittedArrays(int[] leftArray, int[] rightArray)
    {
        int[] mergedArray = new int[leftArray.Length + rightArray.Length];
        int l = 0;
        int r = 0;
        int k = 0;

        while (l < leftArray.Length && r < rightArray.Length)
        {
            if (leftArray[l] < rightArray[r])
            {
                mergedArray[k] = leftArray[l];
                l++;
                k++;
            }
            else
            {
                mergedArray[k] = rightArray[r];
                r++;
                k++;
            }
        }
        //Left outliers
        while (l < leftArray.Length)
        {
            mergedArray[k] = leftArray[l];
            l++;
            k++;
        }

        //Right outliers
        while (r < rightArray.Length)
        {
            mergedArray[k] = rightArray[r];
            r++;
            k++;
        }
        return mergedArray;
    }
}
