using Proyecto_Correos.Modelo;
using System;
using System.Collections.Generic;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            List<CentroDistribucion> centros = new List<CentroDistribucion>
            {
                new CentroDistribucion("A1", "Disponible", "1", "Cartago", 10),
                new CentroDistribucion("A2", "Disponible", "2", "Alajuela", 10),
                new CentroDistribucion("A3", "Disponible", "3", "Heredia", 10)
            };

            CentroDistribucion centroSeleccionado = null;

            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=== MENÚ PRINCIPAL ===");
                Console.WriteLine("1. Seleccionar centro de distribución");
                Console.WriteLine("2. Crear nuevo centro");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Ingrese un número válido.");
                    Console.ReadKey();
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("--- Centros Disponibles ---");
                        for (int i = 0; i < centros.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {centros[i].DescripUbicacion} (ID: {centros[i].IdCentroDist})");
                        }

                        Console.Write("Seleccione el número del centro: ");
                        if (int.TryParse(Console.ReadLine(), out int indice) &&
                            indice >= 1 && indice <= centros.Count)
                        {
                            centroSeleccionado = centros[indice - 1];
                            MenuCentroDistribucion(centroSeleccionado);
                        }
                        else
                        {
                            Console.WriteLine("Selección inválida.");
                            Console.ReadKey();
                        }
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("--- Crear nuevo centro ---");
                        Console.Write("ID: ");
                        string id = Console.ReadLine();
                        Console.Write("Estado: ");
                        string estado = Console.ReadLine();
                        Console.Write("Zona: ");
                        string zona = Console.ReadLine();
                        Console.Write("Descripción (Nombre del centro): ");
                        string descripcion = Console.ReadLine();
                        Console.Write("Capacidad: ");
                        int capacidad = int.TryParse(Console.ReadLine(), out int cap) ? cap : 10;

                        CentroDistribucion nuevoCentro = new CentroDistribucion(id, estado, zona, descripcion, capacidad);
                        centros.Add(nuevoCentro);
                        Console.WriteLine("Centro creado exitosamente.");
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        Console.ReadKey();
                        break;
                }

            } while (opcion != 3);
        }

        static void MenuCentroDistribucion(CentroDistribucion centro)
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine($"=== MENÚ CENTRO: {centro.DescripUbicacion} ===");
                Console.WriteLine("1. Registrar Entrega");
                Console.WriteLine("2. Consultar Entrega");
                Console.WriteLine("3. Cancelar Entrega");
                Console.WriteLine("4. Eliminar Paquete");
                Console.WriteLine("5. Ver Info del Centro");
                Console.WriteLine("6. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Ingrese un número válido.");
                    Console.ReadKey();
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        centro.RegistrarEntrega();
                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("Ingrese ID de entrega: ");
                        string idEntrega = Console.ReadLine();
                        var entrega = centro.ConsultarEntrega(idEntrega);
                        if (entrega != null)
                            Console.WriteLine("Entrega encontrada.");
                        else
                            Console.WriteLine("Entrega no encontrada.");
                        break;

                    case 3:
                        Console.Clear();
                        Console.Write("Ingrese ID de entrega a cancelar: ");
                        string idCancel = Console.ReadLine();
                        centro.CancelarEntrega(idCancel);
                        break;

                    case 4:
                        Console.Clear();
                        Console.Write("Ingrese número de paquete a eliminar: ");
                        if (int.TryParse(Console.ReadLine(), out int numPaquete))
                        {
                            bool eliminado = centro.EliminarPaquetePorNumero(numPaquete);
                            Console.WriteLine(eliminado ? "Paquete eliminado." : "No se encontró el paquete.");
                        }
                        else
                        {
                            Console.WriteLine("Número inválido.");
                        }
                        break;

                    case 5:
                        Console.Clear();
                        centro.MostrarInformacion();
                        break;

                    case 6:
                        Console.WriteLine("Volviendo al menú principal...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();

            } while (opcion != 6);
        }
    }
}
