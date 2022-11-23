Pixel[] piecesPixels = 
{
    new(true, "██", ConsoleColor.Yellow),
    new(true, "██", ConsoleColor.Cyan),
    new(true, "██", ConsoleColor.Green),
    new(true, "██", ConsoleColor.Red),
    new(true, "██", ConsoleColor.DarkMagenta),
    new(true, "██", ConsoleColor.DarkYellow),
    new(true, "██", ConsoleColor.Magenta)
};

Vector2[,,] piecesShapes =
{
    // SQUARE XX██
    //        ████
    {
        { new(0, 0), new(1, 0), new(0, 1), new(1, 1) },
        { new(0, 0), new(1, 0), new(0, 1), new(1, 1) },
        { new(0, 0), new(1, 0), new(0, 1), new(1, 1) },
        { new(0, 0), new(1, 0), new(0, 1), new(1, 1) },
    },

    // LINE XX██████
    {
        { new(0, 0), new(1, 0), new(2, 0), new(3, 0) },
        { new(0, 0), new(0, 1), new(0, 2), new(0, 3) },
        { new(0, 0), new(1, 0), new(2, 0), new(3, 0) },
        { new(0, 0), new(0, 1), new(0, 2), new(0, 3) },
    },
    
    // Z shape  XX██
    //            ████
    {
        { new(0, 0), new(1, 0), new(1, 1), new(2, 1) },
        { new(0, 1), new(1, 1), new(1, 0), new(0, 2) },
        { new(0, 0), new(1, 0), new(1, 1), new(2, 1) },
        { new(0, 1), new(1, 1), new(1, 0), new(0, 2) },
    },
    
    // reverse Z shape XX████
    //                 ████
    {
        { new(1, 0), new(2, 0), new(0, 1), new(1, 1) },
        { new(0, 0), new(0, 1), new(1, 1), new(1, 2) },
        { new(1, 0), new(2, 0), new(0, 1), new(1, 1) },
        { new(0, 0), new(0, 1), new(1, 1), new(1, 2) },
    },

    // T shape  XX████
    //            ██
    {
        { new(0, 0), new(1, 0), new(1, 1), new(2, 0) },
        { new(0, 0), new(0, 1), new(1, 1), new(0, 2) },
        { new(0, 1), new(1, 0), new(1, 1), new(2, 1) },
        { new(0, 1), new(1, 0), new(1, 1), new(1, 2) },
    },

    // L XX████
    //   ██
    {
        {new(0,0), new(1, 0), new(2, 0), new(0, 1)},
        {new(0,0), new(0, 1), new(0, 2), new(1, 2)},
        {new(0,1), new(1, 1), new(2, 1), new(2, 0)},
        {new(0,0), new(1, 0), new(1, 1), new(1, 2)},
    },
    
    // reverse L XX████
    //               ██
    {
        {new(0,0), new(1, 0), new(2, 0), new(2, 1)},
        {new(0,0), new(1, 0), new(0, 1), new(0, 2)},
        {new(0,0), new(0, 1), new(1, 1), new(2, 1)},
        {new(1,0), new(1, 1), new(1, 2), new(0, 2)},
    },
};

ConsoleKeyInfo input;

var mapSize = new Vector2(10, 20);
var mapData = new Pixel[mapSize.X * mapSize.Y];
var startPos = new Vector2(4, 0);

Vector2 holdPos;
int holdId;
int holdRotation = 0;

var rng = new Random();

var cursorPosition = Console.GetCursorPosition();

int timer = 0;
int maxTime = 20;


foreach (ref var pixel in mapData.AsSpan())
{
    pixel = new Pixel();
}

var isGameRunning = true;

input = new ConsoleKeyInfo();
var inputThread = new Thread(Input);
inputThread.Start();

holdId = 0;
holdPos = startPos;

var clearedLines = 0;
var score = 0;

int[] scoreToReceive = { 40, 100, 300, 1200 };

int Level()
{
    return clearedLines / 10;
}

// TestPrintShapes();

while (isGameRunning)
{
    if (timer >= maxTime - Level())
    {
        if (CheckCollideOnMove(new Vector2(0, 1)))
            LockBlock();
        else
            holdPos += new Vector2(0, 1);

        timer = 0;
    }

    timer++;
    
    HandleInput();
    input = new ConsoleKeyInfo();
    
    Render();

    Thread.Sleep(50);
}

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("GAME OVER");
Console.WriteLine("Score: " + score);
Console.WriteLine();
Console.WriteLine();



#region Physics

bool CheckCollideOnMove(Vector2 offset)
{
    return CheckCollideBase(holdPos + offset, holdId, holdRotation);
}

bool CheckCollideOnShapeSwap(int newId)
{
    // reset all things
    return CheckCollideBase(startPos, newId, 0);
}


bool CheckCollideOnRotate(int rotationOffset)
{
    return CheckCollideBase(holdPos, holdId, (holdRotation + rotationOffset + 4) % 4);
}

bool CheckCollideBase(Vector2 holdPos, int holdId, int holdRotation)
{
    for (var i = 0; i < 4; i++)
    {
        var pixelCoord = holdPos + piecesShapes[holdId, holdRotation, i];
        
        // bounds check
        if (pixelCoord.X < 0 || pixelCoord.X >= mapSize.X
                              || pixelCoord.Y < 0 || pixelCoord.Y >= mapSize.Y)
            return true;
        // check if occupied
        if (mapData[pixelCoord.X + pixelCoord.Y * mapSize.X].IsOccupied)
            return true;
    }

    return false;
}

