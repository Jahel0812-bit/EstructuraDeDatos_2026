using System;

class Program
{
    static void Main()
    {
        int x = 10;
        int y = 25;

        Console.WriteLine("=== MODIFICADOR REF ===");
        Console.WriteLine($"Antes: x = {x}, y = {y}");

        Intercambiar(ref x, ref y);
        Console.WriteLine($"Después: x = {x}, y = {y}");

        Console.WriteLine("\n=== MODIFICADOR OUT ===");

        int residuo;

        int cociente = CalcularYValidar(17, 5, out residuo);

        Console.WriteLine($"Cociente: {cociente}");
        Console.WriteLine($"Residuo: {residuo}");

        Console.WriteLine("\n=== REFERENCIAS A OBJETOS ===");

        Alumno alumno1 = new Alumno();

        alumno1.Nombre = "Juan";
        alumno1.Promedio = 9.5;

        Alumno alumno2 = alumno1;

        alumno2.Nombre = "Pedro";
        alumno2.Promedio = 8.0;

        Console.WriteLine($"Alumno 1: {alumno1.Nombre} - {alumno1.Promedio}");
        Console.WriteLine($"Alumno 2: {alumno2.Nombre} - {alumno2.Promedio}");
    }

    static void Intercambiar(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
    static int CalcularYValidar(int dividendo, int divisor, out int residuo)
    {
    if (divisor == 0)
    {
        residuo = 0;
        Console.WriteLine("Error: No se puede dividir entre cero.");
        return 0;
    }

    residuo = dividendo % divisor;
    return dividendo / divisor;
    }
}