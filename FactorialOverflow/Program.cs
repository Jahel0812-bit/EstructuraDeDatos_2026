using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== COMPARACIÓN DE FACTORIAL ===\n");

        for (int i = 1; i <= 20; i++)
        {
            Console.WriteLine(
                $"n={i:D2} | Recursivo: {FactorialInt(i),15} | Iterativo: {FactorialIterativo(i),15}");
        }

        Console.WriteLine("\n === FACTORIAL CON BIGINTEGER ===");
        BigInteger numeroGrande = 100;
        BigInteger resultado = FactorialProfesional(numeroGrande);
        Console.WriteLine($"100! = {resultado}");
    }

    static int FactorialInt(int n)
    {
        if (n == 0 || n == 1)
            return 1;

        return n * FactorialInt(n - 1);
    }

    static int FactorialIterativo(int n)
    {
        int resultado = 1;

        for (int i = 2; i <= n; i++)
        {
            resultado *= i;
        }

        return resultado;
    }

    static BigInteger FactorialProfesional(BigInteger n)
    {
        if (n <= 1)
        return 1;
        return n * FactorialProfesional(n - 1);
    }
}