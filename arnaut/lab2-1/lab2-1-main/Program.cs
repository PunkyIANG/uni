namespace lab2_1_main;

internal static class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"{Rational.TryParse("1.23", out var a)} : {a}");
        Console.WriteLine($"{Rational.TryParse("1.28/.64", out var b)} : {b}");
    }
}
