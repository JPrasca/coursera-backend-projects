# UserManagementAPI - Backend con .NET

## 📖 Descripción del Proyecto
Este módulo contiene la implementación de una **API RESTful** para la gestión de usuarios, desarrollada con **ASP.NET Core**. Forma parte de la etapa de desarrollo web backend de la ruta de aprendizaje de Coursera.

En este proyecto se aplicaron herramientas de Inteligencia Artificial (Copilot) para agilizar la escritura de código, depurar errores e implementar políticas de seguridad corporativas.

## 🚀 Características
- **Endpoints CRUD Completos:** `GET`, `POST`, `PUT` y `DELETE` para gestionar usuarios (con datos almacenados en memoria).
- **Validación de Entradas:** Asegura que los datos proporcionados (como correo y nombre) sean correctos antes de procesarlos.
- **Canalización de Middleware Personalizada:**
  - **Manejo Global de Errores:** Atrapa excepciones no controladas y devuelve un error `500 Internal Server Error` en formato JSON.
  - **Autenticación:** Protege los endpoints requiriendo un token `Bearer` (`Bearer mi-token-valido`) en las cabeceras HTTP.
  - **Registro (Logging):** Registra los métodos HTTP, las rutas y los códigos de estado de respuesta en la consola.
- **Paginación:** Optimización en la recuperación de listas de usuarios utilizando `.Skip()` y `.Take()`.

## 📄 Documentación Adicional
Para más detalles sobre cómo la IA asistió en el desarrollo, depuración e implementación de middleware en este proyecto, consulta el archivo [Copilot_Documentation.md](./UserManagementAPI/Copilot_Documentation.md).

## ⚙️ Cómo ejecutar el proyecto
1. Abre tu terminal y navega hasta la carpeta de la API:
   ```bash
   cd 03-backend-dotnet/UserManagementAPI
   ```
2. Ejecuta el servidor de desarrollo:
   ```bash
   dotnet run
   ```
3. Puedes probar la API accediendo a la documentación interactiva de Swagger en tu navegador:
   `http://localhost:<PUERTO>/swagger` (Sustituye `<PUERTO>` por el puerto indicado en la consola, ignorando la verificación de autenticación).
