using System;
using System.Collections.Generic;

class SistemaPedidos
{
    static void Main()
    {
        List<decimal> costos = new List<decimal>();
        string continuar;

        do
        {
            Console.Write("¿Cuántos pedidos desea ingresar?: ");
            int cantidadPedidos;

            // VALIDACIÓN con while
            while (!int.TryParse(Console.ReadLine(), out cantidadPedidos) || cantidadPedidos <= 0)
            {
                Console.Write("Valor inválido. Ingrese un número válido: ");
            }

            // FOR → múltiples pedidos
            for (int i = 0; i < cantidadPedidos; i++)
            {
                Console.WriteLine($"\n--- Pedido #{i + 1} ---");

                decimal monto;
                int items;
                string ciudad;
                string tipoCliente;

                // VALIDACIONES
                Console.Write("Ingrese monto del pedido: ");
                while (!decimal.TryParse(Console.ReadLine(), out monto) || monto <= 0)
                {
                    Console.Write("Monto inválido. Intente nuevamente: ");
                }

                Console.Write("Ingrese ciudad destino (local/exterior): ");
                ciudad = Console.ReadLine().ToLower();
                while (ciudad != "local" && ciudad != "exterior")
                {
                    Console.Write("Valor inválido. Ingrese 'local' o 'exterior': ");
                    ciudad = Console.ReadLine().ToLower();
                }

                Console.Write("Ingrese tipo de cliente (nuevo/recurrente): ");
                tipoCliente = Console.ReadLine().ToLower();
                while (tipoCliente != "nuevo" && tipoCliente != "recurrente")
                {
                    Console.Write("Valor inválido. Ingrese 'nuevo' o 'recurrente': ");
                    tipoCliente = Console.ReadLine().ToLower();
                }

                Console.Write("Ingrese cantidad de ítems: ");
                while (!int.TryParse(Console.ReadLine(), out items) || items <= 0)
                {
                    Console.Write("Cantidad inválida. Intente nuevamente: ");
                }

                // LÓGICA
                string categoria = "";
                decimal costoEnvio = 0;

                if (monto >= 150000m && tipoCliente == "recurrente")
                {
                    categoria = "Envío Gratis";
                    costoEnvio = 0;
                }
                else if (items >= 5 || monto >= 300000m)
                {
                    categoria = "Envío Express";
                    costoEnvio = 30000;
                }
                else
                {
                    categoria = "Envío Estándar";
                    costoEnvio = 15000;
                }

                if (ciudad == "exterior")
                {
                    costoEnvio += 25000;
                }

                costos.Add(costoEnvio);

                // SALIDA
                Console.WriteLine("\n--- RESULTADO ---");
                Console.WriteLine("Categoría: " + categoria);
                Console.WriteLine("Costo de envío: $" + costoEnvio);

                Console.WriteLine("\nMensaje:");
                if (categoria == "Envío Gratis")
                {
                    Console.WriteLine("¡Gracias por tu fidelidad! Tu envío es completamente gratis.");
                }
                else if (categoria == "Envío Express")
                {
                    Console.WriteLine("Tu pedido será enviado en modalidad express.");
                }
                else
                {
                    Console.WriteLine("Tu pedido será enviado en modalidad estándar.");
                }
            }

            // Mostrar resumen con FOR
            Console.WriteLine("\n--- RESUMEN DE COSTOS ---");
            for (int i = 0; i < costos.Count; i++)
            {
                Console.WriteLine($"Pedido #{i + 1}: ${costos[i]}");
            }

            // DO-WHILE → repetir programa
            Console.Write("\n¿Desea ingresar más pedidos? (si/no): ");
            continuar = Console.ReadLine().ToLower();

        } while (continuar == "si");

        Console.WriteLine("Programa finalizado.");
    }
}
