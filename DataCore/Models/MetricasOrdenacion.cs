namespace DataCore.Models;

/// <summary>
/// Representa las métricas obtenidas durante
/// una ejecución del algoritmo de ordenamiento.
/// </summary>
public readonly struct MetricasOrdenacion
{
    /// <summary>
    /// Obtiene el número total de comparaciones realizadas.
    /// </summary>
    public long TotalComparaciones { get; }

    /// <summary>
    /// Obtiene el número total de intercambios realizados.
    /// </summary>
    public int TotalIntercambios { get; }

    /// <summary>
    /// Obtiene el tiempo total de ejecución en milisegundos.
    /// </summary>
    public double TiempoMs { get; }

    /// <summary>
/// Inicializa una nueva instancia de MetricasOrdenacion.
/// </summary>
/// <param name="totalComparaciones">
/// Número de comparaciones realizadas.
/// </param>
/// <param name="totalIntercambios">
/// Número de intercambios realizados.
/// </param>
/// <param name="tiempoMs">
/// Tiempo de ejecución en milisegundos.
/// </param>
public MetricasOrdenacion(
    long totalComparaciones,
    int totalIntercambios,
    double tiempoMs)
{
    TotalComparaciones = totalComparaciones;
    TotalIntercambios = totalIntercambios;
    TiempoMs = tiempoMs;
}

/// <summary>
/// Devuelve una representación legible de las métricas.
/// </summary>
public override string ToString()
{
    return
        $"Comparaciones : {TotalComparaciones}\n" +
        $"Intercambios  : {TotalIntercambios}\n" +
        $"Tiempo (ms)   : {TiempoMs:F3}";
}
}