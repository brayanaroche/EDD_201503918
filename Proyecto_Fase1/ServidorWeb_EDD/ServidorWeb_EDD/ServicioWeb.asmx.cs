using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServidorWeb_EDD
{
    /// <summary>
    /// Descripción breve de ServicioWeb
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ServicioWeb : System.Web.Services.WebService
    {
        static ArbolBB nuevoArbol = new ArbolBB();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public string MostrarLDJuego()
        {
            ListaDobleJuego listaJuego = new ListaDobleJuego();
            listaJuego.inicializarLDJuego();
            listaJuego.insertLDJuego("Brayan", 5, 3, 2, true);
            listaJuego.insertLDJuego("Carlos", 5, 3, 2, true);
            listaJuego.insertLDJuego("Eddy", 5, 3, 2, true);
            listaJuego.generarGraficaLDJuego();
            listaJuego.GraficarListaDoble("ListaDoble.txt", "C:/Estructuras");
            return listaJuego.mostrarValores();
        }

        [WebMethod]
        public void AgregarArbol(string usuario, string password, string email, bool conetado)
        {
            
            nuevoArbol.insertarABB(usuario, password, email, conetado);
            nuevoArbol.generarGraficaABB();
            
            nuevoArbol.GraficarArbolBB("ArbolBB.txt","C:/Estructuras");
            
        }

        [WebMethod]
        public String cantidadHojas()
        {
            nuevoArbol.graficarArbolEspejo();
            nuevoArbol.GraficarArbolBB("ArbolEspejo.txt", "C:/Estructuras");
            return "Cantidad Hojas: " + nuevoArbol.cantidadHojas().ToString() + ", Nivel: " + nuevoArbol.nivelMaximo().ToString() + ", Altura: " + nuevoArbol.alturaArbolBB().ToString() + ", Ramas: " + nuevoArbol.cantidadRamas().ToString();
        }

        [WebMethod]
        public void insertarMatriz()
        {
            MatrizDisperza nuevaMatriz = new MatrizDisperza();
            nuevaMatriz.insertarMatriz("Submarino1", 10, 5, 2, 0, 4, 4);
            nuevaMatriz.insertarMatriz("Barco1", 10, 8, 4, 1, 4, 4);
            nuevaMatriz.insertarMatriz("Satelite1", 10, 3, 9, 3, 4, 4);
        }

        [WebMethod]
        public string buscarUsuario(string usuario, string password)
        {
            if (usuario == "Admin" && password == "Password")
            {
                return "Admin.aspx";
            }
            else if ((usuario == ArbolBB.usuarioMetodo(usuario)) && password == ArbolBB.passwordMetodo(usuario, password))
            {
                return "Cliente.aspx";
            }
            else
            {
                return "No hay valores";
            }
            //return "";
        }
    }
}
