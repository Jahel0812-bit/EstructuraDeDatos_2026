# DataCore - Proyecto Final Fase 1

## Descripción

DataCore es un proyecto desarrollado en C# que implementa el algoritmo
Selection Sort utilizando un `readonly struct` llamado `RegistroDatos`.

El programa genera 40 registros con identificadores únicos y desordenados,
los ordena por ID y muestra métricas del algoritmo como:

- Comparaciones
- Intercambios
- Tiempo de ejecución

---

## Estructura del proyecto

DataCore
│
├── Models
├── Algorithms
├── Services
├── Presentation
└── Program.cs

---

## Tecnologías

- C#
- .NET
- Visual Studio Code
- Git
- GitHub

---

## Compilación

```bash
dotnet build
```

---

## Ejecución

```bash
dotnet run
```

---

## Decisiones de diseño

Durante el desarrollo se tomaron las siguientes decisiones:

- Uso de `readonly struct` para representar registros inmutables.
- Separación de responsabilidades mediante carpetas Models,
  Algorithms, Services y Presentation.
- Uso de Selection Sort para ordenar por identificador.
- Medición del tiempo mediante `Stopwatch`.
- Intercambio utilizando sintaxis moderna de tuplas.

---

## Resultados obtenidos

La ejecución del programa muestra:

- Registros antes del ordenamiento.
- Registros después del ordenamiento.
- Total de comparaciones.
- Total de intercambios.
- Tiempo de ejecución.

---

## IA Utilizada

### Herramienta

OpenAI ChatGPT.

### Prompt utilizado

> Estoy desarrollando la Fase 1 del proyecto DataCore para Estructura de Datos
> utilizando C# moderno. Estoy implementando Selection Sort sobre un arreglo de
> `readonly struct RegistroDatos`. Explícame cómo intercambiar dos elementos del
> arreglo utilizando la sintaxis moderna de tuplas de C#, sin utilizar una variable
> temporal. Explica también qué sucede durante el intercambio y por qué esta
> sintaxis es adecuada para el proyecto.

### Respuesta obtenida

La IA propuso utilizar la siguiente sintaxis:

