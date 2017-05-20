using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace AccesoDatos
{
    public class AccesoDatosPaciente
    {
        public void IngresarPaciente(Paciente paciente)
        {
            PacientesContext contexto = new PacientesContext();
            Paciente pacienteActual = contexto.Pacientes.FirstOrDefault(p => p.NumeroDocumento.Equals(paciente.NumeroDocumento) && p.IdTipoDocumento == paciente.TipoDocumento.IdTipoDocumento);
            Sexo sexo = contexto.Sexos.FirstOrDefault(s => s.IdSexo == paciente.Sexo.IdSexo);
            paciente.Sexo = sexo;
            if (pacienteActual == null)
            {
                TipoDocumento tipoDocumento = contexto.TiposDocumento.FirstOrDefault(t => t.IdTipoDocumento == paciente.TipoDocumento.IdTipoDocumento);
                paciente.TipoDocumento = tipoDocumento;
                contexto.Pacientes.Add(paciente);
            }
            else
            {
                pacienteActual.Nombres = paciente.Nombres;
                pacienteActual.Apellidos = paciente.Apellidos;
                pacienteActual.FechaNacimiento = paciente.FechaNacimiento;
                pacienteActual.Sexo = sexo;
                pacienteActual.Direccion = paciente.Direccion;
                pacienteActual.CorreoElectronico = paciente.CorreoElectronico;
                pacienteActual.EsCotizante = paciente.EsCotizante;
                pacienteActual.Observaciones = paciente.Observaciones;
            }
            contexto.SaveChanges();
        }

        public void EliminarPaciente(string documento, short idTipoDocumento)
        {
            PacientesContext contexto = new PacientesContext();
            Paciente paciente = contexto.Pacientes.
                FirstOrDefault(p => p.NumeroDocumento.Equals(documento) &&
                    p.IdTipoDocumento == idTipoDocumento);

            if (paciente != null)
            {
                contexto.Pacientes.Remove(paciente);
                contexto.SaveChanges();
            }

        }

        public BindingList<Paciente> ConsultarPacientes(string documento, string nombres, string apellidos)
        {
            PacientesContext contexto = new PacientesContext();
            BindingList<Paciente> pacientes = new BindingList<Paciente>(contexto.Pacientes.Where(p => (documento == null || p.NumeroDocumento == documento)
            || (nombres == null || p.Nombres.ToLower().Contains(nombres.ToLower()))
            || (apellidos == null || p.Apellidos.ToLower().Contains(apellidos.ToLower()))).ToList());

            return pacientes;

        }

        public void EliminarPaciente(long idPaciente)
        {
            PacientesContext contexto = new PacientesContext();
            Paciente paciente = contexto.Pacientes.
                FirstOrDefault(p => p.IdPaciente == idPaciente);

            if (paciente != null)
            {
                contexto.Pacientes.Remove(paciente);
                contexto.SaveChanges();
            }

        }


        public Paciente ObtenerPaciente(long idPaciente)
        {
            PacientesContext contexto = new PacientesContext();
            Paciente paciente = contexto.Pacientes.
                FirstOrDefault(p => p.IdPaciente == idPaciente);

            return paciente;

        }
    }
}
