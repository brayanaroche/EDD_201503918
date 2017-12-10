#include <cstdlib>
#include <iostream>
#include <stdio.h>
#include <stdlib.h>

using namespace std;

struct NodoDoble
{
    int dato;
    NodoDoble *siguiente;
    NodoDoble *anterior;
};

struct ListaDoble
{
    NodoDoble *ini;
    NodoDoble *fin;
    int tam;
};
//Metodos y funciones

void inicializar(ListaDoble* lista);
int insertListaDFinal(ListaDoble *lista,int dato);
void viewListaD(ListaDoble * lista);
int deleteNodo(ListaDoble *lista,int pos);

int main()
{
    ListaDoble *lista;
    lista = (ListaDoble*)malloc(sizeof(ListaDoble));
    inicializar(lista);

    cout << "Hello world!" << endl;
    insertListaDFinal(lista,1);
    insertListaDFinal(lista,2);
    insertListaDFinal(lista,100);
    insertListaDFinal(lista,600);
    insertListaDFinal(lista,70);
    viewListaD(lista);
    deleteNodo(lista,3);
    viewListaD(lista);
    deleteNodo(lista,4);
    viewListaD(lista);
    return 0;

}


void inicializar(ListaDoble * lista){
    lista->ini = NULL;
    lista->fin = NULL;
    lista->tam = 0;
}

int insertListaDFinal(ListaDoble *lista,int dato)
{
    NodoDoble *nuevoNodo = NULL;
    nuevoNodo = (NodoDoble*)malloc(sizeof(NodoDoble));
    nuevoNodo->dato = dato;
    if(lista->ini == NULL)
    {
        nuevoNodo->siguiente = lista->fin;
        nuevoNodo->anterior = lista->ini;
        lista->ini = nuevoNodo;
        lista->fin = nuevoNodo;
        lista->tam++;
    }
    else
    {
        nuevoNodo->siguiente = NULL;
        nuevoNodo->anterior = lista->fin;
        lista->fin->siguiente = nuevoNodo;
        lista->fin = nuevoNodo;
        lista->tam++;
    }
    return 0;
}

void viewListaD(ListaDoble *lista)
{
    NodoDoble *nodoActual;
    nodoActual = lista->ini;
    printf("<><><><><><><>Los Valores Son:<><><><><><><><><>\n");
    while(nodoActual->siguiente!=NULL)
    {
        cout << nodoActual->dato << "\n" << endl;
        nodoActual = nodoActual->siguiente;
    }
    cout << nodoActual->dato << "\n" << endl;
    printf("<><><><><><><><><><><><><><><><><><><><><><><><>\n");
}

int deleteNodo(ListaDoble *lista, int pos)
{
    NodoDoble *nodoDelete,*nodoAux;
    if(lista->tam==0)
    {
        cout<<"esta lista no contiene elementos"<<"\n"<<endl;
        return -1;
    }
    else if(pos==1)
    {
        /*Eliminamos el primer nodo de la lista*/
        nodoDelete = lista->ini;
        lista->ini = lista->ini->siguiente;
        if(lista->ini == NULL)
            lista->fin = NULL;
        else
            lista->ini->anterior = NULL;
    }
    else if(pos == lista->tam)
    {
        /*eliminamos el ultimo nodo*/
        nodoDelete = lista->fin;
        lista->fin->anterior->siguiente = NULL;
        lista->fin = lista->fin->anterior;
    }
    else
    {
        /*
         * En cualquier otro caso
        */
        nodoAux = lista->ini;
        for(int i = 1; i<pos;++i)
        {
            nodoAux = nodoAux->siguiente;
        }
        nodoDelete = nodoAux;
        nodoAux->anterior->siguiente = nodoAux->siguiente;
        nodoAux->siguiente->anterior = nodoAux->anterior;
    }
    //free(nodoDelete->dato);
    free(nodoDelete);
    lista->tam--;
    return 0;
}
