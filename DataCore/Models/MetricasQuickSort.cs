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
}