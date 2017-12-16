#ifndef NODOCOLADOBLE
#define NODOCOLADOBLE
#include <QString>

struct NodoColaDoble
{
    QString tipoAvion;
    int pasajerosAvion;
    int desabordajeAvion;
    int mantenimientoAvion;
    int identificador;
    NodoColaDoble *siguiente;
    NodoColaDoble *anterior;
};

#endif // NODOCOLADOBLE

