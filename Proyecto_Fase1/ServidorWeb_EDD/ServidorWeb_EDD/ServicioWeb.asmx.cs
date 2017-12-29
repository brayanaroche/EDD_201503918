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
        static MatrizDisperza nuevaMatriz = new MatrizDisperza();
        ConvertirImagen nuevaImagen = new ConvertirImagen();

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
        /*
         * Metodos para Graficar Arbol y Matriz
         */
        [WebMethod]
        public void GraficarArbolBB()
        {
            nuevoArbol.generarGraficaABB();
            nuevoArbol.GraficarArbolBB("ArbolBB.txt", "C:/Estructuras");
            nuevoArbol.graficarArbolEspejo();
            nuevoArbol.GraficarArbolBB("ArbolEspejo.txt", "C:/Estructuras");
        }

        [WebMethod]
        public string GraficaMatriz(int nivel)
        {
            nuevaMatriz.graficarMatriz(nivel);
            nuevaMatriz.GraficarMatriz("matrizNivel" + nivel.ToString() + ".txt", "C:/Estructuras");
            return "Grafica Generada";
        }

        /*
         * Datos del Arbol
         */

        [WebMethod]
        public String cantidadHojas()
        {            
            return "Cantidad Hojas: " + nuevoArbol.cantidadHojas().ToString() + ", Nivel: " + nuevoArbol.nivelMaximo().ToString() + ", Altura: " + nuevoArbol.alturaArbolBB().ToString() + ", Ramas: " + nuevoArbol.cantidadRamas().ToString();
        }

        /*
         * Insertar Matriz y Arbol
         */
        [WebMethod]
        public void insertarMatriz(string unidad, int vida, int x, int y, int nivel , int alcance, int hurt)
        {
            //MatrizDisperza nuevaMatriz = new MatrizDisperza();
            nuevaMatriz.insertarMatriz(unidad, vida, x, y, nivel, alcance, hurt);
        }

        [WebMethod]
        public void AgregarArbol(string usuario, string password, string email, bool conetado)
        {
            nuevoArbol.insertarABB(usuario, password, email, conetado);
        }

        /*
         * Login
         */
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
                return "Login.aspx";
            }
        }

        /*
         * Imagenes para Arbol BB, Espejo y Matriz Dispeza por niveles
         */
        [WebMethod]
        public byte[] imagenArbolBB()
        {            
            return nuevaImagen.convertirImagenBytes("C:/Estructuras/ArbolBB.jpg");
        }

        [WebMethod]
        public byte[] imagenMatriz(string nivel)
        {
            return nuevaImagen.convertirImagenBytes("C:/Estructuras/matrizNivel" + nivel.ToString() + ".jpg");
        }

        [WebMethod]
        public byte[] imagenArbolEspejo()
        {
            return nuevaImagen.convertirImagenBytes("C:/Estructuras/ArbolEspejo.jpg");
        }

        /*
         * Eliminar Arbol y Matriz
         */
        
        [WebMethod]
        public string EliminarUsuario(string nickName)
        {
            nuevoArbol.eliminarABB(ref ArbolBB.raiz, nickName);
            return "Usuario Eliminado";
        }

        [WebMethod]
        public string EliminarMatriz(string unidad, int x, int y, int z)
        {
            nuevaMatriz.eliminarMatriz(unidad, x, y, z);
            return "Unidad Eliminada";
        }
    }
}
