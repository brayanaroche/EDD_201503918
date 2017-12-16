#ifndef NODOCOLAMANT
#define NODOCOLAMANT
#include <QString>

struct NodoColaMant
{
    int identificador;
    QString tipo;
    int turnos;
    NodoColaMant *siguiente;
};

#endif // NODOCOLAMANT

