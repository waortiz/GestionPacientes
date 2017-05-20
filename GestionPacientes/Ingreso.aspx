<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ingreso.aspx.cs" Inherits="FNSP.Web.GestionDieta.Ingreso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="Content/assets/demo.css" />
    <link rel="stylesheet" href="Content/assets/form-login.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <header>
        <h1>Gestión de Pacientes</h1>
    </header>
    <ul>
        <li></li>
    </ul>
    <div class="main-content">
        <form id="frmIngreso" runat="server" defaultfocus="txtUsuario" defaultbutton="btnIngresar" class="form-login">

            <div class="form-log-in-with-email">

                <div class="form-white-background">

                    <div class="form-title-row">
                        <h1>Iniciar Sesión</h1>
                    </div>
                    <div class="form-row">
                        <asp:Label ID="lblMensaje" runat="server" />
                    </div>
                    <div class="form-row">
                        <asp:ValidationSummary ID="vsUsuario" runat="server" ValidationGroup="ValidacionDatos" />
                    </div>
                    <div class="form-row">
                        <label>
                            <span>Usuario</span>
                            <asp:TextBox ID="txtUsuario" runat="server" />
                        </label>
                        <asp:RequiredFieldValidator ID="rfvUsuario" runat="server"
                            ControlToValidate="txtUsuario"
                            ErrorMessage="Por favor ingrese el nombre de usuario."
                            ToolTip="Por favor ingrese el nombre de usuario"
                            Text="*"
                            ValidationGroup="ValidacionDatos" />
                    </div>

                    <div class="form-row">
                        <label>
                            <span>Clave</span>
                            <asp:TextBox ID="txtClave" runat="server" TextMode="Password" />
                        </label>
                        <asp:RequiredFieldValidator ID="rfvClave" runat="server" ControlToValidate="txtClave"
                            ValidationGroup="ValidacionDatos"
                            ErrorMessage="Debe ingresar la clave."
                            Text="*" ToolTip="Por favor ingrese la clave."></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-row">
                        <asp:Button ID="btnIngresar" CssClass="form-log-in-with-email-button" Text="Ingresar" runat="server"
                            OnClick="btnIngresar_Click"
                            ValidationGroup="ValidacionDatos" />
                    </div>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
