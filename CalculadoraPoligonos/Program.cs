class Program
{
    static void Main()
    {
        int lados = SeleccionarPoligono();
        double lado;
        double apotema;

        PedirDatos(out lado, out apotema);
        double area = CalcularArea(lados, lado, apotema);
        Console.WriteLine($"El área del polígono es: {area}");
    }
static int SeleccionarPoligono()
    {
        while (true)
        {
            Console.WriteLine("Seleccione un polígono:");
            Console.WriteLine("1. Penágono");
            Console.WriteLine("2. Hexágono");
            Console.WriteLine("3. Heptágono");

            string entrada = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(entrada, out int opcion))
            {
                if (opcion == 1)
                return 5;
                else if (opcion == 2)
                    return 6;
                else if (opcion == 3)
                    return 7;
            }
            Console.WriteLine("Entrada Invalida. Intente Nuevamente. \n");
            }
    }
static void PedirDatos(out double lado, out double apotema)
{
    Console.WriteLine("Ingrese la longitud del lado: ");
    lado = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("Ingrese la longitud del apotema: ");
    apotema = Convert.ToDouble(Console.ReadLine());
}
static double CalcularArea(int lados, double lado, double apotema)
{
    double perimetro = lados* lado;
    double area = (perimetro * apotema) / 2;
    return area;
}
}