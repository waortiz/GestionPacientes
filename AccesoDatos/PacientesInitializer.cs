using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class PacientesInitializer : DropCreateDatabaseIfModelChanges<PacientesContext>
    {
        protected override void Seed(PacientesContext context)
        {
            context.Usuarios.Add(new Usuario() { Nombre = "william", Clave = "123" });

            context.Sexos.Add(new Sexo() { IdSexo = 1, Nombre = "Femenino" });
            context.Sexos.Add(new Sexo() { IdSexo = 2, Nombre = "Masculino" });

            context.TiposDocumento.Add(new TipoDocumento() { Nombre = "Cédula de Ciudadanía", IdTipoDocumento = 1});
            context.TiposDocumento.Add(new TipoDocumento() { Nombre = "Cédula de Extranjería", IdTipoDocumento = 2 });
            context.TiposDocumento.Add(new TipoDocumento() { Nombre = "Tarjeta de Identidad", IdTipoDocumento = 3 });

            base.Seed(context);
        }
    }
}
