using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ServidorWeb_EDD
{
    public class ArbolBB
    {
        public static NodoArbolBB raiz;
        public static NodoArbolBB raizGlobal;
        public int altura;
        public int hojas;
        public int ramas;
        public int nivel;

        public void inicializarArbolBB()
        {
            raiz = null;
            altura = 0;
            hojas = 0;
            ramas = 0;
            nivel = 0;
        }

        public void insertarABB(string nickName, string password, string email, bool conectado)//, ListaDobleJuego LDJuego)
        {
            //Creando el nuevo nodo
            NodoArbolBB nuevoNodo = null;
            nuevoNodo = new NodoArbolBB();
            nuevoNodo.nickName = nickName;
            nuevoNodo.password = password;
            nuevoNodo.email = email;
            nuevoNodo.conectado = conectado;
            //nuevoNodo.LDJuego = LDJuego;
            nuevoNodo.hijoDer = null;
            nuevoNodo.hijoIzq = null;

            if (raiz == null)
            {
                raiz = nuevoNodo;
            }
            else
            {
                insertarABB(raiz, nickName, password, email, conectado);//, LDJuego);
            }
        }

        /*Cantidad de hojas*/
        public int cantidadHojas()
        {
            return cantidadHojas(raiz);
        }

        private static int cantidadHojas(NodoArbolBB actualRaiz)
        {
            if (actualRaiz != null)
            {
                if ((actualRaiz.hijoIzq == null)&&(actualRaiz.hijoDer == null))
                {
                    return 1;
                }
                else
                {
                    return cantidadHojas(actualRaiz.hijoIzq) + cantidadHojas(actualRaiz.hijoDer);
                }
            }
            return 0;
        }
        private static void insertarABB(NodoArbolBB actualRaiz, string nickName, string password, string email, bool conectado)//, ListaDobleJuego LDJuego)
        {
            //Validar si el nuevo nada es mayor o menor para colocarlo en el arbol
            //Lado Izquierdo
            if (nickName.CompareTo(actualRaiz.nickName)<0)//(String.Compare(nickName,actualRaiz.nickName)==-1)
            {
                if (actualRaiz.hijoIzq == null)
                {
                    NodoArbolBB nuevoNodo = new NodoArbolBB();
                    nuevoNodo.nickName = nickName;
                    nuevoNodo.password = password;
                    nuevoNodo.email = email;
                    nuevoNodo.conectado = conectado;
                    //nuevoNodo.LDJuego = LDJuego;

                    actualRaiz.hijoIzq = nuevoNodo;
                }
                else
                {
                    insertarABB(actualRaiz.hijoIzq, nickName, password, email, conectado);//, LDJuego);
                }
            }
            else if(nickName.CompareTo(actualRaiz.nickName)>0)//(String.Compare(nickName,actualRaiz.nickName)==1)
            {
                //Lado derecho
                if (actualRaiz.hijoDer == null)
                {
                    NodoArbolBB nuevoNodo = new NodoArbolBB();
                    nuevoNodo.nickName = nickName;
                    nuevoNodo.password = password;
                    nuevoNodo.email = email;
                    nuevoNodo.conectado = conectado;
                    //nuevoNodo.LDJuego = LDJuego;

                    actualRaiz.hijoDer = nuevoNodo;
                }
                else
                {
                    insertarABB(actualRaiz.hijoDer, nickName, password, email, conectado);//, LDJuego);
                }
            }
            else
            {
                Console.WriteLine("Nodo Existente");
                Console.ReadLine();
            }
        }

        private string graph;
        public void generarGraficaABB()
        {
            graph = "";
            System.IO.StreamWriter f = new System.IO.StreamWriter("c:/Estructuras/ArbolBB.txt");
            f.Write("digraph arbolbb{ rankdir=TB;\nnode[shape = record,height = .1, color = blue]; ");

            if(raiz != null)
            {
                graph += InOrden(raiz);
            }
              
            f.Write(graph);
            f.Write("}");
            f.Close();
        }

        private string InOrden(NodoArbolBB actualRaiz)
        {
            
            if (actualRaiz != null)
            {
                graph += "\nnodo" + actualRaiz.nickName.ToString() + "[label=\" <f0> |<f1> " + actualRaiz.nickName.ToString() + " Email: " + actualRaiz.email + " |<f2>\"]; \n";
                if (actualRaiz.hijoIzq != null)
                {
                    InOrden(actualRaiz.hijoIzq);
                    graph += "\n\"nodo" + actualRaiz.nickName.ToString() + "\":f0 -> \"nodo" + actualRaiz.hijoIzq.nickName.ToString() + "\":f1;";
                }

                if(actualRaiz.hijoDer != null)
                {
                    InOrden(actualRaiz.hijoDer);
                    graph += "\n\"nodo" + actualRaiz.nickName.ToString() + "\":f2 -> \"nodo" + actualRaiz.hijoDer.nickName.ToString() + "\":f1;";
                }                
            }
            return graph;
        }

        public void GraficarArbolBB(string fileName, string path)
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
        
        //Nivel Maximo
        public int nivelMaximo()
        {
            if(raiz != null)//si la raiz es diferente de null quiere decir que hay valores para recorrer
            {
                return nivelMaximo(raiz);
            }
            return -1;
        }
        private int nivelMaximo(NodoArbolBB actualRaiz)
        {
            if(actualRaiz != null)
            {
                if((actualRaiz.hijoIzq != null) || (actualRaiz.hijoDer != null))//si la raiz tiene hijos llamada metodo recursivo
                {
                    int contIzq = nivelMaximo(actualRaiz.hijoIzq);
                    int contDer = nivelMaximo(actualRaiz.hijoDer);
                    return 1 + Math.Max(contIzq, contDer);
                }
            }
            return 0;
        }

        //Altura o profundidad del arbol
        public int alturaArbolBB()
        {
            if(raiz != null)
            {
                return alturaArbolBB(raiz);
            }
            return 0;
        }
        
        private int alturaArbolBB(NodoArbolBB actualRaiz)
        {
            if (actualRaiz != null)
            {
                if ((actualRaiz.hijoDer != null) || (actualRaiz.hijoIzq != null))
                {
                    int camIzq = alturaArbolBB(actualRaiz.hijoIzq);
                    int camDer = alturaArbolBB(actualRaiz.hijoDer);
                    if (camDer > camIzq)
                    {
                        return camDer + 1;
                    }
                    else
                    {
                        return camIzq + 1;
                    }
                }
                return 1;//retorna 1 cuando termina de buscar el mas a la izquierda y empieza a retorna el valor                
            }
            return 0;//retorna 0 si encuentra que la raiz del arbol en nula
        }

        //Contador para las ramas del arbol Binario 
        public int cantidadRamas()
        {
            int ramastotales = cantidadRamas(raiz) - cantidadHojas() - 1;
            return ramastotales;
        }

        private int contadorRamas;

        private int cantidadRamas(NodoArbolBB actualRaiz)
        {
            if (actualRaiz != null)
            {
                int ramasIzq = cantidadRamas(actualRaiz.hijoIzq);
                int ramasDer = cantidadRamas(actualRaiz.hijoDer);
                contadorRamas = ramasDer + ramasIzq + 1;
                return contadorRamas;
            }
            return 0;
        }
        
        //Eliminar nodo del Arbol Binario
        public void eliminarABB(ref NodoArbolBB actualRaiz, string nickName)
        {
            if (actualRaiz != null)
            {
                if (nickName.CompareTo(actualRaiz.nickName) < 0)
                {
                    eliminarABB(ref actualRaiz.hijoIzq, nickName);
                }
                else if(nickName.CompareTo(actualRaiz.nickName) > 0)
                {
                    eliminarABB(ref actualRaiz.hijoDer, nickName);
                }
                else
                {
                    NodoArbolBB nodoEliminar = actualRaiz;
                    if(nodoEliminar.hijoDer == null)
                    {
                        actualRaiz = nodoEliminar.hijoIzq;
                    }
                    else if(nodoEliminar.hijoIzq == null)
                    {
                        actualRaiz = nodoEliminar.hijoDer;
                    }
                    else
                    {
                        NodoArbolBB nodoAux = null;
                        NodoArbolBB Aux = actualRaiz.hijoIzq;
                        bool bandera = false;
                        while (Aux.hijoDer != null)
                        {
                            nodoAux = Aux;
                            Aux = nodoAux.hijoDer;
                            bandera = true;
                        }
                        //Reacomodando el arbol para que no se pierdan los apuntadores y las referencias.
                        actualRaiz.nickName = Aux.nickName;
                        actualRaiz.password = Aux.password;
                        actualRaiz.email = Aux.email;
                        actualRaiz.conectado = Aux.conectado;
                        actualRaiz.LDJuego = Aux.LDJuego;
                        nodoEliminar = Aux;
                        if (bandera == true)
                        {
                            nodoAux.hijoDer = Aux.hijoIzq;
                        }
                        else
                        {
                            actualRaiz.hijoIzq = Aux.hijoIzq;
                        }
                    }
                }
            }
        }

        //Arbol Espejo
        private NodoArbolBB arbolEspejo(NodoArbolBB actualRaiz)
        {
            NodoArbolBB temporal;
            if (actualRaiz != null)
            {

                temporal = actualRaiz.hijoIzq;
                graph1 += "\nnodo" + actualRaiz.nickName + "[label=\" <f0> |<f1> " + actualRaiz.nickName + " Email: " + actualRaiz.email + " |<f2>\"]; \n";
                if ((actualRaiz.hijoIzq != null && actualRaiz.hijoDer != null))
                {
                    actualRaiz.hijoIzq = arbolEspejo(actualRaiz.hijoDer);
                    graph1 += "\n\"nodo" + actualRaiz.nickName.ToString() + "\":f0 -> \"nodo" + actualRaiz.hijoIzq.nickName.ToString() + "\":f1;";
                    actualRaiz.hijoDer = arbolEspejo(temporal);
                    graph1 += "\n\"nodo" + actualRaiz.nickName.ToString() + "\":f2 -> \"nodo" + actualRaiz.hijoDer.nickName.ToString() + "\":f1;";
                }
                else
                {
                    //    //graph1 += "\n\"nodo" + actualRaiz.nickName + "\":f0 -> \"nodo" + actualRaiz.hijoDer.nickName + "\":f1;";
                    actualRaiz.hijoIzq = arbolEspejo(actualRaiz.hijoDer);
                    actualRaiz.hijoDer = arbolEspejo(temporal);
                }
            }
            return actualRaiz;
        }

        /*
         * Recorrer arbol buscar el usuario y password
         */
        public static string usuarioMetodo(string usuario)
        {
            return usuarioMetodo(raiz, usuario);
        }

        private static string usuarioMetodo(NodoArbolBB actualRaiz, string usuario)
        {
            if(actualRaiz != null)
            {
                if(usuario.CompareTo(actualRaiz.nickName) < 0) //(String.Compare(usuario, actualRaiz.nickName) == -1)
                {
                    /*
                     * Buscar en el subarbol Izquierdo
                     */
                    if (actualRaiz.hijoIzq == null)
                    {
                        Console.WriteLine("ERROR, No se encuentra el Nodo...");
                        Console.ReadLine();
                    }
                    else
                    {
                        usuarioMetodo(actualRaiz.hijoIzq, usuario);
                    }
                }
                else if (usuario.CompareTo(actualRaiz.nickName) > 0)
                {
                    /*
                    * Buscar en el subarbol Derecho
                    */
                    if (actualRaiz.hijoDer == null)
                    {
                        Console.WriteLine("ERROR, No se encuentra el Nodo...");
                        Console.ReadLine();
                    }
                    else
                    {
                        usuarioMetodo(actualRaiz.hijoDer, usuario);
                    }
                }
                else
                {
                    return usuario.ToString();
                }
            }
            return "no hay valores";
        }

        public static string passwordMetodo(string usuario, string password)
        {
            return passwordMetodo(raiz, usuario, password);
        }
        private static string passwordMetodo(NodoArbolBB actualRaiz, string usuario, string password)
        {
            if (actualRaiz != null)
            {
                if (usuario.CompareTo(actualRaiz.nickName) < 0) //(String.Compare(usuario, actualRaiz.nickName) == -1)
                {
                    /*
                     * Buscar en el subarbol Izquierdo
                     */
                    if (actualRaiz.hijoIzq == null)
                    {
                        Console.WriteLine("ERROR, No se encuentra el Nodo...");
                        Console.ReadLine();
                    }
                    else
                    {
                        usuarioMetodo(actualRaiz.hijoIzq, usuario);
                    }
                }
                else if (usuario.CompareTo(actualRaiz.nickName) > 0)
                {
                    /*
                    * Buscar en el subarbol Derecho
                    */
                    if (actualRaiz.hijoDer == null)
                    {
                        Console.WriteLine("ERROR, No se encuentra el Nodo...");
                        Console.ReadLine();
                    }
                    else
                    {
                        usuarioMetodo(actualRaiz.hijoDer, usuario);
                    }
                }
                else
                {
                    return password;
                }
            }
            return "no hay valores";
        }
        
        //Graficar Arbol Espejo
        string graph1;
        public void graficarArbolEspejo()
        {
            graph1 = "";
            System.IO.StreamWriter f = new System.IO.StreamWriter("c:/Estructuras/ArbolEspejo.txt");
            f.Write("digraph arbolespejo{ rankdir=TB;\nnode[shape = record,height = .1, color = blue]; ");

            if (raiz != null)
            {
                arbolEspejo(raiz);
            }

            f.Write(graph1);
            f.Write("}");
            f.Close();
        }
    }
}