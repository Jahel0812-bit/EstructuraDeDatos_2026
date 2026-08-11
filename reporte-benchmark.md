# Reporte de Benchmark — Selection Sort vs QuickSort

## Fase 2 — Proyecto Final de Estructura de Datos

Este reporte presenta los resultados experimentales obtenidos al comparar los algoritmos Selection Sort y QuickSort implementados en el proyecto DataCore.

Los algoritmos ordenan objetos `RegistroDatos` de forma ascendente utilizando la propiedad `Id`.

Para realizar una comparación justa, cada algoritmo recibió una copia independiente del mismo conjunto de datos.

---

## 1. Resultados del benchmark

Se realizaron pruebas utilizando conjuntos de 100, 1,000 y 10,000 registros.

| Registros | Algoritmo | Comparaciones | Intercambios | Tiempo (ms) |
|---:|---|---:|---:|---:|
| 100 | Selection Sort | 4,950 | 96 | 0.0856 |
| 100 | QuickSort | 913 | 162 | 0.4605 |
| 1,000 | Selection Sort | 499,500 | 993 | 4.0861 |
| 1,000 | QuickSort | 15,415 | 2,277 | 0.2502 |
| 10,000 | Selection Sort | 49,995,000 | 9,989 | 194.9990 |
| 10,000 | QuickSort | 174,225 | 31,263 | 1.7507 |

---

## 2. Análisis de resultados

Selection Sort presenta un crecimiento considerable en el número de comparaciones conforme aumenta el tamaño del arreglo.

Con 10,000 registros realizó 49,995,000 comparaciones, mientras que QuickSort realizó 174,225 comparaciones sobre el mismo conjunto de datos.

QuickSort realizó más intercambios que Selection Sort en las pruebas. Sin embargo, la reducción en el número de comparaciones permitió obtener tiempos considerablemente menores al aumentar la cantidad de registros.

Con 100 registros, Selection Sort obtuvo un tiempo menor. Al tratarse de un conjunto pequeño, la sobrecarga de la partición y las llamadas recursivas de QuickSort puede influir en la medición.

Con 1,000 y 10,000 registros, QuickSort mostró una ventaja considerable en tiempo de ejecución.

Los tiempos son resultados experimentales y pueden variar dependiendo del equipo, la carga del sistema y cada ejecución del programa.

---

## 3. Casos extremos

También se evaluó QuickSort con tres distribuciones especiales de 1,000 registros.

| Distribución | Comparaciones | Intercambios | Llamadas recursivas | Tiempo (ms) |
|---|---:|---:|---:|---:|
| Ordenado | 10,975 | 0 | 998 | 0.1064 |
| Inverso | 10,974 | 500 | 998 | 0.0600 |
| Elementos repetidos | 11,412 | 3,951 | 998 | 0.1744 |

### Arreglo ordenado

QuickSort procesó correctamente el arreglo previamente ordenado y no necesitó realizar intercambios entre posiciones diferentes.

### Arreglo inverso

El arreglo en orden descendente también fue ordenado correctamente. En este escenario se registraron 500 intercambios.

### Elementos repetidos

La implementación procesó correctamente registros con identificadores repetidos sin producir un ciclo infinito. Este escenario presentó la mayor cantidad de intercambios entre los tres casos evaluados.

---

## 4. Validación de correctitud

Después de ejecutar cada algoritmo se comprobó automáticamente que los registros estuvieran ordenados ascendentemente por `Id`.

Las pruebas realizadas confirmaron resultados correctos para:

- Arreglo vacío.
- Un elemento.
- Dos elementos ordenados.
- Dos elementos invertidos.
- Elementos repetidos.
- Datos aleatorios.
- Arreglo previamente ordenado.
- Arreglo inversamente ordenado.

---

## 5. Conclusión

Los resultados muestran de forma experimental la diferencia de escalabilidad entre Selection Sort y QuickSort.

Selection Sort mantiene un comportamiento aproximado de O(n²), por lo que el número de comparaciones aumenta rápidamente al incrementar la entrada.

QuickSort presenta un comportamiento promedio de O(n log n), permitiendo trabajar de manera mucho más eficiente con conjuntos de datos grandes cuando las particiones son adecuadas.

La selección del pivote central utilizada en este proyecto también permitió obtener un comportamiento adecuado en las pruebas con arreglos ordenados e inversamente ordenados.