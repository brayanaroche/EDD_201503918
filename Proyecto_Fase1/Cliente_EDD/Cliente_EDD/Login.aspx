<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Cliente_EDD.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
        Usuario:
    </div>
    <div>
        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
    </div>
    <div>
        Password:
    </div>        
    <div>
        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
    </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" />
    </form>
</body>
</html>
