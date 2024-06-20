<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="AppClinicaMedica.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Loguearse</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>

    <link href="css/styles.css" rel="stylesheet" />
    <link href="css/header.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="Home.aspx"><- Volver</a>
            <div class="containerLogIn" style="margin-top:400px">
                <div class="rowLogIn">
                    <div>
                    </div>

                    <div>
                        <asp:TextBox cssclass="paddingLogIn" style="width:400px; margin-bottom: 20px" ID="txtbUserName" placeholder="Usuario" runat="server" />
                    </div>
                    <div>
                        <asp:TextBox cssclass="paddingLogIn" type="password" style="width:400px; margin-bottom: 20px;" ID="txtbPassword" placeholder="Contraseña" runat="server" />
                    </div>
                    <div>
                        <asp:Button CssClass="button button-primary button-ingresar paddingLogIn" ID="btnIngresar" Text="Ingresar" runat="server" />
                    </div>
                    <div class="registrarseLogIn">
                        <a class="fuenteLogIn" href="NuevoPaciente.aspx">Si usted es Paciente: regístrese dando click aquí</a>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
