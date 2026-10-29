using System;
using ec.edu.monster.modelo;
using CLICON_CONUNI_SOAPDOTNET_GR06.ServiceReference1;

namespace ec.edu.monster.vista
{
    internal class Program
    {
        private const string ValidUsername = "MONSTER";
        private const string ValidPassword = "MONSTER69";

        private static void Main(string[] args)
        {
            Console.WriteLine("Conversor de unidades - SOAP");
            Console.WriteLine();

            // Login
            if (!Login())
            {
                Console.WriteLine("Presione cualquier tecla para salir...");
                Console.ReadKey();
                return;
            }

            // Conversion loop
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("=== CONVERSOR DE UNIDADES ===");
                var category = PromptOption("Categoria", UnitCatalog.Categories);
                var fromUnit = PromptOption("Unidad origen", UnitCatalog.GetUnits(category));
                var toUnit = PromptOption("Unidad destino", UnitCatalog.GetUnits(category));
                var value = PromptDouble("Valor");

                using (var client = new Service1Client())
                {
                    var result = client.Convert(category, fromUnit, toUnit, value);
                    Console.WriteLine();
                    Console.WriteLine("Resultado: {0} {1}", result, toUnit);
                }

                Console.Write("\n¿Desea realizar otra conversion? (s/n): ");
                var continuar = Console.ReadLine()?.ToLower();
                if (continuar != "s")
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }

        private static bool Login()
        {
            int intentos = 0;
            const int maxIntentos = 3;

            while (intentos < maxIntentos)
            {
                Console.WriteLine("=== INICIAR SESION ===");
                var username = PromptString("Usuario");
                var password = PromptPassword("Contraseña");

                if (username == ValidUsername && password == ValidPassword)
                {
                    Console.WriteLine("\n✓ Bienvenido, {0}!", username);
                    return true;
                }

                intentos++;
                Console.WriteLine("\n✗ Error de credenciales. Intente de nuevo. ({0}/{1})\n", intentos, maxIntentos);
            }

            Console.WriteLine("✗ Ha excedido el número máximo de intentos.");
            return false;
        }

        private static string PromptString(string label)
        {
            while (true)
            {
                Console.Write(label + ": ");
                var input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }

                Console.WriteLine("El campo no puede estar vacío. Intente de nuevo.\n");
            }
        }

        private static string PromptPassword(string label)
        {
            Console.Write(label + ": ");
            var password = string.Empty;
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
        }

        private static string PromptOption(string label, string[] options)
        {
            while (true)
            {
                Console.WriteLine(label + ":");
                for (var i = 0; i < options.Length; i++)
                {
                    Console.WriteLine("  {0}. {1}", i + 1, options[i]);
                }

                Console.Write("Seleccione una opcion: ");
                var input = Console.ReadLine();

                if (int.TryParse(input, out var index) && index >= 1 && index <= options.Length)
                {
                    Console.WriteLine();
                    return options[index - 1];
                }

                Console.WriteLine("Opcion invalida. Intente de nuevo.\n");
            }
        }

        private static double PromptDouble(string label)
        {
            while (true)
            {
                Console.Write(label + ": ");
                var input = Console.ReadLine();

                if (double.TryParse(input, out var value))
                {
                    return value;
                }

                Console.WriteLine("Valor invalido. Intente de nuevo.\n");
            }
        }
    }
}
