namespace DataCore.Models;
    /// <summary>
/// Representa una tabla dinámica implementada
/// mediante una lista simplemente enlazada.
/// </summary>
public class TablaDinamica
{
    private NodoRegistro? cabeza;
    private int contadorRegistros;
/// <summary>
    /// Inicializa una nueva tabla dinámica vacía.
    /// </summary>
    public TablaDinamica()
    {
        cabeza = null;
        contadorRegistros = 0;
    }
   /// <summary>
    /// Inserta un registro al inicio de la lista enlazada.
    /// </summary>
    /// <param name="nuevoRegistro">
    /// Registro que se agregará como nueva cabeza.
    /// </param>
    public void InsertarInicio(RegistroDatos nuevoRegistro)
    {
            /// <summary>
    /// Inserta un registro al final de la lista enlazada.
    /// </summary>
    /// <param name="nuevoRegistro">
    /// Registro que se agregará al final de la estructura.
    /// </param>
        NodoRegistro nuevoNodo = new(nuevoRegistro);

        nuevoNodo.Siguiente = cabeza;
        cabeza = nuevoNodo;

        contadorRegistros++;
    }

    public void InsertarFinal(RegistroDatos nuevoRegistro)
    {
        NodoRegistro nuevoNodo = new(nuevoRegistro);

        if (cabeza == null)
        {
            cabeza = nuevoNodo;
        }
        else
        {
            NodoRegistro actual = cabeza;

            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }

            actual.Siguiente = nuevoNodo;
        }

        contadorRegistros++;
    }
    /// <summary>
    /// Busca y elimina el primer registro cuyo Id
    /// coincida con el identificador especificado.
    /// </summary>
    /// <param name="idTarget">
    /// Identificador del registro que se desea eliminar.
    /// </param>
    public void EliminarPorId(int idTarget)
    {
        if (cabeza == null)
        {
            return;
        }

        if (cabeza.Dato.Id == idTarget)
        {
            cabeza = cabeza.Siguiente;
            contadorRegistros--;
            return;
        }

        NodoRegistro anterior = cabeza;
        NodoRegistro? actual = cabeza.Siguiente;

        while (actual != null)
        {
            if (actual.Dato.Id == idTarget)
            {
                anterior.Siguiente = actual.Siguiente;
                contadorRegistros--;
                return;
            }

            anterior = actual;
            actual = actual.Siguiente;
        }
    }
    /// <summary>
    /// Convierte los registros almacenados en la lista
    /// enlazada a un arreglo de RegistroDatos.
    /// </summary>
    /// <returns>
    /// Arreglo que contiene exactamente los registros
    /// existentes en la tabla dinámica.
    /// </returns>
    public RegistroDatos[] ObtenerComoArreglo()
    {
        RegistroDatos[] resultado =
            new RegistroDatos[contadorRegistros];

        NodoRegistro? actual = cabeza;
        int i = 0;

        while (actual != null)
        {
            resultado[i] = actual.Dato;

            actual = actual.Siguiente;
            i++;
        }

        return resultado;
    }
}