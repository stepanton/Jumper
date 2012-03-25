using System;
using System.Drawing;
using System.Windows.Forms;

namespace mygame
{
    class Game
    {
        Image background;
//        Image ninja;
        int delta;//смещение экрана
        Player player;
        Items missile;
        Rectangle drawingPlace;
        public Game()
        {
            background = new Bitmap("resources/bg.jpg");
            delta = 0;
            player = new Player();
            missile = new Items();
            drawingPlace = new Rectangle(player.X, player.Y, 60, 74);
        }

        public void DrawNewFrame(Graphics g, Rectangle r)
        {
            //замощаем задний план фоновым изображением
            for (int i = -delta; i < r.Right; i += background.Width) 
                g.DrawImage(background, i, 0, background.Width, background.Height);
            delta += 10;
            // работаем с ракетой
            g.DrawImage(missile.Rocket, missile.X, missile.Y);
            missile.X -= missile.Speed;

            if (delta > background.Width) delta = 0;
            drawingPlace.X = player.X;
            player.Y += 10;
            drawingPlace.Y = player.Y;
            g.DrawImage(player.Hero,drawingPlace,player.Sprite,GraphicsUnit.Pixel);
        }
        public void InputProcessor(Keys key, GameState state)
        //обрабатывает поступающий ввод
        {
            
            if (state == GameState.play)
            {
                if (key == Keys.Space) player.Y -= 20;
                               
            }
        }
    }
}
