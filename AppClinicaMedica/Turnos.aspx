<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="AppClinicaMedica.Turnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function validar() {
            const ddlPacientes = document.getElementById("ddlPacientes");
            if (ddlPacientes.value == "0") {
                alert("Debes elegir un Paciente");
                ddlPacientes.classList.add("is-invalid");
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptManager" runat="server" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Label Text="Turnos Encontrados" runat="server"
                Style="color: mediumorchid; margin-top: 5px; margin-left: 42px; font-size: 35px" />
            <%if (Session["error"] != null)
                {  %>
            <div style="color: red; font-size: 25px; margin-top: 25px; margin-bottom: 25px;">
                <asp:Label runat="server" ID="lblError"></asp:Label>
            </div>
            <% }  %>
            <div class="row" style="overflow: scroll; flex: content; max-height: 300px; margin-bottom: 50px;">
                <asp:GridView runat="server" ID="dgvTurnos" DataKeyNames="IDTurno" OnSelectedIndexChanged="dgvTurnos_SelectedIndexChanged"
                    CssClass="table table-bordered" Style="margin-left: 0px; margin-top: 0px; box-shadow: 0px 0px 8px 0px blueviolet;" AutoGenerateColumns="false" > <%--AllowSorting="true" OnSorting="dgvTurnos_Sorting"--%>
                    <Columns>
                        <%--EL GRID SE DEBE AUTOCOMPLETAR CADA VEZ QUE SE CAMBIA EL MEDICO--%>
                        <asp:BoundField HeaderText="Nro de Turno" DataField="IDTurno" />
                        <asp:BoundField HeaderText="Medico" DataField="Medico.Nombre" />
                        <asp:BoundField HeaderText="Especialidad" DataField="Especialidad.Nombre" />
                        <asp:BoundField HeaderText="Paciente" DataField="Paciente.Nombre" />
                        <asp:TemplateField HeaderText="Fecha">
                            <ItemTemplate>
                                <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("Fecha", "{0:dddd, dd/MM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Hora" DataField="HoraInicio" />
                        <asp:CommandField ShowSelectButton="true" SelectText="Elegir" HeaderText="Elegir Turno" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" />
                        <asp:CommandField ShowSelectButton="true" SelectText="Desasignar" HeaderText="Desasignar" ButtonType="Button" ControlStyle-CssClass="btn btn-danger" />
                        <asp:CommandField ShowSelectButton="true" SelectText="Cancelar" HeaderText="Canelar Turno" ButtonType="Button" ControlStyle-CssClass="btn btn-danger" />
                    </Columns>
                </asp:GridView>
            </div>
            <hr />
            <div class="row">
                <div class="col-6">

                    <div class="col-6">
                        <asp:Label Text="Especialidad" Style="color: royalblue" runat="server" />
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEspecialidades" OnSelectedIndexChanged="ddlEspecialidades_SelectedIndexChanged"
                            AutoPostBack="true" AppendDataBoundItems="true" OnPreRender="ddlEspecialidades_PreRender">
                            <%--<asp:ListItem Text="Seleccione una opción" Value="0"></asp:ListItem>--%>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-6">

                    <div class="col-6">
                        <asp:Label Text="Médico" Style="color: royalblue" runat="server" />
                        <asp:DropDownList runat="server" OnDataBound="ddlMedicosFiltrados_DataBound" OnPreRender="ddlMedicosFiltrados_PreRender"
                            CssClass="form-control" Style="width: 300px" ID="ddlMedicosFiltrados" AutoPostBack="true" OnSelectedIndexChanged="ddlMedicosFiltrados_SelectedIndexChanged">
                            <%--<asp:ListItem Text="Seleccione una opción" Value="0"></asp:ListItem>--%>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-6">
                    <div class="col-6">
                        <asp:Label Text="Fecha" Style="color: royalblue" runat="server" />
                        <asp:TextBox ID="txtFecha" CssClass="form-control" runat="server" TextMode="Date" OnTextChanged="txtFecha_TextChanged" AutoPostBack="true" />

                        <div style="margin-top: 30px">
                            <asp:Label ID="lblHorario" Text="Horario" Style="color: royalblue" runat="server" />
                            <asp:TextBox ID="txtHorario" CssClass="form-control" runat="server" TextMode="Time" class="fomr-control"
                                OnTextChanged="txtHorario_TextChanged" AutoPostBack="true" />
                        </div>
                    </div>
                </div>
                <div class="col-6">
                    <asp:Label Text="Paciente" Style="color: royalblue" runat="server" />
                    <asp:DropDownList ID="ddlPacientes" OnPreRender="ddlPacientes_PreRender" ClientIDMode="Static" OnDataBound="ddlPacientes_DataBound" CssClass="form-control" runat="server"
                        OnSelectedIndexChanged="ddlPacientes_SelectedIndexChanged" AutoPostBack="true" Style="margin-bottom: 30px; width: 300px;" REQUIRED>
                        <asp:ListItem Text="Seleccione un Paciente" Value="0" />
                    </asp:DropDownList>
                    <%--<div class="row">--%>
                    <div>
                        <div class="col-6" style="color: slateblue">
                            <asp:Label Text="Su elección" runat="server" />
                            <asp:TextBox runat="server" TextMode="MultiLine" ID="txtbEleccion" ReadOnly="true" Style="width: 580px; font-size: 15px; border-color: blue; box-shadow: 0px 0px 8px 0px blue; text-indent: 8px;" />
                        </div>
                    </div>
                    <%--</div>--%>
                </div>
            </div>
            <div style="display: flex; justify-content: center; gap: 50px;">
                <asp:Button ID="btnConfirmar" Text="Confirmar Turno" runat="server" ClientIDMode="Static" OnClientClick="return validar()" OnClick="btnConfirmar_Click" CssClass="btn btn-success" Style="margin-top: 40px; margin-left: 42px" />
                <a href="Turnos.aspx" class="btn btn-danger" style="margin-top: 40px; margin-left: 10px;">Cancelar</a>
            </div>
            <hr />
            
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
