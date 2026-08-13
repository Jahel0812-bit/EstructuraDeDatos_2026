using DataCore.Models;

namespace DataCore.Algorithms;

/// <summary>
/// Proporciona operaciones de búsqueda binaria
/// sobre arreglos de RegistroDatos ordenados por Id.
/// </summary>
public static class BuscadorIndexado
{
    /// <summary>
    /// Busca un registro por su Id utilizando búsqueda binaria.
    /// </summary>
    /// <param name="registros">
    /// Arreglo previamente ordenado de forma ascendente por Id.
    /// </param>
    /// <param name="idBuscado">
    /// Identificador que se desea localizar.
    /// </param>
    /// <param name="comparaciones">
    /// Devuelve la cantidad de comparaciones realizadas.
    /// </param>
    /// <returns>
    /// El RegistroDatos encontrado o null si el Id no existe.
    /// </returns>
    public static RegistroDatos? BuscarRegistroIndexado(
        RegistroDatos[] registros,
        int idBuscado,
        out int comparaciones)
    {
        ArgumentNullException.ThrowIfNull(registros);

        comparaciones = 0;

        int izquierda = 0;
        int derecha = registros.Length - 1;

        while (izquierda <= derecha)
        {
            int medio =
                izquierda + (derecha - izquierda) / 2;

            comparaciones++;

            if (registros[medio].Id == idBuscado)
            {
                return registros[medio];
            }

            if (registros[medio].Id < idBuscado)
            {
                izquierda = medio + 1;
            }
            else
            {
                derecha = medio - 1;
            }
        }

        return null;
    }
}