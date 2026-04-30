# ESQUEMA DE DISEÑO DEL SISTEMA
## Sistema de Gestión de Inventario

---

## PASO 3: ESQUEMA Y PLANIFICACIÓN DEL DISEÑO

### ARQUITECTURA DEL SISTEMA

El sistema está dividido en dos componentes principales:

```
╔═══════════════════════════════════════════════════════════════════╗
║                    🏢 SISTEMA DE INVENTARIO                       ║
╠═══════════════════════════════════════════════════════════════════╣
║                                                                   ║
║   ╔═══════════════════╗              ╔════════════════════════╗  ║
║   ║  📦 Clase Product ║              ║  ⚙️  Clase Program     ║  ║
║   ║  (Modelo datos)   ║◄─────────────║  (Lógica principal)   ║  ║
║   ╚═══════════════════╝              ╚════════════════════════╝  ║
║            │                                      │               ║
║   ┌────────┴────────┐                   ┌────────┴─────────┐     ║
║   │                 │                   │                  │     ║
║   │ 📌 Propiedades: │                   │ 🔧 Gestiona:     │     ║
║   │  • Id (int)     │                   │  • Lista de      │     ║
║   │  • Name (str)   │                   │    productos     │     ║
║   │  • Price (dec)  │                   │  • Menú UI       │     ║
║   │  • Stock (int)  │                   │  • Operaciones   │     ║
║   │                 │                   │    CRUD          │     ║
║   │ 🔨 Métodos:     │                   │  • Validaciones  │     ║
║   │  • DisplayInfo()│                   │  • Búsquedas     │     ║
║   │  • GetTotal     │                   │  • Estadísticas  │     ║
║   │    Value()      │                   │                  │     ║
║   └─────────────────┘                   └──────────────────┘     ║
║                                                                   ║
╚═══════════════════════════════════════════════════════════════════╝
```

---

### DIAGRAMA DE FLUJO PRINCIPAL

```
                         ╔═══════════════╗
                         ║   🚀 INICIO   ║
                         ╚═══════╤═══════╝
                                 │
                         ╔═══════▼════════╗
                         ║  📂 Cargar     ║
                         ║  datos ejemplo ║
                         ╚═══════╤════════╝
                                 │
                ╔════════════════▼═════════════════╗
                ║        📋 Mostrar Menú          ║◄──────┐
                ║      (7 opciones disponibles)   ║       │
                ╚════════════════╤═════════════════╝       │
                                 │                         │
                         ╔═══════▼════════╗                │
                         ║  ⌨️  Leer      ║                │
                         ║  opción usuario║                │
                         ╚═══════╤════════╝                │
                                 │                         │
                    ╔════════════▼═════════════╗           │
                    ║    🔀 SWITCH Statement   ║           │
                    ║   (Evaluar opción 1-7)   ║           │
                    ╚════════════╤═════════════╝           │
                                 │                         │
        ┌────────────┬───────────┼────────────┬──────────┐ │
        │            │            │            │          │ │
   ╔════▼═══╗  ╔════▼═══╗  ╔════▼═══╗  ╔════▼═══╗  ╔═══▼══▼═══╗
   ║   ➕   ║  ║   🔄   ║  ║   👁️   ║  ║   ❌   ║  ║  🔍 📊  ║
   ║ Agregar║  ║Actualiz║  ║  Ver   ║  ║Eliminar║  ║ Buscar & ║
   ║Product ║  ║ Stock  ║  ║ Todos  ║  ║        ║  ║  Stats   ║
   ╚════╤═══╝  ╚════╤═══╝  ╚════╤═══╝  ╚════╤═══╝  ╚═══╤══════╝
        │            │            │            │          │
        └────────────┴────────────┴────────────┴──────────┘
                                 │
                         ╔═══════▼════════╗
                         ║  ❓ ¿Salir?    ║
                         ║   (Opción 7)   ║
                         ╚═══╤═══════╤════╝
                             │       │
                         NO  │       │  SI
                             │       │
                         ────┘       └────┐
                         │                │
                         └────────────────┘
                                          │
                                  ╔═══════▼═══════╗
                                  ║  🏁 FIN APP   ║
                                  ║ ¡Hasta pronto!║
                                  ╚═══════════════╝
```

---

### DESGLOSE DE TAREAS Y CÓDIGO REQUERIDO

#### **TAREA 1: Agregar Nuevo Producto**

**Componentes de código:**
- **Variables**: `string name`, `decimal price`, `int stock`, `int nextId`
- **Estructuras de control**: 
  - `if-else` para validar nombre vacío
  - `if` para validar precio positivo
  - `if` para validar stock no negativo
