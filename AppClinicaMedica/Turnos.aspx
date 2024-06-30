<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="AppClinicaMedica.Turnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="titPpal">Turnos</h1>
    <asp:ScriptManager id="scriptManager" runat="server" />

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col">
                    <asp:Label Text="Especialidad" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlEspecialidades" OnSelectedIndexChanged="ddlEspecialidades_SelectedIndexChanged" 
                        AutoPostBack="true" AppendDataBoundItems="true">
                        <asp:ListItem Text="Seleccione una opción" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col">
                    <asp:Label Text="Médico" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlMedicosFiltrados" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <asp:Label Text="Fecha" runat="server" />
                    <%--<asp:TextBox runat="server" TextMode="Date"/> --%>
                    <asp:DropDownList runat="server" id="ddlFechaTurno">
                        <asp:ListItem Text="text1" />
                        <asp:ListItem Text="text2" />
                    </asp:DropDownList>
                    <asp:Label Text="Horario" runat="server" />
                    <asp:DropDownList runat="server">
                        <asp:ListItem Text="Horario 1" />
                        <asp:ListItem Text="Horario 2" />
                    </asp:DropDownList>
                </div>
            </div>
            <asp:Button Text="Confirmar Turno" runat="server" CssClass="btn btn-success"/>
            <a href="Turnos.aspx" class="btn btn-danger" style="margin-left: 10px;">Cancelar</a>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
