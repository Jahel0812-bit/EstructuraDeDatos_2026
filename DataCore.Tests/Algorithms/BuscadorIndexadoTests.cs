using DataCore.Algorithms;
using DataCore.Models;

namespace DataCore.Tests.Algorithms;

public class BuscadorIndexadoTests
{
    [Fact]
    public void BuscarRegistroIndexado_IdExistente_RegresaRegistro()
    {
        RegistroDatos[] registros =
        {
            new(1, 100, "Registro-1"),
            new(2, 200, "Registro-2"),
            new(3, 300, "Registro-3"),
            new(4, 400, "Registro-4"),
            new(5, 500, "Registro-5")
        };

        RegistroDatos? resultado =
            BuscadorIndexado.BuscarRegistroIndexado(
                registros,
                4,
                out int comparaciones);

        Assert.NotNull(resultado);
        Assert.Equal(4, resultado.Value.Id);
        Assert.True(comparaciones > 0);
    }

    [Fact]
    public void BuscarRegistroIndexado_IdInexistente_RegresaNull()
    {
        RegistroDatos[] registros =
        {
            new(1, 100, "Registro-1"),
            new(2, 200, "Registro-2"),
            new(3, 300, "Registro-3"),
            new(4, 400, "Registro-4"),
            new(5, 500, "Registro-5")
        };

        RegistroDatos? resultado =
            BuscadorIndexado.BuscarRegistroIndexado(
                registros,
                99,
                out int comparaciones);

        Assert.Null(resultado);
        Assert.True(comparaciones > 0);
    }

    [Fact]
    public void BuscarRegistroIndexado_ArregloVacio_RegresaNull()
    {
        RegistroDatos[] registros =
            Array.Empty<RegistroDatos>();

        RegistroDatos? resultado =
            BuscadorIndexado.BuscarRegistroIndexado(
                registros,
                1,
                out int comparaciones);

        Assert.Null(resultado);
        Assert.Equal(0, comparaciones);
    }

    [Fact]
    public void BuscarRegistroIndexado_UnElemento_EncuentraCorrectamente()
    {
        RegistroDatos[] registros =
        {
            new(10, 1000, "Registro-10")
        };

        RegistroDatos? resultado =
            BuscadorIndexado.BuscarRegistroIndexado(
                registros,
                10,
                out int comparaciones);

        Assert.NotNull(resultado);
        Assert.Equal(10, resultado.Value.Id);
        Assert.Equal(1, comparaciones);
    }

[Fact]
public void BuscarRegistroIndexado_DesdeTablaDinamica_EncuentraRegistro()
{
    TablaDinamica tabla = new();

    tabla.InsertarFinal(
        new RegistroDatos(8, 800, "Registro-8"));

    tabla.InsertarFinal(
        new RegistroDatos(2, 200, "Registro-2"));

    tabla.InsertarFinal(
        new RegistroDatos(15, 1500, "Registro-15"));

    tabla.InsertarFinal(
        new RegistroDatos(5, 500, "Registro-5"));

    tabla.InsertarFinal(
        new RegistroDatos(11, 1100, "Registro-11"));

    RegistroDatos[] registros =
        tabla.ObtenerComoArreglo();

    QuickSorter.Ordenar(registros);

    RegistroDatos? resultado =
        BuscadorIndexado.BuscarRegistroIndexado(
            registros,
            11,
            out int comparaciones);

    Assert.NotNull(resultado);
    Assert.Equal(11, resultado.Value.Id);
    Assert.True(comparaciones > 0);
}
}