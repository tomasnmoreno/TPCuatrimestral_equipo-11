<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Medicos.aspx.cs" Inherits="AppClinicaMedica.Medicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="titPpal">Médicos </h1>
    <% //<a href="NuevoMedico.aspx" class="btn my-boton" style="margin-left: 70px">Agregar Medico</a>%>

    <div class="row">
        <div class="col table-responsive">
            <asp:GridView runat="server" ID="dgvMedicos" OnSelectedIndexChanged="dgvMedicos_SelectedIndexChanged" CssClass="table table-info table-bordered table-sm">
                <Columns>
                    <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Acción" ControlStyle-CssClass="btn btn-sm btn-primary" />
                </Columns>
            </asp:GridView>
            <asp:TextBox ID="txtId" CssClass="d-none" runat="server" />
        </div>
        <div class="col">
            <asp:Button Text="Baja" ID="btnBajaMedico" OnClick="btnBajaMedico_Click" CssClass="btn btn-danger" runat="server" />
        </div>



    </div>
</asp:Content>
