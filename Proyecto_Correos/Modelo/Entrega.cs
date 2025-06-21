using Proyecto_Correos.Modelo;

public class Entrega
{
    public string IdEntrega { get; set; }
    public string Estado { get; set; }
    public List<Ruta> RutasEntrega { get; set; }

    public Entrega(string id)
    {
        IdEntrega = id;
        Estado = "Pendiente";
        RutasEntrega = new List<Ruta>();
    }
}
