using DataCore.Models;

namespace DataCore.Services;

/// <summary>
/// Proporciona métodos para validar
/// el resultado de los algoritmos de ordenamiento.
/// </summary>
public static class ValidadorOrdenamiento
{
    /// <summary>
    /// Determina si un arreglo está ordenado
    /// ascendentemente por Id.
    /// </summary>
    public static bool EstaOrdenado(
        RegistroDatos[] registros)
    {
        ArgumentNullException.ThrowIfNull(registros);

        for (int i = 0; i < registros.Length - 1; i++)
        {
            if (registros[i].Id > registros[i + 1].Id)
            {
                return false;
            }
        }

        return true;
    }
}