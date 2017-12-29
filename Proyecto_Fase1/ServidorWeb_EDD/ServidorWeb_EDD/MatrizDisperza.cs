using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ServidorWeb_EDD
{
    public class MatrizDisperza
    {
        //Instancia para el encabezado
        EncabezadoMatriz columna;
        EncabezadoMatriz fila;

        //constructor Matriz
        public MatrizDisperza()
        {
            columna = new EncabezadoMatriz();
            fila = new EncabezadoMatriz();
        }

        //Validar para que no vaya a ver una colicion
        NodoMatrizDispersa validarMovimiento(NodoMatrizDispersa nodoDestinio, string unidad, int x, int y, int z)
        {
            return nodoDestinio;
        }

        //Buscar nivel
        private NodoMatrizDispersa buscarNivel(NodoMatrizDispersa nodoBuscar, int nivel)
        {
            NodoMatrizDispersa nodoAux = nodoBuscar;
            while (nodoAux != null)
            {
                if (nodoAux.coor_z == nivel)
                    break;
                else
                    nodoAux = nodoAux.atras;
            }
            return nodoAux;
        }

        /*
         * Metodos publicos para insertar, mover, graficar la matriz         
         * 1. Insertar
         * 2. Mover
         * 3. Graficar
         * 4. Eliminar
         */
         
        //Insertar a la matriz
        public void insertarMatriz(string unidad, int vida, int x, int y, int nivel,int alcance, int hurt)
        {
            NodoEncabezadoMatriz col = columna.insertarEncabezado(x);
            NodoEncabezadoMatriz fil = fila.insertarEncabezado(y);

            //Se tiene que llamar al constructor del nodo Matriz para inicializar el nodo
            NodoMatrizDispersa nuevoNodo = new NodoMatrizDispersa(unidad,vida, x, y,nivel,alcance,hurt);

            //Insertamos en la fila y columna 
            fil.insertarFila(nuevoNodo);
            col.insertarFila(nuevoNodo);
        }

        /*
         * Eliminar
         */
        NodoMatrizDispersa nodoEliminar;
        public void eliminarMatriz(string unidad, int x, int y, int z)
        {
            nodoEliminar.unidad = unidad;
            nodoEliminar.coor_x = x;
            nodoEliminar.coor_y = y;
            nodoEliminar.coor_z = z;
            columna.eliminarColumna(nodoEliminar);
            fila.eliminarFila(nodoEliminar);
        }
        //Mover pieza
        public bool moverUnidad(string unidad, int vida, int x, int y, int alcance, int hurt)
        {
            return true;
        }

        /*
         * Graficar Matriz
         * Fila y columna
         */
        string graphMatriz;
        public void graficarMatriz(int nivel)
        {
            graphMatriz = "";
            System.IO.StreamWriter f = new System.IO.StreamWriter("c:/Estructuras/matrizNivel" + nivel.ToString() + ".txt");

            /*
             * Encabezado del archivo dot para la matriz
             */
            f.Write("digraph matriz\n{\tnode[shape=box, style=filled, color=lightsteelblue3];\n\tedge[color=black];\n\trankdir=UD;\n");

            /*
             * Ordenar grafica
             */
            enviarRank("matrizNivel" + nivel.ToString() + ".txt", nivel);
            /*
             * Columnas y Filas del metodo graficar
             */
            graficarColumna("matrizNivel" + nivel.ToString() + ".txt", nivel);
            graficarFila("matrizNivel" + nivel.ToString() + ".txt", nivel);
            

            /*
             * Enlazar los nodos de fila y columna
             */
            graficarEnlaceColumnaNodo("matrizNivel" + nivel.ToString() + ".txt", nivel);
            graficarEnlaceFilaNodo("matrizNivel" + nivel.ToString() + ".txt", nivel);
            graficarEnlaceColumna("matrizNivel" + nivel.ToString() + ".txt", nivel);
            graficarEnlaceFila("matrizNivel" + nivel.ToString() + ".txt", nivel);

            f.Write(graphMatriz);
            f.Write("\n}");
            f.Close();
        }

        public void linealizarFilaNiveles(int nivel)
        {

        }

        public void linealizarColumnaNiveles(int nivel)
        {

        }

        /*
         * Metodos privados para graficar
         */
        string fi;
        string col;
        string nodo;
        private void graficarEnlaceColumnaNodo(string titulo, int nivel)
        {
            NodoEncabezadoMatriz columnaGrafica = columna.ini;
            while(columnaGrafica!= null)
            {
                NodoMatrizDispersa nodoActualGrafica = columnaGrafica.accesoMatriz;
                col = "C" + columnaGrafica.indice.ToString();

                while (nodoActualGrafica != null)
                {
                    NodoMatrizDispersa nodoAux = buscarNivel(nodoActualGrafica, nivel);
                    //col = "C" + columnaGrafica.indice.ToString();//Identificador para columna
                    if(nodoAux != null)
                    {
                        nodo = "nd" + nodoAux.coor_y.ToString() + nodoAux.coor_x.ToString() + nodoAux.coor_z.ToString();//Identificador para nodo                        
                        graphMatriz += col + " -> " + nodo + ";\n\t";
                        graphMatriz += nodo + " -> " + col + ";\n\t";
                        break;
                    }
                    nodoActualGrafica = nodoActualGrafica.abajo;
                }
                columnaGrafica = columnaGrafica.siguiente;
            }
        }

        private void graficarEnlaceFilaNodo(string titulo, int nivel)
        {
            NodoEncabezadoMatriz filaGrafica = fila.ini;
            while (filaGrafica != null)
            {
                NodoMatrizDispersa nodoActualGrafica = filaGrafica.accesoMatriz;
                fi = "F" + filaGrafica.indice.ToString();

                while (nodoActualGrafica != null)
                {
                    NodoMatrizDispersa nodoAux = buscarNivel(nodoActualGrafica, nivel);
                    if (nodoAux != null)
                    {
                        nodo = "nd" + nodoAux.coor_y.ToString() + nodoAux.coor_x.ToString() + nodoAux.coor_z.ToString();//Identificador para nodo                        
                        graphMatriz += fi + " -> " + nodo + ";\n\t";
                        graphMatriz += nodo + " -> " + fi + ";\n\t";
                        break;
                    }
                    nodoActualGrafica = nodoActualGrafica.derecha;
                }
                filaGrafica = filaGrafica.siguiente;
            }
        }

        private void graficarEnlaceColumna(string titulo, int nivel)
        {
            NodoEncabezadoMatriz columnaGrafica = columna.ini;
            graphMatriz += "MATRIZ";

            while(columnaGrafica != null)
            {
                NodoMatrizDispersa nodoActual = columnaGrafica.accesoMatriz;
                col = "C" + columnaGrafica.indice.ToString();
                while (nodoActual != null)
                {
                    NodoMatrizDispersa nodoAux = buscarNivel(nodoActual, nivel);
                    if(nodoAux != null)
                    {
                        graphMatriz += " -> " + col;
                        //graphMatriz += "";
                        break;
                    }
                    nodoActual = nodoActual.abajo;
                }
                columnaGrafica = columnaGrafica.siguiente;
            }
            graphMatriz += ";\n\t";
        }

        private void graficarEnlaceFila(string titulo, int nivel)
        {
            NodoEncabezadoMatriz filaGrafica = fila.ini;
            graphMatriz += "MATRIZ";

            while (filaGrafica != null)
            {
                NodoMatrizDispersa nodoActual = filaGrafica.accesoMatriz;
                fi = "F" + filaGrafica.indice.ToString();
                while (nodoActual != null)
                {
                    NodoMatrizDispersa nodoAux = buscarNivel(nodoActual, nivel);
                    if (nodoAux != null)
                    {
                        graphMatriz += " -> " + fi;
                        break;
                    }
                    nodoActual = nodoActual.derecha;
                }
                filaGrafica = filaGrafica.siguiente;
            }
            graphMatriz += ";\n\t";
        }

        private void graficarColumna(string titulo, int nivel)
        {
            NodoEncabezadoMatriz columnaGraficar = columna.ini;

            while(columnaGraficar != null)
            {
                NodoMatrizDispersa nodoActual = columnaGraficar.accesoMatriz;
                while (nodoActual != null)
                {
                    NodoMatrizDispersa nodoAux = buscarNivel(nodoActual, nivel);
                    if(nodoAux != null)
                    {
                        nodo = "\tnd" + nodoAux.coor_y.ToString() + nodoAux.coor_x.ToString() + nodoAux.coor_z.ToString();
                        graphMatriz += nodo + ";\n\t" + nodo + "[label=\"" + "Unidad: " + nodoAux.unidad + "\nVida: " + nodoAux.vida.ToString() + "\nAlcance: " + nodoAux.alcance.ToString() + "\nDaño: " + nodoAux.hurt.ToString() + "\nNivel: " + nodoAux.coor_z.ToString() +  "\", color=gray75];\n\t";                        

                        if (buscarNivel(nodoActual.abajo, nivel) != null)
                        {
                            graphMatriz += nodo + " -> ";
                        }
                    }
                    nodoActual = nodoActual.abajo;
                }
                columnaGraficar = columnaGraficar.siguiente;
            }
        }

        private void graficarFila(string titulo, int nivel)
        {
            NodoEncabezadoMatriz filaGraficar = fila.ini;

            while (filaGraficar != null)
            {
                NodoMatrizDispersa nodoActual = filaGraficar.accesoMatriz;
                while (nodoActual != null)
                {
                    NodoMatrizDispersa nodoAux = buscarNivel(nodoActual, nivel);
                    if (nodoAux != null)
                    {
                        nodo = "nd" + nodoAux.coor_y.ToString() + nodoAux.coor_x.ToString() + nodoAux.coor_z.ToString();
                        graphMatriz += nodo + ";\n\t";

                        if (buscarNivel(nodoActual.derecha, nivel) != null)
                        {
                            graphMatriz += nodo + " ->";
                        }
                    }
                    nodoActual = nodoActual.derecha;
                }
                filaGraficar = filaGraficar.siguiente;
            }
        }

        private void enviarRank(string titulo, int nivel)
        {
            //Columnas

            NodoEncabezadoMatriz nodoEncabezadoAux = columna.ini;
            graphMatriz += "{ rank=min; MATRIZ; ";
            while (nodoEncabezadoAux != null)
            {
                NodoMatrizDispersa nodoActual = nodoEncabezadoAux.accesoMatriz;
                col = "C" + nodoEncabezadoAux.indice.ToString();
                
                while (nodoActual != null)
                {
                    NodoMatrizDispersa nodoAux = buscarNivel(nodoActual, nivel);
                    if (nodoAux != null)
                    {
                        graphMatriz += col + "; ";
                        break;
                    }
                    nodoActual = nodoActual.abajo;
                }
                nodoEncabezadoAux = nodoEncabezadoAux.siguiente;
            }
            graphMatriz += "};\n\t";

            //Filas
            nodoEncabezadoAux = fila.ini;
            while (nodoEncabezadoAux != null)
            {
                NodoMatrizDispersa nodoActual = nodoEncabezadoAux.accesoMatriz;
                bool esFila = false;
                fi = "F" + nodoEncabezadoAux.indice.ToString();
                graphMatriz += "{ rank=same; " + fi + "; ";
                fi = "";

                while(nodoActual != null)
                {
                    NodoMatrizDispersa nodoAux = buscarNivel(nodoActual, nivel);
                    if (nodoAux != null)
                    {
                        esFila = true;
                        nodo = "nd" + nodoAux.coor_y.ToString() + nodoAux.coor_x.ToString() + nodoAux.coor_z.ToString();
                        graphMatriz += nodo + "; ";
                    }
                    nodoActual = nodoActual.derecha;
                }
                if (esFila)
                {
                    graphMatriz += "};\n\t";
                    esFila = false;
                }
                nodoEncabezadoAux = nodoEncabezadoAux.siguiente;
            }

        }

        /*
         * Ejecutar el Archivo dot
         */
        public void GraficarMatriz(string fileName, string path)
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