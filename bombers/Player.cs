using System;
using System.Drawing;

namespace mygame
{
    class Player
    //представляет собой описание игрока
    {
        Image hero;
        Rectangle[] sprite;
        int number;
        int coordx;
        int coordy;
        public Player()
        {
            number = 0;
            
            hero = new Bitmap("resources/player.png");
            sprite = new Rectangle[4];
            for (int i = 0; i < 4; ++i) sprite[i] = new Rectangle(i * 37, 96, 37, 48);
            coordx = 50;
            coordy = 400;
        }
        public Image Hero
        {
            get
            {
                return hero;
            }
        }
        public Rectangle Sprite
        {
            get
            {
                int t = number >> 1;//меняем спрайт раз в два кадра
                if (++number > 7) number = 0;
                return sprite[t];
            }
        }
        public int X
        {
            get
            {
                return coordx;
            }
            set
            {
                if (value < 0) coordx = 0;
                else if (value > 400) coordx = 400;
                else coordx = value;
            }
        }

        

        public int Y
        {
            get
            {
                return coordy;
            }
            set
            {
                if (value < 0) coordy = 0;
                else if (value > 400) coordy = 400;
                else coordy = value;
            }
        }

    }
}
