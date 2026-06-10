namespace Gestor_de_Datos_Oficina_Legal.Models.DTOs
{
    public class CasoDTO
    {
        public int Id { get; set; }
        public string NumeroExpediente { get; set; }
        public int ClienteAsociado { get; set; }
        public int AbogadoAsociado { get; set; }
        public string Titulo { get; set; }
        public string TipoCaso { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaApertura { get; set; }
        public string Estado { get; set; }
        public string Tribunal { get; set; }
        public string ParteContraria { get; set; }
    }
}
