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