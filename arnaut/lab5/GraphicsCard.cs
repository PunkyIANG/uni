using System.Data;

namespace lab5;

public class GraphicsCard
{
    public static readonly string[] Properties = { "Chip Manufacturer", "Model Manufacturer", "Memory Type", "Model" };
    public static readonly string[] Categories = { "Manufacturers", "Specs" };
    public static int PropertyCount => Properties.Length;
    public static int CategoriesCount => 2;
}