namespace Gestor_de_Datos_Oficina_Legal.Controllers.Models.Entities
{
    public class Abogado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Exequatur { get; set; }
        public string NumeroTelefonico { get; set; }
        public string CorreoEletronico { get; set; }
        public string Direccion { get; set; }
        public string Especialidad { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Estado { get; set; }
    }
}
