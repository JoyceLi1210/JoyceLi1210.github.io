
/* class name：Caption
 *　showline(char const *line, int h, int w):字幕, 參數為(台詞,螢幕長,螢幕寬)
 *  action_line(int ms, int h, int w):Action字樣, 參數為(消失速度[豪秒], 螢幕長, 螢幕寬)
 */


#ifndef CAPTION_H
#define CAPTION_H

#include <QLabel>
#include <string>
#include <QPropertyAnimation>

class Caption
{
    public:
        Caption();
        ~Caption();
        void showline(char const *line, int h, int w);
        void action_line(int ms, int h, int w);
        void set_text();
        void disappear(int ms);


    private:
        QLabel *myline;
        QPropertyAnimation *animation;

};

#endif // CAPTION_H
