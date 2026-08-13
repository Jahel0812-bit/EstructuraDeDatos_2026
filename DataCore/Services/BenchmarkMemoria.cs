using DataCore.Models;
using System.Diagnostics;

namespace DataCore.Services;
/// <summary>
/// Proporciona operaciones para comparar el rendimiento
/// y uso aproximado de memoria entre estructuras de datos.
/// </summary>
public static class BenchmarkMemoria
{
        /// <summary>
    /// Ejecuta un benchmark con la cantidad de registros indicada
    /// para comparar un arreglo estático y una lista enlazada.
    /// </summary>
    /// <param name="cantidad">
    /// Número de registros que se utilizarán durante la prueba.
    /// </param>
    public static void Ejecutar(int cantidad)
    {
        Console.WriteLine();
        Console.WriteLine(
            $"=== BENCHMARK MEMORIA: {cantidad:N0} REGISTROS ===");

        MedirArreglo(cantidad);
        MedirLista(cantidad);
    }

    private static void MedirArreglo(int cantidad)
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        long memoriaAntes =
            GC.GetTotalMemory(true);

        Stopwatch reloj =
            Stopwatch.StartNew();

        RegistroDatos[] arreglo =
            new RegistroDatos[cantidad];

        for (int i = 0; i < cantidad; i++)
        {
            arreglo[i] = new RegistroDatos(
                i + 1,
                (i + 1) * 100,
                $"Registro-{i + 1}");
        }

        reloj.Stop();

        long memoriaDespues =
            GC.GetTotalMemory(false);

        long memoriaUsada =
            memoriaDespues - memoriaAntes;

        Console.WriteLine();
        Console.WriteLine("--- Arreglo estático ---");
        Console.WriteLine(
            $"Tiempo de inserción : {reloj.Elapsed.TotalMilliseconds:F4} ms");
        Console.WriteLine(
            $"Memoria aproximada  : {memoriaUsada:N0} bytes");
    }

    private static void MedirLista(int cantidad)
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        long memoriaAntes =
            GC.GetTotalMemory(true);

        Stopwatch reloj =
            Stopwatch.StartNew();

        TablaDinamica lista =
            new();

        for (int i = 0; i < cantidad; i++)
        {
            lista.InsertarFinal(
                new RegistroDatos(
                    i + 1,
                    (i + 1) * 100,
                    $"Registro-{i + 1}"));
        }

        reloj.Stop();

        long memoriaDespues =
            GC.GetTotalMemory(false);

        long memoriaUsada =
            memoriaDespues - memoriaAntes;

        Console.WriteLine();
        Console.WriteLine("--- Lista enlazada ---");
        Console.WriteLine(
            $"Tiempo de inserción : {reloj.Elapsed.TotalMilliseconds:F4} ms");
        Console.WriteLine(
            $"Memoria aproximada  : {memoriaUsada:N0} bytes");
    }
}