using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBinarioBusqueda
{
    class ArbolBB
    {
        public NodoABB raiz;
        public void inicializarArbol()
        {
            raiz = null;
        }

        public void insertarArbol(string informacion)
        {
            NodoABB nuevoNodo = new NodoABB();
            nuevoNodo.informacion = informacion;
            nuevoNodo.hijoDer = raiz;
            nuevoNodo.hijoIzq = raiz;

            if (raiz == null)
            {
                raiz = nuevoNodo;
            }
            else
            {
                insertarArbol(raiz, informacion);
            }
        }

        private static void insertarArbol(NodoABB actualRaiz, string informacion)
        {
            if (String.Compare(informacion,actualRaiz.informacion)==-1)
            {
                if (actualRaiz.hijoIzq == null)
                {
                    NodoABB nuevoNodo = new NodoABB();
                    nuevoNodo.informacion = informacion;

                    actualRaiz.hijoIzq = nuevoNodo;
                }
                else
                {
                    insertarArbol(actualRaiz.hijoIzq, informacion);
                }
            }
            else if (String.Compare(informacion, actualRaiz.informacion) == 1)
            {
                //Lado derecho
                if (actualRaiz.hijoDer == null)
                {
                    NodoABB nuevoNodo = new NodoABB();
                    nuevoNodo.informacion = informacion;

                    actualRaiz.hijoDer = nuevoNodo;
                }
                else
                {
                    insertarArbol(actualRaiz.hijoDer, informacion);
                }
            }
            else
            {
                Console.WriteLine("El Dato ya existe no se podra insertar el valor");
                Console.ReadLine();
            }
        }

        public string retorno;
        public string retornoIn;
        public string retornoPost;
        public string PreOrden(NodoABB actualRaiz)
        {
            
            if(actualRaiz != null)
            {
                Console.Write("{0}, ", actualRaiz.informacion);
                retorno += actualRaiz.informacion + ", ";
                PreOrden(actualRaiz.hijoIzq);
                PreOrden(actualRaiz.hijoDer);
            }
            return retorno + "\n";
        }

        public string InOrden(NodoABB actualRaiz)
        {
            if (actualRaiz != null)
            {
                InOrden(actualRaiz.hijoIzq);
                Console.Write("{0}, ", actualRaiz.informacion);
                retornoIn += actualRaiz.informacion + ", ";
                InOrden(actualRaiz.hijoDer);
            }
            return retornoIn + "\n";
        }
        public string PostOrden(NodoABB actualRaiz)
        {
            if (actualRaiz != null)
            {
                PostOrden(actualRaiz.hijoIzq);
                PostOrden(actualRaiz.hijoDer);
                Console.Write("{0}, ", actualRaiz.informacion);
                retornoPost += actualRaiz.informacion + ", ";
                
            }
            return retornoPost + "\n";
        }

    }
}
