# Documentación de Asistencia de IA (Copilot)

Este documento detalla cómo la inteligencia artificial asistió en la creación y mejora del proyecto `UserManagementAPI`.

## 1. Configuración del Proyecto
**Uso de IA:** La IA ayudó a generar el comando adecuado (`dotnet new webapi -n UserManagementAPI`) para crear un andamiaje base de una aplicación de API web utilizando ASP.NET Core, así como a entender la estructura de archivos inicial y las dependencias (como Swagger para la documentación interactiva).

## 2. Generación de Endpoints CRUD
**Uso de IA:** Se utilizó la IA para escribir rápidamente el código repetitivo en `Program.cs` mediante Minimal APIs. La IA estructuró los siguientes endpoints utilizando una lista de memoria estática (in-memory) en lugar de una base de datos compleja, permitiendo probar la lógica rápidamente:
- **GET (`/users` y `/users/{id}`):** Se implementaron funciones que devuelven la lista completa de usuarios o filtran usando LINQ para obtener un usuario específico, retornando códigos HTTP adecuados (200 OK o 404 Not Found).
- **POST (`/users`):** La IA generó lógica para auto-incrementar el `Id` basado en el usuario con el Id más alto existente y añadir el nuevo usuario a la lista.
- **PUT (`/users/{id}`):** Se añadió lógica para encontrar al usuario, actualizar sus campos (Nombre, Email, Departamento) si existe, o devolver un error 404.
- **DELETE (`/users/{id}`):** Se agregó la funcionalidad para buscar y remover un usuario de la lista, devolviendo `204 No Content`.

## 3. Mejora del Código y Buenas Prácticas
**Uso de IA:** 
- La IA sugirió el uso de `Results.Ok()`, `Results.NotFound()`, `Results.Created()`, y `Results.NoContent()` para asegurar que la API cumpla con los estándares REST y devuelva los códigos de estado HTTP correctos.
- Ayudó a definir el modelo `User` con tipos de datos adecuados e inicializó las cadenas de texto (`string.Empty`) para evitar advertencias de valores nulos (nullables) que son comunes en las versiones recientes de C#.

## 4. Pruebas de la API
**Uso de IA:** La IA incluyó la configuración del middleware de Swagger (`app.UseSwagger()` y `app.UseSwaggerUI()`) dentro de la verificación del entorno de desarrollo. Esto permite que la API pueda ser probada fácilmente desde el navegador al lanzar el proyecto sin requerir configuración manual de Postman en la etapa inicial.

## 5. Depuración y Resolución de Errores (Fase de Corrección)
**Uso de IA:** La IA se utilizó para depurar y resolver problemas reportados tras el despliegue inicial:
- **Validación de Entradas:** Se identificó la falta de validación en los endpoints `POST` y `PUT`. La IA sugirió añadir validaciones simples utilizando `string.IsNullOrWhiteSpace` y la verificación del símbolo `@` para asegurar que el nombre y correo electrónico sean válidos, devolviendo `400 Bad Request` en caso de fallo.
- **Manejo de Excepciones:** Se produjeron bloqueos ocasionales en la API. La IA recomendó implementar bloques `try-catch` en cada uno de los endpoints para gestionar excepciones no controladas de manera segura, retornando un `500 Internal Server Error` (mediante `Results.Problem()`) en lugar de que la aplicación fallase abruptamente.
- **Optimización de Rendimiento:** Para el problema reportado en la recuperación de usuarios (`GET /users`), la IA indicó que devolver una lista masiva sin control puede causar cuellos de botella. La solución sugerida fue implementar paginación mediante los parámetros `skip` y `take` usando `.Skip()` y `.Take()` de LINQ, optimizando la cantidad de datos retornados al cliente.

## 6. Implementación de Middleware (Seguridad, Registro y Errores)
**Uso de IA:** La IA ayudó a diseñar e implementar una canalización (pipeline) de middleware personalizada para cumplir con las políticas corporativas:
- **Gestión de Errores:** Se creó un middleware global al inicio del pipeline usando `try-catch` para capturar cualquier excepción no controlada en la aplicación y retornar una respuesta JSON estándar con el mensaje `{"error": "Internal server error."}` y un código `500`.
- **Autenticación:** Se implementó un middleware que inspecciona las cabeceras HTTP de las peticiones entrantes. Valida que exista el header `Authorization` con un token válido (`Bearer mi-token-valido`). Si el token no está presente o es incorrecto, retorna de inmediato un código `401 Unauthorized`, protegiendo así los endpoints. (Se excluyó la ruta `/swagger` de esta validación para facilitar las pruebas).
- **Registro (Logging):** Se generó un middleware que registra en consola cada solicitud entrante, mostrando su método y ruta (ej. `GET /users`), y posteriormente registra el código de estado de la respuesta saliente.
- **Configuración del Pipeline:** La IA aseguró que el orden de ejecución de los middlewares fuera el óptimo y el solicitado por los requisitos de seguridad: Primero *Errores* (para atrapar fallos en los siguientes middlewares), segundo *Autenticación* (para bloquear peticiones no autorizadas sin gastar recursos extra), y tercero *Registro* (para loguear solo peticiones autenticadas o los intentos que pasen hasta este punto).
