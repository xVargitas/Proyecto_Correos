using Proyecto_Correos.Modelo;

public class Ruta
{
    public int Zona { get; set; }
    public double Distancia { get; set; }
    public string Origen { get; set; }
    public string Destino { get; set; }
    public List<Paquete> ppAlmacenados { get; set; }

    public Ruta()
    {
        ppAlmacenados = new List<Paquete>();
    }
}
