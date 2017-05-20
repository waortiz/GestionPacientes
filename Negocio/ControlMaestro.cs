using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using AccesoDatos;

namespace Negocio
{
    public class ControlMaestro
    {
        public BindingList<TipoDocumento> ObtenerTiposDocumento()
        {
            AccesoDatosMaestro accesoDatosMaestro = new AccesoDatosMaestro();
            return accesoDatosMaestro.ObtenerTiposDocumento();
        }

        public BindingList<Sexo> ObtenerTiposSexo()
        {
            AccesoDatosMaestro accesoDatosMaestro = new AccesoDatosMaestro();
            return accesoDatosMaestro.ObtenerTiposSexo();
        }
    }
}
