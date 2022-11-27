namespace lab3;

internal class Program
{
    static void Main(string[] args)
    {
        #region Constructors

        Console.WriteLine("1. Testam constructorii");
        
        Console.WriteLine("Constructor gol: " + new MyString());

        Console.WriteLine("Constructor cu parametru string: " + new MyString("string"));
        
        Console.WriteLine($"Constructor cu parametru MyString: {new MyString(new MyString("MyString"))}");
        
        Console.Write("Constructor cu parametru char[]: ");
        Console.WriteLine(new MyString(new[] {'c', 'h', 'a', 'r', 's'}));

        Console.WriteLine();
        
        #endregion

        #region Indexer

        var stringToIndex = new MyString("Indexer");
        
        Console.WriteLine("2. Testam indexerul");
        Console.WriteLine("Stringul initial este: " + stringToIndex);
        
        stringToIndex[0] = 'i';
        stringToIndex[1] = 'N';
        stringToIndex[2] = 'd';
        stringToIndex[3] = 'E';
        stringToIndex[4] = 'x';
        stringToIndex[5] = 'E';
        stringToIndex[6] = 'r';
        
        Console.WriteLine("Stringul dupa modificare este: " + stringToIndex);
        
        Console.WriteLine();

        #endregion
        
        #region Properties
        
        Console.WriteLine("3. Testam proprietatile");
        
        Console.WriteLine("String gol prin proprietati: " + MyString.Empty);
        Console.WriteLine("Lungimea stringului indexer: " + stringToIndex.Length);
        Console.WriteLine("Este stringul indexer gol? " + stringToIndex.IsEmpty);
        
        Console.WriteLine();
        
        #endregion
        
        #region Methods
        
        Console.WriteLine("4. Testam metodele");
        
        var stringToCharArray = new MyString("ToCharArray");
        var charArray = stringToCharArray.ToCharArray();
        
        Console.WriteLine("Initiem stringul ToCharArray si il convertim in char[]: " + stringToCharArray + " -> " + new string(charArray));
        
        charArray[0] = 't';
        charArray[1] = 'O';
        charArray[2] = 'c';
        charArray[3] = 'H';
        charArray[4] = 'a';
        charArray[5] = 'R';
        charArray[6] = 'a';
        charArray[7] = 'R';
        charArray[8] = 'r';
        charArray[9] = 'A';
        charArray[10] = 'y';
        
        Console.WriteLine("Modificam char[] si il comparam cu stringul ToCharArray: " + stringToCharArray + " -> " + new string(charArray));
        
        Console.WriteLine("Convertim MyString in string: " + stringToCharArray + " -> " + stringToCharArray.ToString());
        
        Console.WriteLine("Enumeram elementele din MyString: ");
        
        foreach (var c in stringToCharArray)
        {
            Console.Write(c + " ");
        }
        Console.WriteLine();
        
        Console.WriteLine("Luam o parte din MyString: " + stringToCharArray.Substring(2, 4));
        
        Console.WriteLine("Concatenam parti din stringuri: " + stringToCharArray.Concat(charArray, 0, 2));
        
        Console.WriteLine();
        
        #endregion

        #region Operators

        var first = new MyString("first");
        var second = new MyString("second");
        
        Console.WriteLine("5. Testam operatorii");
        Console.WriteLine("Adunam stringurile first si second: " + (first + second));
        
        Console.WriteLine("Comparam stringurile first si second: " + (first == second));
        
        Console.WriteLine("MyString automat se convertesc in string, altfel nu ar fi printate");
        #endregion
    }
}