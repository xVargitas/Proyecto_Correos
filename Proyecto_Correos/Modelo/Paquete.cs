using System;

namespace Proyecto_Correos.Modelo
{
    public class Paquete
    {
        public int NumPaquete { get; set; }
        public double Peso { get; set; }
        public int Largo { get; set; }
        public int Ancho { get; set; }
        public string Estado { get; set; }
        public bool Prioridad { get; set; }
        public string Descripcion { get; set; }
    }
}
