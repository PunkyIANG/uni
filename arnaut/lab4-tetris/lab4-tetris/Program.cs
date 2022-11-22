

Pixel[] piecesPixels = 
{
    new Pixel(true, '\u2000', ConsoleColor.Cyan),
};

int[,] piecesShapes =
{
    { }
};

ConsoleKeyInfo input;

const int mapSizeX = 10;
const int mapSizeY = 20;
var setData = new Pixel[mapSizeX * mapSizeY];

int holdPosX;
int holdPosY;
int holdId;

foreach (ref var pixel in setData.AsSpan())
{
    pixel = new Pixel();
}

Render();



#region Input

void HandleInput()
{
    switch (input)
    {
        // add keybinds
        default:
            break;
    }

    input = new ConsoleKeyInfo();
}

void Input()
{
    while (true)
    {
        input = Console.ReadKey(true);
    }
}

#endregion

#region Render

void Render()
{
    for (var y = 0; y < mapSizeY; y++)
    {
        for (var x = 0; x < mapSizeX; x++)
        {
            ref var pixel = ref setData[x + y * mapSizeX];
            Console.ForegroundColor = pixel.Color;
            Console.Write(pixel.Character);
        }
        Console.WriteLine();
    }
}

struct Pixel
{
    public bool IsOccupied { get; }
    public char Character { get; }
    public ConsoleColor Color { get; }

    public Pixel(bool isOccupied, char character, ConsoleColor color)
    {
        IsOccupied = isOccupied;
        Character = character;
        Color = color;
    }
    
    public Pixel() : this(false, '\u2002', ConsoleColor.Gray) { }

    public Pixel(Pixel pixel) : this(pixel.IsOccupied, pixel.Character, pixel.Color) { }
}

#endregion
