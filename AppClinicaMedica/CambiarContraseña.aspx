<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CambiarContraseña.aspx.cs" Inherits="AppClinicaMedica.CambiarContraseña" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="titPpal">Cambiar Contraseña</h1>
    <div class="row">
        <div class="col-3">
            <%--textmode="Password"--%>
            <asp:Label Style="color: black;" Text="Contraseña Actual" runat="server" />
            <asp:TextBox CssClass="form-control" ID="txtPassActual" REQUIRED runat="server" textmode="Password"/>
            <asp:Label Style="color: black;" Text="Nueva contraseña" runat="server" />
            <asp:TextBox CssClass="form-control" ID="txtPassNueva" REQUIRED runat="server" textmode="Password" />
            <asp:Label Style="color: black;" Text="Repita la nueva contraseña" runat="server" />
            <asp:TextBox CssClass="form-control" ID="txtRepetirPass" REQUIRED runat="server" textmode="Password" />
            <asp:Button CssClass="btn btn-success" Style="margin: 30px;" Text="Confirmar" ID="btnConfirmarContraseña" OnClick="btnConfirmarContraseña_Click" runat="server" />
            <a href="MiSesion.aspx" class="btn btn-danger">Cancelar</a>

            <%if (Session["error"] != null)
                {

            %>
            <div style="background-color: white; color: red; font-size: 20px; font-weight: bold; margin-top: 25px; margin-bottom: 25px; text-align: center;" class="form-control">
                <asp:Label runat="server" ID="lblErrorPassword"></asp:Label>
            </div>
            <%}
                else
                { %>
            <div style="background-color: white; color: darkgreen; font-size: 20px; font-weight: bold; margin-top: 25px; margin-bottom: 25px; text-align: center;" class="form-control">
                <asp:Label runat="server" ID="lblPasswordOk"></asp:Label>
            </div>
            <% }%>
        </div>
    </div>
</asp:Content>
