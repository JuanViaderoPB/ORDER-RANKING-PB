using System;
using System.Collections.Generic;

class Pedido
{
    public decimal Monto { get; set; }
    public string Ciudad { get; set; }
    public string TipoCliente { get; set; }
    public int Items { get; set; }
    public string Categoria { get; set; }
    public decimal CostoEnvio { get; set; }
}

class SistemaPedidos
{
    static void Main()
    {
        List<Pedido> pedidos = new List<Pedido>();
        int opcion;

        do
        {
            Console.WriteLine("\n===== MENÚ =====");
            Console.WriteLine("1. Ingresar pedidos");
            Console.WriteLine("2. Mostrar resultados");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");

            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 3)
            {
                Console.Write("Opción inválida. Intente nuevamente: ");
            }

            switch (opcion)
            {
                case 1:
                    IngresarPedidos(pedidos);
                    break;

                case 2:
                    MostrarResultados(pedidos);
                    break;

                case 3:
                    Console.WriteLine("Saliendo del sistema...");
                    break;
            }

        } while (opcion != 3);
    }

    // 🔹 OPCIÓN 1
    static void IngresarPedidos(List<Pedido> pedidos)
    {
        Console.Write("¿Cuántos pedidos desea ingresar?: ");
        int cantidad;

        while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0)
        {
            Console.Write("Valor inválido. Intente nuevamente: ");
        }

        for (int i = 0; i < cantidad; i++)
        {
            Console.WriteLine($"\n--- Pedido #{i + 1} ---");

            Pedido p = new Pedido();

            // MONTO
            decimal monto;
            Console.Write("Ingrese monto del pedido: ");
            while (!decimal.TryParse(Console.ReadLine(), out monto) || monto <= 0)
            {
                Console.Write("Monto inválido: ");
            }
            p.Monto = monto;

            // CIUDAD
            Console.Write("Ingrese ciudad (local/exterior): ");
            p.Ciudad = Console.ReadLine().ToLower();
            while (p.Ciudad != "local" && p.Ciudad != "exterior")
            {
                Console.Write("Valor inválido: ");
                p.Ciudad = Console.ReadLine().ToLower();
            }

            // CLIENTE
            Console.Write("Tipo cliente (nuevo/recurrente): ");
            p.TipoCliente = Console.ReadLine().ToLower();
            while (p.TipoCliente != "nuevo" && p.TipoCliente != "recurrente")
            {
                Console.Write("Valor inválido: ");
                p.TipoCliente = Console.ReadLine().ToLower();
            }

            // ITEMS
            int items;
            Console.Write("Cantidad de ítems: ");
            while (!int.TryParse(Console.ReadLine(), out items) || items <= 0)
            {
                Console.Write("Cantidad inválida: ");
            }
            p.Items = items;

            // LÓGICA
            if (p.Monto >= 150000m && p.TipoCliente == "recurrente")
            {
                p.Categoria = "Envío Gratis";
                p.CostoEnvio = 0;
            }
            else if (p.Items >= 5 || p.Monto >= 300000m)
            {
                p.Categoria = "Envío Express";
                p.CostoEnvio = 30000;
            }
            else
            {
                p.Categoria = "Envío Estándar";
                p.CostoEnvio = 15000;
            }

            if (p.Ciudad == "exterior")
            {
                p.CostoEnvio += 25000;
            }

            pedidos.Add(p);

            Console.WriteLine("✅ Pedido registrado.");
        }
    }

    // 🔹 OPCIÓN 2
    static void MostrarResultados(List<Pedido> pedidos)
    {
        if (pedidos.Count == 0)
        {
            Console.WriteLine("No hay pedidos registrados.");
            return;
        }

        Console.WriteLine("\n--- RESULTADOS ---");

        decimal total = 0;

        for (int i = 0; i < pedidos.Count; i++)
        {
            var p = pedidos[i];

            Console.WriteLine($"\nPedido #{i + 1}");
            Console.WriteLine($"Monto: ${p.Monto}");
            Console.WriteLine($"Ciudad: {p.Ciudad}");
            Console.WriteLine($"Cliente: {p.TipoCliente}");
            Console.WriteLine($"Items: {p.Items}");
            Console.WriteLine($"Categoría: {p.Categoria}");
            Console.WriteLine($"Costo envío: ${p.CostoEnvio}");

            total += p.CostoEnvio;
        }

        Console.WriteLine("\nTOTAL ENVÍOS: $" + total);
    }
}
