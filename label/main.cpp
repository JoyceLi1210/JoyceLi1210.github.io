#include "mainwindow.h"
#include "Caption.h"

#include <QApplication>
#include <string>
#include <windows.h>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    MainWindow w;
    w.QWidget::showFullScreen();


    char myline[] = "However, as described below, through extensive praxis and ongoing  and ongoing . and ongoing rg 123456789 ";

    Caption *MyLabel = new Caption();
    MyLabel -> showline(myline,1080,1920);

    w.show();

    return a.exec();
}
