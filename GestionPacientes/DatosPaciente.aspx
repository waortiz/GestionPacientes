<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DatosPaciente.aspx.cs" Inherits="GestionPacientes.DatosPaciente" %>

<%@ Register Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function ValidarFechaNacimiento(fuente, argumentos) {
            var fechas = argumentos.Value.split("-");
            var fecha = new Date(fechas[0],
                parseInt(fechas[1], 10) - 1,
                fechas[2]);
            if (fecha > new Date()) {
                argumentos.IsValid = false;
            }
            else {
                argumentos.IsValid = true;
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <ContentTemplate>
            <div class="form-content">
                <div class="form-row">
                    <asp:ValidationSummary ID="vsPaciente" runat="server" />
                </div>
                <div class="form-row">
                    <asp:Label runat="server" ID="lblResultado" ForeColor="Blue" Font-Bold="true"></asp:Label>
                </div>
                <div class="form-title-row">
                    <h1>DATOS GENERALES</h1>
                </div>
                <div class="form-row">
                    <div class="divTableCell">
                        <span>Nombres</span>
                    </div>
                    <div class="divTableCell">
                        <asp:TextBox ID="txtNombres" runat="server" MaxLength="100" />
                        <asp:RequiredFieldValidator ID="rfvNombres"
                            ControlToValidate="txtNombres"
                            runat="server"
                            Text="*"
                            ForeColor="Red"
                            ErrorMessage="Por favor ingrese el nombre del paciente" />
                    </div>
                    <div class="divTableCell">
                        <span>Apellidos</span>
                    </div>
                    <div class="divTableCell">
                        <asp:TextBox ID="txtApellidos" runat="server" MaxLength="100" />
                    </div>
                </div>
                <div class="form-row">
                    <div class="divTableCell">
                        <span>Tipo de Documento</span>
                    </div>
                    <div class="divTableCell">
                        <asp:DropDownList ID="ddlTiposDocumento" runat="server" />
                    </div>
                    <div class="divTableCell">
                        <span>Documento</span>
                    </div>
                    <div class="divTableCell">
                        <asp:TextBox ID="txtDocumento" runat="server" MaxLength="20" TextMode="Number" />
                    </div>
                </div>
                <div class="form-row">
                    <div class="divTableCell">
                        <span>Fecha de Nacimiento</span>
                    </div>
                    <div class="divTableCell">
                        <asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="Date" MaxLength="10" />
                        <asp:CustomValidator ID="cvFechaNacimiento"
                            runat="server"
                            ClientValidationFunction="ValidarFechaNacimiento"
                            ControlToValidate="txtFechaNacimiento"
                            ToolTip="La fecha de nacimiento no debe ser mayor a 
                             la fecha del sistema."
                            Text="*"
                            ErrorMessage="La fecha de nacimiento no debe 
                             ser mayor a la fecha del sistema." />
                    </div>
                    <div class="divTableCell">
                        <span>Dirección</span>
                    </div>
                    <div class="divTableCell">
                        <asp:TextBox ID="txtDireccion" runat="server" MaxLength="20" />
                    </div>
                </div>
                <div class="form-row">
                    <div class="divTableCell">
                        <span>Sexo</span>
                    </div>
                    <div class="divTableCell">
                        <asp:DropDownList ID="ddlSexos" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="divTableCell">
                        <span>Cotizante</span>
                    </div>
                    <div class="divTableCell">
                        <asp:CheckBox ID="chkCotizante" runat="server" />
                    </div>
                </div>
                <div class="form-row">
                    <div class="divTableCell">
                        <span>Correo electrónico</span>
                    </div>
                    <div class="divTableCell">
                        <asp:TextBox ID="txtCorreoElectronico" runat="server" />
                    </div>
                    <div class="divTableCell">
                        <span>Observaciones</span>
                    </div>
                    <div class="divTableCell">
                        <asp:TextBox ID="txtObservaciones" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="divTableCell"></div>
                    <div class="divTableCell"></div>
                    <div class="divTableCell"></div>
                    <div class="divTableCell">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="form-basic-button" />
                    </div>
                </div>
            </div>
        </ContentTemplate>

    </asp:UpdatePanel>
</asp:Content>
