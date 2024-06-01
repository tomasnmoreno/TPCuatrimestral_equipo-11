<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="AppClinicaMedica.Especialidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" style="padding 20px">
    <h1 class="titPpal">Especialidades</h1>
    <form action="/" method="post" runat="server">
        <div class="row" style="margin-left: 20px;">
            <div class="col-2 ">
                <asp:DropDownList runat="server" ID="ddlEspecialidades" cssclass="form-select">
                    
                </asp:DropDownList>
            </div>
        </div>
    </form>
</asp:Content>
