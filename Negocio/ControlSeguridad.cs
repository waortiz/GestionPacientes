using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;

namespace Negocio
{
    public class ControlSeguridad
    {
        public Usuario ConsultarUsuario(string nombreUsuario)
        {
            AccesoDatosSeguridad accesoDatosSeguridad = new AccesoDatosSeguridad();
            return accesoDatosSeguridad.ConsultarUsuario(nombreUsuario);
        }

        public bool VerificarUsuario(Usuario usuario, string clave)
        {
            return (usuario != null && usuario.Clave == clave);
        }
    }
}
