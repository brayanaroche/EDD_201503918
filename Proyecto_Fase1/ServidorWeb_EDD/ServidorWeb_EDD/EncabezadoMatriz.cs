using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorWeb_EDD
{
    public class EncabezadoMatriz
    {
        public NodoEncabezadoMatriz ini;
        public NodoEncabezadoMatriz fin;
        int tam;
        
        //constructor
        public EncabezadoMatriz()
        {
            ini = null;
            fin = null;
            tam = 0;
        }

        public NodoEncabezadoMatriz insertarEncabezado(int indice)
        {
            if (ini != null)
            {
                /*
                 * si es mayor se inserta a la cabeza el nuevo indice
                 */
                if (ini.indice > indice)
                {
                    NodoEncabezadoMatriz nodoTem = ini;
                    ini = new NodoEncabezadoMatriz(indice);
                    ini.siguiente = nodoTem;
                    nodoTem.anterior = ini;

                    return ini;
                }
                else if (fin.indice < indice)
                {
                    fin.siguiente = new NodoEncabezadoMatriz(indice);
                    fin = fin.siguiente;

                    return fin;
                }
                else
                {
                    NodoEncabezadoMatriz nodoActual = ini;
                    while (nodoActual != fin)
                    {
                        if (nodoActual.indice < indice)
                            nodoActual = nodoActual.siguiente;
                        else
                            break;
                    }

                    if (nodoActual.indice > indice)
                    {
                        NodoEncabezadoMatriz nuevoNodo = new NodoEncabezadoMatriz(indice);
                        nuevoNodo.anterior = nodoActual.anterior;
                        nuevoNodo.siguiente = nodoActual;
                        nodoActual.anterior.siguiente = nuevoNodo;
                        nodoActual.anterior = nuevoNodo;

                        return nuevoNodo;
                    }
                    else
                        return nodoActual;
                }
            }
            else
            {
                ini = new NodoEncabezadoMatriz(indice);
                fin = ini;
                return ini;
            }
        }

        //Eliminacion por fila
        public void eliminarFila(NodoMatrizDispersa nodoEliminar)
        {
            NodoEncabezadoMatriz filaEliminar = ini;

            while (filaEliminar != null)
            {
                if (filaEliminar.indice < nodoEliminar.coor_y)
                    filaEliminar = filaEliminar.siguiente;
                else
                    break;
            }

            filaEliminar.eliminarFila(nodoEliminar);
        }

        //eliminacion por columna
        public void eliminarColumna(NodoMatrizDispersa nodoEliminar)
        {
            NodoEncabezadoMatriz columnaEliminar = ini;

            while(columnaEliminar != null)
            {
                if (columnaEliminar.indice < nodoEliminar.coor_x)
                    columnaEliminar = columnaEliminar.siguiente;
                else
                    break;
            }

            columnaEliminar.eliminarColumna(nodoEliminar);
        }

        //Buscar Nodo en la matriz por unidad
        public NodoMatrizDispersa buscarNodo(string unidad, int nivel)
        {
            NodoEncabezadoMatriz filaAux = ini;
            NodoMatrizDispersa nodoAux = null;

            while (filaAux != null)
            {
                nodoAux = filaAux.buscarNodo(filaAux.accesoMatriz, unidad, nivel);
                if(nodoAux == null)
                {
                    filaAux = filaAux.siguiente;
                }
                else
                {
                    break;
                }
            }
            return nodoAux;
        }

        //Buscar Nodo en la matriz por columna y nivel
        public NodoMatrizDispersa buscarNodo(int fila, int columna, int nivel)
        {
            NodoEncabezadoMatriz filaAux = ini;
            NodoMatrizDispersa nodoAux = null;

            while (filaAux != null)
            {
                if(filaAux.indice < fila)
                {
                    filaAux = filaAux.siguiente;
                }
                else
                {
                    break;
                }
            }
            if (filaAux != null && filaAux.indice == fila)
                nodoAux = filaAux.buscarNodo(filaAux.accesoMatriz, columna, nivel);

            return nodoAux;
        }
    }
}