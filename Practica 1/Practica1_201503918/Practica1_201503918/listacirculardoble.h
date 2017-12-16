#ifndef LISTACIRCULARDOBLE
#define LISTACIRCULARDOBLE
#include "nodolistacirculardoble.h"
#include <QDebug>

struct ListaCircularDoble
{
    NodoListaCircularDoble *ini;
    NodoListaCircularDoble *fin;
    int tam;

    void inicializarListaCircularDoble()
    {
        ini = NULL;
        fin = NULL;
        tam = 0;
    }

    int insertarListaCircularDoble(int maletas)
    {
        NodoListaCircularDoble *nuevoNodo = NULL;
        nuevoNodo = new NodoListaCircularDoble();
        nuevoNodo->maletas = maletas;
        if(ini == NULL)
        {
            nuevoNodo->anterior = nuevoNodo;
            nuevoNodo->siguiente = nuevoNodo;
            ini = nuevoNodo;
            fin = nuevoNodo;
            tam++;
        }
        else
        {
            nuevoNodo->siguiente = ini;
            ini->anterior = nuevoNodo;
            nuevoNodo->anterior = fin;
            fin->siguiente = nuevoNodo;
            fin = nuevoNodo;
            tam++;
        }
    }

    void mostrarListaCircularDoble()
    {
        NodoListaCircularDoble *nodoActual;
        nodoActual = ini;
        int i;
        for(i=0;i<tam;++i){
            //printf ("%p - %s\n", actual, actual->dato);
            qDebug()<<nodoActual->maletas;
            nodoActual = nodoActual->siguiente;
        }
    }

    int eliminarListaCircularDoble(int pos)
    {
        NodoListaCircularDoble *nodoDelete;
        if(tam == 0)
            return -1;
        if(pos==1)
        {
            nodoDelete = ini;
            ini = ini->siguiente;
            fin->siguiente = ini;
            ini->anterior = fin;
            tam--;
            free(nodoDelete);
        }
        return 0;
    }
};

#endif // LISTACIRCULARDOBLE

