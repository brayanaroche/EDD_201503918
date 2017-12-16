#ifndef PILA
#define PILA
#include "nodopila.h"
#include <QDebug>

struct Pila
{
    int tam;
    NodoPila *ini;

    void inicialiizarPila()
    {
        tam = 0;
        ini = NULL;
    }

    int push(int documento)
    {
        NodoPila *nuevoNodo = NULL;
        nuevoNodo = new NodoPila();
        nuevoNodo->doccumento = documento;
        if(ini == NULL)
        {
            nuevoNodo->siguiente = ini;
            ini = nuevoNodo;
            tam++;
        }
        else
        {
            nuevoNodo->siguiente = ini;
            ini = nuevoNodo;
            tam++;
        }
    }

    void mostrarPila()
    {
        NodoPila *nodoAux;
        int i;
        nodoAux = ini;
        for(i=0;i<tam;++i)
        {
            //printf("%d",nodoAux->doccumento,"\n");
            qDebug()<<nodoAux->doccumento<<"\n";
            nodoAux = nodoAux->siguiente;
        }
    }

    int pop()
    {
        NodoPila *nodoDelete;
        if(tam==0)
            return -1;
        nodoDelete = ini;
        ini = ini->siguiente;
        free(nodoDelete);
        tam--;
        return 0;
    }
};
#endif // PILA

