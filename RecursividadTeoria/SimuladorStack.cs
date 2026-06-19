using System;

public static class SimuladorStack
{
    public static void ImprimirCuentaRegresiva(int numero)
    {
        Console.WriteLine($"Entrando: {numero}");

        if (numero <= 0)
        {
            Console.WriteLine("Caso base alcanzado.");
            return;
        }

        ImprimirCuentaRegresiva(numero - 1);

        Console.WriteLine($"Saliendo: {numero}");
    }
}