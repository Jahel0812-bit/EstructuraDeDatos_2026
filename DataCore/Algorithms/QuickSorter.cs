using DataCore.Models;
using System.Diagnostics;

namespace DataCore.Algorithms;

/// <summary>
/// Proporciona métodos para ordenar registros
/// mediante el algoritmo QuickSort.
/// </summary>
public static class QuickSorter
{
    /// <summary>
    /// Ordena un arreglo de registros mediante QuickSort.
    /// </summary>
    /// <param name="datos">
    /// Arreglo de registros que será ordenado.
    /// </param>
    /// <param name="izquierda">
    /// Índice inicial del segmento a ordenar.
    /// </param>
    /// <param name="derecha">
    /// Índice final del segmento a ordenar.
    /// </param>
    public static MetricasQuickSort Ordenar(RegistroDatos[] datos)
{
    ArgumentNullException.ThrowIfNull(datos);

    MetricasQuickSort metricas = new();

    Stopwatch reloj = Stopwatch.StartNew();

    if (datos.Length > 1)
    {
        OrdenarRecursivo(
            datos,
            0,
            datos.Length - 1,
            metricas);
    }

    reloj.Stop();

    metricas.TiempoMilisegundos =
        reloj.Elapsed.TotalMilliseconds;

    return metricas;
}

private static void OrdenarRecursivo(
    RegistroDatos[] datos,
    int izquierda,
    int derecha,
    MetricasQuickSort metricas)
{
    if (izquierda >= derecha)
    {
        return;
    }

    int indice = Particionar(
        datos,
        izquierda,
        derecha,
        metricas);

    if (izquierda < indice - 1)
    {
        metricas.LlamadasRecursivas++;

        OrdenarRecursivo(
            datos,
            izquierda,
            indice - 1,
            metricas);
    }

    if (indice < derecha)
    {
        metricas.LlamadasRecursivas++;

        OrdenarRecursivo(
            datos,
            indice,
            derecha,
            metricas);
    }
}

    private static int Particionar(
    RegistroDatos[] datos,
    int izquierda,
    int derecha,
    MetricasQuickSort metricas)
{
    int indicePivote =
        izquierda + (derecha - izquierda) / 2;

    int idPivote =
        datos[indicePivote].Id;

    int i = izquierda;
    int j = derecha;

    while (i <= j)
    {
        while (true)
        {
            metricas.TotalComparaciones++;

            if (datos[i].Id >= idPivote)
            {
                break;
            }

            i++;
        }

        while (true)
        {
            metricas.TotalComparaciones++;

            if (datos[j].Id <= idPivote)
            {
                break;
            }

            j--;
        }

        if (i <= j)
        {
            if (i != j)
            {
                (datos[i], datos[j]) =
                    (datos[j], datos[i]);

                metricas.TotalIntercambios++;
            }

            i++;
            j--;
        }
    }

    return i;
}
}