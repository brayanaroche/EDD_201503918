#ifndef NODOLISTADOBLE
#define NODOLISTADOBLE
#include "pila.h"
#include "colasimplepasajeros.h"
struct NodoListaDoble
{
    char letra;
    ColaEscriorio *cola = new Cola();
    Pila *pila = new Pila();
    NodoListaDoble *siguiente;
    NodoListaDoble *anterior;
};

#endif // NODOLISTADOBLE

