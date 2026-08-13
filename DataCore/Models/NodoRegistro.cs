namespace DataCore.Models;

public class NodoRegistro
{
    public RegistroDatos Dato { get; set; }

    public NodoRegistro? Siguiente { get; set; }

    public NodoRegistro(RegistroDatos dato)
    {
        Dato = dato;
        Siguiente = null;
    }
}