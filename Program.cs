using System.Diagnostics;
using System.Numerics;

public class Program
{
    private static readonly Stopwatch stopWatch = Stopwatch.StartNew();
    
    public static void Main(string[] args)
    {
        BigInteger number = 10000;
        System.Console.WriteLine($"Testing different algorithms for the n = {number} factorial problem \n");

        MeasureExecutionTime(n => ClassicFactorial(n), number, "Classic Factorial");
        MeasureExecutionTime(n => RecursiveFactorial(n), number, "Recursive Factorial");
        MeasureExecutionTime(n => TailRecursiveFactorial(n), number, "Tail Recursive Factorial");
    }

    private static void MeasureExecutionTime(Func<BigInteger, BigInteger> factorialMethod, BigInteger number, string methodName)
    {
        
        stopWatch.Start();
        BigInteger result = factorialMethod(number);
        stopWatch.Stop();

        Console.WriteLine($"{methodName} : Time = {stopWatch.Elapsed.TotalSeconds}");
    }

    private static BigInteger ClassicFactorial(BigInteger number)
    {
        BigInteger result = 1;
        for (BigInteger i = number; i > 0; i--)
        {
            result *= i;
        }

        return result;
    }

    private static BigInteger RecursiveFactorial(BigInteger number)
    {
        if (number < 2)
            return 1;

        return number * RecursiveFactorial(number - 1);
    }

    private static BigInteger TailRecursiveFactorial(BigInteger number, BigInteger? result = null)
    {
        if (number == 0)
            return result ?? 1;

        return TailRecursiveFactorial(number - 1, number * (result ?? number));
    }
}