namespace servicio_empresa_abc.Entities;

public class Cliente
{
    public int Id { get; set; }
    public string nombre { get; set; } = default!;
    public string apellido { get; set; } = default!;

    public string numCedula { get; set; } = default!;

    
    public string tipoCanal { get; set; } = default!;

}