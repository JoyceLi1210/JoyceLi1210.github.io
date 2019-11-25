#include "Caption.h"
#include <iostream>



Caption::Caption(){

    myline = new QLabel();
    animation = new QPropertyAnimation(myline,"windowOpacity");

}
Caption::~Caption(){

    delete myline;
    delete animation;

}

void Caption::showline(char const *line, int h, int w){

    /* 文字超過螢幕寬,自動換行 */
    QFontMetrics fm(QFont("Timers", 25, QFont::Bold));
    if( fm.width(line)> w-60)
        myline -> setWordWrap(true);

    myline -> setFont(QFont("Timers", 25, QFont::Bold));
    myline -> setGeometry(0, h-h/5, w, NULL);
    set_text();
    myline -> setText(line);
    myline -> show();

}

void Caption::action_line( int ms, int h, int w){

    myline -> setText("Action");
    set_text();
    myline -> setGeometry(w/2-150, h/6, 300, 150 );
    myline -> setFont(QFont("Timers", 30, QFont::Bold));
    myline -> show();
    disappear(ms);

}

void Caption::set_text(){

    myline -> setStyleSheet("color: white ;"
                             " background-color:rgba(255, 255, 225, 25%)");
    myline -> setAlignment(Qt::AlignCenter);
    myline -> setContentsMargins(30, 30, 30, 30);

}

void Caption::disappear(int ms){ //淡出

    animation->setDuration(ms);
    animation->setStartValue(1);
    animation->setEndValue(0);
    animation->start();

}


