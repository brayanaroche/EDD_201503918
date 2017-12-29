<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminUsuariosABB.aspx.cs" Inherits="Cliente_EDD.AdminUsuariosABB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Administrador - Proyecto 1</title>
    <link rel="stylesheet" type="text/css" href="css/normalize.css" />
    <link rel="stylesheet" type="text/css" href="css/demo.css" />
    <link rel="stylesheet" type="text/css" href="css/component.css" />
    <!-- Script --> 
    <script src="js/modernizr.custom.25376.js"></script>
</head>
<body>
    <div id="perspective" class="perspective effect-airbnb">
			<div class="container">
				<div class="wrapper">
					<!-- Top Navigation -->
					<div class="codrops-top clearfix">
                        <a class="codrops-icon codrops-icon-prev" id="showMenu" style="cursor: pointer"><span>Menu</span></a>                                            
					</div>
					<header class="codrops-header">
						<h1>Operaciones<span>Basicas Usuario </span></h1>	
					</header>
					<div class="main clearfix">
                        <form id="form1" class="main clearfix" runat="server">
						<div class="column">
							<p><label id="showMenu">Modificar.</label></p>
                            
                            <div>
                                
                                <label id="showMenu">
                                <asp:TextBox ID="txtNickname" runat="server"></asp:TextBox>
                                <br />
                                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                                <br />
                                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                <br />
                                <asp:TextBox ID="txtConectado" runat="server"></asp:TextBox>
                                <br />
                                <asp:Button ID="Button3" runat="server" Text="Modificar" />
                                </label>
                                
                                <br />
                                
                            </div>
                            
						</div>
						<div class="column">
                            <p><label id="showMenu">Eliminar.</label></p>
                            
                            <div>
                                
                                <label id="showMenu">
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                <br />
                                <asp:Button ID="Button1" runat="server" Text="Eliminar" />
                                </label>
                                
                                <br />
                                
                            </div>                            
						</div>
                        </form>
						<div class="related">
							<p>Naval Wars</p>							
						</div>
					</div><!-- /main -->
				</div><!-- wrapper -->
			</div><!-- /container -->
			<nav class="outer-nav bottom horizontal">
                <a href="AdminUsuariosABB.aspx" class="icon-image">Opciones Arbol BB</a>				
                <a href="CargarArchivo.aspx" class="icon-upload">Cargar Archivos Juegos</a>
                <a href="CargaArchivoTablero.aspx" class="icon-upload">Cargar Archivos Tablero</a>
                <a href="CargaArchivoJuegoActual.aspx" class="icon-upload">Cargar Archivos Juego Actual</a>
                <a href="CargaArchivoUsuarios.aspx" class="icon-upload">Cargar Archivos Usuarios</a>
                <a href="UsuarioArbol.aspx" class="icon-news">Reporte Arbol</a>			
                <a href="ReporteJugadores.aspx" class="icon-news">Reporte Jugadores</a>			
                <a href="Login.aspx" class="icon-lock">Salir</a>
			</nav>
		</div><!-- /perspective -->
		<script src="js/classie.js"></script>
		<script src="js/menu.js"></script>
</body>
</html>
