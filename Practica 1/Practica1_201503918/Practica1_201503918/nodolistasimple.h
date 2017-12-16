#ifndef NODOLISTASIMPLE
#define NODOLISTASIMPLE

struct NodoListaSimple
{
    int identificador;
    bool estado;
    int turnos;
    int lugares;
    NodoListaSimple *siguiente;
};

#endif // NODOLISTASIMPLE

