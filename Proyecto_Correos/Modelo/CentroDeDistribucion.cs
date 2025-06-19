using System;

namespace Proyecto_Correos.Modelo
{
    public class CentroDistribucion
    {
        public string IdCentroDist { get; private set; }
        public string Estado { get; set; }
        public string Zona { get; set; }
        public string DescripUbicacion { get; set; }
        public int Capacidad { get; set; }

        
        public List<Paquete> paqAlmacenados;
        public List<Entrega> entregas;

        // Constructor
        public CentroDistribucion(string idCentroDist, string estado, string zona, string descripcion, int capacidad)
        {
            IdCentroDist = idCentroDist;
            Estado = estado;
            Zona = zona;
            DescripUbicacion = descripcion;
            Capacidad = capacidad;
            paqAlmacenados = new List<Paquete>();
            entregas = new List<Entrega>();
        }

        // Métodos
        public void RegistrarEntrega()
        {
            Console.WriteLine("");
        }
        public Entrega ConsultarEntrega()
        {
            Console.WriteLine("");
            return null;
        }
        public void CancelarEntrega()
        {
            Console.WriteLine("");
        }
        public void EliminarPaquete()
        {
            Console.WriteLine("");
        }

        public bool VerificarYAgregarPaquete(Paquete paquete)
        {
            if (paquete == null) return false;
            if (paquete.NumPaquete <= 0 || paquete.Peso <= 0 || paquete.Largo <= 0 || paquete.Ancho <= 0)
                return false;
            if (string.IsNullOrWhiteSpace(paquete.Estado) || string.IsNullOrWhiteSpace(paquete.Descripcion))
                return false;
            if (paqAlmacenados.Count >= Capacidad) return false;

            paqAlmacenados.Add(paquete);
            return true;
        }

        public List<Paquete> ObtenerTodosLosPaquetes()
        {
            return new List<Paquete>(paqAlmacenados); // Copia segura
        }

        public void MostrarInfo()//Propuesta de menu de confirmacion de entrega
        {
            Console.WriteLine($"Centro: {IdCentroDist} | Estado: {Estado} | Zona: {Zona}");
            Console.WriteLine($"Ubicación: {DescripUbicacion} | Capacidad: {Capacidad} | Paquetes actuales: {paqAlmacenados.Count}");
        }
    }
}
