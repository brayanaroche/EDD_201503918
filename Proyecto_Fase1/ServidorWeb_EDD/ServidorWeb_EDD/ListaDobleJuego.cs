using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ServidorWeb_EDD
{
    public class ListaDobleJuego
    {
        NodoListaDobleJuego ini;
        NodoListaDobleJuego fin;
        int tam;

        public void inicializarLDJuego()
        {
            ini = null;
            fin = null;
            tam = 0;
        }

        public int insertLDJuego(string nickName, int uniDesplegadas, int uniSobrevivientes, int uniDestruidas, bool ganador)
        {
            NodoListaDobleJuego nuevoNodo = null;
            nuevoNodo = new NodoListaDobleJuego();
            nuevoNodo.nickName = nickName;
            nuevoNodo.unidadesDesplegadas = uniDesplegadas;
            nuevoNodo.unidadesSobrevivientes = uniSobrevivientes;
            nuevoNodo.unidadesDesplegadas = uniDestruidas;
            nuevoNodo.ganador = ganador;

            if (ini == null)
            {
                nuevoNodo.siguiente = fin;
                nuevoNodo.anterior = ini;
                fin = nuevoNodo;
                ini = nuevoNodo;
                tam++;
            }
            else
            {
                nuevoNodo.siguiente = null;
                nuevoNodo.anterior = fin;
                fin.siguiente = nuevoNodo;
                fin = nuevoNodo;
                tam++;
            }
            return 0;
        }

        public string mostrarValores()
        {
            string valorRetorno = " ";

            NodoListaDobleJuego nodoAux;
            nodoAux = ini;

            while (nodoAux!=null)
            {
                valorRetorno += nodoAux.nickName + "\n";
                nodoAux = nodoAux.siguiente;
            }
            return valorRetorno;
        }
        string graph = "";
        public void generarGraficaLDJuego()
        {
            System.IO.StreamWriter f = new System.IO.StreamWriter("c:/Estructuras/ListaDoble.txt");
            f.Write("digraph lista{ rankdir=TB;node[shape = box, style = filled, color = white]; ");
            //imprimiendo todos los nodos
            NodoListaDobleJuego nodoAux;
            nodoAux = ini;
            if(nodoAux != null)
            {
                while (nodoAux != null)
                {
                    //graph += "\nnodo" + nodoAux.nickName + "[label=\"" + nodoAux.nickName.ToString().Replace("\"", "\\\"") + " \", fillcolor=\"LightBlue\", style =\"filled\", shape=\"box\"]; \n";
                    graph += "\nnodo" + nodoAux.nickName + "[label=\"" + nodoAux.nickName + "\nUnidades Desplegadas: " + nodoAux.unidadesDesplegadas.ToString().Replace("\"", "\\\"") + " \", fillcolor=\"LightBlue\", style =\"filled\", shape=\"box\"]; \n";
                    nodoAux = nodoAux.siguiente;
                }

                string actual = "";
                string sig = "";
                nodoAux = ini;
                while (nodoAux != null)
                {
                    if (nodoAux.siguiente != null)
                    {
                        actual = "nodo" + nodoAux.nickName;
                        sig = "nodo" + nodoAux.siguiente.nickName;
                        graph += actual + " -> " + sig + ";\n";
                        graph += sig + " -> " + actual + ";\n";
                    }
                    nodoAux = nodoAux.siguiente;
                }
            }
            f.Write(graph);
            f.Write("}");
            f.Close();
        }

        public void GraficarListaDoble(string fileName, string path)
        {
            try
            {
                var command = string.Format("dot.exe -Tjpg {0} -o {1}", Path.Combine(path, fileName), Path.Combine(path, fileName.Replace(".txt", ".jpg")));
                var procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/C " + command);
                var proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception x)
            {

            }
        }
    }
}