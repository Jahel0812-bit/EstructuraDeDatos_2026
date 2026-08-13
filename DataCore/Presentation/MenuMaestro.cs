using DataCore.Algorithms;
using DataCore.Models;
using System.Linq;

namespace DataCore.Presentation;

/// <summary>
/// Controla la interfaz interactiva principal de DataCore v4.0.
/// </summary>
public class MenuMaestro
{
    private readonly TablaDinamica tabla;

    /// <summary>
    /// Inicializa el menú con una tabla dinámica vacía.
    /// </summary>
    public MenuMaestro()
    {
        tabla = new TablaDinamica();
    }

    /// <summary>
    /// Inicia el ciclo principal del Menú Maestro.
    /// </summary>
    public void Ejecutar()
    {
        int opcion;

        do
        {
            MostrarMenu();

            opcion = LeerOpcion();

            Console.WriteLine();

            switch (opcion)
            {
                case 1:
                    InsertarRegistro();
                    break;

                case 2:
                    EliminarRegistro();
                    break;

                case 3:
                    MostrarRegistros();
                    break;

                case 4:
                    OrdenarRegistros();
                    break;

                case 5:
                    BuscarRegistro();
                    break;

                case 6:
                    if (ConfirmarSalida())
                    {
                        Console.WriteLine(
                            "DataCore finalizado correctamente.");

                        return;
                    }

                    break;

                default:
                    Console.WriteLine(
                        "Opción inválida. Intente nuevamente.");
                    break;
            }

            Pausar();

        } while (true);
    }

    private void MostrarMenu()
    {
        Console.Clear();

        int total =
            tabla.ObtenerComoArreglo().Length;

        Console.WriteLine(
            "===========================================");

        Console.WriteLine(
            "       DATACORE v4.0 - MENÚ MAESTRO");

        Console.WriteLine(
            "===========================================");

        Console.WriteLine(
            $" Registros actuales: {total}");

        Console.WriteLine();

        Console.WriteLine(" [1] Insertar registro");
        Console.WriteLine(" [2] Eliminar registro por Id");
        Console.WriteLine(" [3] Mostrar todos los registros");
        Console.WriteLine(" [4] Ordenar registros por Id");
        Console.WriteLine(" [5] Búsqueda avanzada");
        Console.WriteLine(" [6] Salir");

        Console.WriteLine(
            "===========================================");
    }

    private static int LeerOpcion()
    {
        Console.Write("Seleccione una opción: ");

        string? entrada =
            Console.ReadLine();

        if (int.TryParse(entrada, out int opcion))
        {
            return opcion;
        }

        return -1;
    }

   private void InsertarRegistro()
{
    Console.WriteLine(
        "--- INSERTAR REGISTRO ---");

    Console.Write("Id: ");

    if (!int.TryParse(
            Console.ReadLine(),
            out int id))
    {
        Console.WriteLine(
            "El Id debe ser un número entero.");

        return;
    }

    // Verificar el Id ANTES de insertar.
    RegistroDatos[] existentes =
        tabla.ObtenerComoArreglo();

    bool idDuplicado =
        existentes.Any(registro => registro.Id == id);

    if (idDuplicado)
    {
        Console.WriteLine(
            $"Ya existe un registro con Id {id}.");

        return;
    }

    Console.Write("Valor: ");

    if (!double.TryParse(
            Console.ReadLine(),
            out double valor))
    {
        Console.WriteLine(
            "El valor debe ser numérico.");

        return;
    }

    Console.Write("Etiqueta: ");

    string? etiqueta =
        Console.ReadLine();

    if (string.IsNullOrWhiteSpace(etiqueta))
    {
        Console.WriteLine(
            "La etiqueta no puede estar vacía.");

        return;
    }

    RegistroDatos registro =
        new(id, valor, etiqueta);

    tabla.InsertarFinal(registro);

    Console.WriteLine(
        $"Registro con Id {id} agregado correctamente.");
}

    private void EliminarRegistro()
    {
        Console.WriteLine(
            "--- ELIMINAR REGISTRO ---");

        Console.Write("Id a eliminar: ");

        if (!int.TryParse(
                Console.ReadLine(),
                out int id))
        {
            Console.WriteLine(
                "El Id debe ser un número entero.");

            return;
        }

        int antes =
            tabla.ObtenerComoArreglo().Length;

        tabla.EliminarPorId(id);

        int despues =
            tabla.ObtenerComoArreglo().Length;

        if (despues < antes)
        {
            Console.WriteLine(
                $"Registro {id} eliminado correctamente.");
        }
        else
        {
            Console.WriteLine(
                $"No se encontró el registro con Id {id}.");
        }
    }

    private void MostrarRegistros()
    {
        Console.WriteLine(
            "--- REGISTROS EN MEMORIA ---");

        RegistroDatos[] registros =
            tabla.ObtenerComoArreglo();

        if (registros.Length == 0)
        {
            Console.WriteLine(
                "La tabla se encuentra vacía.");

            return;
        }

        foreach (RegistroDatos registro in registros)
        {
            Console.WriteLine(registro);
        }
    }

    private void OrdenarRegistros()
    {
        Console.WriteLine(
            "--- ORDENAMIENTO POR ID ---");

        RegistroDatos[] registros =
            tabla.ObtenerComoArreglo();

        if (registros.Length == 0)
        {
            Console.WriteLine(
                "No hay registros para ordenar.");

            return;
        }

        QuickSorter.Ordenar(registros);

        foreach (RegistroDatos registro in registros)
        {
            Console.WriteLine(registro);
        }

        Console.WriteLine(
            "Arreglo auxiliar ordenado correctamente.");
    }

    private void BuscarRegistro()
    {
        Console.WriteLine(
            "--- BÚSQUEDA BINARIA INDEXADA ---");

        RegistroDatos[] registros =
            tabla.ObtenerComoArreglo();

        if (registros.Length == 0)
        {
            Console.WriteLine(
                "No existen registros para buscar.");

            return;
        }

        Console.Write("Id a buscar: ");

        if (!int.TryParse(
                Console.ReadLine(),
                out int id))
        {
            Console.WriteLine(
                "El Id debe ser un número entero.");

            return;
        }

        QuickSorter.Ordenar(registros);

        RegistroDatos? resultado =
            BuscadorIndexado.BuscarRegistroIndexado(
                registros,
                id,
                out int comparaciones);

        if (resultado.HasValue)
        {
            Console.WriteLine(
                $"Encontrado: {resultado.Value}");
        }
        else
        {
            Console.WriteLine(
                $"No existe un registro con Id {id}.");
        }

        Console.WriteLine(
            $"Comparaciones realizadas: {comparaciones}");
    }

    private static bool ConfirmarSalida()
    {
        Console.Write(
            "¿Desea salir del sistema? (S/N): ");

        string? respuesta =
            Console.ReadLine();

        return string.Equals(
            respuesta,
            "S",
            StringComparison.OrdinalIgnoreCase);
    }

    private static void Pausar()
    {
        Console.WriteLine();
        Console.WriteLine(
            "Presione ENTER para continuar...");

        Console.ReadLine();
    }
}