```csharp
(registros[i], registros[indiceMinimo]) =
    (registros[indiceMinimo], registros[i]);

# DataCore - Proyecto Final Fase 2

## Objetivo

La Fase 2 del proyecto incorpora el algoritmo QuickSort recursivo para ordenar registros por su identificador y comparar su rendimiento con Selection Sort.

La implementación utiliza un pivote central y registra métricas que permiten analizar el comportamiento de ambos algoritmos con diferentes cantidades y distribuciones de datos.

## Funcionalidades implementadas

- Implementación recursiva de QuickSort.
- Selección del elemento central como pivote.
- Ordenamiento ascendente mediante `RegistroDatos.Id`.
- Conteo de comparaciones e intercambios.
- Conteo de llamadas recursivas.
- Medición del tiempo de ejecución.
- Comparación con Selection Sort.
- Benchmark con 100, 1,000 y 10,000 registros.
- Uso de copias independientes del mismo conjunto de datos.
- Validación automática del ordenamiento.
- Pruebas con arreglos ordenados, inversos y elementos repetidos.
- Pruebas unitarias para casos normales y extremos.

## Benchmark

Los siguientes resultados corresponden a una ejecución experimental del proyecto.

| Registros | Algoritmo | Comparaciones | Intercambios | Tiempo (ms) |
|-----------|-----------|--------------:|-------------:|------------:|
| 100 | Selection Sort | 4,950 | 96 | 0.0856 |
| 100 | QuickSort | 913 | 162 | 0.4605 |
| 1,000 | Selection Sort | 499,500 | 993 | 4.0861 |
| 1,000 | QuickSort | 15,415 | 2,277 | 0.2502 |
| 10,000 | Selection Sort | 49,995,000 | 9,989 | 194.9990 |
| 10,000 | QuickSort | 174,225 | 31,263 | 1.7507 |

Los resultados muestran que QuickSort reduce considerablemente el número de comparaciones conforme aumenta el tamaño del conjunto de datos.

Los tiempos pueden variar entre ejecuciones y equipos, por lo que se utilizan como evidencia experimental de la tendencia de rendimiento y no como valores absolutos.

## Casos evaluados

Además del benchmark principal se probaron los siguientes escenarios:

- Arreglo vacío.
- Un solo elemento.
- Dos elementos ordenados.
- Dos elementos invertidos.
- Identificadores repetidos.
- Datos aleatorios.
- Arreglo previamente ordenado.
- Arreglo inversamente ordenado.

Todos los resultados fueron verificados mediante una validación automática del orden ascendente por `Id`.

## Pruebas

Las pruebas automatizadas se encuentran en el proyecto `DataCore.Tests`.

Para ejecutarlas:

```powershell
dotnet test EstructuraDeDatos_2026.slnx
```

Al finalizar la implementación de esta fase, las pruebas de las fases anteriores se conservaron para comprobar que los nuevos cambios no afectaran el comportamiento existente.

## Ejecución del proyecto

### Clonar el repositorio

```bash
git clone URL_DEL_REPOSITORIO
cd EstructuraDeDatos_2026
```

> Reemplazar `URL_DEL_REPOSITORIO` por la dirección HTTPS del repositorio en GitHub.

### Compilar y ejecutar

Desde la raíz del repositorio:

```powershell
dotnet build
dotnet run --project DataCore
```

### Ejecutar las pruebas

```powershell
dotnet test EstructuraDeDatos_2026.slnx
```

### Salida esperada

Al ejecutar el proyecto se muestra en consola la comparación entre Selection Sort y QuickSort para conjuntos de:

- 100 registros.
- 1,000 registros.
- 10,000 registros.

Para cada algoritmo se muestran métricas como comparaciones, intercambios y tiempo de ejecución. QuickSort también muestra el número de llamadas recursivas.

Finalmente se ejecutan los casos especiales con arreglos ordenados, inversamente ordenados y con elementos repetidos, verificando automáticamente que ambos algoritmos produzcan un resultado correctamente ordenado.

## Documentación

El análisis teórico de QuickSort, su complejidad temporal y espacial, la selección del pivote y los resultados experimentales se encuentran en:

`TEORIA.md`

## IA Utilizada - Fase 2

### Herramienta

ChatGPT de OpenAI.

### Problema consultado

Durante la implementación de QuickSort se utilizó IA como apoyo para comprender cómo influye la selección del pivote en el rendimiento del algoritmo y cómo instrumentar la implementación para obtener métricas sin modificar su funcionamiento.

### Prompt utilizado

> Estoy implementando QuickSort recursivo en C# para ordenar un arreglo de `RegistroDatos` por su propiedad `Id`. Quiero utilizar el elemento central del segmento como pivote y comparar su rendimiento contra Selection Sort. ¿Cómo funciona esta estrategia de pivote y cómo puedo registrar comparaciones, intercambios, llamadas recursivas y tiempo de ejecución sin cambiar el resultado del algoritmo?

### Respuesta obtenida

La IA explicó que el elemento central puede utilizarse como pivote calculando su índice a partir de los límites izquierdo y derecho del segmento.

También propuso instrumentar el algoritmo mediante contadores para registrar las comparaciones realizadas contra el pivote, los intercambios entre posiciones diferentes y las llamadas recursivas. Para medir el tiempo de ejecución recomendó utilizar `Stopwatch`.

### Decisión tomada

Se adoptó el uso del elemento central como pivote y la instrumentación mediante una clase independiente denominada `MetricasQuickSort`.

La propuesta fue adaptada a la arquitectura existente de DataCore para mantener separados el algoritmo, el modelo de métricas y la presentación de resultados.

Además, se validó la implementación mediante pruebas unitarias y benchmarks antes de conservar los cambios.

## Autor

Jahel Corona
UNITEC
Proyecto Final – Estructura de Datos