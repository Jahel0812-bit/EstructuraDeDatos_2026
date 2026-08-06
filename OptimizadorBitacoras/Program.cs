using System;

class Program
{
    static void Main()
    {
        try
        {
            Transaccion[] bitacora = new Transaccion[50];
            Random random = new Random();

            // Primeras 45 transacciones: IDs ordenados.
            for (int i = 0; i < 45; i++)
            {
                bitacora[i] = new Transaccion(
                    id: i + 1,
                    monto: Math.Round(random.NextDouble() * 9999.99 + 0.01, 2),
                    timestamp: DateTimeOffset.UtcNow
                        .ToUnixTimeMilliseconds() + i * 100
                );
            }

            // Últimas 5 transacciones: registros fuera de orden.
            int[] idsDesordenados = { 78, 3, 99, 12, 55 };

            for (int i = 0; i < idsDesordenados.Length; i++)
            {
                bitacora[45 + i] = new Transaccion(
                    id: idsDesordenados[i],
                    monto: Math.Round(random.NextDouble() * 9999.99 + 0.01, 2),
                    timestamp: DateTimeOffset.UtcNow
                        .ToUnixTimeMilliseconds() + (45 + i) * 100
                );
            }

            Console.WriteLine(
                "=== OPTIMIZADOR DE BITÁCORAS DE TRANSACCIONES ===\n");

            Console.WriteLine("--- ANTES DEL ORDENAMIENTO ---");

            ImprimirBitacora(bitacora);

            int totalDesplazamientos =
                OrdenarPorInsercion(bitacora);

            Console.WriteLine("\n--- DESPUÉS DEL ORDENAMIENTO ---");

            ImprimirBitacora(bitacora);

            int peorCaso = bitacora.Length * (bitacora.Length - 1) / 2;

            double eficiencia =
                (1 - (double)totalDesplazamientos / peorCaso) * 100;

            Console.WriteLine(
                $"\nTotal de desplazamientos realizados: " +
                $"{totalDesplazamientos}");

            Console.WriteLine(
                $"Eficiencia: {eficiencia:F1}% mejor que el peor caso.");
        }
        catch (OverflowException ex)
        {
            Console.WriteLine(
                $"[ERROR] Desbordamiento de datos: {ex.Message}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine(
                $"[ERROR] Formato de entrada inválido: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                $"[ERROR] Excepción inesperada: {ex.Message}");
        }
    }

    static int OrdenarPorInsercion(Transaccion[] arr)
    {
        int contadorDesplazamientos = 0;

        for (int i = 1; i < arr.Length; i++)
        {
            Transaccion clave = arr[i];
            int j = i - 1;

            while (j >= 0 && arr[j].Id > clave.Id)
            {
                arr[j + 1] = arr[j];
                contadorDesplazamientos++;
                j--;
            }

            arr[j + 1] = clave;
        }

        return contadorDesplazamientos;
    }

    static void ImprimirBitacora(Transaccion[] arr)
    {
        foreach (Transaccion transaccion in arr)
        {
            Console.WriteLine(transaccion);
        }
    }
}