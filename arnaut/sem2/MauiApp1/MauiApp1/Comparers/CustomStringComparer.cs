namespace MauiApp1.Comparers;

public class CustomStringComparer : IComparer<CustomString>
{
    public int Compare(CustomString x, CustomString y)
    {
        return string.Compare(x.Value, y.Value, StringComparison.OrdinalIgnoreCase);
    }
}