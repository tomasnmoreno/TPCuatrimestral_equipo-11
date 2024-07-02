﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevoMedico.aspx.cs" Inherits="AppClinicaMedica.NuevoMedico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row nuevoPaciente">
        <div class="col-6">
            <div class="col-6 ">
                <asp:Label ID="lblUsuario" Text="Usuario" Font-Size="Large" CssClass="" runat="server" Style="color: black;" />
                <asp:TextBox runat="server" ID="txtUsuario" placeholder="Nombre de Usuario" CssClass="form-control" />

                <asp:Label ID="lblcontra" Text="Contraseña" Font-Size="Large" CssClass="" runat="server" Style="color: black;" />
                <asp:TextBox runat="server" TextMode="Password" placeholder="Contraseña" ID="txtPass" CssClass="form-control" />

                <asp:Label ID="lblNombre" Text="Nombre" Font-Size="Large" CssClass="" runat="server" Style="color: black;" />
                <asp:TextBox ID="txtNombre" CssClass="form-control" placeholder="Nombre" runat="server" />

                <asp:Label ID="lblApellido" Text="Apellido" Font-Size="Large" runat="server" Style="color: black;" />
                <asp:TextBox ID="txtApellido" CssClass="form-control" placeholder="Apellido" runat="server" />

                <asp:Label ID="lblMatricula" Text="Matricula" Font-Size="Large" runat="server" Style="color: black;" />
                <asp:TextBox ID="txtMatricula" CssClass="form-control" placeholder="Matricula" runat="server" />

                <asp:Label ID="lblEmail" Text="Email" Font-Size="Large" runat="server" Style="color: black;" />
                <asp:TextBox ID="txtEmail" CssClass="form-control" placeholder="Email" runat="server" />

                <asp:Label ID="lblDni" Text="Dni" Font-Size="Large" runat="server" Style="color: black;" />
                <asp:TextBox ID="txtDni" CssClass="form-control" placeholder="Dni" runat="server" />

                <asp:Label ID="lblCelular" Text="Celular" Font-Size="Large" runat="server" Style="color: black;" />
                <asp:TextBox ID="txtCelular" CssClass="form-control" placeholder="Celular" runat="server" />

                <asp:Label ID="lblDomicilio" Text="Domicilio" Font-Size="Large" runat="server" Style="color: black;" />
                <asp:TextBox ID="txtDomicilio" CssClass="form-control" placeholder="Domicilio" runat="server" />

                <asp:Label ID="lblCodPost" Text="Codigo postal" Font-Size="Large" runat="server" Style="color: black;" />
                <asp:TextBox ID="txtCodPost" CssClass="form-control" placeholder="Codigo Postal" runat="server" />

                <asp:Label ID="lblNacimiento" Text="Fecha Nacimiento" Font-Size="Large" runat="server" Style="color: black;" />
                <asp:TextBox runat="server" TextMode="Date" ID="txtNacimiento" CssClass="form-control" />


                <div class="container agregarEspecialidad">
                    <asp:Button Text="Aceptar" CssClass="btn btn-primary" ID="BtnAgregarMedico" OnClick="BtnAgregarMedico_Click1" runat="server" />
                    <a href="Medicos.aspx" class="btn btn-danger" style="margin-left: 10px;">Cancelar</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
