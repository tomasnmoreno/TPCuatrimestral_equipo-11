﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarEstado.aspx.cs" Inherits="AppClinicaMedica.ModificarEstado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .contenedor {
            display: grid;
            place-items: center;
        }
    </style>
    <h1 class="titPpal">Modificar Estado del Turno </h1>
    <div class="contenedor" style="margin-top: 100px; margin-bottom: 1000px">


        <div class="mb-3">
            <asp:Label Text="Nuevo Estado" CssClass="form-label" runat="server" />
        </div>
        <div class="mb-3">
            <asp:DropDownList ID="ddlEstados" CssClass="form-control" runat="server">
                <asp:ListItem Value="1" Text="Nuevo" />
                <asp:ListItem Value="2" Text="Reprogramado" />
                <asp:ListItem Value="3" Text="Cancelado" />
                <asp:ListItem Value="4" Text="No asistio" />
                <asp:ListItem Value="5" Text="Cerrado" />
            </asp:DropDownList>
        </div>
        <div class="mb-3">
            <asp:Label Text="Nueva Observacion" CssClass="form-label" ID="lblObservacion" runat="server" />

        </div>
        <div class="mb-3">
            <asp:TextBox ID="txtObservaciones" TextMode="MultiLine" CssClass="form-control" required placeholder="Observaciones" runat="server" />

        </div>
        <div class="mb-3">

            <asp:Button ID="btnModificar" Text="Modificar" OnClick="btnModificar_Click" CssClass="btn btn-primary" runat="server" />
            <a href="MisTurnos.aspx" class="btn btn-danger">Cancelar</a>
        </div>

    </div>
</asp:Content>
