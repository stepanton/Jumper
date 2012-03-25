using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace yobaivan
{
    class Object
    {
        Image missile;

        public Object()
        {
            missile = new Bitmap("resources/missile.png");
         }
        public Image Rocket
        {
            get
            {
                return missile;
            }
        }
    }


}
