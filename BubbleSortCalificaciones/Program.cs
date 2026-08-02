using System;

class Program
{
    static void Main()
    {
        try
        {
            const int cantidad = 100;

            int[] calificaciones = new int[cantidad];
            Random random = new Random();

            for (int i = 0; i < cantidad; i++)
            {
                calificaciones[i] = random.Next(0, 101);
            }

            Console.WriteLine("=== CALIFICACIONES GENERADAS ===\n");

            for (int i = 0; i < cantidad; i++)
            {
                Console.Write($"{calificaciones[i]} ");

                if ((i + 1) % 10 == 0)
                {
                    Console.WriteLine();
                }
            }

            int totalIntercambios = OrdenarPorBurbuja(calificaciones);

            Console.WriteLine("\n=== CALIFICACIONES ORDENADAS ===\n");

            for (int i = 0; i < cantidad; i++)
            {
                Console.Write($"{calificaciones[i]} ");

                if ((i + 1) % 10 == 0)
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine(
                $"\nTotal de intercambios realizados: {totalIntercambios}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocurrió un error: {ex.Message}");
        }
    }

    static int OrdenarPorBurbuja(int[] arr)
{
    int contadorIntercambios = 0;
    int n = arr.Length;

    for (int i = 0; i < n - 1; i++)
    {
        bool huboIntercambio = false;

        for (int j = 0; j < n - i - 1; j++)
        {
            if (arr[j] > arr[j + 1])
            {
                (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);

                contadorIntercambios++;
                huboIntercambio = true;
            }
        }

        if (!huboIntercambio)
        {
            Console.WriteLine($"\nEl arreglo quedó ordenado en la pasada {i + 1}.");
            break;
        }
    }

    return contadorIntercambios;
}
}