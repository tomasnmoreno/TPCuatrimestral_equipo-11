<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevoRecepcionista.aspx.cs" Inherits="AppClinicaMedica.NuevoRecepcionista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="titPpal">Nuevo Recepcionista</h1>
    <div class="row nuevoPaciente">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtUsuario" class="form-label nuevoPaciente">Usuario</label>
                <asp:TextBox runat="server" ID="txtUsuario" placeholder="Usuario" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtPass" class="form-label">Constraseña</label>
                <asp:TextBox runat="server" TextMode="Password" placeholder="Contraseña" ID="txtPass" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" placeholder="Nombre" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox runat="server" ID="txtApellido" placeholder="Apellido" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtDNI" class="form-label">DNI</label>
                <asp:TextBox runat="server" ID="txtDNI" placeholder="DNI" CssClass="form-control" />
            </div>
        </div>
        <div class="col-6">
            <div class="mb-3">
                <label for="txtNacimiento" class="form-label">Fecha Nacimiento</label>
                <asp:TextBox runat="server" TextMode="Date" ID="txtNacimiento" placeholder="Fecha de Nacimiento" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox runat="server" TextMode="Email" ID="txtEmail" placeholder="Email" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtCelular" class="form-label">Celular</label>
                <asp:TextBox runat="server" TextMode="Phone" ID="txtCelular" placeholder="Celular" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtDomicilio" class="form-label">Domicilio</label>
                <asp:TextBox runat="server" ID="txtDomicilio" placeholder="Domicilio" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtCodPostal" class="form-label">Codigo Postal</label>
                <asp:TextBox runat="server" ID="txtCodPostal" placeholder="Código Postal" CssClass="form-control" />
            </div>
        </div>

        <div class="container agregarEspecialidad">
            <asp:Button Text="Aceptar" CssClass="btn btn-primary" ID="btnAgregarRecepcionista" OnClick="btnAgregarRecepcionista_Click" runat="server" />
            <a href="Pacientes.aspx" class="btn btn-danger" style="margin-left: 10px;">Cancelar</a>
            <asp:Button Text="Baja" ID="btnBajaRecepcionista" OnClick="btnBajaRecepcionista_Click" CssClass="btn btn-danger" runat="server" />
        </div>
        <%--</div>--%>
    </div>
</asp:Content>
