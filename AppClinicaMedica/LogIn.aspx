<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="AppClinicaMedica.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Loguearse</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>

    <link href="css/styles.css" rel="stylesheet" />
    <link href="css/header.css" rel="stylesheet" />
</head>
<body style="background-color: aliceblue">
    <form id="form1" runat="server">
        <div>
            <a class="btn btn-warning prueba" style="margin-top: 10px; margin-left: 10px" href="Home.aspx">Volver </a>
            <div class="containerLogIn" style="margin-top: 100px; margin-bottom: 1000px">
                <div class="rowLogIn">
                    <div>
                        <asp:TextBox CssClass="paddingLogIn" Style="width: 400px; margin-bottom: 40px; font-size: 25px; border-radius: 5px; text-indent: 5px;" ID="txtbUserName" placeholder="Usuario" runat="server" />
                    </div>
                    <div>
                        <asp:TextBox CssClass="paddingLogIn" type="password" Style="width: 400px; margin-bottom: 40px; font-size: 25px; border-radius: 5px; text-indent: 5px;" ID="txtbPassword" placeholder="Contraseña" runat="server" />
                    </div>
                    <div>
                        <asp:Button CssClass="button button-primary button-ingresar paddingLogIn" ID="btnIngresar" OnClick="btnIngresar_Click" Text="Ingresar" runat="server" />
                        <asp:Button CssClass="button button-primary button-ingresar paddingLogIn" ID="btnOlvideMiContraseña" OnClick="btnOlvideMiContraseña_Click" Text="Olvide mi contraseña" runat="server" />
                    </div>
                    <%if (Session["error"] != null)
                        {  %>
                    <div style="color: red; font-size: 25px; margin-top: 25px; margin-bottom: 25px;">
                        <asp:Label runat="server" ID="lblError"></asp:Label>
                    </div>
                    <% }  %>
                    <div class="registrarseLogIn">
                        <a class="fuenteLogIn" href="NuevoPaciente.aspx">Si usted es Paciente: regístrese dando click aquí</a>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
