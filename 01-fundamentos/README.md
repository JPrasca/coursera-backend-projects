# Sistema de Gestión de Inventario
## Guía de Ejecución y Uso

---

## 📋 REQUISITOS PREVIOS

Para ejecutar este proyecto necesitas:

- **.NET SDK 8.0** o superior instalado
- Un editor de código (Visual Studio Code recomendado)
- Terminal o línea de comandos

---

## 🚀 CÓMO EJECUTAR EL PROYECTO

### Opción 1: Desde la terminal

1. Navega a la carpeta del proyecto:
```bash
cd /Users/pro/Desktop/Desk/coursera_backend/01-fundamentos
```

2. Ejecuta el proyecto:
```bash
dotnet run
```

### Opción 2: Compilar y ejecutar

1. Compilar el proyecto:
```bash
dotnet build
```

2. Ejecutar el compilado:
```bash
dotnet run
```

---

## 📖 GUÍA DE USO

### Menú Principal

Al ejecutar el programa, verás el siguiente menú:

```
═══════════════════════════════════════════════════
              MENÚ PRINCIPAL
═══════════════════════════════════════════════════
1. Agregar nuevo producto
2. Actualizar stock de producto
3. Ver todos los productos
4. Eliminar producto
5. Buscar producto
6. Mostrar estadísticas
7. Salir
═══════════════════════════════════════════════════
```

### Funcionalidades Disponibles

#### 1️⃣ Agregar Nuevo Producto

- Solicita: Nombre, Precio, Cantidad en stock
- Valida que los datos sean correctos
- Asigna automáticamente un ID único

**Ejemplo:**
```
Nombre del producto: Mouse Gaming
Precio del producto: $45.99
Cantidad en stock: 25
```

#### 2️⃣ Actualizar Stock

- Busca producto por ID
- Opciones:
  - Agregar stock (reposición)
  - Reducir stock (venta)
  - Establecer stock específico
- Previene stock negativo

#### 3️⃣ Ver Todos los Productos

- Lista completa del inventario
- Muestra: ID, Nombre, Precio, Stock
- Alertas visuales para stock bajo:
  - 🔴 Rojo: Stock < 10 (crítico)
  - 🟡 Amarillo: Stock < 50 (moderado)

#### 4️⃣ Eliminar Producto

- Busca por ID
- Muestra información del producto
- Solicita confirmación (S/N)
- Elimina permanentemente

#### 5️⃣ Buscar Producto

Dos opciones de búsqueda:
- **Por ID**: Búsqueda exacta
- **Por nombre**: Búsqueda parcial (encuentra coincidencias)

**Ejemplo:**
```
Buscar: "mouse" 
Encuentra: "Mouse Gaming", "Mouse Inalámbrico", etc.
```

#### 6️⃣ Mostrar Estadísticas

Muestra análisis completo del inventario:
- Total de productos diferentes
- Total de unidades
- Valor total del inventario
- Precio promedio
- Productos con stock bajo
- Producto más caro y más barato
- Lista de productos críticos

---

## 🎨 CARACTERÍSTICAS ESPECIALES

### Validaciones Implementadas

✓ Nombres no vacíos
✓ Precios positivos
✓ Stock no negativo
✓ Prevención de stock negativo en ventas
✓ IDs válidos

### Alertas Visuales

- 🟢 **Verde**: Operaciones exitosas
- 🔴 **Rojo**: Errores y stock crítico
- 🟡 **Amarillo**: Advertencias y stock moderado

### Datos de Ejemplo

El sistema inicia con 5 productos de ejemplo para que puedas probar todas las funcionalidades inmediatamente:

1. Laptop Dell XPS - $1299.99 (15 unidades)
2. Mouse Logitech - $29.99 (45 unidades)
3. Teclado Mecánico - $89.99 (8 unidades) ⚠️
4. Monitor 24 pulgadas - $249.99 (20 unidades)
5. Auriculares Bluetooth - $79.99 (30 unidades)

---

## 💻 ESTRUCTURA DEL CÓDIGO

### Archivos del Proyecto

```
01-fundamentos/
├── InventorySystem.csproj    # Configuración del proyecto
├── Program.cs                 # Lógica principal y menú
├── Product.cs                 # Clase modelo de producto
├── README.md                  # Esta guía
├── REQUISITOS_Y_OBJETIVOS.md # Documentación de requisitos
└── ESQUEMA_DE_DISEÑO.md       # Diagrama y planificación
```

### Conceptos de C# Demostrados

✅ **Variables y tipos de datos**: string, int, decimal, bool
✅ **Colecciones**: List<Product>
✅ **Clases y objetos**: Product con propiedades y métodos
✅ **Estructuras de control**: if-else, switch
✅ **Bucles**: for, while, foreach
✅ **Métodos**: 14 métodos personalizados
✅ **Validación de datos**: TryParse, validaciones lógicas
✅ **Formateo**: String interpolation, formato de moneda

---

## 🎯 CONCEPTOS APRENDIDOS

### 1. Estructuras de Control

**IF-ELSE**: Usado para validaciones y decisiones
```csharp
if (product.Stock < 10) {
    Console.WriteLine("ALERTA: Stock bajo");
}
```

**SWITCH**: Usado para menús y opciones múltiples
```csharp
switch (option) {
    case "1": AddNewProduct(); break;
    case "2": UpdateStock(); break;
    ...
}
```

### 2. Bucles

**FOR**: Para iterar con índice conocido
```csharp
for (int i = 0; i < inventory.Count; i++) {
    inventory[i].DisplayInfo();
}
```

**WHILE**: Para bucles con condición
```csharp
while (!exit) {
    DisplayMenu();
    // procesar opción
}
```

**FOREACH**: Para iterar colecciones
```csharp
foreach (Product product in inventory) {
    if (product.Id == id) return product;
}
```

### 3. Métodos

- Organización del código en funciones reutilizables
- Separación de responsabilidades
- Parámetros y valores de retorno

---

## 📊 EJEMPLO DE USO COMPLETO

1. **Ejecutar** el programa
2. **Ver** todos los productos (opción 3)
3. **Agregar** un nuevo producto (opción 1)
4. **Buscar** el producto agregado (opción 5)
5. **Actualizar** el stock (opción 2) - simular venta
6. **Ver estadísticas** (opción 6)
7. **Eliminar** un producto (opción 4)
8. **Salir** (opción 7)

---

## 📝 NOTAS IMPORTANTES

- Los datos **no se guardan** entre ejecuciones (la persistencia no es parte de los requisitos)
- El sistema valida todas las entradas del usuario
- Los IDs son autoincrementales y únicos
- Los precios se muestran con formato de moneda ($)
- El sistema usa colores para mejorar la experiencia del usuario

---

## 🏆 CUMPLIMIENTO DE REQUISITOS DEL PROYECTO

✅ Aplicación de consola funcional
✅ Gestión completa de inventario (CRUD)
✅ Uso de estructuras de control (if-else, switch)
✅ Uso de bucles (for, while, foreach)
✅ Métodos personalizados definidos y utilizados
✅ Validación robusta de datos
✅ Código bien documentado
✅ Experiencia de usuario intuitiva

---

## 🎓 PARA ENTREGAR EL PROYECTO

Este proyecto incluye:

1. ✓ **Código fuente** completo y funcional
2. ✓ **Requisitos y objetivos** documentados
3. ✓ **Esquema de diseño** con diagramas
4. ✓ **Documentación** de uso (este archivo)

**¡El proyecto está completo y listo para entregar!** 🎉
