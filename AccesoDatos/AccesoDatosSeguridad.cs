using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace AccesoDatos
{
    public class AccesoDatosSeguridad
    {
        public Usuario ConsultarUsuario(string nombreUsuario)
        {
            PacientesContext contexto = new PacientesContext();
            Usuario usuario = contexto.Usuarios.FirstOrDefault(u => u.Nombre.ToLower().Equals(nombreUsuario.ToLower()));

            return usuario;
        }
    }
}
