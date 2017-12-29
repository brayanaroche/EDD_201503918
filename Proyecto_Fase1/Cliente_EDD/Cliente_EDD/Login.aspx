<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Cliente_EDD.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href='https://fonts.googleapis.com/css?family=Source+Sans+Pro:400,700' rel='stylesheet' type='text/css'/>
    <link rel="stylesheet" href="css/reset.css"/>
    <link rel="stylesheet" href="css/styleNav.css"/>
    <link rel="stylesheet" href="css/style.css"/>
    <script src="js/modernizr.js"></script>
</head>
<body>
    <main class="cd-main-content">
        <div class="login-wrap">
                <div class="login-html">
                        <input id="tab-1" type="radio" name="tab" class="sign-in" checked /><label for="tab-1" class="tab">Login</label>
                        <input id="tab-2" type="radio" name="tab" class="sign-up" /><label for="tab-2" class="tab">Datos</label>
                        <div class="login-form">
                                <div class="sign-in-htm">
                                    <form id="form2" runat="server">
                                    <div class="group">    
                                        <label for="user" class="label">Usuario</label>
                                        <asp:TextBox ID="txtUsuario" class="input" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="group">
                                        <label for="user" class="label">Password</label>
                                        <asp:TextBox ID="txtPassword" class="input" runat="server"></asp:TextBox>
                                    </div>
                                        <asp:Button ID="btnLogin" CssClass="button" runat="server" OnClick="Button1_Click" Text="Login" />
                                    </form>
                                </div>
                                <div class="sign-up-htm">
                                        <div class="group">
                                                <label for="user" class="label">Nombre: Brayan Mauricio Aroche Boror</label>
                                        </div>
                                        <div class="group">
                                                <label for="pass" class="label">Carne: 201503918</label>
                                        </div>
                                        <div class="group">
                                                <label for="pass" class="label">Estructuras de Datos - 2017</label>
                                        </div>
                                        <div class="group">
                                                <label for="pass" class="label">Proyecto 1- Naval Wars</label>
                                        </div>
                                        <div class="group">
                                            <label for="user" class="label">Sección: A</label>
                                        </div>
                                </div>
                        </div>
                </div>
            </div>
    </main>
</body>
</html>
