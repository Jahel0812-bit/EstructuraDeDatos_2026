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
    int[] tamanos = { 100, 1_000, 10_000 };

foreach (int tamanio in tamanos)
{
    Console.WriteLine();
    Console.WriteLine(
        $"=== BENCHMARK CON {tamanio:N0} REGISTROS ===");

    RegistroDatos[] registros =
        GeneradorRegistros.Crear(tamanio);

    RegistroDatos[] copiaSeleccion =
        (RegistroDatos[])registros.Clone();

    RegistroDatos[] copiaQuickSort =
        (RegistroDatos[])registros.Clone();

    MetricasOrdenacion metricasSelection =
        SelectionSorter.OrdenarPorSeleccion(
            copiaSeleccion);

    MetricasQuickSort metricasQuick =
        QuickSorter.Ordenar(
            copiaQuickSort);

    bool selectionOrdenado =
        ValidadorOrdenamiento.EstaOrdenado(
            copiaSeleccion);

    bool quickSortOrdenado =
        ValidadorOrdenamiento.EstaOrdenado(
            copiaQuickSort);

    Console.WriteLine();
    Console.WriteLine("--- Selection Sort ---");
    Console.WriteLine(
        $"Comparaciones : {metricasSelection.TotalComparaciones:N0}");
    Console.WriteLine(
        $"Intercambios  : {metricasSelection.TotalIntercambios:N0}");
    Console.WriteLine(
        $"Tiempo (ms)   : {metricasSelection.TiempoMs:F4}");

    Console.WriteLine();
    Console.WriteLine("--- QuickSort ---");
    Console.WriteLine(
        $"Llamadas recursivas : {metricasQuick.LlamadasRecursivas:N0}");
    Console.WriteLine(
        $"Tiempo (ms)         : {metricasQuick.TiempoMilisegundos:F4}");

    Console.WriteLine();
    Console.WriteLine("--- Validación ---");
    Console.WriteLine(
        $"Selection Sort : {(selectionOrdenado ? "ORDENADO" : "ERROR")}");
    Console.WriteLine(
        $"QuickSort      : {(quickSortOrdenado ? "ORDENADO" : "ERROR")}");
}
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