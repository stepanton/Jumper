using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;


namespace mygame
{
    class Items
    {
        Image rocket;
        int coordx;
        int v;
        int coordy;
        int damage;
        bool solid;
        Random rnd;

        public Items() {
            rocket = new Bitmap("resources/missile.png");
            coordx = 900;
            v = 30;
            rnd = new Random();
            coordy = rnd.Next(10,420);
        }

        public Image Rocket
        {
            get
            {
                return rocket;
            }
        }

        public int Speed
        {
            get
            {
                return v;
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
                if (value < 0) { coordx = 900; coordy = rnd.Next(50, 410); }
                else coordx = value;
            }
        }

        public int Y
        {
            get
            {
                return coordy;
            }
        }
    }
}
