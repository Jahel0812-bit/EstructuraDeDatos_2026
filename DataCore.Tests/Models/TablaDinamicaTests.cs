using DataCore.Algorithms;
using DataCore.Models;
using DataCore.Services;

namespace DataCore.Tests.Models;

public class TablaDinamicaTests
{
    [Fact]
    public void InsertarFinal_TresRegistros_ConservaElOrden()
    {
        TablaDinamica tabla = new();

        tabla.InsertarFinal(
            new RegistroDatos(3, 300, "HASH-3"));

        tabla.InsertarFinal(
            new RegistroDatos(1, 100, "HASH-1"));

        tabla.InsertarFinal(
            new RegistroDatos(2, 200, "HASH-2"));

        RegistroDatos[] resultado =
            tabla.ObtenerComoArreglo();

        Assert.Equal(3, resultado.Length);
        Assert.Equal(3, resultado[0].Id);
        Assert.Equal(1, resultado[1].Id);
        Assert.Equal(2, resultado[2].Id);
    }

    [Fact]
public void ObtenerComoArreglo_ListaVacia_RegresaArregloVacio()
{
    TablaDinamica tabla = new();

    RegistroDatos[] resultado = tabla.ObtenerComoArreglo();

    Assert.Empty(resultado);
}

[Fact]
public void InsertarInicio_UnRegistro_ConservaElRegistro()
{
    TablaDinamica tabla = new();

    tabla.InsertarInicio(
        new RegistroDatos(10, 100, "HASH-10"));

    RegistroDatos[] resultado = tabla.ObtenerComoArreglo();

    Assert.Single(resultado);
    Assert.Equal(10, resultado[0].Id);
}

[Fact]
public void EliminarPorId_PrimerNodo_EliminaCorrectamente()
{
    TablaDinamica tabla = new();

    tabla.InsertarFinal(new RegistroDatos(1, 100, "HASH-1"));
    tabla.InsertarFinal(new RegistroDatos(2, 200, "HASH-2"));
    tabla.InsertarFinal(new RegistroDatos(3, 300, "HASH-3"));

    tabla.EliminarPorId(1);

    RegistroDatos[] resultado = tabla.ObtenerComoArreglo();

    Assert.Equal(2, resultado.Length);
    Assert.Equal(2, resultado[0].Id);
    Assert.Equal(3, resultado[1].Id);
}

[Fact]
public void EliminarPorId_UltimoNodo_EliminaCorrectamente()
{
    TablaDinamica tabla = new();

    tabla.InsertarFinal(new RegistroDatos(1, 100, "HASH-1"));
    tabla.InsertarFinal(new RegistroDatos(2, 200, "HASH-2"));
    tabla.InsertarFinal(new RegistroDatos(3, 300, "HASH-3"));

    tabla.EliminarPorId(3);

    RegistroDatos[] resultado = tabla.ObtenerComoArreglo();

    Assert.Equal(2, resultado.Length);
    Assert.Equal(1, resultado[0].Id);
    Assert.Equal(2, resultado[1].Id);
}

[Fact]
public void ObtenerComoArreglo_PermiteOrdenarConQuickSortYSelectionSort()
{
    TablaDinamica tabla = new();

    tabla.InsertarFinal(new RegistroDatos(5, 500, "Registro-5"));
    tabla.InsertarFinal(new RegistroDatos(2, 200, "Registro-2"));
    tabla.InsertarFinal(new RegistroDatos(4, 400, "Registro-4"));
    tabla.InsertarFinal(new RegistroDatos(1, 100, "Registro-1"));
    tabla.InsertarFinal(new RegistroDatos(3, 300, "Registro-3"));

    RegistroDatos[] original =
        tabla.ObtenerComoArreglo();

    RegistroDatos[] paraQuickSort =
        (RegistroDatos[])original.Clone();

    RegistroDatos[] paraSelectionSort =
        (RegistroDatos[])original.Clone();

    QuickSorter.Ordenar(paraQuickSort);

    SelectionSorter.OrdenarPorSeleccion(
        paraSelectionSort);

    Assert.True(
        ValidadorOrdenamiento.EstaOrdenado(
            paraQuickSort));

    Assert.True(
        ValidadorOrdenamiento.EstaOrdenado(
            paraSelectionSort));

    Assert.Equal(
        paraQuickSort.Select(r => r.Id),
        paraSelectionSort.Select(r => r.Id));
}
}