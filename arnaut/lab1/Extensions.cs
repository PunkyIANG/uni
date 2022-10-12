namespace Extensions;
public static class Extensions
{
    public static void BubbleSort(this int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
            for (int j = i + 1; j < arr.Length; j++)
                SwapValues(arr, i, j);
    }

    public static void InsertionSort(this int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            var currentIndex = i;

            while (currentIndex != 0 && arr[currentIndex] < arr[currentIndex - 1])
            {
                arr.SwapValues(currentIndex, currentIndex - 1);
                currentIndex--;
            }

            if (currentIndex != 0)
                arr.SwapValues(currentIndex, currentIndex - 1);
        }
    }

    /* This function takes last element as pivot, places
         the pivot element at its correct position in sorted
         array, and places all smaller (smaller than pivot)
         to left of pivot and all greater elements to right
         of pivot */
    static int partition(int[] arr, int low, int high)
    {

        // pivot
        int pivot = arr[high];

        // Index of smaller element and
        // indicates the right position
        // of pivot found so far
        int i = (low - 1);

        for (int j = low; j <= high - 1; j++)
        {
            // If current element is smaller
            // than the pivot
            arr.HighlightValues(i, j, high);
            if (arr[j] < pivot)
            {
                // Increment index of
                // smaller element
                i++;

                if (i != j)
                    arr.SwapValues(i, j);
            }
        }

        if (i + 1 != high)
            arr.SwapValues(i + 1, high);

        return (i + 1);
    }

    /* The main function that implements QuickSort
                arr[] --> Array to be sorted,
                low --> Starting index,
                high --> Ending index
    */
    static void qSort(int[] arr, int low, int high)
    {
        if (low < high)
        {

            // pi is partitioning index, arr[p]
            // is now at right place
            int pi = partition(arr, low, high);

            // Separately sort elements before
            // partition and after partition
            qSort(arr, low, pi - 1);
            qSort(arr, pi + 1, high);
        }
    }


    public static void QuickSort(this int[] arr)
    {
        qSort(arr, 0, arr.Length - 1);
    }


    public static void SwapValues(this int[] arr, int first, int second)
    {
        if ((first < second) != (arr[first] < arr[second]))
        {
            Console.Write("\r");
            for (int i = 0; i < arr.Length; i++)
            {
                if (i != first && i != second)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{arr[i]} ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write($"{arr[i]} ");
                }
            }

            Thread.Sleep(500);

            var temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
        }


        Console.Write("\r");
        for (int i = 0; i < arr.Length; i++)
        {
            if (i != first && i != second)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{arr[i]} ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($"{arr[i]} ");
            }
        }

        Thread.Sleep(500);
        Console.ResetColor();

                Console.ResetColor();
        Console.Write("\r");
        foreach (int i in arr)
            Console.Write($"{i} ");

        Thread.Sleep(500);
    }

    public static void HighlightValues(this int[] arr, int first, int second, int third)
    {
        Console.Write("\r");
        for (int i = 0; i < arr.Length; i++)
        {
            if (i != first && i != second && i != third)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{arr[i]} ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"{arr[i]} ");
            }
        }

        Thread.Sleep(500);
    }


    public static void Shuffle<T>(this Random rng, T[] array)
    {
        int n = array.Length;
        while (n > 1)
        {
            int k = rng.Next(n--);
            T temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
    }

}
