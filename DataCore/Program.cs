using DataCore.Algorithms;
using DataCore.Models;
using DataCore.Presentation;
using DataCore.Services;

namespace DataCore;

internal class Program
{
    static void Main()
    {
        try
        {
            RegistroDatos[] registros =
                GeneradorRegistros.Crear(40);

            ReporteConsola.MostrarRegistros(
                "ANTES DEL ORDENAMIENTO",
                registros);

            MetricasOrdenacion metricas =
                SelectionSorter.OrdenarPorSeleccion(registros);

            ReporteConsola.MostrarRegistros(
                "DESPUÉS DEL ORDENAMIENTO",
                registros);

            ReporteConsola.MostrarMetricas(metricas);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(
                $"[ERROR DE VALIDACIÓN] {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                $"[ERROR INESPERADO] {ex.Message}");
        }
    }
}