- **Métodos**: `AddNewProduct()`
- **Objetos**: Crear nueva instancia de `Product`
    ┌─────────────────────────────────────────────┐
    │  🎯 TAREA 1: Agregar Nuevo Producto        │
    └─────────────────────────────────────────────┘

    ╔═══════════════════════╗
    ║  📝 Solicitar nombre  ║
    ╚══════════╤════════════╝
               │
    ╔══════════▼══════════╗      ❌
    ║  Validar nombre     ║─────────► Error: Nombre vacío
    ║  (if vacío?)        ║
    ╚══════════╤══════════╝
               │ ✅
    ╔══════════▼══════════╗
    ║  💰 Solicitar precio║
    ╚══════════╤══════════╝
               │
    ╔══════════▼══════════╗      ❌
    ║  Validar precio     ║─────────► Error: Precio inválido
    ║  (if ≤ 0?)          ║
    ╚══════════╤══════════╝
               │ ✅
    ┌─────────────────────────────────────────────┐
    │  🎯 TAREA 2: Actualizar Stock               │
    └─────────────────────────────────────────────┘

    ╔════════════════════╗
    ║  🆔 Solicitar ID   ║
    ╚═════════╤══════════╝
              │
    ╔═════════▼══════════╗
    ║  🔍 Buscar producto║
    ║  (foreach)         ║
    ╚═════════╤══════════╝
              │
              │ ❌ No encontrado
              ├──────────────► Error: Producto no existe
              │
              │ ✅ Encontrado
    ╔═════════▼══════════════════╗
    ║  🔀 SWITCH (tipo operación)║
    ╚═════════╤══════════════════╝
              │
    ┌─────────┼─────────┬─────────┐
    │         │         │         │
 ╔══▼══╗  ╔══▼══╗  ╔══▼══╗     │
    ┌─────────────────────────────────────────────┐
    │  🎯 TAREA 3: Ver Todos los Productos       │
    └─────────────────────────────────────────────┘

    ╔══════════════════════╗
    ║  📊 Verificar        ║
    ║  inventory.Count     ║
    ╚═══════╤══════════════╝
            │
    ╔═══════▼═══════╗
    ║  if Count==0? ║
    ╚═══╤═══════╤═══╝
        │       │
    ✅ SI      NO
        │       │
    ┌───▼────┐  │
    │⚠️ Vacío│  │
    │mensaje │  │
    └────────┘  │
                │
    ╔═══════════▼════════════╗
    ║  🔁 FOR Loop           ║
    ║  i = 0 to Count-1      ║
    ╚═══════════╤════════════╝
                │
                │ (para cada i)
    ╔═══════════▼═══════════╗
    ║  🖥️  inventory[i]     ║
    ║  .DisplayInfo()       ║
    ╚═══════════╤═══════════╝
                │
    ╔═══════════▼═══════════╗
    ║  🔀 IF-ELSE           ║
    ║  (alertas de stock)   ║
    ╠═══════════════════════╣
    ║  if Stock < 10:       ║
    ║    🔴 CRÍTICO         ║
    ║  else if Stock < 50:  ║
    ║    🟡 MODERADO        ║
    ║  else:                ║
    ║    🟢 OK              ║
    ╚═══════════╤═══════════╝
                │
                │ (siguiente iteración)
                └──────► Continuar for
                
    ╔═══════════════════════╗
    ║  ✅ Lista completa    ║
    ╚═══════════════════════╝
    │     ║ Validar    ║        │
    │     ║ suficiente?║        │
    ┌─────────────────────────────────────────────┐
    │  🎯 TAREA 5: Buscar Productos               │
    └─────────────────────────────────────────────┘

                    ╔═══════════════════╗
                    ║  🔀 SWITCH        ║
                    ║  Tipo de búsqueda ║
                    ╚════════╤══════════╝
                             │
                  ┌──────────┴──────────┐
                  │                     │
    ╔═════════════▼═════════╗  ╔═══════▼═══════════════╗
    ║  🔢 OPCIÓN 1:         ║  ║  📝 OPCIÓN 2:         ║
    ║  Buscar por ID        ║  ║  Buscar por Nombre    ║
    ╚═════════════╤═════════╝  ╚═══════╤═══════════════╝
                  │                    │
    ╔═════════════▼═════════╗  ╔═══════▼═══════════════╗
    ║  🆔 Solicitar ID      ║  ║  📝 Solicitar término ║
    ╚═════════════╤═════════╝  ╚═══════╤═══════════════╝
                  │                    │
    ╔═════════════▼═════════╗  ╔═══════▼═══════════════╗
    ║  🔁 FOREACH           ║  ║  📋 Crear lista vacía ║
    ║  Buscar en inventory  ║  ║  results = []         ║
    ╚═════════════╤═════════╝  ╚═══════╤═══════════════╝
                  │                    │
    ╔═════════════▼═════════╗  ╔═══════▼═══════════════╗
    ║  if product.Id == id? ║  ║  🔁 FOREACH producto  ║
    ╚══╤══════════════════╤═╝  ║  en inventory         ║
       │              │        ╚═══════╤═══════════════╝
    ✅ SI          ❌ NO              │
    ┌─────────────────────────────────────────────┐
    │  🎯 TAREA 6: Mostrar Estadísticas           │
    └─────────────────────────────────────────────┘

    ╔════════════════════════╗
    ║  📊 Inicializar vars   ║
    ║  • totalValue = 0      ║
    ║  • totalUnits = 0      ║
    ║  • lowStockCount = 0   ║
    ║  • mostExpensive = null║
    ║  • cheapest = null     ║
    ║  • index = 0           ║
    ╚════════════╤═══════════╝
                 │
    ╔════════════▼═══════════════════════╗
    ║  🔁 WHILE (index < Count)          ║
    ╠════════════════════════════════════╣
    ║  product = inventory[index]        ║
    ║                                    ║
    ║  totalValue += GetTotalValue() ━━┓ ║
    ║  totalUnits += stock           ━━┫ ║
    ║                                  ┃ ║  Operaciones
    ║  ╔═══════════════════════════╗  ┃ ║  por cada
    ║  ║ if stock < 10:            ║  ┃ ║  producto
    ║  ║   lowStockCount++         ║  ┃ ║
    ║  ╚═══════════════════════════╝  ┃ ║
    ║                                  ┃ ║
    ║  ╔═══════════════════════════╗  ┃ ║
    ║  ║ if price > mostExpensive: ║  ┃ ║
    ║  ║   actualizar              ║  ┃ ║
    ║  ╚═══════════════════════════╝  ┃ ║
    ║                                  ┃ ║
    ║  ╔═══════════════════════════╗  ┃ ║
    ║  ║ if price < cheapest:      ║  ┃ ║
    ║  ║   actualizar              ║  ┃ ║
    ║  ╚═══════════════════════════╝  ┃ ║
    ║                                  ┃ ║
    ║  index++ ━━━━━━━━━━━━━━━━━━━━━━━┛ ║
    ╚════════════╤═══════════════════════╝
                 │
    ╔════════════▼═══════════╗
    ║  🧮 Calcular promedio  ║
    ║  = totalValue / units  ║
    ╚════════════╤═══════════╝
                 │
    ╔════════════▼════════════════════╗
    ║  📋 Mostrar estadísticas:       ║
    ║  • Total productos              ║
    ║  • Total unidades               ║
    ║  • Valor total                  ║
    ║  • Precio promedio              ║
    ║  • Productos stock bajo         ║
    ║  • Más caro / Más barato        ║
    ╚════════════╤════════════════════╝
                 │
    ╔════════════▼═══════════════════╗
    ║  🔁 FOR Loop                   ║
    ║  Mostrar productos con         ║
    ║  🔴 stock bajo (< 10)          ║
    ╚════════════════════════════════╝═╝    │
                                 │◄───────────┘
                        ╔════════▼═══════╗
                        ║  🔁 FOR Loop   ║
                        ║  Mostrar todos ║
                        ║  los results   ║
                        ╚════════════════╝
    ╚════════════════════╝═══════╝
               │ ✅
    ╔══════════▼══════════╗
    ║  🆔 Crear Product   ║
    ║  con ID único       ║
    ╚══════════╤══════════╝
               │
    ╔══════════▼══════════╗
    ║  📋 Agregar a       ║
    ║  List<Product>      ║
    ╚══════════╤══════════╝
               │
    ╔══════════▼══════════╗
    ║  ✅ Confirmar éxito ║
    ╚═════════════════════╝o → Validar (if ≤ 0 → error)
