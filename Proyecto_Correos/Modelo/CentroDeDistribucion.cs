using System;
using System.Collections.Generic;

namespace Proyecto_Correos.Modelo
{
    public class CentroDistribucion
    {
        // Propiedades
        public string IdCentroDist { get; private set; }
        public string Estado { get; set; }
        public string Zona { get; set; }
        public string DescripUbicacion { get; set; }
        public int Capacidad { get; set; }

        // Relaciones
        private List<Paquete> paqAlmacenados;
        private List<Entrega> entregas;


        // Constructor
        public CentroDistribucion(string id, string estado, string zona, string descripcion, int capacidad)
        {
            IdCentroDist = id;
            Estado = estado;
            Zona = zona;
            DescripUbicacion = descripcion;
            Capacidad = capacidad;
            paqAlmacenados = new List<Paquete>();
            entregas = new List<Entrega>();
        }

        // Mostrar información general
        public void MostrarInformacion()
        {
            Console.WriteLine($"Centro de Distribución: {IdCentroDist} | Estado: {Estado} | Zona: {Zona}");
            Console.WriteLine($"Ubicación: {DescripUbicacion} | Capacidad: {Capacidad} paquetes");
            Console.WriteLine($"Paquetes almacenados: {paqAlmacenados.Count} | Entregas registradas: {entregas.Count}");
        }

        // Agregar paquete con validaciones detalladas
        public bool VerificarYAgregarPaquete(Paquete paquete)
        {
            if (paquete == null) return false;
            if (paqAlmacenados.Count >= Capacidad) return false;

            if (paquete.NumPaquete <= 0) return false;
            if (paquete.Peso <= 0) return false;
            if (paquete.Largo <= 0) return false;
            if (paquete.Ancho <= 0) return false;

            if (paquete.Estado == null || paquete.Estado == "" || paquete.Estado.Trim() == "") return false;
            if (paquete.Descripcion == null || paquete.Descripcion == "" || paquete.Descripcion.Trim() == "") return false;

            paqAlmacenados.Add(paquete);
            return true;
        }

        // Eliminar paquete por número
        public bool EliminarPaquetePorNumero(int numPaquete)
        {
            for (int i = 0; i < paqAlmacenados.Count; i++)
            {
                if (paqAlmacenados[i].NumPaquete == numPaquete)
                {
                    paqAlmacenados.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        // Registrar una nueva entrega
        public void RegistrarEntrega(Entrega entrega)
        {
            if (entrega != null)
            {
                entregas.Add(entrega);
                Console.WriteLine("Entrega registrada correctamente.");
            }
            else
            {
                Console.WriteLine("Error: entrega nula.");
            }
        }

        // Consultar entrega por ID
        public Entrega ConsultarEntrega(string idEntrega)
        {
            foreach (var entrega in entregas)
            {
                if (entrega.IdEntrega == idEntrega)
                    return entrega;
            }
            Console.WriteLine("Entrega no encontrada.");
            return null;
        }

        // Cancelar entrega por ID
        public bool CancelarEntrega(string idEntrega)
        {
            foreach (var entrega in entregas)
            {
                if (entrega.IdEntrega == idEntrega)
                {
                    entrega.Estado = "Cancelada";
                    Console.WriteLine("Entrega cancelada exitosamente.");
                    return true;
                }
            }
            Console.WriteLine("No se encontró la entrega.");
            return false;
        }

        // Obtener lista de paquetes
        public List<Paquete> ObtenerPaquetes()
        {
            return new List<Paquete>(paqAlmacenados);
        }

        // Obtener lista de entregas
        public List<Entrega> ObtenerEntregas()
        {
            return new List<Entrega>(entregas);
        }
    }
}
