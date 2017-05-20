using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace AccesoDatos
{
    public class AccesoDatosMaestro
    {
        public BindingList<TipoDocumento> ObtenerTiposDocumento()
        {
            PacientesContext contexto = new PacientesContext();
            BindingList<TipoDocumento> tiposDocumento = new BindingList<TipoDocumento>(contexto.TiposDocumento.OrderBy(t=>t.Nombre).ToList());

            return tiposDocumento;
        }

        public BindingList<Sexo> ObtenerTiposSexo()
        {
            PacientesContext contexto = new PacientesContext();
            BindingList<Sexo> tiposSexo = new BindingList<Sexo>(contexto.Sexos.OrderBy(t => t.Nombre).ToList());
            
            return tiposSexo;
        }
    }
}
