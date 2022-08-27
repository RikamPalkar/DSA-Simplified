public class Program
{
    public static int[] SelectionSort(int[] array)
    {
        if (array.Length <= 1) return array;

        for (int i = 0; i < array.Length - 1; i++)
        {
            int lowest = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[lowest])
                {
                    lowest = j;
                }
            }
            (array[i], array[lowest]) = (array[lowest], array[i]);
        }
        return array;
    }
}
