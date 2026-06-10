using System;
class Program
{
    static void Main()
    {
        int numero = 5;

        int[] arreglo = {1, 2, 3};

        Console.WriteLine("ANTES");
        Console.WriteLine("numero = " + numero);
        Console.WriteLine("arreglo[0] = " + arreglo[0]);

        CambiarValor(numero);

        CambiarReferencia(arreglo);

        Console.WriteLine("\nDESPUES");
        Console.WriteLine("numero = " + numero);
        Console.WriteLine("arreglo[0] = " + arreglo[0]);
    }
    static void CambiarValor(int x)
    {
        x = 100;
        Console.WriteLine("Valor dentro de CambiarValor: " + x);
    }

    static void CambiarReferencia(int[] arr)
    {
        arr[0] = 100;
        Console.WriteLine("Valor dentro de CambiarReferencia: " + arr[0]);
    }
}