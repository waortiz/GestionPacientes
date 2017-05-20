using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class PacientesContext : DbContext
    {
        public PacientesContext()
            : base("name=PacientesConnection") 
        {
            Database.SetInitializer(new PacientesInitializer());
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Sexo> Sexos { get; set; }
        public DbSet<TipoDocumento> TiposDocumento { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
