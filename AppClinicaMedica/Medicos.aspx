<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Medicos.aspx.cs" Inherits="AppClinicaMedica.Medicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="titPpal">Médicos </h1>
    <a href="NuevoMedico.aspx" class="btn my-boton" style="margin-left: 70px">Agregar Medico</a>

    <asp:ScriptManager ID="scriptManager" runat="server" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row" style="overflow: scroll; flex: content; max-height: 270px; margin-bottom: 50px;">
                <div class="col-15 table-responsive ">
                    <asp:GridView runat="server" ID="dgvMedicos" DataKeyNames="IDMedico" OnSelectedIndexChanged="dgvMedicos_SelectedIndexChanged" CssClass="table table-bordered" Style="margin-left: 0px; margin-top: 0px; box-shadow: 0px 0px 8px 0px green;" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField HeaderText="Usuario" DataField="Usuario" />
                            <asp:BoundField HeaderText="Id" DataField="IdMedico" />
                            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                            <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                            <asp:BoundField HeaderText="Matricula" DataField="Matricula" />
                            <asp:BoundField HeaderText="DNI" DataField="Dni" />
                            <asp:BoundField HeaderText="Nacimiento" DataField="FechaDeNacimiento" />
                            <asp:BoundField HeaderText="Mail" DataField="Email" />
                            <asp:BoundField HeaderText="Celular" DataField="Celular" />
                            <asp:BoundField HeaderText="Domicilio" DataField="Domicilio" />
                            <asp:BoundField HeaderText="Cod Postal" DataField="CodPostal" />
                            <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Acción" ControlStyle-CssClass="btn btn-sm btn-primary" />

                        </Columns>
                    </asp:GridView>
                    <asp:TextBox ID="txtId" CssClass="d-none" runat="server" />
                </div>
            </div>
            <div class="row nuevoPaciente" style="margin-left: 50px">
                <div class="col-6 ">

                    <div class="mb-3">

                        <asp:Label ID="lblNombre" Text="Nombre" runat="server" Font-Size="Large" Style="color: black;" />
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
                        <div class="row">

                            <div>
                                <asp:Button Text="Limpiar" CssClass="btn btn-primary" ID="LimpiarCampos" OnClick="LimpiarCampos_Click" runat="server" />
                                <asp:Button Text="Modificar" CssClass="btn btn-warning prueba" OnClick="btnModificar_Click" runat="server" />
                                <asp:Button Text="Baja" ID="btnBajaMedico" OnClick="btnBajaMedicoClick" CssClass="btn btn-danger" runat="server" />
                            </div>
                        </div>
                    </div>

                </div>
                <di class="col-6">
                    <div class="mb-3">

                        <asp:Label ID="lblCodPost" Text="Codigo postal" Font-Size="Large" runat="server" Style="color: black;" />
                        <asp:TextBox ID="txtCodPost" CssClass="form-control" placeholder="Codigo Postal" runat="server" />

                        <asp:Label ID="lblEspecialidades" Text="Especialidades" runat="server" Font-Size="Large" Style="color: black;" />
                        <div class="mb-1">
                            <asp:DropDownList ID="ddlAgregarEsp" CssClass="form-control" runat="server"></asp:DropDownList>
                            <asp:Button ID="btnAgregarEsp" runat="server" OnClick="btnAgregarEspecialidadaMedico" CssClass="btn btn-success" Text="Agregar" />
                            <asp:Button ID="btnEliminarEsp" runat="server" OnClick="btnEliminarEspecialidadaMedico" CssClass="btn btn-dark" Text="Eliminar" />
                        </div>

                        <div class="input-group">
                            <asp:ListBox ID="listBox" CssClass="form-control h-100" runat="server"></asp:ListBox>
                        </div>

                        <asp:Label ID="lblHorarios" Text="Horarios" runat="server" Font-Size="Large" Style="color: black;" />
                        <div class="mb-1">
                            <asp:DropDownList ID="DropDownListHxM" OnDataBound="DropDownListHxM_DataBound" class="form-control" runat="server"></asp:DropDownList>
                            <%  if (txtId.Text == "")
                                { %>
                            <button class="btn btn-primary" type="button" data-bs-toggle="collapse" data-bs-target="#collapseWidthExample" aria-expanded="false" aria-controls="collapseWidthExample">
                                +
                            </button>
                            <div style="min-height: 0px">
                                <div class="collapse collapse-horizontal" id="collapseWidthExample">
                                    <div class="card card-body" style="width: 200px; color: black; font-size: 15px; background-color: firebrick">
                                        No hay medico seleccionado
                                    </div>
                                </div>
                            </div>

                            <%--<button type="button" class="btn btn-secondary" data-bs-container="body" data-bs-toggle="popover" data-bs-placement="right" data-bs-content="Seleccione un Médico">
                                +
                            </button>--%>


                            <%  }  %>
                            <%else
                                { %>

                            <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
                                +
                            </button>

                            <% } %>
                        </div>
                        <asp:Button ID="agregarHxM" class="btn btn-success" OnClick="btnAgregarHorarioaMedico" runat="server" Text="Agregar" />
                        <asp:Button ID="eliminarHxM" class="btn btn-dark" OnClick="btnEliminarHorarioaMedico" runat="server" Text="Eliminar" />


                        <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <%--<div class="modal-header">
                                        <h1 class="modal-title fs-5" id="exampleModalLabel">Modal title</h1>
                                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                    </div>--%>
                                    <div class="modal-body">
                                        <asp:Label ID="lblIni" Text="Hora Inicio" Font-Size="Large" runat="server" Style="color: black;" />
                                        <asp:TextBox ID="txtHorarioIni" TextMode="Time" CssClass="form-control" runat="server" />
                                        <asp:Label ID="lblFin" Text="Hora Fin" Font-Size="Large" runat="server" Style="color: black;" />
                                        <asp:TextBox ID="txtHorarioFin" TextMode="Time" CssClass="form-control" runat="server" />

                                        <asp:DropDownList ID="ddlAgregarHorario" CssClass="form-control" runat="server"></asp:DropDownList>
                                        <%--AutoPostBack="true" OnSelectedIndexChanged="ddlAgregarHorario_SelectedIndexChanged"--%>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                                        <asp:Button Text="Agregar" CssClass="btn btn-primary" data-bs-dismiss="modal" ID="btnAgregarHorario" OnClick="btnAgregarHorario_Click" runat="server" AutoPostBack="false" />
                                    </div>

                                </div>
                            </div>


                            <%--<button type="button" class="btn btn-success border rounded" data-toggle="modal" data-target="#miModal">
                            + 
                        </button>--%>

                            <%-- <div class="modal fade" id="miModal" tabindex="-1" role="dialog" aria-labelledby="miModalLabel" aria-hidden="true">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <!-- Contenido de la ventana emergente -->
                                    <asp:Label ID="lblIni" Text="Hora Inicio" Font-Size="Large" runat="server" Style="color: black;" />
                                    <asp:TextBox ID="txtHorarioIni" TextMode="Time" CssClass="form-control" runat="server" />
                                    <asp:Label ID="lblFin" Text="Hora Fin" Font-Size="Large" runat="server" Style="color: black;" />
                                    <asp:TextBox ID="txtHorarioFin" TextMode="Time" CssClass="form-control" runat="server" />

                                    <asp:DropDownList ID="ddlAgregarHorario" CssClass="form-control" runat="server"></asp:DropDownList> 
                                    <div>
                                        <asp:Button Text="Aceptar" CssClass="btn btn-primary" ID="btnAgregarHorario" OnClick="btnAgregarHorario_Click" runat="server" />
                                        <asp:Button Text="Cancelar" class="btn btn-danger" OnClick="Unnamed_Click" Style="margin-left: 10px;" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>--%>


                            <div>
                                <asp:ListBox ID="listBoxHxM" CssClass="form-control h-100" runat="server"></asp:ListBox>
                            </div>
                        </div>

                    </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
