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
                        <asp:Label Text="Especialidad" Style="color: royalblue" runat="server" />
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEspecialidades" OnSelectedIndexChanged="ddlEspecialidades_SelectedIndexChanged"
                            AutoPostBack="true" AppendDataBoundItems="true">
                            <asp:ListItem Text="Seleccione una opción" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-6">

                    <div class="col-6">
                        <asp:Label Text="Médico" Style="color: royalblue" runat="server" />
                        <asp:DropDownList runat="server" OnDataBound="ddlMedicosFiltrados_DataBound" OnPreRender="ddlMedicosFiltrados_PreRender"
                            CssClass="form-control" ID="ddlMedicosFiltrados" AutoPostBack="true" OnSelectedIndexChanged="ddlMedicosFiltrados_SelectedIndexChanged">
                            <%--<asp:ListItem Text="Seleccione una opción" Value="0"></asp:ListItem>--%>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-6">
                    <div class="col-6">
                        <asp:Label Text="Fecha" Style="color: royalblue" runat="server" />
                        <asp:TextBox ID="txtFecha" runat="server" TextMode="Date" OnTextChanged="txtFecha_TextChanged" AutoPostBack="true" />

                        <div style="margin-top: 30px">
                            <asp:Label ID="lblHorario" Text="Horario" Style="color: royalblue" runat="server" />
                            <asp:TextBox ID="txtHorario" runat="server" TextMode="Time" class="fomr-control"
                                OnTextChanged="txtHorario_TextChanged" AutoPostBack="true" />
                        </div>
                    </div>
                </div>
                <div class="col-6">
                    <asp:Label Text="Paciente" Style="color: royalblue" runat="server" />
                    <asp:DropDownList ID="ddlPacientes" OnPreRender="ddlPacientes_PreRender" OnDataBound="ddlPacientes_DataBound" CssClass="form-control" runat="server"
                        OnSelectedIndexChanged="ddlPacientes_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Text="Seleccione un Paciente" Value="0" />
                    </asp:DropDownList>
                </div>
            </div>
            <hr />
            <asp:Label Text="Turnos Encontrados" runat="server"
                Style="color: mediumorchid; margin-left: 42px; font-size: 35px" />
            <div class="row" style="overflow: scroll; flex: content; max-height: 500px">
                <asp:GridView runat="server" ID="dgvTurnos" DataKeyNames="IDTurno" OnSelectedIndexChanged="dgvTurnos_SelectedIndexChanged"
                    CssClass="table table-bordered" Style="margin-left: 0px; margin-top: 10px" AutoGenerateColumns="false">  <%--OnRowDataBound="dgvTurnos_RowDataBound"--%>
                    <Columns>
                        <%--EL GRID SE DEBE AUTOCOMPLETAR CADA VEZ QUE SE CAMBIA EL MEDICO--%>
                        <asp:BoundField HeaderText="Nro de Turno" DataField="IDTurno" />
                        <asp:BoundField HeaderText="Medico" DataField="Medico.Nombre" />
                        <asp:BoundField HeaderText="Especialidad" DataField="Especialidad.Nombre" />
                        <asp:BoundField HeaderText="Paciente" DataField="Paciente.Nombre" />
                        <asp:TemplateField HeaderText="Fecha">
                            <ItemTemplate>
                                <%--<%# Eval("Fecha", "{0:dd/MM/yyyy}") %>--%>
                                <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("Fecha", "{0:dd/MM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%--<asp:TemplateField HeaderText="Hora">
                            <ItemTemplate>
                                <asp:Label ID="lblHora" runat="server" Text='<%# Bind("Hora", "{0:HH:mm}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:BoundField HeaderText="Hora" DataField="HoraInicio" />
                        <asp:CommandField ShowSelectButton="true" SelectText="Asignar Actual" HeaderText="Asignar" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" />
                        <asp:CommandField ShowSelectButton="true" SelectText="Desasignar" HeaderText="Desasignar" ButtonType="Button" ControlStyle-CssClass="btn btn-danger" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="row">
                <div class="col-6">
                </div>
            </div>
            <div class="row">
                <div class="col-6" style="color: slateblue">
                    <asp:Label Text="Su elección" runat="server" />
                    <asp:TextBox runat="server" TextMode="MultiLine" ID="txtbEleccion" ReadOnly="true" Style="width: 1000px" />
                </div>
            </div>
            <asp:Button ID="btnConfirmar" Text="Confirmar Turno" runat="server" OnClick="btnConfirmar_Click" CssClass="btn btn-success" Style="margin-top: 40px; margin-left: 42px" />
            <a href="Turnos.aspx" class="btn btn-danger" style="margin-top: 40px; margin-left: 10px;">Cancelar</a>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
