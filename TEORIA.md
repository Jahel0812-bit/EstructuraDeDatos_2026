# Sustento Teórico — Proyecto Final Fase 1

## 1. Gestión de Memoria: Stack vs. Heap

Si `RegistroDatos` se modela como un `struct`, se comporta como un tipo de valor. 
Cuando se utiliza como variable local, el valor forma parte del contexto de ejecución del método, a diferencia de una `class`, donde normalmente se trabaja mediante una referencia hacia un objeto administrado por el runtime.

La principal ventaja de usar `struct` en este proyecto es que permite representar registros pequeños e inmutables sin depender del mismo modelo de objetos mutables de una clase. Además, al declararlo como `readonly struct`, evitamos que sus propiedades cambien accidentalmente una vez creado el registro.

Una diferencia importante es la semántica de copia. Cuando se copia un `struct`, se copian sus campos, mientras que con una `class` normalmente se copia una referencia al mismo objeto. Esto significa que hay que tener cuidado con estructuras demasiado grandes, porque copiarlas repetidamente puede tener un costo.

En DataCore, `RegistroDatos` se diseñó como `readonly struct` porque representa una unidad de datos sencilla formada por `Id`, `Valor` y `Etiqueta`, y no necesita cambiar su estado después de ser creada. Esta decisión ayuda a mantener los registros consistentes mientras son procesados por el algoritmo de ordenamiento.

## 2. Eficiencia de Intercambios en Selection Sort

Selection Sort tiene una complejidad temporal O(n²) porque en cada pasada necesita recorrer la parte restante del arreglo para encontrar el elemento mínimo. Sin embargo, una de sus ventajas es que realiza pocos intercambios.

En cada pasada del ciclo externo puede realizar como máximo un intercambio. Por esta razón, para un arreglo de n elementos, el número máximo de intercambios es n - 1.

Esto lo diferencia de Bubble Sort. Bubble Sort compara elementos adyacentes y puede realizar un intercambio cada vez que encuentra dos valores fuera de orden, por lo que en el peor caso puede realizar O(n²) intercambios.

Por ejemplo, con el arreglo:

[5, 3, 1, 4, 2]

Selection Sort encuentra primero el valor mínimo y lo coloca directamente en su posición correcta. Después repite el proceso sobre la parte restante del arreglo. Para este ejemplo puede ordenar los cinco elementos utilizando solamente tres intercambios.

Esta característica resulta útil cuando escribir o mover datos es más costoso que compararlos, ya que Selection Sort puede realizar muchas comparaciones pero pocas operaciones de escritura.

En el proyecto DataCore esta propiedad se observa mediante los contadores de `TotalComparaciones` y `TotalIntercambios`. Para 40 registros el algoritmo realiza siempre 780 comparaciones, mientras que la cantidad de intercambios depende del orden inicial de los registros y nunca debe superar 39.

## 3. Intercambio con Tuplas en C#

En la implementación de Selection Sort se utiliza la sintaxis moderna de tuplas:

(registros[i], registros[indiceMinimo]) =
    (registros[indiceMinimo], registros[i]);

Esta instrucción intercambia ambos elementos sin declarar manualmente una variable temporal. La sintaxis es equivalente al intercambio tradicional, pero resulta más clara y reduce la posibilidad de errores al copiar valores entre variables.

En este proyecto se utiliza para intercambiar dos elementos de tipo `RegistroDatos` dentro del arreglo cuando el algoritmo encuentra un identificador menor en otra posición.