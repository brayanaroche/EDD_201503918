#ifndef LISTASIMPLE
#define LISTASIMPLE
#include "nodolistasimple.h"
#include <QDebug>

struct ListaSimple
{
    NodoListaSimple *ini;
    NodoListaSimple *fin;
    int tam;

    void inicializarListaSimple()
    {
        ini = NULL;
        fin = NULL;
        tam = 0;
    }

    int insertarListaSimple(int id, bool estado, int turnos,int lugar)
    {
        NodoListaSimple *nuevoNodo = NULL;
        NodoListaSimple *nodoAux;
        nuevoNodo = new NodoListaSimple();
        nodoAux = new NodoListaSimple();
        nuevoNodo->identificador = id;
        nuevoNodo->estado = estado;
        nuevoNodo->turnos = turnos;
        nuevoNodo->lugares = lugar;

        if(ini == NULL)
        {
            nuevoNodo->siguiente = ini;
            ini = nuevoNodo;
            fin = nuevoNodo;
            tam++;
        }
        else
        {
            nodoAux = fin;
            nodoAux->siguiente = nuevoNodo;
            nuevoNodo->siguiente = NULL;
            fin = nuevoNodo;
            tam++;
        }
        return 0;
    }

    void modificarListaSimple(int id, bool estado, int turnos)
    {
        NodoListaSimple *nuevoNodo;
        NodoListaSimple *nodoAux;
        nuevoNodo = new NodoListaSimple();
        nuevoNodo->identificador = id;
        nuevoNodo->estado = estado;
        nuevoNodo->turnos = turnos;

        nodoAux = ini;
        while(nodoAux->estado!=false)
        {
            nodoAux = nodoAux->siguiente;
        }
        nodoAux->estado = nuevoNodo->estado;
        nodoAux->identificador = nuevoNodo->identificador;
        nodoAux->turnos = nuevoNodo->turnos;
    }

    bool turnosFaltantes()
    {
        if(ini->turnos>0)
        {
            for(int i = 0; i<tam; ++i)
            {
                ini->turnos--;
                ini = ini->siguiente;
            }
            return true;
        }
        else
        {
            modificarListaSimple(0,false,0);
            return false;
        }
        //while(nodoActual->turnos)
    }

    bool recorrido()
    {
        NodoListaSimple *nodoActual;
        nodoActual = ini;
        while(nodoActual->estado != false)
        {
            nodoActual = nodoActual->siguiente;
            //return false;
        }
        return true;
    }

    void recorridoListaSimple()
    {
        NodoListaSimple *nodoActual;
        nodoActual = ini;
        while(nodoActual!= NULL)
        {
            //printf("Persona: %d",nodoActual->identificador,"%s \n");
            //qDebug() << "Persona: " << nodoActual->identificador << "\n";
            qDebug() << "Avion en lista s->"<<nodoActual->identificador << "Estado: "<<nodoActual->estado;
            nodoActual = nodoActual->siguiente;
        }
        //return true;
    }

};
#endif // LISTASIMPLE

