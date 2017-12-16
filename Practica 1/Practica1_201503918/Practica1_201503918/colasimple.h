#ifndef COLASIMPLE
#define COLASIMPLE
#include "nodocolasimple.h"
#include <QDebug>

struct ColaSimple
{
    NodoColaSimple *ini;
    NodoColaSimple *fin;
    int tam;

    void inicializarColaSimple()
    {
        ini = NULL;
        fin = NULL;
        tam = 0;
    }

    int insertarColaSimple(int id, int maletas, int documentos, int turnos)
    {
        NodoColaSimple *nuevoNodo = NULL;
        NodoColaSimple *nodoAux;
        nuevoNodo = new NodoColaSimple();
        nodoAux = new NodoColaSimple();
        nuevoNodo->identificador = id;
        nuevoNodo->maletas = maletas;
        nuevoNodo->documentos = documentos;
        nuevoNodo->turnos = turnos;

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

    void mostrarColaSimple()
    {
        NodoColaSimple *nodoActual;
        nodoActual = ini;
        while(nodoActual != NULL)
        {
            //printf("Persona: %d",nodoActual->identificador,"%s \n");
            //qDebug() << "Persona: " << nodoActual->identificador << "\n";
            nodoActual = nodoActual->siguiente;
        }
    }

    int eliminarColaSimple()
    {
        if(tam==0)
        {
            return -1;
        }
        NodoColaSimple *nodoDelete;
        nodoDelete = ini;
        ini = ini->siguiente;
        if(tam==1)
        {
            fin == NULL;
        }
        free(nodoDelete);
        tam--;
        return 0;
    }
};

#endif // COLASIMPLE

