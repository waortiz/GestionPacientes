using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.ComponentModel;
using Entidades;
using System.IO;
using System.Drawing;
using System.Net;

namespace GestionPacientes
{
    public partial class ListadoPacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Consultar();
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            this.Consultar();
        }

        protected void gvPacientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Detalle")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label lblIdPaciente = (Label)row.FindControl("lblIdPaciente");
                this.Session["IdPaciente"] = long.Parse(lblIdPaciente.Text);
                Response.Redirect("DatosPaciente.aspx", true);
            }
            if (e.CommandName == "EliminarPaciente")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label lblIdPaciente = (Label)row.FindControl("lblIdPaciente");
                long idPaciente = long.Parse(lblIdPaciente.Text.ToString());
                lblMensajes.Text = "Paciente eliminado exitosamente";
                ControlPaciente control = new ControlPaciente();
                control.EliminarPaciente(idPaciente);
                this.Consultar();
            }
        }

        protected void gvPacientes_SelectedIndexChanging(object source, GridViewPageEventArgs e)
        {
            this.gvPacientes.PageIndex = e.NewPageIndex;
            this.gvPacientes.DataSource = this.Session["ListadoPacientes"];
            this.gvPacientes.DataBind();
        }

        private void Consultar()
        {
            string documento = null;
            string nombres = null;
            string apellidos = null;
            if (!string.IsNullOrEmpty(txtNumeroDocumento.Text))
            {
                documento = txtNumeroDocumento.Text;
            }
            if (!string.IsNullOrEmpty(txtNombres.Text))
            {
                nombres = txtNombres.Text;
            }
            if (!string.IsNullOrEmpty(txtApellidos.Text))
            {
                apellidos = txtApellidos.Text;
            }

            ControlPaciente control = new ControlPaciente();
            BindingList<Paciente> pacientes = control.ConsultarPacientes(documento, nombres, apellidos);
            this.Session["ListadoPacientes"] = pacientes;

            this.gvPacientes.DataSource = pacientes;
            this.gvPacientes.DataBind();
            if(pacientes.Count > 0)
            {
                this.btnExportarExcel.Enabled = true;
            }
            else
            {
                this.btnExportarExcel.Enabled = false;
            }
        }

        protected void btnExportarExcel_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.ContentType = "application/excel";
            Response.AppendHeader("content-disposition", "attachment; filename=" + "ListadoPacientes" + string.Format("{0:yyyyMMddHmmss}", DateTime.Now) + ".xls;");

            const string head = "<html><head><meta http-equiv='Content-Type' content='Text/Html; charset=UTF-8'></head><body><table>" +
                                     "<tr><td colspan='5'><strong><center>PACIENTES</center></strong></td></tr>";
            const string footer = "</table></body></html>";

            string encabezado =  "<tr>" +
                   "<td><strong>Tipo de Documento</font></strong></td>" +
                   "<td><strong>Número de Documento</font></strong></td>" +
                   "<td><strong>Nombres</font></strong></td>" +
                   "<td><strong>Apellidos</font></strong></td>" +
                   "<td><strong>Fecha de Nacimiento</font></strong></td>" +
                    "</tr>";
            BindingList<Paciente> pacientes = this.Session["ListadoPacientes"] as BindingList<Paciente>;
            string detalle = string.Empty;
            foreach (Paciente paciente in pacientes)
            {
                detalle += "<tr><td><center>" + WebUtility.HtmlEncode(Convert.ToString(paciente.TipoDocumento.Nombre)) + "</center></dt>" +
                           "<td><center>" + WebUtility.HtmlEncode(paciente.NumeroDocumento) + "</center></td>" +
                           "<td><center>" + WebUtility.HtmlEncode(paciente.Nombres) + "</center></td>" +
                           "<td><center>" + WebUtility.HtmlEncode(paciente.Apellidos) + "</center></td>" +
                           "<td><center>" + WebUtility.HtmlEncode(paciente.FechaNacimiento.ToString("yyyy-MM-dd")) + "</center></td>" + 
                           "</tr>";
            }

            var contenido = encabezado + detalle;

            Response.Write(head + contenido + footer);
        }
    }
}