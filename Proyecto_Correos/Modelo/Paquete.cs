using System;

namespace Proyecto_Correos.Modelo
{
    public class Paquete
    {
        public int NumPaquete { get; set; }
        public double Peso { get; set; }
        public double Largo { get; set; }
        public double Ancho { get; set; }
        public string Estado { get; set; }
        public bool Prioridad { get; set; }
        public string Descripcion { get; set; }

        public Paquete(int num, double peso, double largo, double ancho, string estado, bool prioridad, string descripcion)
        {
            NumPaquete = num;
            Peso = peso;
            Largo = largo;
            Ancho = ancho;
            Estado = estado;
            Prioridad = prioridad;
            Descripcion = descripcion;
        }

        public void MostrarDatos()
        {
            Console.WriteLine($"Paquete #{NumPaquete} | {Descripcion}");
            Console.WriteLine($"Peso: {Peso}kg | Dimensiones: {Largo}x{Ancho} | Prioridad: {Prioridad}");
            Console.WriteLine($"Estado actual: {Estado}");
        }
    }
}
