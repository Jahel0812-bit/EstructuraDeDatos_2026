using DataCore.Algorithms;
using DataCore.Models;

namespace DataCore.Tests.Algorithms;

public class SelectionSorterTests
{
    [Fact]
    public void OrdenarPorSeleccion_OrdenaCorrectamente()
    {
        RegistroDatos[] registros =
        {
            new RegistroDatos(3, 100, "A"),
            new RegistroDatos(1, 200, "B"),
            new RegistroDatos(2, 300, "C")
        };

        SelectionSorter.OrdenarPorSeleccion(registros);

        Assert.Equal(1, registros[0].Id);
        Assert.Equal(2, registros[1].Id);
        Assert.Equal(3, registros[2].Id);
    }

    [Fact]
    public void OrdenarPorSeleccion_DevuelveMetricas()
    {
        RegistroDatos[] registros =
        {
            new RegistroDatos(2, 100, "A"),
            new RegistroDatos(1, 200, "B")
        };

        MetricasOrdenacion metricas =
            SelectionSorter.OrdenarPorSeleccion(registros);

        Assert.True(metricas.TotalComparaciones > 0);
    }

    [Fact]
    public void OrdenarPorSeleccion_ArregloVacio_NoFalla()
    {
        RegistroDatos[] registros = [];

        MetricasOrdenacion metricas =
            SelectionSorter.OrdenarPorSeleccion(registros);

        Assert.Empty(registros);
    }

    [Fact]
    public void OrdenarPorSeleccion_UnElemento_NoModifica()
    {
        RegistroDatos[] registros =
        {
            new RegistroDatos(1, 100, "Único")
        };

        SelectionSorter.OrdenarPorSeleccion(registros);

        Assert.Equal(1, registros[0].Id);
    }
}