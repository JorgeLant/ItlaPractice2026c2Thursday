using Microsoft.EntityFrameworkCore;
using Gestor_de_Datos_Oficina_Legal.Models.Entities;

namespace Gestor_de_Datos_Oficina_Legal.Contexts
{
    public class ConexionDB:DbContext
    {
        public ConexionDB(DbContextOptions<ConexionDB> options): base(options) 
        {
            //
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Abogado> Abogados { get; set; }
        public DbSet<Caso> Casos { get; set; }
        public DbSet<Audiencia> Audiencias { get; set; }
    }
}