void LockBlock()
{
    for (int i = 0; i < 4; i++)
    {
        var currentPos = holdPos + piecesShapes[holdId, holdRotation, i];
        mapData[currentPos.X + currentPos.Y * mapSize.X] = piecesPixels[holdId];
    }

    int clearedLinesAtOnce = 0;
    
    for (int y = 0; y < mapSize.Y; y++)
    {
        bool isFull = true;
        
        for (int x = 0; x < mapSize.X; x++)
        {
            if (mapData[x + y * mapSize.X].IsOccupied) continue;
            
            // if is not full
            isFull = false;
            break;
        }

        // remove row
        if (isFull)
        {
            clearedLines++;
            clearedLinesAtOnce++;
            var buffer = new Pixel[mapSize.X * y];
            Array.Copy(mapData, 0, buffer, 0, mapSize.X * y);
            
            Array.Fill(mapData, new Pixel(), 0, mapSize.X * (y + 1));
            
            Array.Copy(buffer, 0, mapData, mapSize.X, mapSize.X * y);
        }
    }
    
    if (clearedLinesAtOnce > 0)
        score += (Level() + 1) * scoreToReceive[clearedLinesAtOnce - 1];
    
    holdId = rng.Next(7);
    holdPos = startPos;
    holdRotation = 0;

    if (CheckCollideOnMove(new Vector2()))
    {
        isGameRunning = false;
    }
}

#endregion

#region Input

void HandleInput()
{
    switch (input.Key)
    {
        // add keybinds
        case ConsoleKey.UpArrow:
        case ConsoleKey.W:
            if (!CheckCollideOnRotate(1))
            {
                holdRotation++;
                holdRotation %= 4;
            }
            break;
        
        case ConsoleKey.Spacebar:
            while (!CheckCollideOnMove(new Vector2(0, 1)))
            {
                holdPos += new Vector2(0, 1);
            }
            LockBlock();
            timer = 0;
            break;
        
        case ConsoleKey.DownArrow:
        case ConsoleKey.S:
            if (!CheckCollideOnMove(new Vector2(0, 1)))
            {
                holdPos += new Vector2(0, 1);
                timer = 0;
            }
            break;
        
        case ConsoleKey.LeftArrow:
        case ConsoleKey.A:
            if (!CheckCollideOnMove(new Vector2(-1, 0)))
                holdPos += new Vector2(-1, 0);
            break;
        
        case ConsoleKey.RightArrow:
        case ConsoleKey.D:
            if (!CheckCollideOnMove(new Vector2(1, 0)))
                holdPos += new Vector2(1, 0);
            break;

        default:
            break;
    }

    input = new ConsoleKeyInfo();
}

void Input()
{
    while (isGameRunning)
    {
        input = Console.ReadKey(true);
    }
}

#endregion

#region Render

void Render()
{
    Console.SetCursorPosition(cursorPosition.Left, cursorPosition.Top);
    
    for (var y = 0; y < mapSize.Y; y++)
    {
        for (var x = 0; x < mapSize.X; x++)
        {
            ref var pixel = ref mapData[x + y * mapSize.X];
            PrintPixel(pixel);
        }
        Console.WriteLine();
    }

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(score);

    for (var i = 0; i < 4; i++)
    {
        var currentPos = piecesShapes[holdId, holdRotation, i];
        Console.SetCursorPosition(cursorPosition.Left + 2 * (holdPos.X + currentPos.X),
            cursorPosition.Top + holdPos.Y + currentPos.Y);
        PrintPixel(piecesPixels[holdId]);        
    }
}

void PrintPixel(Pixel pixel)
{
    Console.ForegroundColor = pixel.Color;
    Console.Write(pixel.Character);
}

void TestPrintShapes()
{
    for (int y = 0; y < 28; y++)
    {
        for (int x = 0; x < 16; x++)
        {
            var itemId = y / 4;
            var itemShape = x / 4;

            var isDrawn = false;
        
            for (int i = 0; i < 4; i++)
            {
                if (x == itemShape * 4 + piecesShapes[itemId, itemShape, i].X
                    && y == itemId * 4 + piecesShapes[itemId, itemShape, i].Y)
                {
                    isDrawn = true;
                    break;
                }
            }
        
            Console.Write(isDrawn ? "██" : "  ");
        }
    
        Console.WriteLine();
    }
}

struct Pixel
{
    public bool IsOccupied { get; }
    public string Character { get; }
    public ConsoleColor Color { get; }

    public Pixel(bool isOccupied, string character, ConsoleColor color)
    {
        IsOccupied = isOccupied;
        Character = character;
        Color = color;
    }
    
    public Pixel() : this(false, "  ", ConsoleColor.Gray) { }

    public Pixel(Pixel pixel) : this(pixel.IsOccupied, pixel.Character, pixel.Color) { }
}

struct Vector2
{
    public sbyte X { get; }
    public sbyte Y { get; }
    
    public Vector2() : this(0, 0) { }

    public Vector2(Vector2 vector) : this(vector.Y, vector.X) { }
    
    public Vector2(sbyte x, sbyte y)
    {
        X = x;
        Y = y;
    }
    
    public static Vector2 operator + (Vector2 first, Vector2 second)
    {
        return new Vector2((sbyte)(first.X + second.X), (sbyte)(first.Y + second.Y));
    }
}
#endregion
