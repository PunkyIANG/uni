namespace lab2_1_main;

public static class Extras
{
    private static readonly string[] presets =
    {
        "x",
        "y",
        "z",
        "w",
    };

    public static string Unknown(int i)
    {
        return i < presets.Length ? presets[i] : $"d{i + 1 - presets.Length}";
    }
}