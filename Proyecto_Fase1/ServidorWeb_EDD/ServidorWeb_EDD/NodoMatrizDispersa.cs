using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorWeb_EDD
{
    public class NodoMatrizDispersa
    {
        NodoEncabezadoMatriz encabezado;

        //Objetos nodo matriz para todas las direccion
        public NodoMatrizDispersa arriba;
        public NodoMatrizDispersa abajo;
        public NodoMatrizDispersa atras;
        public NodoMatrizDispersa adelante;
        public NodoMatrizDispersa derecha;
        public NodoMatrizDispersa izquierda;

        public string unidad;
        public int vida;
        public int coor_x;
        public int coor_y;
        public int coor_z;
        public int alcance;
        public int hurt; //daño 

        //Constructor
        public NodoMatrizDispersa(string unidad, int vida, int x, int y, int z, int alcance, int hurt)
        {
            this.unidad = unidad;
            this.vida = vida;
            this.coor_x = x;
            this.coor_y = y;
            this.coor_z = z;
            this.alcance = alcance;
            this.hurt = hurt;

            arriba = null;
            abajo = null;
            adelante = null;
            izquierda = null;
            atras = null;
            derecha = null;
        }
    }
}