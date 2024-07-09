<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CambiarContraseña.aspx.cs" Inherits="AppClinicaMedica.CambiarContraseña" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="titPpal">Cambiar Contraseña</h1>
    <div class="row" >
        <div class="col-3">
            <%--textmode="Password"--%>
            <asp:Label style="color: black;" Text="Contraseña Actual" runat="server" />
            <asp:TextBox cssclass="form-control" ID="txtPassActual" REQUIRED runat="server" />
            <asp:Label style="color: black;" Text="Nueva contraseña" runat="server" />
            <asp:TextBox cssclass="form-control" ID="txtPassNueva" REQUIRED runat="server" />
            <asp:Label style="color: black;" Text="Repita la nueva contraseña" runat="server" />
            <asp:TextBox cssclass="form-control" ID="txtRepetirPass" REQUIRED runat="server" />
            <asp:Button cssclass="btn btn-success" style="margin: 30px;" Text="Confirmar" id="btnConfirmarContraseña" OnClick="btnConfirmarContraseña_Click" runat="server" />
            <a href="MiSesion.aspx" class="btn btn-danger">Cancelar</a>
        </div>
    </div>
</asp:Content>
