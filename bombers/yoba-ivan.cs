using System;
using System.Drawing;
using System.Windows.Forms;

namespace yobaivan
{
    public partial class yobaivan : Form
    {
        Graphics Canvas; //холст для рисования
        GameState state; //индикатор состояния игры
        Menu menu;
        Game game;
        public yobaivan()
        {
            InitializeComponent();
            Canvas = this.CreateGraphics(); //рисуем на всей форме
            state = new GameState();
            state = GameState.start;
            menu = new Menu();
            game = new Game();
        }
        GameState State
        {
            get
            {
                return state;
            }
        }
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            if (state == GameState.start)
            {
                Canvas.DrawImage(menu.BG,this.ClientRectangle);
            }
            else if (state == GameState.play)
            {
                game.DrawNewFrame(Canvas, this.ClientRectangle);
            }
        }

        private void yobaivan_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Escape: this.Close(); break;
                case Keys.Space: if (state == GameState.start) state = GameState.play; break;
                case Keys.Up: goto case Keys.Down;
                case Keys.Left: goto case Keys.Down;
                case Keys.Right: goto case Keys.Down;
                case Keys.Down: if (state == GameState.play) game.InputProcessor(e.KeyData, state); break;
            }
        }
    }
}
