using System;
class Program
{
    static void Main ()
    {
        Nodo? raiz = null;
        Console.WriteLine("=== ARBOLES BINARIOS ===");
        raiz = InsertarNodo(raiz, 10, "Raiz");
        raiz = InsertarNodo(raiz, 5, "Izquierda");
        raiz = InsertarNodo(raiz, 15, "Derecha");
        Console.WriteLine ("Arbol creado correctamente.");

        Nodo? encontrado = BuscarNodo(raiz, 15);
        if ( encontrado != null)
        {
            Console.WriteLine($"Nodo encontrado: { encontrado.ID} - {encontrado.Dato}");
        }
        else
        {
            Console.WriteLine("Nodo no encontrado.");
        }
    }
    static Nodo InsertarNodo(Nodo? raiz, int id, string dato)
    {
        Nodo nuevoNodo = new Nodo(id, dato);
        if (raiz == null)
        {
            return nuevoNodo;
        }
        if (nuevoNodo.ID < raiz.ID)
        {
            raiz.HijoIzquierdo = InsertarNodo
            (raiz.HijoIzquierdo,
            nuevoNodo.ID,
            nuevoNodo.Dato);
        }
        else if (nuevoNodo.ID > raiz.ID)
        {
            raiz.HijoDerecho = InsertarNodo
            (raiz.HijoDerecho,
            nuevoNodo.ID,
            nuevoNodo.Dato);
        }
        return raiz;
    }
    static Nodo? BuscarNodo(Nodo? raiz, int id)
    {
        if (raiz == null)
        return null;
        if (raiz.ID == id)
        return raiz;
        if (id < raiz.ID)
        return BuscarNodo(raiz.HijoIzquierdo, id);
        return BuscarNodo(raiz.HijoDerecho, id);
    }
}