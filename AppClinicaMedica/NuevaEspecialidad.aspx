<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevaEspecialidad.aspx.cs" Inherits="AppClinicaMedica.NuevaEspecialidad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
            <h1 style="text-align: center; margin-top: 20px">Nueva Especialidad</h1>
        <div class="row nuevaEspecialidad">
            <asp:Label Text="Especialidad" ID="lblEspecialidad" cssclass="lblNuevaEspecialidad" runat="server" />
            <asp:TextBox ID="txtEspecialidad" CssClass="txtNuevaEspecialidad" runat="server" />
            <asp:Label Text="Descripción" ID="lblDescripcionEspecialidad" CssClass="lblNuevaEspecialidad" runat="server" />
            <asp:TextBox ID="txtDescripcionEspecialidad" CssClass="txtDescripcionNuevaEspecialidad" runat="server" />
            <asp:Label Text="Imagen" id="lblImagenEspecialidad" CssClass="lblNuevaEspecialidad" runat="server" />
            <asp:TextBox ID="txtImagenNuevaEspecialidad" runat="server" />
        </div>
        <div class="container agregarEspecialidad">
            <asp:Button Text="Agregar" cssclass="btn btn-primary" ID="btnAgregarEspecialidad" onclick="btnAgregarEspecialidad_Click" runat="server" />
        </div>
    </div>
</asp:Content>
