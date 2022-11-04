// ReSharper disable StringLiteralTypo
// ReSharper disable CommentTypo

namespace lab2_2_main;

internal static class Program
{
    private static List<string> _studenti = new ()
    {
        "Turcanu Cristian",
        "Elisa Mccormick",
        "Dave Jordan",
        "Dylon Snow",
        "Tommie Weber"
    };

    private static List<string> _discipline = new ()
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
            _studenti.Clear();

            while (true)
            {
                Console.WriteLine("Dati numele studentului, string gol pentru continuare");
                var input = Console.ReadLine();
                
                if (input is null or "")
                    break;
                
                _studenti.Add(input);
            }

            _discipline.Clear();
            
            while (true)
            {
                Console.WriteLine("Dati numele obiectului, string gol pentru continuare");
                var input = Console.ReadLine();
                
                if (input is null or "")
                    break;
                
                _discipline.Add(input);
            }
        }

        foreach (var student in _studenti) 
        {
            Console.Write(student + " ");
        }

        foreach (var discipline in _discipline)   
        {
            Console.Write(discipline + " ");
        }
        
        // generate
        var rng = new Random(0);
        _note = new int[_studenti.Count][][];
        
        for (var i = 0; i < _note.Length; i++)
        {
            _note[i] = new int[_discipline.Count][];
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

            average /= _discipline.Count;

            if (average > maxAverage)
            {
                maxAverage = average;
                maxStudent = i;
            }
        }
        
        Console.WriteLine($"3. Student cu media maxima: {_studenti[maxStudent]} : {maxAverage:##.##}");
        Console.WriteLine();
        

        Console.WriteLine("4. Media pe obiecte:");
        for (var j = 0; j < _discipline.Count; j++)
        {
            var avg = _note.Sum(t => t[j].Average()) / _studenti.Count;
            
            Console.WriteLine($"{_discipline[j]} : {avg:##.##}");
        }
        Console.WriteLine();
        

        Console.WriteLine("5. Studenti cu bursa:");
        for (var i = 0; i < _note.Length; i++)
        {
            var average = _note[i].Sum(t => t.Average()) / _discipline.Count;
            
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
        for (var j = 0; j < _discipline.Count; j++)
        {
            var avg = _note.Sum(t => t[j].Average()) / _studenti.Count;

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
