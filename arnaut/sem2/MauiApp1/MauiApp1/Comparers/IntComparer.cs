namespace MauiApp1.Comparers;

public class IntComparer : IComparer<int>
{
    public int Compare(int x, int y)
    {
        return x - y;
    }
}