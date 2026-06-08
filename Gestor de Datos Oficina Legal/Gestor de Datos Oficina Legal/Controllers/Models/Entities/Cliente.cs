namespace Gestor_de_Datos_Oficina_Legal.Controllers.Models.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string NumeroTelefonico { get; set; }
        public string CorreoElectronico { get; set; }
        public string Direccion { get; set; }
        public string TipoCliente { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Estado { get; set; }

    }
}

