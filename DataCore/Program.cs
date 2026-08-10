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
        GeneradorRegistros.Crear(10_000);

    RegistroDatos[] copiaSeleccion =
        (RegistroDatos[])registros.Clone();

    RegistroDatos[] copiaQuickSort =
        (RegistroDatos[])registros.Clone();

    Console.WriteLine(
        $"Original       : {registros.Length} registros");

    Console.WriteLine(
        $"Copia Selection: {copiaSeleccion.Length} registros");

    Console.WriteLine(
        $"Copia QuickSort: {copiaQuickSort.Length} registros");
    
    Console.WriteLine();
Console.WriteLine("Ejecutando Selection Sort...");

MetricasOrdenacion metricasSelection =
    SelectionSorter.OrdenarPorSeleccion(copiaSeleccion);

Console.WriteLine("Selection Sort terminado.");

Console.WriteLine();
Console.WriteLine("Ejecutando QuickSort...");

MetricasQuickSort metricasQuick =
    QuickSorter.Ordenar(copiaQuickSort);

Console.WriteLine("QuickSort terminado.");

bool selectionOrdenado =
    ValidadorOrdenamiento.EstaOrdenado(copiaSeleccion);

bool quickSortOrdenado =
    ValidadorOrdenamiento.EstaOrdenado(copiaQuickSort);

Console.WriteLine();
Console.WriteLine("=== RESULTADOS DEL BENCHMARK ===");

Console.WriteLine();
Console.WriteLine("--- Selection Sort ---");
Console.WriteLine(
    $"Comparaciones : {metricasSelection.TotalComparaciones}");
Console.WriteLine(
    $"Intercambios  : {metricasSelection.TotalIntercambios}");
Console.WriteLine(
    $"Tiempo (ms)   : {metricasSelection.TiempoMs:F4}");

Console.WriteLine();
Console.WriteLine("--- QuickSort ---");
Console.WriteLine(
    $"Llamadas recursivas : {metricasQuick.LlamadasRecursivas}");
Console.WriteLine(
    $"Tiempo (ms)         : {metricasQuick.TiempoMilisegundos:F4}");

    Console.WriteLine();
Console.WriteLine("=== VALIDACIÓN ===");

Console.WriteLine(
    $"Selection Sort : {(selectionOrdenado ? "ORDENADO" : "ERROR")}");

Console.WriteLine(
    $"QuickSort      : {(quickSortOrdenado ? "ORDENADO" : "ERROR")}");
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