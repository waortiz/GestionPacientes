using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FNSP.Web.GestionDieta
{
    public partial class Ingreso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            ControlSeguridad control = new ControlSeguridad();
            Usuario usuario = control.ConsultarUsuario(txtUsuario.Text);
            if (usuario != null)
            {
                if (control.VerificarUsuario(usuario, txtClave.Text))
                {
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                        txtUsuario.Text, DateTime.Now,
                        DateTime.Now.AddMinutes(30), true,
                        string.Empty,
                        FormsAuthentication.FormsCookiePath);
                    string hashCookies = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                        hashCookies);
                    if (ticket.IsPersistent)
                    {
                        cookie.Expires = ticket.Expiration;
                    }
                    Response.Cookies.Add(cookie);
                    Response.Redirect("Default.aspx", true);
                }
                else
                {
                    lblMensaje.Text = "Clave incorrecta";
                }
            }
            else
            {
                lblMensaje.Text = "Usuario incorrecto";
            }
        }
    }
}