namespace Domain.Entities;

public class Cliente
{
    public string Ruc { get; set; } = default!;
    public string RazonSocial { get; set; } = default!;
    public long TelefonoContacto { get; set; }
    public string CorreoContacto { get; set; } = default!;
    public string Direccion { get; set; } = default!;
}