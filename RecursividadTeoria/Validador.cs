using System;

public static class Validador
{
    public static int LeerNumero()
    {
        while (true)
        {
            Console.Write("Ingrese un número entero: ");

            string? entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int numero))
            {
                return numero;
            }

            Console.WriteLine("Entrada inválida. Intente nuevamente.");
        }
    }

    public static int SumarHasta(int n)
    {
        if (n <= 0)
            return 0;

        return n + SumarHasta(n - 1);
    }
}