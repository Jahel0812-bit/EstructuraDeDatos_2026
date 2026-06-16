using System;
class Program
{
    static void Main()
    {
        while (true)
        {
        Console.WriteLine("=== RECURSIVIDAD ===");
        Console.WriteLine("1. Calcular Factorial");
        Console.WriteLine("2. Calcular Fibonacci");
        Console.WriteLine("3. Salir");

        Console.Write("Seleccione una opción: ");
        if (!int.TryParse(Console.ReadLine(), out int opcion))
        {
            Console.WriteLine("Opcion Invalida. \n");
            continue;
        }

        switch (opcion)
        {
            case 1:
                Console.Write("Ingrese un numero: ");
                 if (int.TryParse(Console.ReadLine(), out int numero))
                {
                 try
                        {
                            Console.WriteLine($"{numero}! = {CalcularFactorial(numero)}\n");
                        }
                catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}\n");
                        }
                }
                break;
            case 2:
                Console.WriteLine("Ingresa una posicion: ");
                if (int.TryParse(Console.ReadLine(), out int posicion))
                    {
                        try
                        {
                            Console.WriteLine($"Fibonacci({posicion}) = {CalcularFibonacci(posicion)}\n");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}\n");
                        }
                    }
                break;
            case 3:
                Console.WriteLine("Salir");
                return;
            default:
                Console.WriteLine("Opcion Invalida. \n");
                break;
        }
        }
    static long CalcularFactorial(int n)
    {
        if (n < 0) throw new ArgumentException("No existe factorial de negativos");
        if (n <= 1) return 1;
        return n * CalcularFactorial(n - 1);
    }
    static long CalcularFibonacci(int n)
    {
        if (n < 0) throw new ArgumentException("n debe ser un entero positivo");
        if (n <= 1) return n;
        return CalcularFibonacci(n - 1) + CalcularFibonacci(n - 2);
    }
    }  
}