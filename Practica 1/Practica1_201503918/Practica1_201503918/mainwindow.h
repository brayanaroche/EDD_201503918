#ifndef MAINWINDOW_H
#define MAINWINDOW_H
#include "simulador.h"
#include <QMainWindow>
#include <QString>
#include "listasimple.h"

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();
    //Simulador *nuevaconsola;
    ListaSimple *lista;

private slots:
    void on_pushButton_clicked();

private:
    Ui::MainWindow *ui;
};

#endif // MAINWINDOW_H
