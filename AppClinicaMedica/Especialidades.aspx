<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="AppClinicaMedica.Especialidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" style="padding: 20px">

    <script>
        function confirmarBajaEspecialidad() {
            return confirm("¿Desea dar de baja esta especialidad?");
        }
    </script>

    <h1 class="titPpal">Especialidades</h1>
    <%if (Session["usuario"] != null)
        {  %>
    <%if (!esPaciente())
        {  %>
    <a href="NuevaEspecialidad.aspx" class="btn my-boton" style="margin-left: 70px">Agregar Especialidad</a>
    <%} %>
    <%} %>
    <div class="row">
        <div class="col-2">
            <asp:Label Text="Buscar" Style="color: black" runat="server" />
            <asp:TextBox runat="server" ID="txtFiltro" AutoPostBack="true" OnTextChanged="filtro_TextChanged" CssClass="form-control" />
            <a href="Especialidades.aspx" class="btn btn-secondary">Limpiar filtro</a>
        </div>
    </div>
    <div class="row" style="margin-left: 20px;">
        <asp:Repeater runat="server" ID="repetidor">
            <ItemTemplate>
                <div class="col-md-4 mb-4 d-flex align-items-stretch">
                    <div class="card mi-card" style="width: 100%;">
                        <div class="card-body">
                            <img src="<%#Eval("IMAGEN") %>" class="card-img-top" style="object-fit: cover; object-position: center; width: 100%; height: 200px;" alt="...">
                            <h2 class="card-title"><%#Eval("NOMBRE") %></h2>
                            <p class="card-text" style="font-family: 'Times New Roman', Times, serif; font-weight: 200;"><%#Eval("DESCRIPCION") %></p>
                        </div>
                        <div class="col-md-4 mb-4">
                            <%if (Session["usuario"] != null)
                                { %>
                            <%if (!esPaciente())
                                {  %>
                            <a href="NuevaEspecialidad.aspx?id=<%#Eval("IdEspecialidad") %>" class="btn btn-success" style="margin-left: 15px;">Modificar</a>
                            <asp:Button Text="Baja" ID="btnBajaEspecialidad" OnClick="btnBajaEspecialidad_Click" OnClientClick="return confirmarBajaEspecialidad()" CssClass="btn btn-danger" runat="server" CommandArgument='<%#Eval("IdEspecialidad") %>' CommandName="IdEspecialidad" />
                            <%}

                            %>
                            <%}

                            %>
                        </div>
                        <%if (Session["usuario"] == null)
                            { %>
                        <a href="LogIn.aspx" class="btn my-boton">Reservar un turno.</a>
                        <% }

                        %>
                        <%else
                            { %>
                        <a href="Turnos.aspx" class="btn my-boton">Reservar un turno.</a>
                        <% } %>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>

