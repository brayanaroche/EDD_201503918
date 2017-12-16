#include <QFile>
#include <QtGui>
#include <QTextStream>
#include "simulador.h"
#include <cstdlib>
#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "listasimple.h"


MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::on_pushButton_clicked()
{


    Simulador *prueba = new Simulador();
    //int turnos;
    prueba->Turnos= ui->lineEdit->text().toInt();

    //int numeroA;
    prueba->Aviones = ui->lineEdit_2->text().toInt();

    //int escritorios;
    prueba->Estaciones = ui->lineEdit_3->text().toInt();

    //int mantenimiento;
    prueba->Mantenimiento = ui->lineEdit_4->text().toInt();

    for(int i=0;i<prueba->Mantenimiento;i++)
    {
        prueba->listasimple->insertarListaSimple(i,false,0,i);
    }

    prueba->id = 0;

    prueba->show();
   //nuevaconsola = new Simulador();
    //nuevaconsola->show();
    this->close();
}

//void MainWindow::generarEDD()
//{
//    QFile file("_Grafica.dot");
//    file.open(QFile::WriteOnly);
//    QTextStream salida(&file);

//    textEDD = "digraph G {\n node[shape=box,sides=5,peripheries=3, color=skyblue,style=\"filled\"];";
//    graphColaDoble();
//    textEDD += "\n}";
//    salida<<textEDD;
//    file.close();
//    textEDD = "";

//    QString argumento;
//    argumento = "dot -Tpng _Grafica.dot -o _Grafica.png";
//    QProcess *Proceso = new QProcess(this);
//    Proceso->start(argumento);
//}

//void MainWindow::graphColaDoble()
//{
//}
