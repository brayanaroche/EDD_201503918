#ifndef SIMULADOR_H
#define SIMULADOR_H

#include <QWidget>
#include <QDebug>
#include <QString>
#include <QFile>
#include <QtGui>
#include <QTextStream>
#include "coladoble.h"
#include "colasimple.h"
#include "pila.h"
#include "listacirculardoble.h"
#include "colasimplepasajeros.h"
#include "nodocoladoble.h"
#include "exit.h"
#include "colamant.h"
#include "listasimple.h"
#include <QPixmap>
#include <QGraphicsScene>

namespace Ui {
class Simulador;
}

class Simulador : public QWidget
{
    Q_OBJECT

public:
    explicit Simulador(QWidget *parent = 0);
    ~Simulador();
    QString textEDD;
    int Turnos;
    int Estaciones;
    int Mantenimiento;
    int Aviones;
    ColaDoble *colad = new ColaDoble();
    ColaMant *colaMant = new ColaMant();
    ListaSimple *listasimple = new ListaSimple();
    ListaCircularDoble *listaCD = new ListaCircularDoble();
    ColaSimple *colasimple = new ColaSimple();
    int clickContador;
    int idPersonas;
    int id;
    int valor;

private slots:
    void on_pushButton_clicked();

    void graficarEDD();

    void mostrarGrafica();
    //void generarEstaciones(int dato);

private:
    Ui::Simulador *ui;
};

#endif // SIMULADOR_H
