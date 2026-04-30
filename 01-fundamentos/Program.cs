using System;
using System.Collections.Generic;
using System.Linq;

namespace InventorySystem
{
    /// <summary>
    /// Clase que representa un producto en el inventario
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Product(int id, string name, decimal price, int stock)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
        }

        /// <summary>
        /// Muestra la información del producto en formato legible
        /// </summary>
        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id} | Nombre: {Name} | Precio: ${Price:F2} | Stock: {Stock} unidades");
            
            // Estructura de control: Alerta de stock bajo
            if (Stock < 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  ALERTA: Stock critico");
                Console.ResetColor();
            }
            else if (Stock < 50)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("  AVISO: Stock moderado");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Calcula el valor total del producto en inventario
        /// </summary>
        public decimal GetTotalValue()
        {
            return Price * Stock;
        }
    }

    class Program
    {
        // Constantes
        private const int STOCK_CRITICO = 10;
        private const int STOCK_MODERADO = 50;
        
        // Lista para almacenar los productos del inventario
        private static List<Product> inventory = new List<Product>();
        private static int nextId = 1;

        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════════════════");
            Console.WriteLine("   SISTEMA DE GESTIÓN DE INVENTARIO");
            Console.WriteLine("═══════════════════════════════════════════════════");
            Console.WriteLine();

            // Agregar productos de ejemplo
            AddSampleProducts();
            Console.WriteLine("Se han cargado 5 productos de ejemplo.");
            Console.WriteLine("\nPresione cualquier tecla para continuar al menu...");
            Console.ReadKey();

            bool exit = false;

            // Bucle principal del programa
            while (!exit)
            {
                DisplayMenu();
                string option = Console.ReadLine() ?? "";

                // Estructura de control: Switch para manejar opciones del menú
                switch (option)
                {
                    case "1":
                        AddNewProduct();
                        break;
                    case "2":
                        UpdateStock();
                        break;
                    case "3":
                        ViewAllProducts();
                        break;
                    case "4":
                        DeleteProduct();
                        break;
                    case "5":
                        SearchProduct();
                        break;
                    case "6":
                        ShowStatistics();
                        break;
                    case "7":
                        exit = true;
                        Console.WriteLine("\nGracias por usar el sistema! Hasta pronto.");
                        break;
                    default:
                        ShowError("\nOpcion no valida. Por favor, intente de nuevo.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        /// <summary>
        /// Muestra un mensaje de error en rojo
        /// </summary>
        static void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Muestra un mensaje de éxito en verde
        /// </summary>
        static void ShowSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Muestra un mensaje de advertencia en amarillo
        /// </summary>
        static void ShowWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Solicita y valida un número entero
        /// </summary>
        static bool TryReadInt(string prompt, out int result)
        {
            Console.Write(prompt);
            return int.TryParse(Console.ReadLine(), out result);
        }

        /// <summary>
        /// Solicita y valida un número decimal
        /// </summary>
        static bool TryReadDecimal(string prompt, out decimal result)
        {
            Console.Write(prompt);
            return decimal.TryParse(Console.ReadLine(), out result);
        }

        /// <summary>
        /// Muestra el menú principal del sistema
        /// </summary>
        static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════════════════");
            Console.WriteLine("              MENÚ PRINCIPAL");
            Console.WriteLine("═══════════════════════════════════════════════════");
            Console.WriteLine("1. Agregar nuevo producto");
            Console.WriteLine("2. Actualizar stock de producto");
            Console.WriteLine("3. Ver todos los productos");
            Console.WriteLine("4. Eliminar producto");
            Console.WriteLine("5. Buscar producto");
            Console.WriteLine("6. Mostrar estadísticas");
            Console.WriteLine("7. Salir");
            Console.WriteLine("═══════════════════════════════════════════════════");
            Console.Write("Seleccione una opción: ");
        }

        /// <summary>
        /// Agrega productos de ejemplo al iniciar el sistema
        /// </summary>
        static void AddSampleProducts()
        {
            inventory.Add(new Product(nextId++, "Laptop Dell XPS", 1299.99m, 15));
            inventory.Add(new Product(nextId++, "Mouse Logitech", 29.99m, 45));
            inventory.Add(new Product(nextId++, "Teclado Mecánico", 89.99m, 8));
            inventory.Add(new Product(nextId++, "Monitor 24 pulgadas", 249.99m, 20));
            inventory.Add(new Product(nextId++, "Auriculares Bluetooth", 79.99m, 30));
        }

        /// <summary>
        /// Método para agregar un nuevo producto al inventario
        /// </summary>
        static void AddNewProduct()
        {
            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════════════════");
            Console.WriteLine("         AGREGAR NUEVO PRODUCTO");
            Console.WriteLine("═══════════════════════════════════════════════════");
            
            Console.Write("\nNombre del producto: ");
            string name = Console.ReadLine() ?? "";

            // Validación: Nombre no vacío
            if (string.IsNullOrWhiteSpace(name))
            {
                ShowError("El nombre no puede estar vacio.");
                return;
            }

            if (!TryReadDecimal("Precio del producto: $", out decimal price) || price <= 0)
            {
                ShowError("Precio invalido. Debe ser un numero mayor a 0.");
                return;
            }

            if (!TryReadInt("Cantidad en stock: ", out int stock) || stock < 0)
            {
                ShowError("Cantidad invalida. Debe ser un numero no negativo.");
                return;
            }

            // Crear y agregar el producto
            Product newProduct = new Product(nextId++, name, price, stock);
            inventory.Add(newProduct);

            ShowSuccess($"\nProducto agregado exitosamente con ID: {newProduct.Id}");
        }

        /// <summary>
        /// Método para actualizar el stock de un producto existente
        /// </summary>
        static void UpdateStock()
        {
            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════════════════");
            Console.WriteLine("         ACTUALIZAR STOCK");
            Console.WriteLine("═══════════════════════════════════════════════════");

            if (!TryReadInt("\nIngrese el ID del producto: ", out int id))
            {
                ShowError("ID invalido.");
                return;
            }

            // Buscar producto por ID usando LINQ
            Product? product = inventory.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                ShowError($"No se encontro un producto con ID: {id}");
                return;
            }

            Console.WriteLine($"\nProducto encontrado: {product.Name}");
            Console.WriteLine($"Stock actual: {product.Stock}");
            Console.WriteLine("\n1. Agregar stock (reposición)");
            Console.WriteLine("2. Reducir stock (venta)");
            Console.WriteLine("3. Establecer stock específico");
            Console.Write("\nSeleccione una opción: ");

            string option = Console.ReadLine() ?? "";

            // Switch para tipo de actualización
            switch (option)
            {
                case "1":
                    AddStock(product);
                    break;
                case "2":
                    ReduceStock(product);
                    break;
                case "3":
                    SetStock(product);
                    break;
                default:
                    ShowError("Opcion no valida.");
                    break;
            }
        }

        /// <summary>
        /// Agrega unidades al stock de un producto
        /// </summary>
        static void AddStock(Product product)
        {
            if (TryReadInt("Cantidad a agregar: ", out int quantity) && quantity > 0)
            {
                product.Stock += quantity;
                ShowSuccess($"Stock actualizado. Nuevo stock: {product.Stock}");
            }
            else
            {
                ShowError("Cantidad invalida.");
            }
        }

        /// <summary>
        /// Reduce unidades del stock de un producto
        /// </summary>
        static void ReduceStock(Product product)
        {
            if (TryReadInt("Cantidad a reducir: ", out int quantity) && quantity > 0)
            {
                // Validación: No permitir stock negativo
                if (product.Stock >= quantity)
                {
                    product.Stock -= quantity;
                    ShowSuccess($"Stock actualizado. Nuevo stock: {product.Stock}");
                }
                else
                {
                    ShowError($"Stock insuficiente. Stock actual: {product.Stock}");
                }
            }
            else
            {
                ShowError("Cantidad invalida.");
            }
        }

        /// <summary>
        /// Establece un valor específico de stock
        /// </summary>
        static void SetStock(Product product)
        {
            if (TryReadInt("Nuevo stock: ", out int newStock) && newStock >= 0)
            {
                product.Stock = newStock;
                ShowSuccess($"Stock actualizado. Nuevo stock: {product.Stock}");
            }
            else
            {
                ShowError("Cantidad invalida.");
            }
        }

        /// <summary>
        /// Muestra todos los productos en el inventario
        /// </summary>
        static void ViewAllProducts()
        {
            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════════════════");
            Console.WriteLine("         LISTA DE PRODUCTOS");
            Console.WriteLine("═══════════════════════════════════════════════════");

            // Validación: Verificar si hay productos
            if (inventory.Count == 0)
            {
                ShowWarning("\nEl inventario esta vacio.");
                return;
            }

            Console.WriteLine($"\nTotal de productos: {inventory.Count}\n");

            // Bucle for para recorrer todos los productos
            for (int i = 0; i < inventory.Count; i++)
            {
                inventory[i].DisplayInfo();
                Console.WriteLine("───────────────────────────────────────────────────");
            }
        }

        /// <summary>
        /// Elimina un producto del inventario
        /// </summary>
        static void DeleteProduct()
        {
            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════════════════");
            Console.WriteLine("         ELIMINAR PRODUCTO");
            Console.WriteLine("═══════════════════════════════════════════════════");

            if (!TryReadInt("\nIngrese el ID del producto a eliminar: ", out int id))
            {
                ShowError("ID invalido.");
                return;
            }

            // Buscar producto usando LINQ
            Product? product = inventory.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                ShowError($"No se encontro un producto con ID: {id}");
                return;
            }

            Console.WriteLine($"\nProducto a eliminar:");
            product.DisplayInfo();
            Console.Write("\n¿Está seguro de que desea eliminar este producto? (S/N): ");
            string confirmation = Console.ReadLine()?.ToUpper() ?? "";

            // Estructura if-else para confirmación
            if (confirmation == "S")
            {
                inventory.Remove(product);
                ShowSuccess("\nProducto eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("\nOperacion cancelada.");
            }
        }

        /// <summary>
        /// Busca productos por nombre o ID
        /// </summary>
        static void SearchProduct()
        {
            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════════════════");
            Console.WriteLine("         BUSCAR PRODUCTO");
            Console.WriteLine("═══════════════════════════════════════════════════");

            Console.WriteLine("\n1. Buscar por ID");
            Console.WriteLine("2. Buscar por nombre");
            Console.Write("\nSeleccione una opción: ");
            string option = Console.ReadLine() ?? "";

            switch (option)
            {
                case "1":
                    SearchById();
                    break;
                case "2":
                    SearchByName();
                    break;
                default:
                    ShowError("Opcion no valida.");
                    break;
            }
        }

        /// <summary>
        /// Busca un producto por su ID
        /// </summary>
        static void SearchById()
        {
            if (TryReadInt("\nIngrese el ID: ", out int id))
            {
                // Buscar usando LINQ
                Product? product = inventory.FirstOrDefault(p => p.Id == id);
                if (product != null)
                {
                    Console.WriteLine("\nProducto encontrado:");
                    Console.WriteLine("───────────────────────────────────────────────────");
                    product.DisplayInfo();
                }
                else
                {
                    ShowWarning($"\nNo se encontro un producto con ID: {id}");
                }
            }
            else
            {
                ShowError("ID invalido.");
            }
        }

        /// <summary>
        /// Busca productos por nombre (coincidencia parcial)
        /// </summary>
        static void SearchByName()
        {
            Console.Write("\nIngrese el nombre o parte del nombre: ");
            string searchTerm = Console.ReadLine()?.ToLower() ?? "";

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                ShowError("Debe ingresar un termino de busqueda.");
                return;
            }

            // Buscar usando LINQ para mayor eficiencia
            List<Product> results = inventory
                .Where(p => p.Name.ToLower().Contains(searchTerm))
                .ToList();

            // Estructura if-else para mostrar resultados
            if (results.Count > 0)
            {
                Console.WriteLine($"\nSe encontraron {results.Count} producto(s):");
                Console.WriteLine("───────────────────────────────────────────────────");
                
                // Bucle for para mostrar resultados
                for (int i = 0; i < results.Count; i++)
                {
                    results[i].DisplayInfo();
                    Console.WriteLine("───────────────────────────────────────────────────");
                }
            }
            else
            {
                ShowWarning($"\nNo se encontraron productos con el termino: {searchTerm}");
            }
        }

        /// <summary>
        /// Muestra estadísticas del inventario
        /// </summary>
        static void ShowStatistics()
        {
            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════════════════");
            Console.WriteLine("         ESTADÍSTICAS DEL INVENTARIO");
            Console.WriteLine("═══════════════════════════════════════════════════");

            if (inventory.Count == 0)
            {
                ShowWarning("\nEl inventario esta vacio.");
                return;
            }

            // Calcular estadísticas usando LINQ para mayor eficiencia
            decimal totalValue = inventory.Sum(p => p.GetTotalValue());
            int totalUnits = inventory.Sum(p => p.Stock);
            int lowStockCount = inventory.Count(p => p.Stock < STOCK_CRITICO);
            Product? mostExpensive = inventory.OrderByDescending(p => p.Price).FirstOrDefault();
            Product? cheapest = inventory.OrderBy(p => p.Price).FirstOrDefault();
            decimal averagePrice = totalValue / totalUnits;

            // Mostrar estadísticas
            Console.WriteLine($"\nTotal de productos diferentes: {inventory.Count}");
            Console.WriteLine($"Total de unidades en inventario: {totalUnits}");
            Console.WriteLine($"Valor total del inventario: ${totalValue:F2}");
            Console.WriteLine($"Precio promedio por unidad: ${averagePrice:F2}");
            Console.WriteLine($"Productos con stock bajo (< 10): {lowStockCount}");

            if (mostExpensive != null)
            {
                Console.WriteLine($"\nProducto más caro: {mostExpensive.Name} - ${mostExpensive.Price:F2}");
            }

            if (cheapest != null)
            {
                Console.WriteLine($"Producto más barato: {cheapest.Name} - ${cheapest.Price:F2}");
            }

            // Mostrar productos con stock bajo
            if (lowStockCount > 0)
            {
                ShowWarning("\nPRODUCTOS CON STOCK BAJO:");
                Console.WriteLine("───────────────────────────────────────────────────");
                
                // Usar LINQ para filtrar y mostrar productos con stock bajo
                var productosStockBajo = inventory.Where(p => p.Stock < STOCK_CRITICO);
                foreach (var product in productosStockBajo)
                {
                    product.DisplayInfo();
                }
            }
        }
    }
}
