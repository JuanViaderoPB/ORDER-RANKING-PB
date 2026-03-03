using System;

class SistemaPedidos
{
    static void Main()
    {
        // Entradas
        Console.Write("Ingrese monto del pedido: ");
        decimal monto = decimal.Parse(Console.ReadLine());

        Console.Write("Ingrese ciudad destino: ");
        string ciudad = Console.ReadLine().ToLower();

        Console.Write("Ingrese tipo de cliente (nuevo/recurrente): ");
        string tipoCliente = Console.ReadLine().ToLower();

        Console.Write("Ingrese cantidad de ítems: ");
        int items = int.Parse(Console.ReadLine());

        // Variables de salida
        string categoria = "";
        decimal costoEnvio = 0;

        // ---- LÓGICA PRINCIPAL ----

        // 1️⃣ Envío gratis tiene prioridad
        if (monto >= 150000m && tipoCliente == "recurrente")
        {
            categoria = "Envío Gratis";
            costoEnvio = 0;
        }
        else
        {
            // 2️⃣ Evaluar envío express
            if (items >= 5 || monto >= 300000m)
            {
                categoria = "Envío Express";
                costoEnvio = 30000;
            }
            else
            {
                // 3️⃣ Caso restante → estándar
                categoria = "Envío Estándar";
                costoEnvio = 15000;
            }
        }

        // 4️⃣ Recargo por ciudad exterior
        if (ciudad == "exterior")
        {
            costoEnvio += 25000;
        }

        // ---- Salidas ----
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
}