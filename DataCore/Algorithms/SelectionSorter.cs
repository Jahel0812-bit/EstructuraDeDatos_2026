using System.Diagnostics;
using DataCore.Models;

namespace DataCore.Algorithms;

/// <summary>
/// Proporciona operaciones para ordenar registros
/// mediante el algoritmo Selection Sort.
/// </summary>
public static class SelectionSorter
{
    /// <summary>
    /// Ordena un arreglo de registros de menor a mayor
    /// utilizando el identificador como criterio.
    /// </summary>
    /// <param name="registros">
    /// Arreglo de registros que será ordenado.
    /// </param>
    /// <returns>
    /// Métricas obtenidas durante el proceso de ordenamiento.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Se produce cuando el arreglo recibido es nulo.
    /// </exception>
    public static MetricasOrdenacion OrdenarPorSeleccion(
        RegistroDatos[] registros)
    {
        ArgumentNullException.ThrowIfNull(registros);

        long comparaciones = 0;
        int intercambios = 0;

        Stopwatch cronometro = Stopwatch.StartNew();

        for (int i = 0; i < registros.Length - 1; i++)
        {
            int indiceMinimo = i;

            for (int j = i + 1; j < registros.Length; j++)
            {
                comparaciones++;

                if (registros[j].Id < registros[indiceMinimo].Id)
                {
                    indiceMinimo = j;
                }
            }

            if (indiceMinimo != i)
            {
                (registros[i], registros[indiceMinimo]) =
                    (registros[indiceMinimo], registros[i]);

                intercambios++;
            }
        }

        cronometro.Stop();

        return new MetricasOrdenacion(
            comparaciones,
            intercambios,
            cronometro.Elapsed.TotalMilliseconds);
    }
}