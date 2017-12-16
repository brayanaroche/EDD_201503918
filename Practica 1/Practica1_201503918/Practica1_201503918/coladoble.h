#ifndef COLADOBLE_H
#define COLADOBLE_H
#include "nodocoladoble.h"
#include <QString>
#include <QDebug>
#include "mainwindow.h"
using namespace std;

struct ColaDoble
{
    NodoColaDoble *ini;
    NodoColaDoble *fin;
    int tam;
    QString retornar;

    void inicializarColaDoble()
    {
        ini = NULL;
        fin = NULL;
        tam = 0;
    }

    int insertarColaDoble(int id,QString tipoA, int pasajerosA, int desabordajeA,int mantenimientoA)
    {
        NodoColaDoble *nuevoNodo = NULL;
        nuevoNodo = new NodoColaDoble();
        int i;
        nuevoNodo->identificador = id;
        nuevoNodo->tipoAvion = tipoA;
        nuevoNodo->pasajerosAvion = pasajerosA;
        nuevoNodo->desabordajeAvion = desabordajeA;
        nuevoNodo->mantenimientoAvion = mantenimientoA;

        if(ini == NULL)
        {
            nuevoNodo->siguiente = fin;
            nuevoNodo->anterior = ini;
            ini = nuevoNodo;
            fin = nuevoNodo;
            tam++;
            i = i+1;
        }
        else
        {
            nuevoNodo->siguiente = NULL;
            nuevoNodo->anterior = fin;
            fin->siguiente = nuevoNodo;
            fin = nuevoNodo;
            tam++;
            i = i +1;
        }
        return 0;
    }

    void mostrarColaDoble()
    {
        NodoColaDoble *nodoActual;
        nodoActual = ini;
        while(nodoActual!=NULL)
        {
            nodoActual = nodoActual->siguiente;
        }
    }

    QString graficarNodoCD()
    {
        NodoColaDoble * nodoActual;
        nodoActual = ini;
        QString retornar;
        while(nodoActual!=NULL)
        {
            retornar = "\n\"Tipo Avion: "+nodoActual->tipoAvion;
            retornar += "\nCantidad Aviones: "+QString::number(nodoActual->pasajerosAvion);
            retornar += "\nDesabordaje: "+QString::number(nodoActual->desabordajeAvion);
            retornar += "\nMantenimiento: "+QString::number(nodoActual->mantenimientoAvion)+"\"";
            nodoActual = nodoActual->siguiente;
            return retornar;
            //qDebug()<<retornar;
        }

        //return retornar;

    }

    int eliminarColaDoble(int pos)
    {
        NodoColaDoble *nodoDelete,*nodoAux;
        int i;
        if(tam == 0)
        {
            qDebug() << "no hay elementos en la cola\n";
            return -1;
        }
        if(pos == 1)
        {
            nodoDelete = ini;
            ini = ini->siguiente;
            if(ini == NULL)
                fin = NULL;
            else
                ini->anterior == NULL;
            tam--;
        }
        else if(pos == tam)
        {
            /*eliminamos el ultimo nodo*/
            nodoDelete = fin;
            fin->anterior->siguiente = NULL;
            fin = fin->anterior;
            qDebug() << "Valores:"<<nodoDelete->tipoAvion;
            tam--;
        }
        else
        {
            nodoAux = ini;
            for(i=1;i<pos;++i)
            {
                nodoAux = nodoAux->siguiente;
            }
            nodoDelete = nodoAux;
            nodoAux->anterior->siguiente = nodoAux->siguiente;
            nodoAux->siguiente->anterior = nodoAux->anterior;
            qDebug() << "Valores:"<<nodoDelete->tipoAvion;
            tam--;
        }
        free(nodoDelete);
        return 0;
    }
};
#endif // COLADOBLE_H
