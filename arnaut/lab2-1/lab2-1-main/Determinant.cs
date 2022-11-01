namespace lab2_1_main;

public static class Determinant
{
    public static Rational BareissAlgorithm(this Rational[,] input)
    {
        if (input.Length == 0 || input.GetLength(0) != input.GetLength(1))
        {
            Console.WriteLine("WARNING: irregular set given");
            return new Rational();
        }

        var n = input.GetLength(0);

        var matrix = new Rational[n, n];
        Array.Copy(input, matrix, input.Length);

        
        // for (var i = 0; i < n; i++)
        // {
        //     for (var j = 0; j < n; j++) Console.Write($"{matrix[i, j]} ");
        //     Console.WriteLine();
        // }
        // Console.WriteLine();


        for (var k = 0; k < n-1; k++)
        for (var i = k+1; i < n; i++)
        for (var j = k+1; j < n; j++)
        {
            matrix[i, j] = (matrix[i, j] * matrix[k, k] - matrix[i, k] * matrix[k, j]);
            
            if (k != 0)
                matrix[i, j] /= matrix[k - 1, k - 1];
        }

        // for (var i = 0; i < n; i++)
        // {
        //     for (var j = 0; j < n; j++) Console.Write($"{matrix[i, j]} ");
        //     Console.WriteLine();
        // }
        // Console.WriteLine();

        
        return matrix[n - 1, n - 1];
    }
}