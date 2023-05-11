namespace MauiApp1.Comparers;

public class FloatComparer : IComparer<float>
{
    public int Compare(float x, float y)
    {
        return x.CompareTo(y);
    }
}