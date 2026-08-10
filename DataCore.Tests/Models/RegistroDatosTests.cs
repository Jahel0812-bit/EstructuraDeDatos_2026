using DataCore.Models;

namespace DataCore.Tests.Models;

public class RegistroDatosTests
{
    [Fact]
    public void Constructor_ConDatosValidos_CreaRegistroCorrectamente()
    {
        RegistroDatos registro =
            new RegistroDatos(1, 250.50, "Venta");

        Assert.Equal(1, registro.Id);
        Assert.Equal(250.50, registro.Valor);
        Assert.Equal("Venta", registro.Etiqueta);
    }

[Fact]
public void Equals_RegistrosIguales_DevuelveTrue()
{
    RegistroDatos registro1 =
        new RegistroDatos(1, 150.00, "Venta");

    RegistroDatos registro2 =
        new RegistroDatos(1, 150.00, "Venta");

    Assert.True(registro1.Equals(registro2));
}

[Fact]
public void Constructor_EtiquetaVacia_LanzaExcepcion()
{
    Assert.Throws<ArgumentException>(() =>
    {
        new RegistroDatos(1, 150.00, "");
    });
}

[Fact]
public void Constructor_EtiquetaNula_LanzaExcepcion()
{
    Assert.Throws<ArgumentException>(() =>
    {
        new RegistroDatos(1, 150.00, null!);
    });
}

[Fact]
public void ToString_ContieneInformacionDelRegistro()
{
    RegistroDatos registro =
        new RegistroDatos(5, 999.99, "Compra");

    string texto = registro.ToString();

    Assert.Contains("5", texto);
    Assert.Contains("999.99", texto);
    Assert.Contains("Compra", texto);
}
}