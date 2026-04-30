# SISTEMA DE GESTIÓN DE INVENTARIO
## Proyecto Final - Fundamentos de C#

---

## PASO 2: REQUISITOS Y OBJETIVOS DEL PROYECTO

### REQUISITOS FUNCIONALES

Los requisitos funcionales describen las funcionalidades específicas que el sistema debe proporcionar:

1. **RF-01: Agregar Nuevos Productos**
   - El sistema debe permitir al usuario agregar productos con nombre, precio y cantidad de stock
   - El sistema debe validar que el nombre no esté vacío
   - El sistema debe validar que el precio sea un número positivo
   - El sistema debe validar que la cantidad sea un número no negativo
   - El sistema debe asignar automáticamente un ID único a cada producto

2. **RF-02: Actualizar Stock de Productos**
   - El sistema debe permitir agregar unidades (reposición)
   - El sistema debe permitir reducir unidades (venta)
   - El sistema debe permitir establecer un stock específico
   - El sistema debe validar que el stock no sea negativo después de una reducción
   - El sistema debe mostrar alertas cuando el stock sea bajo (< 10 unidades)

3. **RF-03: Ver Todos los Productos**
   - El sistema debe listar todos los productos con su información completa
   - El sistema debe mostrar: ID, Nombre, Precio, y Stock
   - El sistema debe indicar visualmente los productos con stock bajo

4. **RF-04: Eliminar Productos**
   - El sistema debe permitir eliminar productos por ID
   - El sistema debe solicitar confirmación antes de eliminar
   - El sistema debe validar que el producto exista antes de eliminarlo

5. **RF-05: Buscar Productos**
   - El sistema debe permitir buscar por ID
   - El sistema debe permitir buscar por nombre (coincidencia parcial)
   - El sistema debe mostrar todos los resultados encontrados

6. **RF-06: Mostrar Estadísticas**
   - El sistema debe calcular y mostrar:
     * Total de productos diferentes
     * Total de unidades en inventario
     * Valor total del inventario
     * Precio promedio por unidad
     * Cantidad de productos con stock bajo
     * Producto más caro y más barato

### REQUISITOS NO FUNCIONALES

Los requisitos no funcionales describen las cualidades y restricciones del sistema:

1. **RNF-01: Usabilidad**
   - La interfaz de consola debe ser clara e intuitiva
   - Los mensajes deben estar en español
   - El sistema debe usar colores para resaltar información importante
   - El menú debe estar bien organizado y ser fácil de navegar

2. **RNF-02: Validación de Datos**
   - Todas las entradas del usuario deben ser validadas
   - El sistema debe proporcionar mensajes de error claros
   - No se debe permitir que el sistema entre en estados inválidos

3. **RNF-03: Mantenibilidad**
   - El código debe estar bien documentado con comentarios
   - Cada método debe tener una responsabilidad única y clara
   - El código debe seguir convenciones de nomenclatura de C#

4. **RNF-04: Rendimiento**
   - El sistema debe responder inmediatamente a las acciones del usuario
   - Las búsquedas deben ser eficientes

5. **RNF-05: Confiabilidad**
   - El sistema no debe cerrarse inesperadamente por entradas inválidas
   - Los datos deben mantenerse consistentes durante toda la ejecución

### OBJETIVOS DEL PROYECTO

Los objetivos son los resultados concretos que se pretenden conseguir:

1. **Demostrar dominio de fundamentos de C#**
   - Utilizar variables y tipos de datos apropiados (string, int, decimal)
   - Implementar estructuras de control (if-else, switch)
   - Implementar bucles (for, while, foreach)
   - Crear y utilizar métodos personalizados

2. **Crear un sistema funcional y completo**
   - Desarrollar una aplicación de consola completamente funcional
   - Implementar todas las operaciones CRUD (Crear, Leer, Actualizar, Eliminar)
   - Proporcionar una experiencia de usuario satisfactoria

3. **Aplicar buenas prácticas de programación**
   - Organizar el código en clases y métodos lógicos
   - Validar todas las entradas del usuario
   - Documentar el código adecuadamente
   - Manejar errores de forma apropiada

4. **Crear un proyecto extensible**
   - Diseñar una arquitectura que permita futuras mejoras
   - Usar estructuras de datos apropiadas (List<T>)
   - Separar la lógica de negocio de la presentación

---

## INDICADORES DE ÉXITO

El proyecto se considerará exitoso cuando:

✓ Todas las funcionalidades especificadas estén implementadas
✓ El código incluya las estructuras requeridas (if-else, switch, for, while, métodos)
✓ El sistema maneje correctamente entradas válidas e inválidas
✓ El código esté bien documentado y organizado
✓ La aplicación sea fácil de usar y proporcione retroalimentación clara
