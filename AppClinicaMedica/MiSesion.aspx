<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MiSesion.aspx.cs" Inherits="AppClinicaMedica.MiSesion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <h1 style="color: navy">Mi Perfil</h1>
    </div>
    <div class="row">
        <div class="col-6">
            <asp:Button ID="btnDesloguearse" Text="Desloguearse" CssClass="btn btn-danger" runat="server" OnClick="btnDesloguearse_Click" />
        </div>
        <div class="col-6">
            <asp:Button ID="btnCambioContraseña" Text="Cambiar Contraseña" CssClass="btn btn-primary" runat="server" OnClick="btnCambioContraseña_Click"/>
        </div>
    </div>

</asp:Content>
