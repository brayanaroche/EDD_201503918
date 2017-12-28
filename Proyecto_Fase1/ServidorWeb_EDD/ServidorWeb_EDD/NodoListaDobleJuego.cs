using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorWeb_EDD
{
    public class NodoListaDobleJuego
    {
        public string nickName;
        public int unidadesDesplegadas;
        public int unidadesSobrevivientes;
        public int unidadesDestruidas;
        public bool ganador;
        public NodoListaDobleJuego siguiente;
        public NodoListaDobleJuego anterior;
    }
}