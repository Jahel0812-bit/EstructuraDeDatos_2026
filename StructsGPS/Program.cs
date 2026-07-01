using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== STRUCTS GPS ===");

        // Ciudad de México
        CoordenadaGPS c1 = new CoordenadaGPS(19.4326, -99.1332);

        // Copia por valor
        CoordenadaGPS c2 = c1;

        // Reasignamos c2 a Berlín
        c2 = new CoordenadaGPS(52.5200, 13.4050);

        Console.WriteLine("\n--- c1: Ciudad de México ---");
        c1.ImprimirUbicacion();

        Console.WriteLine("\n--- c2: Berlín ---");
        c2.ImprimirUbicacion();

        Console.WriteLine("\n=== VALIDACIÓN DE COORDENADAS ===");

        try
        {
            Console.Write("Latitud: ");
            double latitud = double.Parse(Console.ReadLine()!);

            Console.Write("Longitud: ");
            double longitud = double.Parse(Console.ReadLine()!);

            CoordenadaGPS coordenadaUsuario = new CoordenadaGPS(latitud, longitud);

            Console.WriteLine("\nCoordenada ingresada:");
            coordenadaUsuario.ImprimirUbicacion();
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Error de rango: {ex.Message}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: debes ingresar valores numéricos.");
        }
    }
}