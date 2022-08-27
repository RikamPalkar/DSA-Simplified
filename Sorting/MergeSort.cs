
public class Program
{
    public static int[] MergeSort(int[] array)
    {
        //Half way when arrays are divided into 1,1
        if (array.Length <= 1)
        {
            return array;
        }

        int mid = array.Length / 2;
        int[] leftArray = array.Take(mid).ToArray();
        int[] rightArray = array.Skip(mid).ToArray();

        return SortSplittedArrays(MergeSort(leftArray), MergeSort(rightArray));
    }

    private static int[] SortSplittedArrays(int[] leftArray, int[] rightArray)
    {
        int[] mergedArray = new int[leftArray.Length + rightArray.Length];
        int leftArrayPointer = 0;
        int rightArrayPointer = 0;
        int resultArrayPointer = 0;

        while (leftArrayPointer < leftArray.Length && rightArrayPointer < rightArray.Length)
        {
            if (leftArray[leftArrayPointer] < rightArray[rightArrayPointer])
            {
                mergedArray[resultArrayPointer] = leftArray[leftArrayPointer];
                leftArrayPointer++;
                resultArrayPointer++;
            }
            else
            {
                mergedArray[resultArrayPointer] = rightArray[rightArrayPointer];
                rightArrayPointer++;
                resultArrayPointer++;
            }
        }
        //Left outliers
        while (leftArrayPointer < leftArray.Length)
        {
            mergedArray[resultArrayPointer] = leftArray[leftArrayPointer];
            leftArrayPointer++;
            resultArrayPointer++;
        }

        //Right outliers
        while (rightArrayPointer < rightArray.Length)
        {
            mergedArray[resultArrayPointer] = rightArray[rightArrayPointer];
            rightArrayPointer++;
            resultArrayPointer++;
        }
        return mergedArray;
    }
}