3. Solicitar stock → Validar (if < 0 → error)
4. Crear Product con ID autoincrementado
5. Agregar a lista
6. Confirmar éxito
```

---

#### **TAREA 2: Actualizar Stock**

**Componentes de código:**
- **Variables**: `int id`, `int quantity`, `string option`
- **Estructuras de control**: 
  - `switch` para tipo de actualización (agregar/reducir/establecer)
  - `if-else` para validar stock suficiente
- **Bucles**: `foreach` para buscar producto por ID
- **Métodos**: `UpdateStock()`, `AddStock()`, `ReduceStock()`, `SetStock()`

**Flujo:**
```
1. Solicitar ID → Buscar producto (foreach)
2. Si no existe → error
3. Mostrar opciones (switch):
   - Caso 1: Agregar stock
   - Caso 2: Reducir stock (validar disponibilidad)
   - Caso 3: Establecer nuevo stock
4. Actualizar valor
5. Confirmar cambio
```

---

#### **TAREA 3: Ver Todos los Productos**

**Componentes de código:**
- **Variables**: `int i` (contador)
- **Estructuras de control**: 
  - `if` para verificar lista vacía
  - `if-else` en método `DisplayInfo()` para alertas de stock
- **Bucles**: `for` para iterar sobre todos los productos
- **Métodos**: `ViewAllProducts()`, `Product.DisplayInfo()`

**Flujo:**
```
1. Verificar si inventory.Count == 0 (if)
2. Si vacío → mostrar mensaje
3. Si hay productos:
   - Bucle for desde i=0 hasta inventory.Count
   - Llamar DisplayInfo() para cada producto
   - Mostrar alertas de stock (if-else)
