<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarEstado.aspx.cs" Inherits="AppClinicaMedica.ModificarEstado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style> 
        .contenedor{
            display: grid;
            place-items: center;
        }
    </style>
    <h1 class="titPpal">Modificar Estado del Turno </h1>
    <div class="contenedor" style="margin-top: 100px; margin-bottom: 1000px">
        
            
            <div >
                <asp:Label Text="Nuevo Estado" CssClass="form-label" runat="server" />
            </div>
            <div>
                <asp:DropDownList id="ddlEstados" CssClass="form-control" runat="server">
                    <asp:ListItem Value="1" Text="Nuevo" />
                    <asp:ListItem Value="2" Text="Reprogramado" />
                    <asp:ListItem Value="3" Text="Cancelado" />
                    <asp:ListItem Value="4" Text="No asistio" />
                    <asp:ListItem Value="5" Text="Cerrado" />
                </asp:DropDownList>
            </div>
            <asp:Button ID="btnModificar" Text="Modificar" OnClick="btnModificar_Click" cssclass="btn btn-danger" runat="server" />
        
    </div>
</asp:Content>
