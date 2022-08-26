public class Program
{
    public static int[] HeapSort(int[] array)
    {
        BuildMaxHeap(array);
        for (int i = array.Length - 1; i > 0; i--)
        {
            Swap(0, i, array);
            SiftDown(0, i - 1, array);
        }
        return array;
    }

    private static void BuildMaxHeap(int[] array)
    {
        int lastParent = (array.Length - 2) / 2;
        for (int i = lastParent; i >= 0; i--)
        {
            SiftDown(i, array.Length - 1, array);
        }
    }

    private static void SiftDown(int startIdx, int endIdx, int[] array)
    {
        int firstChild = startIdx * 2 + 1;
        while (firstChild <= endIdx)
        {
            int secondChild = startIdx * 2 + 2 <= endIdx ? startIdx * 2 + 2 : -1;
            int idxToSwap = firstChild;
            if (secondChild != -1 && array[secondChild] > array[firstChild])
            {
                idxToSwap = secondChild;
            }
            if (array[idxToSwap] > array[startIdx])
            {
                Swap(idxToSwap, startIdx, array);
                startIdx = idxToSwap;
                firstChild = startIdx * 2 + 1;
            }
            else
            {
                return;
            }
        }
    }

    private static void Swap(int i, int j, int[] array)
    {
        (array[j], array[i]) = (array[i], array[j]);
    }
}
