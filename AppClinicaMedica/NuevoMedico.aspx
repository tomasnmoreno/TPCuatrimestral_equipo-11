<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevoMedico.aspx.cs" Inherits="AppClinicaMedica.NuevoMedico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row nuevoPaciente">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtUsuario" class="form-label nuevoPaciente">Usuario</label>
                <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtPass" class="form-label">Constraseña</label>
                <asp:TextBox runat="server" TextMode="Password" ID="txtPass" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtNacimiento" class="form-label">Fecha Nacimiento</label>
                <asp:TextBox runat="server" TextMode="Date" ID="txtNacimiento" CssClass="form-control" />
            </div>
            <div class="container agregarEspecialidad">
                <asp:Button Text="Aceptar" CssClass="btn btn-primary" ID="btnAgregarMedico" OnClick="btnAgregarMedico_Click" runat="server" />
                <a href="Medicos.aspx" class="btn btn-danger" style="margin-left: 10px;">Cancelar</a>          </div>
        </div>
    </div>
</asp:Content>
