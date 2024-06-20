<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pacientes.aspx.cs" Inherits="AppClinicaMedica.Pacientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .oculto {
            display: none;
        }
    </style>

    <h1 class="titPpal">Pacientes</h1>
    <a href="NuevoPaciente.aspx" class="btn my-boton" style="margin-left: 50px; margin-bottom: 10px">Agregar Paciente</a>

    <asp:GridView runat="server" ID="dgvPacientes" DataKeyNames="IDPaciente" OnSelectedIndexChanged="dgvPacientes_SelectedIndexChanged" CssClass="table table-bordered" Style="margin-left: 50px" AutoGenerateColumns="false">
        <Columns>
            <%--<asp:BoundField HeaderText="ID" DataField="IDUsuario" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />--%>
            <%--<asp:BoundField HeaderText="ID" DataField="IDUsuario" />--%>
            <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
            <asp:BoundField HeaderText="DNI" DataField="Dni" />
            <asp:BoundField HeaderText="Nacimiento" DataField="FechaDeNacimiento" />
            <asp:BoundField HeaderText="Mail" DataField="Email" />
            <asp:BoundField HeaderText="Celular" DataField="Celular" />
            <asp:BoundField HeaderText="Domicilio" DataField="Domicilio" />
            <asp:BoundField HeaderText="Cod Postal" DataField="CodPostal" />
            <asp:CommandField ShowSelectButton="true" SelectText="Modificar" HeaderText="Modificar" />
        </Columns>
    </asp:GridView>

    <div></div>
</asp:Content>
