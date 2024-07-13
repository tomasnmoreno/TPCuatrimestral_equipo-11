<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MiSesion.aspx.cs" Inherits="AppClinicaMedica.MiSesion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <h1 style="color: navy">Mi Perfil</h1>
    </div>
    <div class="row">
        <div class="col-4">
            <asp:Label Text="Nombre" ID="lblPerfilNombre" runat="server" cssclass="lblPerfil"/>
            <asp:TextBox runat="server" ID="txtPerfilNombre" CssClass="form-control txtPerfil"/>
            <asp:Label Text="Apellido" ID="lblPerfilApellido" runat="server" cssclass="lblPerfil"/>
            <asp:TextBox runat="server" ID="txtPerfilApellido" CssClass="form-control txtPerfil"/>
            <asp:Label Text="Documento" ID="lblPerfilDni" runat="server" cssclass="lblPerfil"/>
            <asp:TextBox runat="server" ID="txtPerfilDni" CssClass="form-control txtPerfil"/>
            <asp:Label Text="Fecha de Nacimiento" ID="lblPerfilNacimiento" runat="server" cssclass="lblPerfil"/>
            <asp:TextBox runat="server" ID="txtPerfilNacimiento" CssClass="form-control txtPerfil"/>
            <asp:Button ID="btnCambioContraseña" Text="Modificar Contraseña" CssClass="btn btn-primary" runat="server" OnClick="btnCambioContraseña_Click" style="margin-top: 35px; margin-bottom: 50px;"/>
        </div>
        <div class="col-4">
            <asp:Label Text="Domicilio" ID="lblPerfilDomicilio" runat="server" cssclass="lblPerfil"/>
            <asp:TextBox runat="server" ID="txtPerfilDomicilio" CssClass="form-control txtPerfil"/>
            <asp:Label Text="E-mail" ID="lblPerfilEmail" runat="server" cssclass="lblPerfil"/>
            <asp:TextBox runat="server" ID="txtPerfilEmail" CssClass="form-control txtPerfil"/>
            <asp:Label Text="Celular" ID="lblPerfilCelular" runat="server" cssclass="lblPerfil"/>
            <asp:TextBox runat="server" ID="txtPerfilCelular" CssClass="form-control txtPerfil"/>
            <asp:Label Text="Fecha de Alta" ID="lblPerfilAlta" runat="server" cssclass="lblPerfil"/>
            <asp:TextBox runat="server" ID="txtPerfilAlta" CssClass="form-control txtPerfil"/>
        </div>
    </div>

</asp:Content>
