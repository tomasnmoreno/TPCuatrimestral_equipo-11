<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Recepcionistas.aspx.cs" Inherits="AppClinicaMedica.Recepcionistas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="titPpal">Recepcionistas</h1>
    <form action="/" method="post" runat="server">
        <div class="row">
            <div class="col table-responsive">
            <p>Aca va el DataGrid. Este es un test mostrando un usuario simple de la BD</p>
                <asp:GridView runat="server" CssClass="table table-info table-bordered table-sm" ID="dgvRecepcionistas">
                </asp:GridView>
            </div>
        </div>
    </form>
</asp:Content>
