using DataCore.Models;
using DataCore.Services;

namespace DataCore.Tests.Services;

public class GeneradorRegistrosTests
{
    [Fact]
    public void Crear_CantidadCorrecta_GeneraArregloEsperado()
    {
        RegistroDatos[] registros =
            GeneradorRegistros.Crear(40);

        Assert.Equal(40, registros.Length);
    }

    [Fact]
    public void Crear_TodosLosIdsSonUnicos()
    {
        RegistroDatos[] registros =
            GeneradorRegistros.Crear(40);

        int distintos =
            registros
                .Select(r => r.Id)
                .Distinct()
                .Count();

        Assert.Equal(40, distintos);
    }

    [Fact]
    public void Crear_CantidadInvalida_LanzaExcepcion()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            GeneradorRegistros.Crear(0);
        });
    }
}