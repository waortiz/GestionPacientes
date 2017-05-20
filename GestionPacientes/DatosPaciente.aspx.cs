using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionPacientes
{
    public partial class DatosPaciente : System.Web.UI.Page
    {
        private long? IdPaciente
        {
            get
            {
                if (this.ViewState["IdPaciente"] == null)
                {
                    return null;
                }
                else
                {
                    return (long)this.ViewState["IdPaciente"];
                }
            }
            set
            {
                this.ViewState["IdPaciente"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.IsPostBack)
            {
                this.CargarListas();
                if (this.Session["IdPaciente"] != null)
                {
                    this.CargarDatosPaciente((long)this.Session["IdPaciente"]);
                    this.IdPaciente = (long)this.Session["IdPaciente"];
                    this.Session["IdPaciente"] = null;
                }
            }
        }

        private void CargarListas()
        {
            ControlMaestro control = new ControlMaestro();
            BindingList<TipoDocumento> tiposDocumento = control.ObtenerTiposDocumento();
            this.ddlTiposDocumento.DataTextField = "Nombre";
            this.ddlTiposDocumento.DataValueField = "IdTipoDocumento";
            this.ddlTiposDocumento.DataSource = tiposDocumento;
            this.ddlTiposDocumento.DataBind();

            BindingList<Sexo> sexos = control.ObtenerTiposSexo();
            this.ddlSexos.DataTextField = "Nombre";
            this.ddlSexos.DataValueField = "IdSexo";
            this.ddlSexos.DataSource = sexos;
            this.ddlSexos.DataBind();
        }

        private void CargarDatosPaciente(long idPaciente)
        {
            ControlPaciente control = new ControlPaciente();
            Paciente paciente = control.ObtenerPaciente(idPaciente);
            txtDocumento.Text = paciente.NumeroDocumento;
            txtApellidos.Text = paciente.Apellidos;
            txtNombres.Text = paciente.Nombres;
            txtDireccion.Text = paciente.Direccion;
            txtCorreoElectronico.Text = paciente.CorreoElectronico;
            txtObservaciones.Text = paciente.Observaciones;
            txtFechaNacimiento.Text = paciente.FechaNacimiento.ToString("yyyy-MM-dd");
            chkCotizante.Checked = paciente.EsCotizante;
            ddlTiposDocumento.SelectedValue = paciente.TipoDocumento.IdTipoDocumento.ToString();
            ddlSexos.SelectedValue = paciente.Sexo.IdSexo.ToString();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Paciente paciente = new Paciente();

                paciente.Nombres = this.txtNombres.Text;
                paciente.Apellidos = this.txtApellidos.Text;
                paciente.FechaNacimiento =
                    DateTime.ParseExact(
                    this.txtFechaNacimiento.Text, "yyyy-MM-dd",
                    CultureInfo.CurrentCulture);
                paciente.NumeroDocumento = this.txtDocumento.Text;
                paciente.TipoDocumento = new TipoDocumento()
                {
                    IdTipoDocumento = short.Parse(
                    this.ddlTiposDocumento.SelectedValue)
                };
                paciente.Sexo = new Sexo()
                {
                    IdSexo = short.Parse(
                    this.ddlSexos.SelectedValue)
                };
                paciente.Direccion = this.txtDireccion.Text;
                paciente.CorreoElectronico = this.txtCorreoElectronico.Text;
                paciente.Observaciones = this.txtObservaciones.Text;
                paciente.EsCotizante = this.chkCotizante.Checked;
                ControlPaciente control = new ControlPaciente();
                if (this.IdPaciente != null)
                {
                    paciente.IdPaciente = this.IdPaciente.Value;
                }
                control.IngresarPaciente(paciente);
                this.lblResultado.Text = "Los datos del paciente se almacenaron correctamente";
            }
            catch(Exception exc)
            {
                this.lblResultado.Text = "Error al ingresar el paciente: " + exc.Message;
            }
        }

        protected void btnListadoPacientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoPacientes.aspx");
        }

        protected void btnEliminarPaciente_Click(object sender, EventArgs e)
        {
            try
            {
                ControlPaciente control = new ControlPaciente();
                string documento =this.txtDocumento.Text;
                short tipoDocumentoId = short.Parse(
                    this.ddlTiposDocumento.SelectedValue);
                control.EliminarPaciente(documento, tipoDocumentoId);
                this.lblResultado.Text = "El paciente se ha eliminado exitosamente";
            }
            catch (Exception exc)
            {
                this.lblResultado.Text = "Error al eliminar el paciente: " + exc.Message;
            }
        }
    }
}