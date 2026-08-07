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

## Uso de Inteligencia Artificial

Durante el desarrollo se utilizó ChatGPT como herramienta de apoyo para:

- Resolver dudas sobre C# moderno.
- Comprender Selection Sort.
- Revisar decisiones de arquitectura.
- Mejorar la documentación.

Todo el código fue revisado, comprendido y probado antes de incorporarlo al proyecto.

---

## Autor

Jahel Corona
UNITEC
Proyecto Final – Estructura de Datos