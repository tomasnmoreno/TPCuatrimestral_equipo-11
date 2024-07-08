<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevaEspecialidad.aspx.cs" Inherits="AppClinicaMedica.NuevaEspecialidad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1 style="text-align: center; margin-top: 20px">Nueva Especialidad</h1>
        <div class="row nuevaEspecialidad">
            <asp:Label Text="Especialidad" ID="lblEspecialidad" CssClass="lblNuevaEspecialidad" runat="server" />
            <asp:TextBox ID="txtEspecialidad" CssClass="txtNuevaEspecialidad" REQUIRED runat="server" />
            <asp:Label Text="Descripción" ID="lblDescripcionEspecialidad" CssClass="lblNuevaEspecialidad" runat="server" />
            <asp:TextBox ID="txtDescripcionEspecialidad" TextMode="MultiLine" CssClass="txtDescripcionNuevaEspecialidad" REQUIRED runat="server" />
            <asp:Label Text="Imagen" ID="lblImagenEspecialidad" CssClass="lblNuevaEspecialidad" runat="server" />
            <asp:TextBox ID="txtImagenNuevaEspecialidad" REQUIRED runat="server" />
        </div>
        <div class="container agregarEspecialidad">
            <asp:Button Text="Confirmar" CssClass="btn btn-primary" ID="btnConfirmarEspecialidad" OnClick="btnConfirmarEspecialidad_Click" runat="server" />
            <a href="Especialidades.aspx" class="btn btn-danger" style="margin-left: 10px;">Cancelar</a>
        </div>
    </div>
</asp:Content>
