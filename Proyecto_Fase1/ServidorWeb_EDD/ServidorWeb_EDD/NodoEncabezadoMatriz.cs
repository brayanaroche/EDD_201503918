using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorWeb_EDD
{
    public class NodoEncabezadoMatriz
    {
        public NodoEncabezadoMatriz siguiente;
        public NodoEncabezadoMatriz anterior;
        public NodoMatrizDispersa accesoMatriz;
        public int indice;

        //Constructor
        public NodoEncabezadoMatriz(int indice)
        {
            this.indice = indice;
            accesoMatriz = null;
            siguiente = null;
            anterior = null;
        }

        //Insertar en fila
        public void insertarFila(NodoMatrizDispersa nuevoNodo)
        {
            if (accesoMatriz != null)
            {
                if (accesoMatriz.coor_x > nuevoNodo.coor_x)//si esto es verdadero se inserta a la cabeza
                {
                    nuevoNodo.derecha = accesoMatriz;
                    accesoMatriz.izquierda = nuevoNodo;
                    accesoMatriz = nuevoNodo;
                }
                else
                {
                    NodoMatrizDispersa nodoAux = accesoMatriz;

                    while (nodoAux.derecha != null)
                    {
                        if (nodoAux.coor_x < nuevoNodo.coor_x)
                            nodoAux = nodoAux.derecha;
                        else
                            break;
                    }

                    if (nodoAux.coor_x > nuevoNodo.coor_x)
                    {
                        nuevoNodo.izquierda = nodoAux.izquierda;
                        nuevoNodo.derecha = nodoAux;
                        nodoAux.izquierda.derecha = nuevoNodo;
                        nodoAux.izquierda = nuevoNodo;
                    }
                    else if (nodoAux.coor_x < nuevoNodo.coor_x)//ahora el nodo nuevo es mayor por lo tanto se ingresa despues
                    {
                        nuevoNodo.derecha = nodoAux.derecha;
                        nuevoNodo.izquierda = nodoAux;
                        if (nodoAux.derecha != null)
                            nodoAux.derecha.izquierda = nuevoNodo;
                        nodoAux.derecha = nuevoNodo;
                    }
                    else//en cual otro caso ordenamos los nodos y el valor de retorno es igual al valor auxiliar
                    {
                        nodoAux = ordenarNodos(nodoAux, nuevoNodo);
                        if (nodoAux.izquierda == null)
                            accesoMatriz = nodoAux;
                    }
                }
            }
            else
            {
                accesoMatriz = nuevoNodo;
            }
            
        }

        //Insertar en Columna
        public void insertarColumna(NodoMatrizDispersa nuevoNodo)
        {
            if(accesoMatriz != null)
            {
                if(accesoMatriz.coor_y > nuevoNodo.coor_y)//Insertando en la cabeza
                {
                    nuevoNodo.abajo = accesoMatriz;
                    accesoMatriz.arriba = nuevoNodo;
                    accesoMatriz = nuevoNodo;
                }
                else
                {
                    NodoMatrizDispersa nodoAux = accesoMatriz;
                    while(nodoAux.abajo != null)
                    {
                        if (nodoAux.coor_y < nuevoNodo.coor_y)
                            nodoAux = nodoAux.abajo;
                        else
                            break;
                    }

                    if (nodoAux.coor_y > nuevoNodo.coor_y)//Insertando antes
                    {
                        nuevoNodo.arriba = nodoAux.arriba;
                        nuevoNodo.abajo = nodoAux;
                        nodoAux.arriba.abajo = nuevoNodo;
                        nodoAux.arriba = nuevoNodo;
                    }
                    else//Insertando despues
                    {
                        nuevoNodo.abajo = nodoAux.abajo;
                        nuevoNodo.arriba = nodoAux;
                        if (nodoAux.abajo != null)
                            nodoAux.abajo.arriba = nuevoNodo;
                        nodoAux.abajo = nuevoNodo;
                    }
                }
            }
            else
            {
                accesoMatriz = nuevoNodo;
            }            
        }

        //Eliminar Fila
        public void eliminarFila(NodoMatrizDispersa nodoEliminar)
        {
            bool top = false;
            bool bottom = false;

            if (nodoEliminar.adelante != null)
                nodoEliminar.adelante.atras = nodoEliminar.atras;
            else
                top = true;

            if (nodoEliminar.atras != null)
                nodoEliminar.atras.adelante = nodoEliminar.adelante;
            else
                top = true;

            if(nodoEliminar.derecha != null)
            {
                if (!bottom)
                {
                    nodoEliminar.derecha.izquierda = nodoEliminar.atras;
                    nodoEliminar.atras.derecha = nodoEliminar.derecha;
                }
                else
                {
                    nodoEliminar.derecha.izquierda = nodoEliminar.izquierda;
                }
            }
            if(nodoEliminar.izquierda != null)
            {
                if (!bottom)
                {
                    nodoEliminar.izquierda.derecha = nodoEliminar.atras;
                    nodoEliminar.atras.izquierda = nodoEliminar.izquierda;
                }
                else
                {
                    nodoEliminar.izquierda.derecha = nodoEliminar.derecha;
                }
            }
            else
            {
                if(top && !bottom)
                {
                    accesoMatriz = nodoEliminar.atras;
                }
                else if (top)
                {
                    accesoMatriz = nodoEliminar.derecha;
                }
            }
        }

        //Eliminar Columna
        public void eliminarColumna(NodoMatrizDispersa nodoEliminar)
        {
            bool top = false;
            bool bottom = false;

            if (nodoEliminar.adelante == null)
                top = true;
            if (nodoEliminar.atras == null)
                bottom = true;

            if(nodoEliminar.abajo != null)
            {
                if (!bottom)
                {
                    nodoEliminar.abajo.arriba = nodoEliminar.atras;
                    nodoEliminar.atras.abajo = nodoEliminar.abajo;
                }
                else
                    nodoEliminar.abajo.arriba = nodoEliminar.arriba;
            }
            if(nodoEliminar.arriba != null)
            {
                if (!bottom)
                {
                    nodoEliminar.arriba.abajo = nodoEliminar.atras;
                    nodoEliminar.atras.arriba = nodoEliminar.arriba;
                }
                else
                    nodoEliminar.arriba.abajo = nodoEliminar.abajo;
            }
            else
            {
                if(top &&!bottom)
                {
                    accesoMatriz = nodoEliminar.atras;
                }
                else
                {
                    accesoMatriz = nodoEliminar.abajo;
                }
            }
        }

        //Buscar Nodo en la matriz por unidad
        public NodoMatrizDispersa buscarNodo(NodoMatrizDispersa nodoBusqueda, string unidad, int nivel)
        {
            NodoMatrizDispersa nodoAux = nodoBusqueda;
            NodoMatrizDispersa nodoTemporal;
            return nodoAux;
        }

        //Buscar Nodo en la matriz por columna y nivel
        public NodoMatrizDispersa buscarNodo(NodoMatrizDispersa nodoBusqueda, int columna, int nivel)
        {
            NodoMatrizDispersa nodoAux = nodoBusqueda;
            return nodoAux;
        }

        //Ordnacion de nodos
        private NodoMatrizDispersa ordenarNodos(NodoMatrizDispersa nodoActual, NodoMatrizDispersa nuevoNodo)
        {
            if(nodoActual.coor_z > nuevoNodo.coor_z)
            {
                nodoActual.adelante = nuevoNodo;
                nuevoNodo.atras = nodoActual;

                nuevoNodo.arriba = nodoActual.arriba;
                nuevoNodo.abajo = nodoActual.abajo;
                nuevoNodo.derecha = nodoActual.derecha;                
                nuevoNodo.izquierda = nodoActual.izquierda;

                if (nodoActual.arriba != null)
                    nodoActual.arriba.abajo = nuevoNodo;
                if (nodoActual.abajo != null)
                    nodoActual.abajo.arriba = nuevoNodo;
                if (nodoActual.izquierda != null)
                    nodoActual.izquierda.derecha = nuevoNodo;
                if (nodoActual.derecha != null)
                    nodoActual.derecha.izquierda = nuevoNodo;

                return nuevoNodo;
            }
            else
            {
                nuevoNodo.atras = nodoActual.atras;
                nuevoNodo.adelante = nodoActual;
                if (nodoActual.atras != null)
                    nodoActual.atras.adelante = nuevoNodo;

                return nodoActual;
            }
        }
    }
}