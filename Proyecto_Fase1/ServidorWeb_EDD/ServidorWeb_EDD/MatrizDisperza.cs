using System;
using System.Collections.Generic;
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
        private void buscarNivel(NodoMatrizDispersa nodoBuscar, int nivel)
        {

        }

        /*
         * Metodos publicos para insertar, mover, graficar la matriz         
         * 1. Insertar
         * 2. Mover
         * 3. Graficar
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
            System.IO.StreamWriter f = new System.IO.StreamWriter("c:/Estructuras/matrizNivel" + nivel.ToString() + ".txt");

            /*
             * Encabezado del archivo dot para la matriz
             */
            f.Write("diagraph matriz\n\tnode[shape=box, style=filled, color=lightsteelblue3];\n\tedge[color=black];\n\trankdir=UD;\n");

            /*
             * Columnas y Filas del metodo graficar
             */
            graficarFila("matrizNivel" + nivel.ToString() + ".txt", nivel);
            graficarColumna("matrizNivel" + nivel.ToString() + ".txt", nivel);

            /*
             * Enlazar los nodos de fila y columna
             */
            graficarEnlaceColumnaNodo("matrizNivel" + nivel.ToString() + ".txt", nivel);
            graficarEnlaceFilaNodo("matrizNivel" + nivel.ToString() + ".txt", nivel);
            graficarEnlaceColumna("matrizNivel" + nivel.ToString() + ".txt", nivel);
            graficarEnlaceFila("matrizNivel" + nivel.ToString() + ".txt", nivel);

            /*
             * Ordenar grafica
             */
            enviarRank("matrizNivel" + nivel.ToString() + ".txt", nivel);
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
        private void graficarEnlaceColumnaNodo(string titulo, int nivel)
        {
            NodoEncabezadoMatriz columnaGrafica = columna.ini;
            while(columnaGrafica!= null)
            {
                NodoMatrizDispersa nodoActualGrafica = columnaGrafica.accesoMatriz;
                while (nodoActualGrafica != null)
                {
                    
                }
            }
        }

        private void graficarEnlaceFilaNodo(string titulo, int nivel)
        {

        }

        private void graficarEnlaceColumna(string titulo, int nivel)
        {

        }

        private void graficarEnlaceFila(string titulo, int nivel)
        {

        }

        private void graficarColumna(string titulo, int nivel)
        {

        }

        private void graficarFila(string titulo, int nivel)
        {

        }

        private void enviarRank(string titulo, int nivel)
        {

        }
    }
}