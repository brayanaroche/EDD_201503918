#include "simulador.h"
#include "ui_simulador.h"
#include "nodocoladoble.h"

Simulador::Simulador(QWidget *parent) :
    QWidget(parent),
    ui(new Ui::Simulador)
{
    ui->setupUi(this);
    idPersonas = 0;
}

Simulador::~Simulador()
{
    delete ui;
    valor = Mantenimiento;
}

void Simulador::on_pushButton_clicked()
{
    //qDebug() << Turnos;
    //qDebug() << Aviones;
    //qDebug() << Estaciones;
    //qDebug() << Mantenimiento;
    //listasimple->recorridoListaSimple();

    Exit * salir = new Exit();

    if(Turnos>0)
    {
        if(Aviones > 0)
        {
            srand(time(NULL));
            int numero = rand()%3;
            if(numero == 0)
            {
                int pasajerosRandom = rand()%(11)+40;
                int mantRandoom = rand()%(4)+3;
                colad->insertarColaDoble(id,"Grande",pasajerosRandom,3,mantRandoom);
            }else if(numero == 1)
            {
                int pasajerosRandom = rand()%(11)+15;
                int mantRandoom = rand()%(3)+2;
                colad->insertarColaDoble(id,"Mediano",pasajerosRandom,2,mantRandoom);
            }else
            {
                int pasajerosRandom = rand()%(6)+5;
                int mantRandoom = rand()%(3)+1;
                colad->insertarColaDoble(id,"Pequeño",pasajerosRandom,1,mantRandoom);
            }
        }

        if(colad->ini->desabordajeAvion>0)
        {
            colad->ini->desabordajeAvion--;
        }
        else
        {
            idPersonas = colad->ini->pasajerosAvion;
            colaMant->insertarColaMant(colad->ini->identificador,colad->ini->tipoAvion,colad->ini->mantenimientoAvion);
            while(colad->ini->pasajerosAvion!=0)
            {
                srand(time(NULL));
                int numeroMaletas = rand()%(4)+1;
                int numeroDocumentos = rand()%(10)+1;
                int numeroRegistro = rand()%(3)+1;
                colasimple->insertarColaSimple(idPersonas,numeroMaletas,numeroDocumentos,numeroRegistro);

                //listaCD->insertarListaCircularDoble(colasimple->ini->maletas);
            }
            //listaCD->insertarListaCircularDoble(colad->ini->)
            colad->eliminarColaDoble(1);
        }


        /*
         * Lista simple para Mantenimiento
        */
        if(Mantenimiento>0)
        {
            if(colaMant->tam>0)
            {
                if(listasimple->recorrido() != false)
                {
                    //listasimple->modificarListaSimple(colaMant->ini->identificador,true,colaMant->ini->turnos);
                    //colaMant->eliminarColaMant();
                    //listasimple->turnosFaltantes();
                }
                else
                {
                    //listasimple->turnosFaltantes();
                    //listasimple->modificarListaSimple(0,false,0);
                }
            }
            else
            {
                listasimple->turnosFaltantes();
            }
        }
        id = id +1;
        Aviones = Aviones -1;
    }else
    {
        salir->show();
        this->close();
    }
    Turnos = Turnos-1;
    graficarEDD();
    mostrarGrafica();
}

