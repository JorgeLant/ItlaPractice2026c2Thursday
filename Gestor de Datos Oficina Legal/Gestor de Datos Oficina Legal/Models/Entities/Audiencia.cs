namespace Gestor_de_Datos_Oficina_Legal.Models.Entities
{
    public class Audiencia
    {
        public int Id { get; set; }
        public int CasoAsociado { get; set; }
        public DateTime Fecha { get; set; }
        public TimeOnly Hora { get; set; }
        public string Tribunal { get; set; }
        public string Estado { get; set; }
    }
}
