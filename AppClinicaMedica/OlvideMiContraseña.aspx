<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OlvideMiContraseña.aspx.cs" Inherits="AppClinicaMedica.OlvideMiContraseña" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <h1 class="titPpal">Olvide Mi Contraseña</h1>
        <div class="containerLogIn" style="margin-top: 100px; margin-bottom: 1000px">
            <div class="rowLogIn">
                <div>
                    <asp:TextBox CssClass="paddingLogIn" Style="width: 400px; margin-bottom: 40px; font-size: 25px; border-radius: 5px; text-indent: 5px;" ID="txtbUserName" placeholder="Usuario" REQUIRED runat="server" />
                </div>
                <div>
                    <asp:TextBox CssClass="paddingLogIn"  Style="width: 400px; margin-bottom: 40px; font-size: 25px; border-radius: 5px; text-indent: 5px;" ID="txtbMail" placeholder="Email" REQUIRED runat="server" />
                </div>
                <div>
                    <asp:Button CssClass="button button-primary button-ingresar paddingLogIn" ID="btnConfirmar" OnClick="btnConfirmar_Click"  Text="Confirmar" runat="server" />
                </div>
                <%if (Session["error"] != null)
                    {  %>
                <div style="color: red; font-size: 25px; margin-top: 25px; margin-bottom: 25px;">
                    <asp:Label runat="server" ID="lblError"></asp:Label>
                </div>
                <% }  %>
                <div class="registrarseLogIn">
                    <a class="fuenteLogIn" href="NuevoPaciente.aspx">o regístrese dando click aquí</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
