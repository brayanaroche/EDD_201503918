using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorWeb_EDD
{
    public class NodoArbolBB
    {
        public string nickName;
        public string password;
        public string email;
        public bool conectado;
        public ListaDobleJuego LDJuego = new ListaDobleJuego();
        //public IComparable nick;

        //apuntadores
        public NodoArbolBB hijoIzq;
        public NodoArbolBB hijoDer;
    }
}