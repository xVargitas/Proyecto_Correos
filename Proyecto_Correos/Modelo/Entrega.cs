using System;

namespace Proyecto_Correos.Modelo
{
    public class Entrega
    {
        public string IdEntrega { get; set; }
        public string Destino { get; set; }
        public string Estado { get; set; } // En Camino, Entregado, Cancelado
        public List<Paquete> Paquetes { get; set; }

        public Entrega(string idEntrega, string destino)
        {
            IdEntrega = idEntrega;
            Destino = destino;
            Estado = "Pendiente";
            Paquetes = new List<Paquete>();
        }

        public void AgregarPaquete(Paquete p)
        {
            Paquetes.Add(p);
        }

        public void MostrarDetalle()
        {
            Console.WriteLine($"Entrega: {IdEntrega} | Estado: {Estado} | Destino: {Destino} | Paquetes: {Paquetes.Count}");
        }
    }
}