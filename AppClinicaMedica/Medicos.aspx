<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Medicos.aspx.cs" Inherits="AppClinicaMedica.Medicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="titPpal">Médicos </h1>

    <div class="row">
        <div class="col-8 table-responsive">
            <asp:GridView runat="server" ID="dgvMedicos" OnSelectedIndexChanged="dgvMedicos_SelectedIndexChanged" CssClass="table table-info table-bordered table-sm">
                <Columns>

                    <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Acción" ControlStyle-CssClass="btn btn-sm btn-primary" />
                </Columns>
            </asp:GridView>
            <asp:TextBox ID="txtId" CssClass="d-none" runat="server" />
        </div>
        <div class="col">
            <div class="col-6 ">

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

                <asp:Label ID="lblEspecialidades" Text="Especialidades" runat="server" Font-Size="Large" Style="color: black;" />
                <div class="mb-1">
                    <asp:DropDownList ID="ddlAgregarEsp" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:Button ID="btnAgregarEsp" runat="server" OnClick="btnAgregarEspecialidadaMedico" CssClass="btn" Text="Agregar" />
                    <asp:Button ID="btnEliminarEsp" runat="server" OnClick="btnEliminarEspecialidadaMedico" CssClass="btn" Text="Eliminar" />
                </div>

                <div class="input-group">
                    <asp:ListBox ID="listBox" CssClass="form-control h-100" runat="server"></asp:ListBox>
                </div>

                <asp:Label ID="lblHorarios" Text="Horarios" runat="server" Font-Size="Large" Style="color: black;" />
                <div class="mb-1">
                    <asp:DropDownList ID="DropDownListHxM" class="form-control" runat="server"></asp:DropDownList>
                    <asp:Button ID="agregarHxM" class="btn" OnClick="btnAgregarHorarioaMedico" runat="server" Text="Agregar" />
                    <asp:Button ID="eliminarHxM" class="btn" OnClick="btnEliminarHorarioaMedico" runat="server" Text="Eliminar" />
                </div>
                <div>
                    <asp:ListBox ID="listBoxHxM" CssClass="form-control h-100" runat="server"></asp:ListBox>
                </div>
                <div class="row">

                    <div>
                        <asp:Button Text="Agregar" CssClass="btn btn-primary" ID="agregarMedico" OnClick="agregarMedico_Click" runat="server" />
                        <asp:Button Text="Modificar" CssClass="btn btn-warning prueba" OnClick="btnModificar_Click" runat="server" />
                        <asp:Button Text="Baja" ID="btnBajaMedico" OnClick="btnBajaMedicoClick" CssClass="btn btn-danger" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
