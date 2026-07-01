using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Ingresa un número entre 35 y 43: ");
        string? input = Console.ReadLine();

        if (!int.TryParse(input, out int n) || n < 0 || n > 43)
        {
            Console.WriteLine("Error: ingresa un número positivo entre 35 y 43.");
            return;
        }

        Stopwatch sw = new Stopwatch();

        Console.WriteLine("\n=== FIBONACCI RECURSIVO INSEGURO ===");

        sw.Restart();
        long resultadoInseguro = FibonacciInseguro(n);
        sw.Stop();

        Console.WriteLine($"Inseguro: F({n}) = {resultadoInseguro}");
        Console.WriteLine($"Tiempo: {sw.ElapsedMilliseconds} ms");

        Console.WriteLine("\n=== FIBONACCI CON MEMOIZATION ===");

        long[] cache = new long[n + 1];

        for (int i = 0; i <= n; i++)
        {
            cache[i] = -1;
        }

        sw.Restart();
        long resultadoPro = FibonacciPro(n, cache);
        sw.Stop();

        Console.WriteLine($"Pro: F({n}) = {resultadoPro}");
        Console.WriteLine($"Tiempo: {sw.ElapsedMilliseconds} ms");
    }

    public static long FibonacciInseguro(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;

        return FibonacciInseguro(n - 1) + FibonacciInseguro(n - 2);
    }

    public static long FibonacciPro(int n, long[] cache)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;

        if (cache[n] != -1)
        {
            return cache[n];
        }

        cache[n] = FibonacciPro(n - 1, cache) + FibonacciPro(n - 2, cache);

        return cache[n];
    }
}