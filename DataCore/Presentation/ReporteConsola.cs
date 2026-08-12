using DataCore.Models;

namespace DataCore.Presentation;

/// <summary>
/// Muestra información del sistema en la consola.
/// </summary>
public static class ReporteConsola
{
    /// <summary>
/// Muestra un conjunto de registros en la consola.
/// </summary>
/// <param name="titulo">
/// Título que se mostrará antes de los registros.
/// </param>
/// <param name="registros">
/// Registros que se imprimirán.
/// </param>
public static void MostrarRegistros(
    string titulo,
    RegistroDatos[] registros)
{
    Console.WriteLine($"\n=== {titulo} ===\n");

    foreach (RegistroDatos registro in registros)
    {
        Console.WriteLine(registro);
    }
}

/// <summary>
/// Muestra las métricas del algoritmo.
/// </summary>
/// <param name="metricas">
/// Métricas obtenidas durante el ordenamiento.
/// </param>
public static void MostrarMetricas(
    MetricasOrdenacion metricas)
{
    Console.WriteLine("\n=== MÉTRICAS ===\n");
    Console.WriteLine(metricas);
}
}