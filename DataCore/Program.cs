using DataCore.Algorithms;
using DataCore.Models;
using DataCore.Presentation;
using DataCore.Services;

namespace DataCore;

internal class Program
{
    static void Main()
    {
        try
{
    RegistroDatos[] registros =
    {
        new RegistroDatos(8, 80.0, "A"),
        new RegistroDatos(3, 30.0, "B"),
        new RegistroDatos(6, 60.0, "C"),
        new RegistroDatos(1, 10.0, "D"),
        new RegistroDatos(5, 50.0, "E")
    };

    ReporteConsola.MostrarRegistros(
        "ANTES DE QUICKSORT",
        registros);

    MetricasQuickSort metricasQuickSort =
    QuickSorter.Ordenar(registros);

    ReporteConsola.MostrarRegistros(
        "DESPUÉS DE QUICKSORT",
        registros);
        Console.WriteLine();
Console.WriteLine("=== MÉTRICAS QUICKSORT ===");
Console.WriteLine(
    $"Llamadas recursivas : {metricasQuickSort.LlamadasRecursivas}");
Console.WriteLine(
    $"Tiempo (ms)         : {metricasQuickSort.TiempoMilisegundos:F4}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(
                $"[ERROR DE VALIDACIÓN] {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                $"[ERROR INESPERADO] {ex.Message}");
        }
    }
}