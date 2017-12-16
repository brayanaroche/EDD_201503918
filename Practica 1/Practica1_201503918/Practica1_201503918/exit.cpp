#include "exit.h"
#include "ui_exit.h"

Exit::Exit(QWidget *parent) :
    QWidget(parent),
    ui(new Ui::Exit)
{
    ui->setupUi(this);
}

Exit::~Exit()
{
    delete ui;
}

void Exit::on_pushButton_clicked()
{
    this->close();
}

void Exit::on_pushButton_2_clicked()
{
    MainWindow *nuevaSimulacion = new MainWindow();
    nuevaSimulacion->show();
    this->close();
}
