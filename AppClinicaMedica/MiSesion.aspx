<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MiSesion.aspx.cs" Inherits="AppClinicaMedica.MiSesion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-6">
            <asp:Button Text="Desloguearse" CssClass="btn btn-danger" runat="server" />
        </div>
        <div class="col-6">
            <asp:Button Text="Cambiar Contraseña" CssClass="btn btn-primary" runat="server" />
        </div>
    </div>

</asp:Content>
