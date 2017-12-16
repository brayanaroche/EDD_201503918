#ifndef LISTADOBLE
#define LISTADOBLE
#include "nodolistadoble.h"

struct ListaDoble
{
    NodoListaDoble *ini;
    NodoListaDoble *fin;
    int tam;

    void inicializarlistadoble()
    {
        ini = NULL;
        fin = NULL;
        tam = 0;
    }

    int insertarListaDoble()
    {

    }

    void ordenamiento(ListaDoble *lista, int izq, int der)
    {
        int i, j, x , aux;
        i = izq;
        j = der;
        x = lista[(izq + der)/2];
            do{
                while( (lista->tam < x) && (j <= der) )
                {
                    i++;
                }

                while( (x < lista->tam) && (j > izq) )
                {
                    j--;
                }

                if( i <= j )
                {
                    aux = lista->tam; lista->tam = lista->tam[j]; lista[j] = aux;
                    i++;  j--;
                }

            }while( i <= j );

            if( izq < j )
                ordenamiento(lista,izq,j);
            if( i < der )
                ordenamiento(lista,i,der);
    }
};

#endif // LISTADOBLE

