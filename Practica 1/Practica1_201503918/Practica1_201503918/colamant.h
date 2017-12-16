#ifndef COLAMANT
#define COLAMANT
#include "nodocolamant.h"

struct ColaMant
{
    NodoColaMant * ini;
    NodoColaMant * fin;
    int tam;

    void inicializarColaMant()
    {
        ini = NULL;
        fin = NULL;
        tam = 0;
    }

    int insertarColaMant(int id, QString tipo, int turnos)
    {
        NodoColaMant * nuevoNodo = NULL;
        NodoColaMant *nodoAux;
        nuevoNodo = new NodoColaMant();
        nuevoNodo = new NodoColaMant();

        nuevoNodo->identificador = id;
        nuevoNodo->tipo = tipo;
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

    int eliminarColaMant()
    {
        if(tam==0)
        {
            return -1;
        }
        NodoColaMant *nodoDelete;
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
#endif // COLAMANT

