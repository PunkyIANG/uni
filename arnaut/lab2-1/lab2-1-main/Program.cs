namespace lab2_1_main;

internal static class Program
{
    enum LaunchConfig
    {
        Default,
        Input,
        Random,
    }
    static void Main(string[] args)
    {
        var n = args.Length >= 1 ? int.Parse(args[0]) : 3;

        var config = args.Length switch
        {
            >= 2 when args[1] == "input" => LaunchConfig.Input,
            >= 2 => LaunchConfig.Random,
            _ => LaunchConfig.Default
        };

        var coefficients = new Rational[n, n];
        var constants = new Rational[1, n];

        switch (config)
        {
            case LaunchConfig.Input:
            {
                for (var i = 0; i < n; i++)
                {
                    for (var j = 0; j < n; j++)
                    {
                        Console.Write($"Dati coeficientul {j} a ecuatiei {i}: ");
                        while (!Rational.TryParse(Console.ReadLine(), out coefficients[j, i]))
                            Console.WriteLine($"Input incorect, dati coeficientul {j} a ecuatiei {i}: ");
                    }

                    Console.Write($"Dati constanta ecuatiei {i}: ");
                    while (!Rational.TryParse(Console.ReadLine(), out constants[0, i]))
                        Console.WriteLine($"Input incorect, dati constanta ecuatiei {i}: ");
                }

                break;
            }
            case LaunchConfig.Random:
            {
                var rng = new Random();
                for (var i = 0; i < n; i++)
                {
                    for (var j = 0; j < coefficients.GetLength(1); j++)
                        coefficients[i, j] = new Rational(rng.Next(-10, 10), rng.Next(1, 6));

                    constants[0, i] = new Rational(rng.Next(-10, 10), rng.Next(1, 6));
                }

                break;
            }
            case LaunchConfig.Default:
            {
                coefficients = new Rational[,]
                {
                    {1, 0, 1},
                    {1, 1, -2},
                    {1, 3, 1}
                };
                constants = new Rational[,]
                {
                    {6, 11, 0}
                };
                break;
            }
        }


        Console.WriteLine("Ecuatiile:");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                // coefficients[j,i]
                if (j != 0)
                {
                    Console.Write(coefficients[j,i].IsPositive() ? " + " : " - ");
                }
                
                coefficients[j,i].PrintNoSign();
                Console.Write(Extras.Unknown(j));
            }
            
            Console.WriteLine($" = {constants[0, i]}");
        }
        Console.WriteLine();
        
        
        
        var dx = new Rational[constants.Length,constants.Length];
        var coefficientDeterminant = coefficients.BareissAlgorithm();
        
        for (var i = 0; i < constants.Length; i++)
        {
            Array.Copy(coefficients, dx, coefficients.Length);
            Array.Copy(constants, 0, dx, i * constants.Length, constants.Length);
        
            var dxDeterminant = dx.BareissAlgorithm();
            
            // Console.WriteLine($"{Extras.Unknown(i)} = {dxDeterminant} / {coefficientDeterminant}" +
            //                       $" = {dxDeterminant  /  coefficientDeterminant}");
            Console.WriteLine($"{Extras.Unknown(i)} = {dxDeterminant / coefficientDeterminant}");

        }

    }
}