void Simulador::graficarEDD()
{
    QFile file("_Grafica.dot");
    file.open(QFile::WriteOnly);
    QTextStream salida(&file);

    textEDD = "digraph G {\n";

    NodoColaDoble * nodoActual;
    nodoActual = colad->ini;
    if(nodoActual != NULL)
    {
        while(nodoActual!=NULL)
        {
            textEDD += "\n\"Identificador: " + QString::number(nodoActual->identificador);
            textEDD += "\nTipo Avion: "+nodoActual->tipoAvion;
            textEDD += "\nCantidad Pasajeros: "+QString::number(nodoActual->pasajerosAvion);
            textEDD += "\nDesabordaje: "+QString::number(nodoActual->desabordajeAvion);
            textEDD += "\nMantenimiento: "+QString::number(nodoActual->mantenimientoAvion)+"\";";
            nodoActual = nodoActual->siguiente;
        }

        nodoActual = colad->ini;
        while(nodoActual!=NULL)
        {
            if(nodoActual->siguiente != NULL)
            {
                QString actual;
                QString sig;
                actual += "\n\"Identificador: " + QString::number(nodoActual->identificador);
                actual += "\nTipo Avion: "+nodoActual->tipoAvion;
                actual += "\nCantidad Pasajeros: "+QString::number(nodoActual->pasajerosAvion);
                actual += "\nDesabordaje: "+QString::number(nodoActual->desabordajeAvion);
                actual += "\nMantenimiento: "+QString::number(nodoActual->mantenimientoAvion)+"\"";

                sig += "\n\"Identificador: " + QString::number(nodoActual->siguiente->identificador);
                sig += "\nTipo Avion: "+nodoActual->siguiente->tipoAvion;
                sig += "\nCantidad Pasajeros: "+QString::number(nodoActual->siguiente->pasajerosAvion);
                sig += "\nDesabordaje: "+QString::number(nodoActual->siguiente->desabordajeAvion);
                sig += "\nMantenimiento: "+QString::number(nodoActual->siguiente->mantenimientoAvion)+"\"";

                textEDD += actual + " -> " + sig + ";";
                textEDD += sig + " -> " + actual + ";";
            }
            nodoActual = nodoActual->siguiente;

        }
    }

    NodoColaMant * nodoMant;
    nodoMant = colaMant->ini;
    if(nodoMant != NULL)
    {
        while(nodoMant != NULL)
        {
            textEDD += "\n\"Identificador: " + QString::number(nodoMant->identificador);
            textEDD += "\nTipo Tipo Avion: "+nodoMant->tipo;
            textEDD += "\nTurnos: "+QString::number(nodoMant->turnos)+"\";";
            nodoMant = nodoMant->siguiente;
        }
        nodoMant = colaMant->ini;
        while(nodoMant != NULL)
        {
            if(nodoMant->siguiente != NULL)
            {
                QString actual;
                QString sig;
                actual += "\n\"Identificador: " + QString::number(nodoMant->identificador);
                actual += "\nTipo Tipo Avion: "+nodoMant->tipo;
                actual += "\nTurnos: "+QString::number(nodoMant->turnos)+"\"";

                sig += "\n\"Identificador: " + QString::number(nodoMant->siguiente->identificador);
                sig += "\nTipo Tipo Avion: "+nodoMant->siguiente->tipo;
                sig += "\nTurnos: "+QString::number(nodoMant->siguiente->turnos)+"\"";

                textEDD += actual + " -> " + sig + ";";
            }
            nodoMant = nodoMant->siguiente;
        }
    }

    NodoListaSimple * nodoSim;
    nodoSim = listasimple->ini;
    if(nodoSim != NULL)
    {
        while(nodoSim != NULL)
        {
            textEDD += "\n\"Identificador: " + QString::number(nodoSim->identificador);
            if(nodoSim->estado != false)
            {
                textEDD += "\nEstado: Habilitado";
            }
            else
            {
                textEDD += "\nEstado: Inhabilitado";
            }

            textEDD += "\nTurnos: "+QString::number(nodoSim->turnos)+"\";";
            nodoSim = nodoSim->siguiente;
        }
        nodoSim = listasimple->ini;
        while(nodoSim != NULL)
        {
            if(nodoSim->siguiente != NULL)
            {
                QString actual;
                QString sig;
                actual += "\n\"Identificador: " + QString::number(nodoSim->identificador);
                if(nodoSim->estado != false)
                {
                    actual += "\nEstado: Habilitado";
                }
                else
                {
                    actual += "\nEstado: Inhabilitado";
                }
                //actual += "\nEstado: "+nodoSim->estado;
                actual += "\nTurnos: "+QString::number(nodoSim->turnos)+"\"";

                sig += "\n\"Identificador: " + QString::number(nodoSim->siguiente->identificador);
                if(nodoSim->siguiente->estado != false)
                {
                    sig += "\nEstado: Habilitado";
                }
                else
                {
                    sig += "\nEstado: Inhabilitado";
                }
                //sig += "\nEstado: "+nodoSim->siguiente->estado;
                sig += "\nTurnos: "+QString::number(nodoSim->siguiente->turnos)+"\"";

                textEDD += actual + " -> " + sig + ";";
            }
            nodoSim = nodoSim->siguiente;
        }
    }

    NodoColaSimple * nodoPasajeros;
    nodoPasajeros = colasimple->ini;
    if(nodoPasajeros != NULL)
    {
        while(nodoPasajeros != NULL)
        {
            textEDD += "\n\"Pasajero: " + QString::number(nodoPasajeros->identificador);
            textEDD += "\nDocumentos: "+QString::number(nodoPasajeros->documentos);
            textEDD += "\nTurnos"+QString::number(nodoPasajeros->turnos);
            textEDD += "\nMaletas: "+QString::number(nodoPasajeros->maletas)+"\";";
            nodoPasajeros = nodoPasajeros->siguiente;
        }
        nodoPasajeros = colasimple->ini;
        while(nodoPasajeros != NULL)
        {
            if(nodoPasajeros->siguiente != NULL)
            {
                QString actual;
                QString sig;
                actual += "\n\"Pasajero: " + QString::number(nodoPasajeros->identificador);
                actual += "\nDocumentos: "+QString::number(nodoPasajeros->documentos);
                actual += "\nTurnos"+QString::number(nodoPasajeros->turnos);
                actual += "\nMaletas: "+QString::number(nodoPasajeros->maletas)+"\"";

                sig += "\n\"Pasajero: " + QString::number(nodoPasajeros->siguiente->identificador);
                sig += "\nDocumentos: "+QString::number(nodoPasajeros->siguiente->documentos);
                sig += "\nTurnos"+QString::number(nodoPasajeros->siguiente->turnos);
                sig += "\nMaletas: "+QString::number(nodoPasajeros->siguiente->maletas)+"\"";

                textEDD += actual + " -> " + sig + ";";
            }
            nodoPasajeros = nodoPasajeros->siguiente;
        }
    }

    textEDD += "\n}";
    salida<<textEDD;
    file.close();
    textEDD = "";

    QString argumento;
    argumento = "dot -Tpng _Grafica.dot -o _Grafica.png";
    QProcess *Proceso = new QProcess(this);
    Proceso->start(argumento);
}

void Simulador::mostrarGrafica()
{
    QPixmap mapa("_Grafica.png");
    QGraphicsScene *imagen = new QGraphicsScene();
    imagen->addPixmap(mapa);
    ui->graphicsView->setScene(imagen);
    ui->graphicsView->show();
}
