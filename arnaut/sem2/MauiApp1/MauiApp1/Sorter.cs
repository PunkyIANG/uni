using System.Collections.ObjectModel;
using Windows.UI.Notifications;

namespace MauiApp1;

public static class Sorter
{
    private static async Task<ObservableCollection<T>> Swap<T>(this ObservableCollection<T> list, int left, int right)
    {
        (list[left], list[right]) = (list[right], list[left]);
        await Task.Delay(500);
        return list;
    }

    public static async Task QuickSort<T>(this ObservableCollection<T> list, int left, int right, IComparer<T> comparer)
    {
        async Task<int>  Partition<T>(ObservableCollection<T> list, int left, int right, IComparer<T> comparer)
        {
            T pivot = list[left];
            while (true)
            {
                while (comparer.Compare(list[left], pivot) < 0)
                {
                    left++;
                }
                while (comparer.Compare(list[right], pivot) > 0)
                {
                    right--;
                }
                if (left < right)
                {
                    if (comparer.Compare(list[left], list[right]) == 0) return right;
                    await list.Swap(left, right);
                }
                else
                {
                    return right;
                }
            }
        }

        if (left < right)
        {
            int pivot = await Partition(list, left, right, comparer);
            if (pivot > 1)
            {
                QuickSort(list, left, pivot - 1, comparer);
            }
            if (pivot + 1 < right)
            {
                QuickSort(list, pivot + 1, right, comparer);
            }
        }
    }
    
    public static async Task BubbleSort<T>(this ObservableCollection<T> list, int left, int right, IComparer<T> comparer)
    {
        if (left >= right) return;
        
        for (int i = 0; i < right - left; i++)
        {
            for (int j = left; j < right - i; j++)
            {
                if (comparer.Compare(list[j], list[j + 1]) > 0)
                {
                    await list.Swap(j, j + 1);
                }
            }
        }
    }

    public static async Task SelectionSort<T>(this ObservableCollection<T> list, int left, int right,
        IComparer<T> comparer)
    {
        for (int i = left; i < right; i++)
        {
            int min = i;
            for (int j = i + 1; j <= right; j++)
            {
                if (comparer.Compare(list[j], list[min]) < 0)
                {
                    min = j;
                }
            }
            if (min != i)
            {
                await list.Swap(i, min);
            }
        }
    }

}