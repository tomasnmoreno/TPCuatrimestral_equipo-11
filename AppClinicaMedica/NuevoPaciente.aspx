<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevoPaciente.aspx.cs" Inherits="AppClinicaMedica.NuevoPaciente" %>

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
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtDNI" class="form-label">DNI</label>
                <asp:TextBox runat="server" ID="txtDNI" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtNacimiento" class="form-label">Fecha Nacimiento</label>
                <asp:TextBox runat="server" TextMode="Date" ID="txtNacimiento" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox runat="server" TextMode="Email" ID="txtEmail" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtCelular" class="form-label">Celular</label>
                <asp:TextBox runat="server" TextMode="Phone" ID="txtCelular" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtDomicilio" class="form-label">Domicilio</label>
                <asp:TextBox runat="server" ID="txtDomicilio" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtCodPostal" class="form-label">Codigo Postal</label>
                <asp:TextBox runat="server" ID="txtCodPostal" CssClass="form-control" />
            </div>
            <%--             <div class="mb-3">
                 <asp:Button Text="Aceptar" ID="btnAceptar" OnClick="btnAceptar_Click" runat="server" />
             </div>--%>
            <div class="container agregarEspecialidad">
                <asp:Button Text="Aceptar" CssClass="btn btn-primary" ID="btnAgregarPaciente" OnClick="btnAgregarPaciente_Click" runat="server" />
                <a href="Pacientes.aspx" class="btn btn-danger" style="margin-left: 10px;">Cancelar</a>
                <asp:Button Text="Baja" ID="btnBajaPaciente" OnClick="btnBajaPaciente_Click" CssClass="btn btn-danger" runat="server"/>
            </div>
        </div>
    </div>

</asp:Content>
