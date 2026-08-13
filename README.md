# DataCore v4.0 — Proyecto Final de Estructura de Datos

## Descripción

DataCore es una aplicación de consola desarrollada en C# para aplicar e integrar diferentes conceptos de Estructura de Datos.

El proyecto fue desarrollado progresivamente en cuatro fases e integra:

- Registros inmutables mediante `readonly struct`.
- Selection Sort.
- QuickSort recursivo.
- Lista simplemente enlazada.
- Conversión de lista enlazada a arreglo.
- Búsqueda binaria indexada.
- Métricas de rendimiento.
- Benchmark de estructuras de datos.
- Pruebas unitarias y de integración.
- Menú Maestro interactivo mediante CLI.

La versión final permite administrar registros durante una misma sesión mediante inserción, eliminación, visualización, ordenamiento y búsqueda.

---

## Tecnologías utilizadas

- C#
- .NET 10
- xUnit
- Visual Studio Code
- Git
- GitHub

---

## Estructura principal

```text
DataCore/
├── Algorithms/
│   ├── BuscadorIndexado.cs
│   ├── QuickSorter.cs
│   └── SelectionSorter.cs
│
├── Models/
│   ├── MetricasOrdenacion.cs
│   ├── MetricasQuickSort.cs
│   ├── NodoRegistro.cs
│   ├── RegistroDatos.cs
│   └── TablaDinamica.cs
│
├── Presentation/
│   ├── MenuMaestro.cs
│   ├── ReporteConsola.cs
│   └── ValidadorOrdenamiento.cs
│
├── Services/
│   ├── BenchmarkMemoria.cs
│   └── GeneradorRegistros.cs
│
└── Program.cs

DataCore.Tests/
└── Pruebas automatizadas de los módulos del sistema
```

---

## Funcionalidades

El Menú Maestro de DataCore v4.0 permite:

1. Insertar registros.
2. Eliminar registros mediante su Id.
3. Mostrar todos los registros almacenados.
4. Ordenar registros por Id.
5. Buscar registros mediante búsqueda binaria indexada.
6. Salir del programa mediante confirmación.

El sistema también valida entradas incorrectas y evita la inserción de identificadores duplicados.

---

## Algoritmos implementados

### Selection Sort

Ordena los registros comparando cada posición con los elementos restantes para encontrar el menor Id.

Complejidad temporal:

- Mejor caso: `O(n²)`
- Caso promedio: `O(n²)`
- Peor caso: `O(n²)`

Complejidad espacial:

- `O(1)`

### QuickSort

Implementación recursiva que utiliza un elemento central como pivote.

Complejidad temporal:

- Mejor caso: `O(n log n)`
- Caso promedio: `O(n log n)`
- Peor caso: `O(n²)`

Complejidad espacial:

- Depende de la profundidad de la recursividad.
- En condiciones balanceadas: `O(log n)`.

### Búsqueda binaria indexada

La búsqueda se realiza sobre un arreglo previamente ordenado por `Id`.

Complejidad temporal:

- Mejor caso: `O(1)`
- Caso promedio: `O(log n)`
- Peor caso: `O(log n)`

El proceso utilizado es:

```text
TablaDinamica
      ↓
ObtenerComoArreglo()
      ↓
QuickSort
      ↓
Búsqueda Binaria
```

### Lista simplemente enlazada

`TablaDinamica` utiliza nodos enlazados para almacenar los registros dinámicamente.

Características principales:

- Inserción al inicio: `O(1)`
- Inserción al final: `O(n)`
- Eliminación por Id: `O(n)`
- Conversión a arreglo: `O(n)`

---

## Compilación

Desde la raíz del repositorio:

```powershell
dotnet build
```

También puede compilarse específicamente DataCore:

```powershell
dotnet build DataCore/DataCore.csproj
```

---

## Ejecución

Para iniciar el Menú Maestro:

```powershell
dotnet run --project DataCore
```

Al iniciar se mostrará:

```text
===========================================
       DATACORE v4.0 - MENÚ MAESTRO
===========================================
 Registros actuales: 0

 [1] Insertar registro
 [2] Eliminar registro por Id
 [3] Mostrar todos los registros
 [4] Ordenar registros por Id
 [5] Búsqueda avanzada
 [6] Salir
===========================================
```

---

## Pruebas automatizadas

Las pruebas se encuentran en el proyecto:

```text
DataCore.Tests
```

Para ejecutar toda la suite:

```powershell
dotnet test EstructuraDeDatos_2026.slnx
```

Durante la integración de la Fase 4 se obtuvieron:

```text
29 pruebas aprobadas
```

Las pruebas incluyen casos normales, casos borde e interoperabilidad entre los diferentes módulos.

---

## Pruebas de integración

Se realizó una prueba manual de extremo a extremo mediante el Menú Maestro con 15 operaciones.

Entre los escenarios evaluados se encuentran:

- Tabla vacía.
- Inserción de múltiples registros.
- Intento de Id duplicado.
- Visualización de registros.
- Ordenamiento.
- Búsqueda de Id existente.
- Búsqueda de Id inexistente.
- Eliminación de registros.
- Eliminación del último elemento.
- Confirmación y cancelación de salida.

Todos los escenarios fueron ejecutados correctamente.

El reporte detallado se encuentra en:

```text
reporte-pruebas-integracion-fase4.md
```

---

## Evolución del proyecto

### Fase 1 — Selection Sort

Se implementó el modelo `RegistroDatos` y el algoritmo Selection Sort con métricas de comparaciones, intercambios y tiempo.

### Fase 2 — QuickSort

Se incorporó QuickSort recursivo y se comparó experimentalmente su rendimiento contra Selection Sort.

### Fase 3 — Lista Simplemente Enlazada

Se implementaron `NodoRegistro` y `TablaDinamica`, permitiendo almacenamiento dinámico, inserción, eliminación y conversión a arreglo.

También se realizaron pruebas de interoperabilidad y un benchmark entre arreglo estático y lista enlazada.

### Fase 4 — Integración Final

Se incorporó búsqueda binaria indexada y el Menú Maestro CLI, integrando los componentes desarrollados en las fases anteriores.

---

## Documentación adicional

El repositorio incluye documentación complementaria:

```text
PF-Fase1.docx
PF-Fase2.docx
PF-Fase3.docx
TEORIA.md
reporte-benchmark.md
reporte-pruebas-integracion-fase4.md
```

---

## Control de versiones

El proyecto utiliza Git y GitHub mediante ramas de trabajo y Pull Requests.

Las funcionalidades fueron desarrolladas en ramas independientes antes de integrarse a la rama principal, manteniendo commits descriptivos y evitando modificaciones directas innecesarias sobre `main`.

---

## Autor

Jahel Corona  
UNITEC  
Proyecto Final — Estructura de Datos