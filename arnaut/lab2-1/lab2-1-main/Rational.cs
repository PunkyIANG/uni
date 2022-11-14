namespace lab2_1_main;

public readonly struct Rational
{
    private readonly int _numerator = 0;
    private readonly int _denominator = 1;

    public bool IsZero => _numerator == 0;
    
    public Rational()
    {
    }

    public Rational(int numerator = 0, int denominator = 1)
    {
        _numerator = numerator;
        _denominator = denominator;
        
        ReduceFraction(ref _numerator, ref _denominator);

        if (_denominator == 0)
            throw new DivideByZeroException("Denominator should not be zero");
    }
    
    public Rational(float dValue)
    {
        try
        {
            checked
            {
                if (dValue % 1 == 0) // if whole number
                {
                    _numerator = (int)dValue;
                }
                else
                {
                    float dTemp = dValue;
                    int iMultiple = 1;
                    string strTemp = dValue.ToString();
                    while (strTemp.IndexOf("E") > 0) // if in the form like 12E-9
                    {
                        dTemp *= 10;
                        iMultiple *= 10;
                        strTemp = dTemp.ToString();
                    }
    
                    int i = 0;
                    while (strTemp[i] != '.')
                        i++;
                    int iDigitsAfterDecimal = strTemp.Length - i - 1;
                    while (iDigitsAfterDecimal > 0)
                    {
                        dTemp *= 10;
                        iMultiple *= 10;
                        iDigitsAfterDecimal--;
                    }
    
                    _numerator = (int)Math.Round(dTemp);
                    _denominator = iMultiple;
                }
            }
        }
        catch (OverflowException)
        {
            throw new Exception("Conversion not possible due to overflow");
        }
        catch (Exception)
        {
            throw new Exception("Conversion not possible");
        }
        
        ReduceFraction(ref _numerator, ref _denominator);
    }

    public static Rational operator +(Rational first, Rational second)
    {
        var denominator = LowestCommonDenominator(first._denominator, second._denominator);

        var numerator = first._numerator * denominator / first._denominator +
                        second._numerator * denominator / second._denominator;

        return new Rational(numerator, denominator);
    }

    public static Rational operator -(Rational first, Rational second)
    {
        var denominator = LowestCommonDenominator(first._denominator, second._denominator);

        var numerator = first._numerator * denominator / first._denominator -
                        second._numerator * denominator / second._denominator;

        return new Rational(numerator, denominator);
    }

    public static Rational operator *(Rational first, Rational second)
    {
        return new Rational(first._numerator * second._numerator, first._denominator * second._denominator);
    }

    public static Rational operator /(Rational first, Rational second)
    {
        return new Rational(first._numerator * second._denominator, first._denominator * second._numerator);
    }

    public static int GetCommonDenominator(int first, int second)
    {
        while (true)
        {
            if (first == 0) return second;

            var first1 = first;
            first = second % first;
            second = first1;
        }
    }

    public static int LowestCommonDenominator(int first, int second)
    {
        return (first * second) / GetCommonDenominator(first, second);
    }

    public static void ReduceFraction(ref int numerator, ref int denominator)
    {
        var newDenominator = GetCommonDenominator(numerator, denominator);

        numerator = numerator / newDenominator;
        denominator = denominator / newDenominator;

        if (denominator == 0)
            throw new DivideByZeroException("Denominator should not be zero");

        if (numerator > 0 && denominator < 0)
        {
            numerator *= -1;
            denominator *= -1;
        }
    }
    
    public override string ToString()
    {
        if (_denominator == 1)
            return $"{_numerator}";

        return $"{_numerator}/{_denominator}";
    }

    public void PrintNoSign()
    {
        if (_denominator == 1)
            Console.Write($"{Math.Abs(_numerator)}");
        else
            Console.Write($"{Math.Abs(_numerator)}/{_denominator}");
    }

    public static bool TryParse(string input, out Rational output)
    {
        output = new Rational();

        var strings = input.Split(' ', '/');

        var floats = new float[strings.Length];

        // check that it all parses and save results
        if (strings.Where((s, index) => !float.TryParse(s, out floats[index])).Any())
        {
            Console.WriteLine("WARNING: unhandled case, invalid rational number");
            return false;
        }

        switch (floats.Length)
        {
            case 1:
                output = new Rational(floats[0]);
                break;

            case 2:
                output = new Rational(floats[0]) / new Rational(floats[1]);
                break;

            default:
                Console.WriteLine("WARNING: unhandled case, invalid rational number");
                return false;
        }
        return true;
    }

    public static implicit operator Rational(int num) => new Rational(num);
    public static implicit operator Rational(float num) => new Rational(num);

    public bool IsPositive() => _numerator >= 0;
}