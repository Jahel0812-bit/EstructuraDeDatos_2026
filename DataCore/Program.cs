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
    $"Comparaciones       : {metricasQuick.TotalComparaciones:N0}");

Console.WriteLine(
    $"Intercambios        : {metricasQuick.TotalIntercambios:N0}");

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

Console.WriteLine();
Console.WriteLine("=== CASO EXTREMO: ARREGLO ORDENADO ===");

RegistroDatos[] ordenados = new RegistroDatos[1_000];

for (int i = 0; i < ordenados.Length; i++)
{
    ordenados[i] = new RegistroDatos(
        i + 1,
        i + 1,
        $"Registro {i + 1}");
}

RegistroDatos[] ordenadosSelection =
    (RegistroDatos[])ordenados.Clone();

RegistroDatos[] ordenadosQuick =
    (RegistroDatos[])ordenados.Clone();

MetricasOrdenacion metricasSelectionOrdenado =
    SelectionSorter.OrdenarPorSeleccion(
        ordenadosSelection);

MetricasQuickSort metricasQuickOrdenado =
    QuickSorter.Ordenar(
        ordenadosQuick);

Console.WriteLine(
    $"Selection Sort : {metricasSelectionOrdenado.TiempoMs:F4} ms");

Console.WriteLine(
    $"QuickSort      : {metricasQuickOrdenado.TiempoMilisegundos:F4} ms");

Console.WriteLine(
    $"Selection válido: {ValidadorOrdenamiento.EstaOrdenado(ordenadosSelection)}");

Console.WriteLine(
    $"QuickSort válido : {ValidadorOrdenamiento.EstaOrdenado(ordenadosQuick)}");

Console.WriteLine(
    $"Comparaciones QuickSort : {metricasQuickOrdenado.TotalComparaciones:N0}");

Console.WriteLine(
    $"Intercambios QuickSort  : {metricasQuickOrdenado.TotalIntercambios:N0}");

Console.WriteLine(
    $"Llamadas recursivas     : {metricasQuickOrdenado.LlamadasRecursivas:N0}");

Console.WriteLine();
Console.WriteLine("=== CASO EXTREMO: ARREGLO INVERSO ===");

RegistroDatos[] inversos = new RegistroDatos[1_000];

for (int i = 0; i < inversos.Length; i++)
{
    int id = inversos.Length - i;

    inversos[i] = new RegistroDatos(
        id,
        id,
        $"Registro {id}");
}

RegistroDatos[] inversosSelection =
    (RegistroDatos[])inversos.Clone();

RegistroDatos[] inversosQuick =
    (RegistroDatos[])inversos.Clone();

MetricasOrdenacion metricasSelectionInverso =
    SelectionSorter.OrdenarPorSeleccion(
        inversosSelection);

MetricasQuickSort metricasQuickInverso =
    QuickSorter.Ordenar(
        inversosQuick);

Console.WriteLine(
    $"Selection Sort : {metricasSelectionInverso.TiempoMs:F4} ms");

Console.WriteLine(
    $"QuickSort      : {metricasQuickInverso.TiempoMilisegundos:F4} ms");

Console.WriteLine(
    $"Selection válido: {ValidadorOrdenamiento.EstaOrdenado(inversosSelection)}");

Console.WriteLine(
    $"QuickSort válido : {ValidadorOrdenamiento.EstaOrdenado(inversosQuick)}");

Console.WriteLine(
    $"Comparaciones QuickSort : {metricasQuickInverso.TotalComparaciones:N0}");

Console.WriteLine(
    $"Intercambios QuickSort  : {metricasQuickInverso.TotalIntercambios:N0}");

Console.WriteLine(
    $"Llamadas recursivas     : {metricasQuickInverso.LlamadasRecursivas:N0}");

Console.WriteLine();
Console.WriteLine("=== CASO EXTREMO: ELEMENTOS REPETIDOS ===");

RegistroDatos[] repetidos = new RegistroDatos[1_000];

for (int i = 0; i < repetidos.Length; i++)
{
    int id = (i % 10) + 1;

    repetidos[i] = new RegistroDatos(
        id,
        i + 1,
        $"Registro {id}");
}

RegistroDatos[] repetidosSelection =
    (RegistroDatos[])repetidos.Clone();

RegistroDatos[] repetidosQuick =
    (RegistroDatos[])repetidos.Clone();

MetricasOrdenacion metricasSelectionRepetidos =
    SelectionSorter.OrdenarPorSeleccion(
        repetidosSelection);

MetricasQuickSort metricasQuickRepetidos =
    QuickSorter.Ordenar(
        repetidosQuick);

Console.WriteLine(
    $"Selection Sort : {metricasSelectionRepetidos.TiempoMs:F4} ms");

Console.WriteLine(
    $"QuickSort      : {metricasQuickRepetidos.TiempoMilisegundos:F4} ms");

Console.WriteLine(
    $"Selection válido: {ValidadorOrdenamiento.EstaOrdenado(repetidosSelection)}");

Console.WriteLine(
    $"QuickSort válido : {ValidadorOrdenamiento.EstaOrdenado(repetidosQuick)}");

Console.WriteLine(
    $"Comparaciones QuickSort : {metricasQuickRepetidos.TotalComparaciones:N0}");

Console.WriteLine(
    $"Intercambios QuickSort  : {metricasQuickRepetidos.TotalIntercambios:N0}");

Console.WriteLine(
    $"Llamadas recursivas     : {metricasQuickRepetidos.LlamadasRecursivas:N0}");

Console.WriteLine();
Console.WriteLine("=== FASE 3: LISTA SIMPLEMENTE ENLAZADA ===");

TablaDinamica tablaDinamica = new();

Console.WriteLine();
Console.WriteLine("--- Inserción de 15 registros ---");

for (int i = 1; i <= 15; i++)
{
    RegistroDatos registro = new(
    i,
    i * 100,
    $"Transaccion-{i}");

    tablaDinamica.InsertarFinal(registro);

    Console.WriteLine(
        $"[INSERT] Registro {i} añadido a la cadena.");
}

Console.WriteLine();
Console.WriteLine("--- Eliminando registros con Id 5 y Id 11 ---");

tablaDinamica.EliminarPorId(5);
tablaDinamica.EliminarPorId(11);

Console.WriteLine(
    "Cadena reestructurada exitosamente.");

RegistroDatos[] arregloDinamico =
    tablaDinamica.ObtenerComoArreglo();

Console.WriteLine();
Console.WriteLine(
    $"Registros en arreglo: {arregloDinamico.Length} (esperado: 13)");

MetricasQuickSort metricasLista =
    QuickSorter.Ordenar(arregloDinamico);

Console.WriteLine();
Console.WriteLine("--- Arreglo ordenado por Id con QuickSort ---");

foreach (RegistroDatos registro in arregloDinamico)
{
    Console.WriteLine(
    $"Id: {registro.Id} | " +
    $"Valor: {registro.Valor:F2} | " +
    $"Etiqueta: {registro.Etiqueta}");
}

Console.WriteLine();
Console.WriteLine(
    $"QuickSort válido: {ValidadorOrdenamiento.EstaOrdenado(arregloDinamico)}");
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