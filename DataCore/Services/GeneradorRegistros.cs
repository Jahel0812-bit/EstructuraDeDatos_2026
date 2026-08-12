using DataCore.Models;

namespace DataCore.Services;

/// <summary>
/// Proporciona métodos para generar registros de prueba.
/// </summary>
public static class GeneradorRegistros
{
    /// <summary>
    /// Crea una cantidad determinada de registros
    /// con identificadores únicos y desordenados.
    /// </summary>
    /// <param name="cantidad">
    /// Número de registros que se crearán.
    /// </param>
    /// <returns>
    /// Arreglo con los registros generados.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Se produce cuando la cantidad no es mayor que cero.
    /// </exception>
    public static RegistroDatos[] Crear(int cantidad)
    {
        if (cantidad <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(cantidad),
                "La cantidad debe ser mayor que cero.");
        }

        RegistroDatos[] registros = new RegistroDatos[cantidad];
        int[] ids = new int[cantidad];

        for (int i = 0; i < cantidad; i++)
        {
            ids[i] = i + 1;
        }

        Random random = new Random(42);

        for (int i = ids.Length - 1; i > 0; i--)
        {
            int indiceAleatorio = random.Next(i + 1);

            (ids[i], ids[indiceAleatorio]) =
                (ids[indiceAleatorio], ids[i]);
        }

        for (int i = 0; i < cantidad; i++)
        {
            registros[i] = new RegistroDatos(
                ids[i],
                Math.Round(random.NextDouble() * 1000, 2),
                $"Registro {ids[i]}");
        }

        return registros;
    }
}