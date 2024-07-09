<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MisTurnos.aspx.cs" Inherits="AppClinicaMedica.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="titPpal">Mis Turnos </h1>
    <div class="row agregarEspecialidad">
        <asp:GridView ID="dgvMisTurnos" CssClass="table table-bordered" OnSelectedIndexChanged="dgvMisTurnos_SelectedIndexChanged" Style="margin-left: 0px; margin-top: 0px; box-shadow: 0px 0px 8px 0px blue;" AutoGenerateColumns="false" runat="server">
            <Columns>
                <asp:BoundField HeaderText="Nro de Turno" DataField="IDTurno" />
                <asp:BoundField HeaderText="Especialidad" DataField="Especialidad.Nombre" />
                <asp:BoundField HeaderText="Paciente" DataField="Paciente.Nombre" />
                <asp:BoundField HeaderText="Estado" DataField="EstadoT.Descripcion" />
                <asp:TemplateField HeaderText="Fecha">
                    <ItemTemplate>
                        <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("Fecha", "{0:dddd, dd/MM/yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Hora" DataField="HoraInicio" />
                <asp:CommandField ShowSelectButton="true" SelectText="Elegir" HeaderText="Cambiar estado" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" />
            </Columns>
        </asp:GridView>
        </div>

</asp:Content>
