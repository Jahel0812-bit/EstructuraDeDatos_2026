namespace DataCore.Models;

/// <summary>
/// Almacena las métricas obtenidas durante
/// la ejecución del algoritmo QuickSort.
/// </summary>
public sealed class MetricasQuickSort
{
    /// <summary>
    /// Número total de llamadas recursivas realizadas.
    /// </summary>
    public long LlamadasRecursivas { get; set; }

    /// <summary>
    /// Tiempo total empleado por el algoritmo.
    /// </summary>
    public double TiempoMilisegundos { get; set; }

    /// <summary>
/// Número total de comparaciones realizadas.
/// </summary>
public long TotalComparaciones { get; set; }

/// <summary>
/// Número total de intercambios realizados.
/// </summary>
public long TotalIntercambios { get; set; }
}