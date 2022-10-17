using System;
using Extensions;

namespace Lab1;
internal class Program
{
    static void Main(string[] args)
    {
        bool keyboardInit = args.Length >= 3;

        int arrLength = 10;
        if (args.Length >= 2)
            arrLength = int.Parse(args[1]);

        var arrayToSort = Enumerable.Range(0, arrLength).ToArray();

        if (keyboardInit)
        {
            for (int i = 0; i < arrLength; i++)
            {
                Console.Write($"Dati elementul {i}: ");
                arrayToSort[i] =  int.Parse(Console.ReadLine());
            }
        }
        else
        {
            var rng = new Random(0);
            rng.Shuffle<int>(arrayToSort);
        }


        string searchAlgo = "bubble";
        if (args.Length >= 1)
            searchAlgo = args[0];

        switch (searchAlgo)
        {
            case "insertion":
                arrayToSort.InsertionSort();
                break;

            case "quick":
                arrayToSort.QuickSort();
                break;

            case "bubble":
            default:
                arrayToSort.BubbleSort();
                break;
        }
    }
}
