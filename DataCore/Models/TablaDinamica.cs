namespace DataCore.Models;

public class TablaDinamica
{
    private NodoRegistro? cabeza;
    private int contadorRegistros;

    public TablaDinamica()
    {
        cabeza = null;
        contadorRegistros = 0;
    }

    public void InsertarInicio(RegistroDatos nuevoRegistro)
    {
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