using System;
using System.Drawing;

namespace mygame
{
    class Menu
        //представляет собой описание меню
    {
        Image background;
        public Menu()
        {
            background = new Bitmap("resources/menu_bg.jpg");
        }
        public Image BG
        {
            get
            {
                return background;
            }
        }
    }
}
