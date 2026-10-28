<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ec.edu.monster.vista.LoginGr06" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Iniciar Sesion - Conversor</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="loginForm" runat="server" class="login-page">
        <div class="login-wrapper">

            <div class="login-image-panel">
                <img src='<%= ResolveUrl("~/Content/Images/monster.jpg") %>'
                     alt="Monster" />
            </div>

            <div class="login-form-panel">
                <div class="login-card">
                    <div class="login-title">CONVERSION DE<br />UNIDADES</div>

                    <div class="login-field">
                        <span class="field-label">Usuario</span>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="text-input" />
                    </div>

                    <div class="login-field">
                        <span class="field-label">Contrasena</span>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="text-input" TextMode="Password" />
                    </div>

                    <asp:Label ID="lblError" runat="server" CssClass="error-msg" />

                    <asp:Button ID="btnLogin" runat="server" CssClass="btn-ingresar"
                                Text="Ingresar" OnClick="btnLogin_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