```

---

#### **TAREA 4: Eliminar Producto**

**Componentes de código:**
- **Variables**: `int id`, `string confirmation`
- **Estructuras de control**: 
  - `if` para validar existencia
  - `if-else` para confirmar eliminación
- **Bucles**: `foreach` implícito en búsqueda
- **Métodos**: `DeleteProduct()`, `FindProductById()`

**Flujo:**
```
1. Solicitar ID
2. Buscar producto (foreach)
3. Si no existe → error
4. Mostrar información del producto
5. Solicitar confirmación (if-else):
   - Si "S" → eliminar de lista
   - Si no → cancelar
```

---

#### **TAREA 5: Buscar Productos**

**Componentes de código:**
- **Variables**: `int id`, `string searchTerm`, `List<Product> results`
- **Estructuras de control**: 
  - `switch` para tipo de búsqueda (por ID o nombre)
  - `if` para verificar resultados encontrados
- **Bucles**: 
  - `foreach` para buscar por nombre
  - `for` para mostrar resultados
- **Métodos**: `SearchProduct()`, `SearchById()`, `SearchByName()`

**Flujo:**
```
Opción 1 - Buscar por ID:
1. Solicitar ID
2. Buscar con foreach
3. Si encuentra → mostrar
4. Si no → mensaje

Opción 2 - Buscar por nombre:
1. Solicitar término de búsqueda
2. Crear lista de resultados vacía
3. Foreach producto en inventory:
   - Si nombre contiene término → agregar a resultados
4. Mostrar todos los resultados con bucle for
```

---

#### **TAREA 6: Mostrar Estadísticas**

**Componentes de código:**
- **Variables**: `decimal totalValue`, `int totalUnits`, `int lowStockCount`, `int index`
- **Estructuras de control**: 
  - `if` para actualizar producto más caro/barato
  - `if` para contar stock bajo
- **Bucles**: 
  - `while` para calcular estadísticas
  - `for` para mostrar productos con stock bajo
- **Métodos**: `ShowStatistics()`, `Product.GetTotalValue()`

**Flujo:**
```
              ╭────────────────────────────╮
              │ 🎯 Mostrar Estadísticas    │
              ╰────────────────────────────╯

                 ┌──────────────┐
                 │ Inicializar  │
                 │  variables:  │
                 │• totalValue  │
                 │• totalUnits  │
                 │• lowStock    │
                 │• mostExpensiv│
                 │• cheapest    │
                 │• index = 0   │
                 └──────┬───────┘
                        │
         ╔══════════════▼═══════════════╗
    ┌───►║   WHILE (index < Count)     ║
    │    ╚══════════════╤═══════════════╝
    │                   │
    │          ┌────────▼─────────┐
    │          │ product =        │
    │          │ inventory[index] │
    │          └────────┬─────────┘
    │                   │
    │          ┌────────▼─────────┐
    │          │ totalValue +=    │
    │          │ GetTotalValue()  │
    │          └────────┬─────────┘
    │                   │
    │          ┌────────▼─────────┐
    │          │ totalUnits +=    │
    │          │     stock        │
    │          └────────┬─────────┘
    │                   │
    │             ╱────▼────╲
    │            ╱  ¿Stock  ╲       ┌──────────────┐
    │           ╱    < 10?   ╲──SI──►│lowStockCount││
    │           ╲            ╱       │     ++       │
    │            ╲──────────╱        └──────────────┘
    │                   │ NO
    │                   │
    │             ╱────▼─────╲
    │            ╱  ¿Precio   ╲      ┌──────────────┐
    │           ╱   > max?     ╲─SI─►│ Actualizar   │
    │           ╲              ╱     │mostExpensive │
    │            ╲────────────╱      └──────────────┘
    │                   │ NO
    │                   │
    │             ╱────▼─────╲
    │            ╱  ¿Precio   ╲      ┌──────────────┐
    │           ╱   < min?     ╲─SI─►│ Actualizar   │
    │           ╲              ╱     │   cheapest   │
    │            ╲────────────╱      └──────────────┘
    │                   │ NO
    │                   │
    │          ┌────────▼─────────┐
    │          │    index++       │
    │          └────────┬─────────┘
    │                   │
    │             ╱────▼─────╲
    │            ╱  ¿Hay más  ╲
    │           ╱  productos?  ╲──SI──┐
    │           ╲              ╱       │
    │            ╲────────────╱        │
    └──────────────┘NO                 │
                   │◄──────────────────┘
                   │
            ┌──────▼────────┐
            │   Calcular    │
            │   promedio    │
            │= value/units  │
            └──────┬────────┘
                   │
            ┌──────▼────────┐
            │  📊 Mostrar   │
            │ estadísticas: │
            │• Total prods  │
            │• Total units  │
            │• Valor total  │
            │• Promedio     │
            │• Stock bajo   │
            │• Más caro     │
            │• Más barato   │
            └──────┬────────┘
                   │
            ┌──────▼────────┐
            │   FOR Loop    │
            │  Listar con   │
            │ 🔴 stock bajo │
            └───────────────┘
