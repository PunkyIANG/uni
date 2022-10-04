using System;
using Extensions;

namespace Lab1;
internal class Program
{
    static void Main(string[] args)
    {
        int arrLength = 10;
        if (args.Length >= 2)
            arrLength = Int32.Parse(args[1]);

        var arrayToSort = Enumerable.Range(0, arrLength).ToArray();
        var rng = new Random(0);
        rng.Shuffle<int>(arrayToSort);


        string searchAlgo = "bubble";
        if (args.Length >= 1)
            searchAlgo = args[0];

        switch (searchAlgo) {
            case "insertion" :
                arrayToSort.InsertionSort();
                break;

            case "quick" :
                arrayToSort.QuickSort();
                break;        

            case "bubble" :
            default:
                arrayToSort.BubbleSort();
                break;
        }      
    }
}
