namespace CodeTests.GrantThornton.Application.Extensions
{
    public static class ArrayExtensions
    {
        public static void BubbleSort(this int[] array) 
        {
            for (var i = 0; i < array.Length - 1; i++)
            {
                for(var j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                        array.SwapElements(i, j);
                }
            }
        }

        public static void SwapElements<T>(this T[] array, int firstIndex, int secondIndex)
        {
            var temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;
        }
    }
}
