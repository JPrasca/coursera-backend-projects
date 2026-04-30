# Coursera Backend Projects

Bienvenido a este repositorio. Aquí encontrarás una colección de proyectos desarrollados como parte de una ruta de aprendizaje en desarrollo Backend con C# y .NET impartida en Coursera.

## 📌 ¿Por qué un solo repositorio?

Originalmente, la idea era que cada uno de estos proyectos tuviera su propio repositorio independiente. Sin embargo, dado que todos son parte de la misma **ruta de aprendizaje de backend**, decidí unificarlos aquí. Esto me permite mantener un registro más organizado de mi evolución, progreso y aprendizaje continuo, desde los fundamentos hasta el desarrollo de APIs con .NET.

## 🚀 Proyectos incluidos

El repositorio está dividido en carpetas correspondientes a cada etapa o curso de la especialización. A continuación, un resumen de lo que encontrarás en cada una:

### 1. [Fundamentos](./01-fundamentos)
- **Proyecto:** `InventorySystem` (Sistema de Inventario)
- **Descripción:** Aplicación de consola en C# donde se aplican los conceptos más básicos y fundamentales del lenguaje: declaración de variables, tipos de datos, estructuras de control (if, switch, bucles) y lógica de programación básica.

### 2. [Programación en C#](./02-csharp-programming)
- **Proyecto:** `LibraryManager` (Gestor de Biblioteca)
- **Descripción:** Un proyecto más avanzado en consola enfocado en la **Programación Orientada a Objetos (POO)**. Implementa clases, objetos, encapsulamiento, manejo de colecciones (Listas, Diccionarios) y principios básicos para estructurar aplicaciones más robustas.

### 3. [Backend .NET](./03-backend-dotnet)
- **Proyecto:** `UserManagementAPI` (API de Gestión de Usuarios)
- **Descripción:** El paso al desarrollo web backend. Es una **API RESTful** construida con **ASP.NET Core** que implementa:
  - Operaciones CRUD (Crear, Leer, Actualizar, Eliminar).
  - Validaciones de entrada.
  - Manejo global de excepciones (`try-catch`).
  - Optimización de consultas y buenas prácticas de desarrollo de APIs.

## 🛠️ Tecnologías y Herramientas utilizadas

- **Lenguaje:** C#
- **Framework:** .NET (ASP.NET Core para la API)
- **Entorno / IDE:** Visual Studio Code / Visual Studio
- **Pruebas de API:** Postman / herramientas integradas como Swagger (si aplica) u `.http` files.

## ⚙️ Cómo ejecutar los proyectos

Dado que cada carpeta es un proyecto de C# / .NET independiente, puedes ejecutarlos individualmente.

1. Clona el repositorio:
   ```bash
   git clone https://github.com/JPrasca/coursera-backend-projects.git
   ```
2. Navega al directorio del proyecto que deseas probar. Por ejemplo:
   ```bash
   cd coursera-backend-projects/03-backend-dotnet/UserManagementAPI
   ```
3. Ejecuta el proyecto usando la CLI de .NET:
   ```bash
   dotnet run
   ```

*(Nota: En el caso de la API, fíjate en la consola para ver en qué puerto de `localhost` se está ejecutando para poder hacer las peticiones HTTP).*

---

> **Nota:** Este repositorio es de carácter educativo y sirve como portafolio personal para demostrar los conocimientos adquiridos a lo largo de los cursos de Coursera.