```

---

### ESTRUCTURAS DE CÓDIGO UTILIZADAS

#### ✅ **Estructuras de Control**

**IF-ELSE:**
- Validación de entradas del usuario
- Verificación de stock suficiente
- Confirmación de operaciones
- Alertas de stock bajo en DisplayInfo()

**SWITCH:**
- Selección de opciones del menú principal
- Selección de tipo de actualización de stock
- Selección de tipo de búsqueda

#### ✅ **Bucles**

**FOR:**
- Iterar sobre todos los productos para mostrarlos
- Mostrar resultados de búsqueda
- Listar productos con stock bajo

**WHILE:**
- Bucle principal de la aplicación (menú)
- Cálculo de estadísticas

**FOREACH:**
- Buscar productos por ID
- Buscar productos por nombre
- Búsquedas en general

#### ✅ **Métodos Personalizados**

```
Clase Product:
- DisplayInfo() → Mostrar información del producto
- GetTotalValue() → Calcular valor total

Clase Program:
- Main() → Punto de entrada
- DisplayMenu() → Mostrar menú
- AddNewProduct() → Agregar producto
- UpdateStock() → Actualizar stock
- AddStock() → Agregar unidades
- ReduceStock() → Reducir unidades
- SetStock() → Establecer stock
- ViewAllProducts() → Ver todos
- DeleteProduct() → Eliminar producto
- SearchProduct() → Buscar (menú)
- SearchById() → Buscar por ID
- SearchByName() → Buscar por nombre
- ShowStatistics() → Mostrar estadísticas
- FindProductById() → Buscar producto por ID
- AddSampleProducts() → Datos de ejemplo
```

---

### ESTRUCTURAS DE DATOS

**Clase Product:**
```
- Id: int
- Name: string
- Price: decimal
- Stock: int
```

**Variables globales:**
```
- inventory: List<Product> → Almacena todos los productos
- nextId: int → Contador para IDs únicos
```

---

### VALIDACIONES IMPLEMENTADAS

1. ✓ Nombre no vacío
2. ✓ Precio positivo
3. ✓ Stock no negativo
4. ✓ ID válido para operaciones
5. ✓ Stock suficiente para reducción
6. ✓ Producto existe antes de operar
7. ✓ Confirmación para eliminar
8. ✓ Término de búsqueda no vacío

---

## RESUMEN DE CUMPLIMIENTO

Este diseño cumple con todos los requisitos del proyecto:

✅ **Estructuras de control**: if-else y switch implementados
✅ **Bucles**: for, while y foreach implementados
✅ **Métodos personalizados**: 14 métodos definidos
✅ **Funcionalidad completa**: Todas las operaciones CRUD
✅ **Validaciones**: Manejo robusto de entradas
✅ **Organización**: Código modular y bien estructurado
