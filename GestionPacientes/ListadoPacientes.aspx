<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoPacientes.aspx.cs" Inherits="GestionPacientes.ListadoPacientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-title-row">
        <h1>Pacientes</h1>
    </div>
    <div class="form-content">
        <div class="form-row">
            <asp:Label ID="lblMensajes" runat="server" Width="550" CssClass="Mensaje" />
        </div>
        <div class="form-row">
            <div class="divTableCellSearch">
                <span>Número de Documento</span>
            </div>
            <div class="divTableCellSearch">
                <asp:TextBox ID="txtNumeroDocumento" runat="server" Width="135px" TabIndex="1" MaxLength="20"></asp:TextBox>
            </div>
            <div class="divTableCellSearch">
                <span>Nombres</span>
            </div>
            <div class="divTableCellSearch">
                <asp:TextBox ID="txtNombres" runat="server" TabIndex="2" Width="135px" MaxLength="100"></asp:TextBox>
            </div>
            <div class="divTableCellSearch">
                <span>Apellidos</span>
            </div>
            <div class="divTableCellSearch">
                <asp:TextBox ID="txtApellidos" runat="server" TabIndex="4" Width="135px" MaxLength="100"></asp:TextBox>
            </div>
            <div class="divTableCellSearch">
                <asp:Button ID="btnConsultar" runat="server" OnClick="btnConsultar_Click" TabIndex="6"
                    Text="Consultar" CssClass="form-basic-button" />
            </div>
        </div>
        <br />
        <br />
        <div class="form-row">
            <asp:GridView ID="gvPacientes" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="gvPacientes_SelectedIndexChanging"
                AllowPaging="true" HorizontalAlign="Center" CssClass="Grid"
                OnRowCommand="gvPacientes_RowCommand">
                <HeaderStyle CssClass="EncabezadoGrid" HorizontalAlign="Center" VerticalAlign="Middle" />
                <RowStyle CssClass="FilaGrid" />
                <AlternatingRowStyle CssClass="FilaAlternaGrid" />
                <PagerStyle CssClass="rowPaginador" HorizontalAlign="Left" />
                <Columns>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                        <HeaderStyle Width="5%" />
                        <ItemTemplate>
                            <asp:LinkButton CommandName="Detalle" runat="server" ID="lnkVerDetalle">
                                <asp:Image ID="imgVerDetalle" runat="server" Width="16" Height="16" AlternateText="Ver Detalle Paciente"
                                    BorderWidth="0" ImageUrl="~/images/iconoDetalle.jpg" />
                            </asp:LinkButton>
                            <asp:Label ID="lblIdPaciente" runat="server" Visible="false" Text='<%#Eval("IdPaciente") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="TipoDocumento.Nombre" HeaderText="Tipo de Documento" HeaderStyle-Width="15%" />
                    <asp:BoundField DataField="NumeroDocumento" HeaderText="Documento" HeaderStyle-Width="15%" />
                    <asp:BoundField DataField="Nombres" HeaderText="Nombres" HeaderStyle-Width="15%" />
                    <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" HeaderStyle-Width="15%" />
                    <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" HeaderStyle-Width="20%" DataFormatString="{0:yyy/MM/dd}" />
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="5%" ItemStyle-VerticalAlign="Middle">
                        <HeaderTemplate>
                            Eliminar
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton CommandName="EliminarPaciente" runat="server" ID="lnkEliminarpaciente">
                                <asp:Image ID="imgEliminarPaciente" runat="server" Width="16" Height="16" AlternateText="Eliminar Paciente"
                                    BorderWidth="0" ImageUrl="~/images/Delete.gif" />
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="form-row">
            <div class="divTableCellSearch"></div>
            <div class="divTableCellSearch"></div>
            <div class="divTableCellSearch"></div>
            <div class="divTableCellSearch"></div>
            <div class="divTableCellSearch">
                <asp:Button ID="btnExportarExcel" Enabled="false" runat="server" OnClick="btnExportarExcel_Click" 
                    Text="Exportar Excel" CssClass="form-basic-button" />
            </div>
        </div>
    </div>
</asp:Content>
