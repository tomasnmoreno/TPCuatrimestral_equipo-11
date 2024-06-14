<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="AppClinicaMedica.Especialidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" style="padding 20px">
    <style>
/*        .my-boton {
            background: linear-gradient(to bottom, #007bff, #0096ff);
            border: none;
            color: white;
            padding: 10px 20px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            transition-duration: 0.4s;
            cursor: pointer;
            border-radius: 12px;
        }

        .my-boton { 
            color: dodgerblue;
        }

            .my-boton:hover {
                color: white;
            }

        .mi-card {
            border-radius: 12px;
        }*/
    </style>
    <h1 class="titPpal">Especialidades</h1>
    <a href="NuevaEspecialidad.aspx" class="btn btn-light" style="margin-left: 70px">Agregar Especialidad</a>

    <div class="row" style="margin-left: 20px;">
        <asp:Repeater runat="server" ID="repetidor">
            <ItemTemplate>
                <div class="col-md-4 mb-4 d-flex align-items-stretch">
                    <div class="card mi-card" style="width: 100%;">
                        <div class="card-body">
                            <img src="<%#Eval("IMAGEN") %>" class="card-img-top" style="object-fit: cover; object-position: center; width: 100%; height: 200px;" alt="...">
                            <h2 class="card-title"><%#Eval("NOMBRE") %></h2>
                            <p class="card-text" style="font-family: 'Times New Roman', Times, serif; font-weight: 200;"><%#Eval("DESCRIPCION") %></p>
                            <asp:Button Text="Modificar" cssclass="btn btn-success" runat="server" CommandArgument='<%#Eval("IdEspecialidad") %>' CommandName="IdEspecialidad"/>
                            <asp:Button Text="Baja" ID="btnBajaEspecialidad" onclick="btnBajaEspecialidad_Click" cssclass="btn btn-danger" runat="server" CommandArgument='<%#Eval("IdEspecialidad") %>' CommandName="IdEspecialidad" />                          
                        </div>
                        <a href="Turnos.aspx" class="btn btn-primary">Más información</a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>

