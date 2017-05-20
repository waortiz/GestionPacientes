using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ControlPaciente
    {
        public void IngresarPaciente(Paciente paciente)
        {
            AccesoDatosPaciente accesoDatosPaciente = new AccesoDatosPaciente();
            accesoDatosPaciente.IngresarPaciente(paciente);
        }

        public void EliminarPaciente(string documento, short idTipoDocumento)
        {
            AccesoDatosPaciente accesoDatosPaciente = new AccesoDatosPaciente();
            accesoDatosPaciente.EliminarPaciente(documento, idTipoDocumento);
        }

        public void EliminarPaciente(long idPaciente)
        {
            AccesoDatosPaciente accesoDatosPaciente = new AccesoDatosPaciente();
            accesoDatosPaciente.EliminarPaciente(idPaciente);
        }

        public Paciente ObtenerPaciente(long idPaciente)
        {
            AccesoDatosPaciente accesoDatosPaciente = new AccesoDatosPaciente();
            return accesoDatosPaciente.ObtenerPaciente(idPaciente);
        }

        public BindingList<Paciente> ConsultarPacientes(string documento, string nombres, string apellidos)
        {
            AccesoDatosPaciente accesoDatosPaciente = new AccesoDatosPaciente();
            return accesoDatosPaciente.ConsultarPacientes(documento, nombres, apellidos);
        }

    }
}
