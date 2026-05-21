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
            MostrarMenu();
            opcion = LeerOpcionMenu();

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

    /// <summary>
    /// Muestra el menú principal del sistema.
    /// </summary>
    static void MostrarMenu()
    {
        Console.WriteLine("\n===== MENÚ =====");
        Console.WriteLine("1. Ingresar pedidos");
        Console.WriteLine("2. Mostrar resultados");
        Console.WriteLine("3. Salir");
    }

    /// <summary>
    /// Lee y valida la opción seleccionada por el usuario.
    /// </summary>
    /// <returns>Opción válida del menú.</returns>
    static int LeerOpcionMenu()
    {
        int opcion;

        Console.Write("Seleccione una opción: ");

        while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 3)
        {
            Console.Write("Opción inválida. Intente nuevamente: ");
        }

        return opcion;
    }

    /// <summary>
    /// Permite ingresar múltiples pedidos al sistema.
    /// </summary>
    /// <param name="pedidos">Lista donde se almacenan los pedidos.</param>
    static void IngresarPedidos(List<Pedido> pedidos)
    {
        int cantidad = LeerCantidadPedidos();

        for (int i = 0; i < cantidad; i++)
        {
            Console.WriteLine($"\n--- Pedido #{i + 1} ---");

            Pedido pedido = CrearPedido();

            pedidos.Add(pedido);

            Console.WriteLine("✅ Pedido registrado.");
        }
    }

    /// <summary>
    /// Solicita la cantidad de pedidos a ingresar.
    /// </summary>
    /// <returns>Cantidad válida de pedidos.</returns>
    static int LeerCantidadPedidos()
    {
        int cantidad;

        Console.Write("¿Cuántos pedidos desea ingresar?: ");

        while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0)
        {
            Console.Write("Valor inválido. Intente nuevamente: ");
        }

        return cantidad;
    }

    /// <summary>
    /// Crea un pedido solicitando los datos al usuario.
    /// </summary>
    /// <returns>Objeto Pedido completamente diligenciado.</returns>
    static Pedido CrearPedido()
    {
        Pedido pedido = new Pedido();

        pedido.Monto = LeerMonto();
        pedido.Ciudad = LeerCiudad();
        pedido.TipoCliente = LeerTipoCliente();
        pedido.Items = LeerCantidadItems();

        pedido.Categoria = CalcularCategoria(
            pedido.Monto,
            pedido.TipoCliente,
            pedido.Items
        );

        pedido.CostoEnvio = CalcularCostoEnvio(
            pedido.Categoria,
            pedido.Ciudad
        );

        return pedido;
    }

    /// <summary>
    /// Solicita y valida el monto del pedido.
    /// </summary>
    /// <returns>Monto válido.</returns>
    static decimal LeerMonto()
    {
        decimal monto;

        Console.Write("Ingrese monto del pedido: ");

        while (!decimal.TryParse(Console.ReadLine(), out monto) || monto <= 0)
        {
            Console.Write("Monto inválido. Intente nuevamente: ");
        }

        return monto;
    }

    /// <summary>
    /// Solicita y valida la ciudad del pedido.
    /// </summary>
    /// <returns>Ciudad válida.</returns>
    static string LeerCiudad()
    {
        string ciudad;

        Console.Write("Ingrese ciudad (local/exterior): ");
        ciudad = Console.ReadLine().ToLower();

        while (ciudad != "local" && ciudad != "exterior")
        {
            Console.Write("Valor inválido. Ingrese 'local' o 'exterior': ");
            ciudad = Console.ReadLine().ToLower();
        }

        return ciudad;
    }

    /// <summary>
    /// Solicita y valida el tipo de cliente.
    /// </summary>
    /// <returns>Tipo de cliente válido.</returns>
    static string LeerTipoCliente()
    {
        string tipoCliente;

        Console.Write("Ingrese tipo de cliente (nuevo/recurrente): ");
        tipoCliente = Console.ReadLine().ToLower();

        while (tipoCliente != "nuevo" && tipoCliente != "recurrente")
        {
            Console.Write("Valor inválido. Ingrese 'nuevo' o 'recurrente': ");
            tipoCliente = Console.ReadLine().ToLower();
        }

        return tipoCliente;
    }

    /// <summary>
    /// Solicita y valida la cantidad de ítems.
    /// </summary>
    /// <returns>Cantidad válida de ítems.</returns>
    static int LeerCantidadItems()
    {
        int items;

        Console.Write("Ingrese cantidad de ítems: ");

        while (!int.TryParse(Console.ReadLine(), out items) || items <= 0)
        {
            Console.Write("Cantidad inválida. Intente nuevamente: ");
        }

        return items;
    }

    /// <summary>
    /// Calcula la categoría de envío según las reglas del negocio.
    /// </summary>
    /// <param name="monto">Monto del pedido.</param>
    /// <param name="tipoCliente">Tipo de cliente.</param>
    /// <param name="items">Cantidad de ítems.</param>
    /// <returns>Categoría asignada al pedido.</returns>
    static string CalcularCategoria(decimal monto, string tipoCliente, int items)
    {
        if (monto >= 150000m && tipoCliente == "recurrente")
        {
            return "Envío Gratis";
        }

        if (items >= 5 || monto >= 300000m)
        {
            return "Envío Express";
        }

        return "Envío Estándar";
    }

    /// <summary>
    /// Calcula el costo de envío según categoría y ciudad.
    /// </summary>
    /// <param name="categoria">Categoría del envío.</param>
    /// <param name="ciudad">Ciudad destino.</param>
    /// <returns>Costo total de envío.</returns>
    static decimal CalcularCostoEnvio(string categoria, string ciudad)
    {
        decimal costoEnvio = 0;

        switch (categoria)
        {
            case "Envío Gratis":
                costoEnvio = 0;
                break;

            case "Envío Express":
                costoEnvio = 30000;
                break;

            default:
                costoEnvio = 15000;
                break;
        }

        if (ciudad == "exterior")
        {
            costoEnvio += 25000;
        }

        return costoEnvio;
    }

    /// <summary>
    /// Muestra todos los pedidos registrados y el total de envíos.
    /// </summary>
    /// <param name="pedidos">Lista de pedidos registrados.</param>
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
            Pedido p = pedidos[i];

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
