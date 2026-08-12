using DataCore.Algorithms;
using DataCore.Models;
using DataCore.Services;

namespace DataCore.Tests.Algorithms;

public class QuickSorterTests
{
    [Fact]
    public void Ordenar_ArregloVacio_NoLanzaExcepcion()
    {
        RegistroDatos[] datos = [];

        Exception? excepcion = Record.Exception(
            () => QuickSorter.Ordenar(datos));

        Assert.Null(excepcion);
        Assert.Empty(datos);
    }

    [Fact]
public void Ordenar_UnElemento_ConservaElRegistro()
{
    RegistroDatos[] datos =
    {
        new RegistroDatos(
            1,
            100.0,
            "Registro 1")
    };

    QuickSorter.Ordenar(datos);

    Assert.Single(datos);
    Assert.Equal(1, datos[0].Id);
}

[Fact]
public void Ordenar_DosElementosOrdenados_ConservaElOrden()
{
    RegistroDatos[] datos =
    {
        new RegistroDatos(1, 10.0, "Registro 1"),
        new RegistroDatos(2, 20.0, "Registro 2")
    };

    QuickSorter.Ordenar(datos);

    Assert.Equal(1, datos[0].Id);
    Assert.Equal(2, datos[1].Id);
}

[Fact]
public void Ordenar_DosElementosInvertidos_LosOrdena()
{
    RegistroDatos[] datos =
    {
        new RegistroDatos(2, 20.0, "Registro 2"),
        new RegistroDatos(1, 10.0, "Registro 1")
    };

    QuickSorter.Ordenar(datos);

    Assert.Equal(1, datos[0].Id);
    Assert.Equal(2, datos[1].Id);
}

[Fact]
public void Ordenar_IdsRepetidos_LosOrdenaCorrectamente()
{
    RegistroDatos[] datos =
    {
        new RegistroDatos(3, 30.0, "A"),
        new RegistroDatos(1, 10.0, "B"),
        new RegistroDatos(3, 35.0, "C"),
        new RegistroDatos(2, 20.0, "D"),
        new RegistroDatos(1, 15.0, "E")
    };

    QuickSorter.Ordenar(datos);

    Assert.True(
        ValidadorOrdenamiento.EstaOrdenado(datos));
}

[Fact]
public void Ordenar_ArregloAleatorio_QuedaOrdenado()
{
    RegistroDatos[] datos =
        GeneradorRegistros.Crear(100);

    QuickSorter.Ordenar(datos);

    Assert.True(
        ValidadorOrdenamiento.EstaOrdenado(datos));
}
}