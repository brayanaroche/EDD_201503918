#ifndef COLASIMPLEPASAJEROS
#define COLASIMPLEPASAJEROS
#include "nodocolasimple.h"
#include <QDebug>

struct ColaEscriorio
{
    int tam_variable;
    int tam_fijo;
    NodoColaSimple *ini;
    NodoColaSimple *fin;

    void inicializarColaEscri()
    {
        tam_fijo = 0;
        tam_variable = 0;
        ini = NULL;
        fin = NULL;
    }

    int QueueColaEscritorio(int id, int maletas, int documentos, int turnos)
    {
        NodoColaSimple *nuevoNodo = NULL;
        nuevoNodo = new NodoColaSimple();
        NodoColaSimple *nodoAux;
        nodoAux = new NodoColaSimple();
        nuevoNodo->identificador = id;
        nuevoNodo->maletas = maletas;
        nuevoNodo->documentos = documentos;
        nuevoNodo->turnos = turnos;

        tam_fijo = 10;

        if(ini == NULL)
        {
            nuevoNodo->siguiente = ini;
            ini = nuevoNodo;
            fin = nuevoNodo;
            tam_variable++;
        }
        else if(tam_variable<=tam_fijo)
        {
            nodoAux = fin;
            nodoAux->siguiente = nuevoNodo;
            nuevoNodo->siguiente = NULL;
            fin = nuevoNodo;
            tam_variable++;
        }
        else
        {
            qDebug()<<"Lista LLena";
            return -1;
        }
        return 0;
    }

    void mostrarColaEscritorio()
    {
        NodoColaSimple *nodoActual;
        nodoActual = ini;
        while(nodoActual != NULL)
        {
            //printf("Persona: %d",nodoActual->identificador,"%s \n");
            qDebug() << "Persona: " << nodoActual->identificador << "\n";
            nodoActual = nodoActual->siguiente;
        }
    }

};

#endif // COLASIMPLEPASAJEROS

