// ReSharper disable StringLiteralTypo
// ReSharper disable CommentTypo

namespace lab2_2_main; // Note: actual namespace depends on the project name.

internal static class Program
{
    //TODO: input these by hand
    //TODO: rotunjirea notei?
    private static string[] _studenti =
    {
        "Turcanu Cristian",
        "Elisa Mccormick",
        "Dave Jordan",
        "Dylon Snow",
        "Tommie Weber"
    };

    private static string[] _discipline =
    {
        "Tehnologii de programare",
        "Paradigme de programare",
        "Programare vizuala",
        "Teoria compilarii",
        "Tehnologii fara fir",
    };
    
    private static int[][][] _note = null!;
    
    static void Main(string[] args)
    {
        if (args.Length >= 1 && args[0] == "input")
        {
            //TODO: input students and disciplines
        }
        
        
        // generate
        var rng = new Random(0);
        _note = new int[_studenti.Length][][];
        
        for (var i = 0; i < _note.Length; i++)
        {
            _note[i] = new int[_discipline.Length][];
            for (var j = 0; j < _note[i].Length; j++)
            {
                _note[i][j] = new int[rng.Next(4, 10)];

                for (var k = 0; k < _note[i][j].Length; k++)
                    _note[i][j][k] = 10 - i - j; //rng.Next(2, 11);
            }
        }

        
        // print + avg
        Console.WriteLine("1. Media tuturor obiectelor la fiecare student:");
        for (var i = 0; i < _note.Length; i++)
        {
            Console.WriteLine(_studenti[i]);
            for (var j = 0; j < _note[i].Length; j++)
            {
                Console.Write(_discipline[j] + ": ");

                for (var k = 0; k < _note[i][j].Length; k++)
                    Console.Write($"{_note[i][j][k]} ");
                
                Console.WriteLine($": {_note[i][j].Average():##.##}");
            }
            Console.WriteLine();
        }
        
        
        // cati restantieri in grupa
        Console.WriteLine($"2. Restantierii din grupa:");
        var numRestantieri = 0;
        for (var i = 0; i < _note.Length; i++)
        for (var j = 0; j < _note[i].Length; j++)
            if (_note[i][j].Average() < 5.0)
            {
                Console.WriteLine(_studenti[i] + " " + _discipline[j] + " " + _note[i][j].Average());
                numRestantieri++;
                break;
            }
        Console.WriteLine($"{numRestantieri} restantieri");
        Console.WriteLine();
        
        
        // student cu nota maxima
        var maxStudent = 0;
        double maxAverage = 0;
        for (var i = 0; i < _note.Length; i++)
        {
            double average = 0;
            for (var j = 0; j < _note[i].Length; j++)
                average += _note[i][j].Average();

            average /= _discipline.Length;

            if (average > maxAverage)
            {
                maxAverage = average;
                maxStudent = i;
            }
        }
        
        Console.WriteLine($"3. Student cu media maxima: {_studenti[maxStudent]} : {maxAverage:##.##}");
        Console.WriteLine();
        

        Console.WriteLine("4. Media pe obiecte:");
        for (var j = 0; j < _discipline.Length; j++)
        {
            var avg = _note.Sum(t => t[j].Average()) / _studenti.Length;
            
            Console.WriteLine($"{_discipline[j]} : {avg:##.##}");
        }
        Console.WriteLine();
        

        Console.WriteLine("5. Studenti cu bursa:");
        for (var i = 0; i < _note.Length; i++)
        {
            var average = _note[i].Sum(t => t.Average()) / _discipline.Length;
            
            if (average >= 8)
                Console.WriteLine($"{_studenti[i]}");
        }
        Console.WriteLine();

        
        Console.WriteLine("6. Obiectul cel mai bun a fiecarui student:");
        for (int i = 0; i < _note.Length; i++)
        {
            double maxAverageDiscipline = 0;
            int maxDiscipline = 0;

            for (int j = 0; j < _note[i].Length; j++)
            {
                var average = _note[i][j].Average();
                if (average > maxAverageDiscipline)
                {
                    maxDiscipline = j;
                    maxAverageDiscipline = average;
                }
            }
            
            Console.WriteLine($"{_studenti[i]} : {_discipline[maxDiscipline]} : {maxAverageDiscipline:##.##}");
        }

        int minDiscipline = 0;
        double minAverage = 10;
        for (var j = 0; j < _discipline.Length; j++)
        {
            var avg = _note.Sum(t => t[j].Average()) / _studenti.Length;

            if (avg < minAverage)
            {
                minAverage = avg;
                minDiscipline = j;
            }
        }
        Console.WriteLine();

        Console.WriteLine($"7. Cel mai greu obiect: {_discipline[minDiscipline]} cu media {minAverage:##.##}");
    }
}
