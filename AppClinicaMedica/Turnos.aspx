<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="AppClinicaMedica.Turnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="titPpal">Turnos</h1>
    <asp:ScriptManager ID="scriptManager" runat="server" />

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-6">

                    <div class="col-6">
                        <asp:Label Text="Especialidad" runat="server" />
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEspecialidades" OnSelectedIndexChanged="ddlEspecialidades_SelectedIndexChanged"
                            AutoPostBack="true" AppendDataBoundItems="true">
                            <asp:ListItem Text="Seleccione una opción" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-6">

                    <div class="col-6">
                        <asp:Label Text="Médico" runat="server" />
                        <asp:DropDownList runat="server" OnDataBound="ddlMedicosFiltrados_DataBound" CssClass="form-control" ID="ddlMedicosFiltrados" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-6">
                    <div class="col-6">
                        <asp:Label Text="Fecha" runat="server" />
                        <%--<asp:TextBox runat="server" TextMode="Date"/> --%>
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlFechaTurno">
                            <asp:ListItem Text="text1" />
                            <asp:ListItem Text="text2" />
                        </asp:DropDownList>
                        <asp:Label Text="Horario" runat="server" />
                        <asp:DropDownList CssClass="form-control" runat="server">
                            <asp:ListItem Text="Horario 1" />
                            <asp:ListItem Text="Horario 2" />
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <asp:Button Text="Confirmar Turno" runat="server" CssClass="btn btn-success" />
            <a href="Turnos.aspx" class="btn btn-danger" style="margin-left: 10px;">Cancelar</a>

        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="col">
        <asp:GridView runat="server" ID="dgvTurnos" CssClass="table table-bordered" Style="margin-left: 50px" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="Turno" DataField="IDTurno" />
                <asp:BoundField HeaderText="Medico" DataField="IDMedico" />
                <%--<asp:BoundField HeaderText="Paciente" DataField="Apellido" />--%>
                <%--<asp:BoundField HeaderText="DNI" DataField="Dni" />--%>
                <asp:BoundField HeaderText="Fecha" DataField="Fecha" />
                <asp:BoundField HeaderText="Hora" DataField="Hora" />
                <%--<asp:BoundField HeaderText="Especialidad" DataField="Email" />--%>
                <%--                        <asp:BoundField HeaderText="Celular" DataField="Celular" />
        <asp:BoundField HeaderText="Domicilio" DataField="Domicilio" />
        <asp:BoundField HeaderText="Cod Postal" DataField="CodPostal" />--%>
                <asp:CommandField ShowSelectButton="true" SelectText="Presente" HeaderText="Asistio" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
