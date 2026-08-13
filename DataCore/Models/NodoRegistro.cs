namespace DataCore.Models;

/// <summary>
/// Representa un nodo individual de la lista simplemente enlazada.
/// </summary>
public class NodoRegistro
{
    /// <summary>
    /// Obtiene o establece el registro almacenado en el nodo.
    /// </summary>
    public RegistroDatos Dato { get; set; }

    /// <summary>
    /// Obtiene o establece la referencia al siguiente nodo de la lista.
    /// </summary>
    public NodoRegistro? Siguiente { get; set; }

    /// <summary>
    /// Inicializa un nuevo nodo con el registro especificado.
    /// </summary>
    /// <param name="dato">
    /// Registro que será almacenado en el nodo.
    /// </param>
    public NodoRegistro(RegistroDatos dato)
    {
        Dato = dato;
        Siguiente = null;
    }
}