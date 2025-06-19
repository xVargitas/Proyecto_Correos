using Proyecto_Correos.Modelo;
using System;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            CentroDistribucion centro = new CentroDistribucion(
                "CD-001",
                "Activo",
                "Zona Norte",
                "Almacén Principal",
                10
            );

            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=== MENÚ CENTRO DE DISTRIBUCIÓN ===");
                Console.WriteLine("1. Registrar Entrega");
                Console.WriteLine("2. Consultar Entrega");
                Console.WriteLine("3. Cancelar Entrega");
                Console.WriteLine("4. Eliminar Paquete");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                    Console.ReadKey();
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("\n[REGISTRAR ENTREGA]");
                        centro.RegistrarEntrega();
                        break;

                    case 2:
                        Console.WriteLine("\n[CONSULTAR ENTREGA]");
                        Entrega entrega = centro.ConsultarEntrega();
                        if (entrega != null)
                            Console.WriteLine("Entrega consultada correctamente.");
                        else
                            Console.WriteLine("No hay entrega registrada.");
                        break;

                    case 3:
                        Console.WriteLine("\n[CANCELAR ENTREGA]");
                        centro.CancelarEntrega();
                        Console.WriteLine("Entrega cancelada.");
                        break;

                    case 4:
                        Console.WriteLine("\n[ELIMINAR PAQUETE]");
                        centro.EliminarPaquete();
                        Console.WriteLine("Paquete eliminado.");
                        break;

                    case 5:
                        Console.WriteLine("\nSaliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();

            } while (opcion != 5);
        }
    }
}
