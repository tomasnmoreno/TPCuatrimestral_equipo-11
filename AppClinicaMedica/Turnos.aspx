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
                        <asp:DropDownList runat="server" OnDataBound="ddlMedicosFiltrados_DataBound" CssClass="form-control" ID="ddlMedicosFiltrados" AutoPostBack="true" OnSelectedIndexChanged="ddlMedicosFiltrados_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-6">
                    <div class="col-6">
                        <asp:Label Text="Fecha" runat="server" />
                        <%--<asp:TextBox runat="server" TextMode="Date"/> --%>
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlFechaTurno"> <%-- TODA ESTA SECCIOM SE TIENE QUE COMPLETAR CON DATOS SELECCIONADOS DEL GRID VIEW--%>
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
            <div>
                <asp:GridView runat="server" ID="dgvTurnos" DataKeyNames="IDTurno" OnSelectedIndexChanged="dgvTurnos_SelectedIndexChanged" CssClass="table table-bordered" Style="margin-left: 42px; margin-top: 10px" AutoGenerateColumns="false">
                    <Columns> <%--EL GRID SE DEBE AUTOCOMPLETAR CADA VEZ QUE SE CAMBIA EL MEDICO--%>
                        <asp:BoundField HeaderText="Nro de Turno" DataField="IDTurno" />
                        <asp:BoundField HeaderText="Medico" DataField="Medico.Nombre" />
                        <asp:BoundField HeaderText="Especialidad" DataField="Especialidad.Nombre" />
                        <asp:BoundField HeaderText="Paciente" DataField="Paciente.Nombre" />
                        <asp:BoundField HeaderText="Fecha" DataField="Fecha" />
                        <asp:BoundField HeaderText="Hora" DataField="Hora" />
                        <asp:CommandField ShowSelectButton="true" SelectText="Asignar" HeaderText="Asignar" />
                    </Columns>
                </asp:GridView>
            </div>
            <asp:Button Text="Confirmar Turno" runat="server" CssClass="btn btn-success" />
            <a href="Turnos.aspx" class="btn btn-danger" style="margin-left: 10px;">Cancelar</a>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
