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

# Fase 2 — QuickSort y análisis de rendimiento

## 1. Algoritmo QuickSort

QuickSort es un algoritmo de ordenamiento basado en la estrategia de divide y vencerás. Su funcionamiento consiste en seleccionar un elemento llamado pivote y utilizarlo como referencia para dividir el arreglo en secciones.

En este proyecto, los objetos `RegistroDatos` se ordenan de forma ascendente utilizando su propiedad `Id`.

La implementación realizada utiliza el elemento central del segmento actual como pivote. A partir de este valor se utilizan dos índices: uno comienza desde la izquierda y otro desde la derecha.

El índice izquierdo avanza mientras encuentra identificadores menores que el pivote, mientras que el índice derecho retrocede mientras encuentra identificadores mayores. Cuando ambos índices encuentran elementos que deben cambiar de posición, estos se intercambian.

Después de realizar la partición, QuickSort aplica nuevamente el mismo procedimiento sobre las secciones resultantes mediante llamadas recursivas.

## 2. Selección del pivote

Para esta implementación se utiliza el elemento central del segmento como pivote:

```csharp
int indicePivote =
    izquierda + (derecha - izquierda) / 2;

int idPivote =
    datos[indicePivote].Id;

## 3. Complejidad temporal y espacial

El rendimiento de QuickSort depende de cómo se divide el arreglo en cada partición.

### Caso promedio

Cuando el pivote divide el arreglo en secciones relativamente equilibradas, QuickSort presenta una complejidad temporal promedio de:

`O(n log n)`

Esto permite que el algoritmo escale de mejor manera conforme aumenta la cantidad de registros.

### Peor caso

El peor caso ocurre cuando las particiones quedan muy desequilibradas y en cada llamada recursiva una de las secciones contiene casi todos los elementos restantes.

En este escenario, la complejidad puede llegar a:

`O(n²)`

La selección del pivote influye directamente en la posibilidad de generar particiones equilibradas o desequilibradas.

### Complejidad espacial

La implementación utiliza recursividad para ordenar las diferentes secciones del arreglo. Por esta razón, además del arreglo original, se utiliza espacio en la pila de llamadas (Call Stack).

En condiciones favorables, la profundidad de la recursión puede aproximarse a:

`O(log n)`

En un escenario desfavorable puede crecer hasta:

`O(n)`

La implementación ordena directamente sobre el mismo arreglo, por lo que no crea un nuevo arreglo completo durante cada partición.

## 4. Instrumentación de QuickSort

Para analizar el comportamiento real del algoritmo se registraron las siguientes métricas:

- Número de comparaciones.
- Número de intercambios.
- Número de llamadas recursivas.
- Tiempo de ejecución en milisegundos.

Estas métricas se almacenan mediante la clase `MetricasQuickSort`.

Las comparaciones se contabilizan cada vez que un elemento es comparado con el identificador del pivote durante la partición.

Los intercambios se contabilizan cuando dos posiciones diferentes del arreglo cambian sus elementos.

También se registra el número de llamadas recursivas realizadas durante el ordenamiento y se utiliza `Stopwatch` para medir el tiempo de ejecución.

## 5. Comparación experimental: Selection Sort vs QuickSort

Para comparar ambos algoritmos se utilizaron conjuntos de 100, 1,000 y 10,000 registros.

Para cada tamaño se generó un conjunto de datos y posteriormente se crearon dos copias independientes. De esta manera, Selection Sort y QuickSort recibieron exactamente los mismos registros sin que el ordenamiento realizado por un algoritmo afectara al otro.

### Resultados obtenidos

| Registros | Algoritmo | Comparaciones | Intercambios | Tiempo (ms) |
|-----------|-----------|--------------:|-------------:|------------:|
| 100 | Selection Sort | 4,950 | 96 | 0.0856 |
| 100 | QuickSort | 913 | 162 | 0.4605 |
| 1,000 | Selection Sort | 499,500 | 993 | 4.0861 |
| 1,000 | QuickSort | 15,415 | 2,277 | 0.2502 |
| 10,000 | Selection Sort | 49,995,000 | 9,989 | 194.9990 |
| 10,000 | QuickSort | 174,225 | 31,263 | 1.7507 |

Los resultados muestran que Selection Sort incrementa rápidamente su número de comparaciones conforme aumenta la cantidad de registros.

Con 10,000 elementos realizó 49,995,000 comparaciones, mientras que QuickSort realizó 174,225 sobre el mismo conjunto de datos.

QuickSort realizó una mayor cantidad de intercambios en estas pruebas. Sin embargo, la reducción considerable en el número de comparaciones permitió obtener un mejor tiempo de ejecución para los conjuntos de mayor tamaño.

En la prueba de 100 registros, Selection Sort obtuvo un tiempo menor que QuickSort. Para conjuntos pequeños, el costo adicional asociado al proceso de partición, las llamadas a métodos y la medición puede hacer que la diferencia entre ambos algoritmos sea pequeña o incluso favorecer a Selection Sort.

Al aumentar el conjunto a 1,000 y 10,000 registros, la diferencia de rendimiento se vuelve considerablemente más evidente a favor de QuickSort.

Los tiempos representan ejecuciones experimentales y pueden variar entre diferentes ejecuciones y equipos, por lo que se utilizan principalmente para observar la tendencia de crecimiento de ambos algoritmos.

## 6. Análisis de casos extremos

Además del benchmark con datos generados, se evaluó QuickSort con tres distribuciones especiales de 1,000 registros: un arreglo previamente ordenado, un arreglo inversamente ordenado y un conjunto con identificadores repetidos.

### Resultados

| Caso | Comparaciones QuickSort | Intercambios QuickSort | Llamadas recursivas | Tiempo QuickSort (ms) |
|------|------------------------:|-----------------------:|---------------------:|----------------------:|
| Ordenado | 10,975 | 0 | 998 | 0.1064 |
| Inverso | 10,974 | 500 | 998 | 0.0600 |
| Repetidos | 11,412 | 3,951 | 998 | 0.1744 |

### Arreglo ordenado

En el arreglo previamente ordenado, QuickSort realizó 10,975 comparaciones y no necesitó realizar intercambios entre posiciones diferentes.

La selección del elemento central como pivote permitió mantener un comportamiento adecuado en este escenario. Al finalizar, el arreglo continuó correctamente ordenado.

### Arreglo inversamente ordenado

Con los registros colocados en orden descendente, QuickSort realizó 10,974 comparaciones y 500 intercambios.

Aunque fue necesario reorganizar los elementos, el algoritmo mantuvo un número de comparaciones similar al obtenido con el arreglo ordenado y produjo correctamente el orden ascendente.

### Elementos repetidos

Para esta prueba se utilizaron 1,000 registros cuyos identificadores se encontraban entre 1 y 10 de manera repetida.

QuickSort realizó 11,412 comparaciones y 3,951 intercambios. Este escenario produjo una cantidad considerablemente mayor de intercambios que los casos ordenado e inverso.

La prueba permitió comprobar que la implementación puede procesar identificadores iguales sin entrar en un ciclo infinito y mantiene correctamente el orden de los registros.

### Validación de resultados

Después de ejecutar cada algoritmo se utilizó una validación automática para comprobar que los identificadores estuvieran ordenados de menor a mayor.

Los tres casos extremos fueron validados correctamente tanto con Selection Sort como con QuickSort.