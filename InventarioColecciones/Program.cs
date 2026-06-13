using System;
using System.Collections.Generic;
using System.Linq;

public class Producto
{
    public int ID { get; set; }
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public int Cantidad { get; set; }

    public Producto(int id, string nombre, double precio, int cantidad)
    {
        ID = id;
        Nombre = nombre;
        Precio = precio;
        Cantidad = cantidad;
    }
public override string ToString()
    {
       return $"[{ID}] {Nombre} - ${Precio:F2} | Stock: {Cantidad}"; 
    }
}

class Program
{
    static void Main()
    {
           List<Producto> inventario = new List<Producto>
           {
               new Producto (1, "Laptop", 15999.00,10),
               new Producto (2, "Mouse Inalambrico", 349.00, 25),
               new Producto (3, "Teclado Mecanico", 899.00, 0),
               new Producto (4, "Monitor 24 pulgadas", 4500.00, 5),
               new Producto (5, "Audifonos", 1200.00, 0)
           };
           inventario.Add(new Producto(6, "Webcam", 750.00, 12));
           var otroProducto = new Producto(7, "Impresora", 2500.00, 3);
              inventario.Add(otroProducto);

              Console.WriteLine("=== INVENTARIO COMPLETO ===");
              foreach (var producto in inventario)
        {
            Console.WriteLine(producto);
        }
        Console.WriteLine($"\nTotal de productos en inventario: {inventario.Count} productos");

        Console.WriteLine("\n=== PRODUCTOS ORDENADOS POR PRECIO DESCENDENTE ===");
        var porPrecio = inventario
            .OrderByDescending(p => p.Precio)
            .ToList();
             foreach (var producto in porPrecio)
        {
            Console.WriteLine(producto);
        }
    Dictionary<int, Producto> catalogo = inventario
        .ToDictionary(p => p.ID, p => p);

    BuscarPorID(catalogo);
    }

        static void BuscarPorID(Dictionary<int, Producto> catalogo)
        {
            Console.WriteLine("\nIngrese el ID del producto a buscar: ");

            if (int.TryParse(Console.ReadLine(), out int idBuscado))
            {
                if (catalogo.TryGetValue(idBuscado, out Producto encontrado))
                {
                    Console.WriteLine("Producto encontrado:");
                    Console.WriteLine(encontrado);
                }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
            }
        else
        {
            Console.WriteLine("ID invalido. Debes ingresar un numero: ");
        }
        }
}