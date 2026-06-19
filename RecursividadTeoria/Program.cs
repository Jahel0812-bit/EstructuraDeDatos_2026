using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== EJERCICIO A: SIMULACIÓN DEL CALL STACK ===");

        SimuladorStack.ImprimirCuentaRegresiva(5);

        Console.WriteLine("\n=== EJERCICIO B: SUMA RECURSIVA ===");

        int numero = Validador.LeerNumero();

        int resultado = Validador.SumarHasta(numero);

        Console.WriteLine($"La suma de 1 hasta {numero} es: {resultado}");
    }
}