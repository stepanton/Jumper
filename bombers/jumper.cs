using System;
using System.Drawing;
using System.Windows.Forms;

namespace yobaivan
{
    public partial class jumper : Form
    {
        enum Direction
        {
            Nothing = 0,
            Left = 1,
            Up = 2,
            Right = 3,
            Down = 4
        }

        Graphics Canvas; //холст для рисования
        GameState state; //индикатор состояния игры
        Menu menu;
        Game game;
        BufferedGraphicsContext context;//контекст графического устройства
        BufferedGraphics canvas;//холст с двойной буферизацией
        Direction direction;//в какую сторону движется герой
        public jumper()
        {
            InitializeComponent();
            Canvas = this.CreateGraphics(); //рисуем на всей форме
            state = new GameState();
            state = GameState.start;
            menu = new Menu();
            game = new Game();
            context = BufferedGraphicsManager.Current;
            context.MaximumBuffer = new Size(this.Width + 1, this.Height + 1);
            canvas = context.Allocate(this.CreateGraphics(), new Rectangle(0, 0, this.Width, this.Height));
            direction = Direction.Nothing;
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
                if (direction == Direction.Right) game.InputProcessor(Keys.Right, state);
                else if (direction == Direction.Left) game.InputProcessor(Keys.Left, state);
                game.DrawNewFrame(canvas.Graphics, this.ClientRectangle);
            }
            canvas.Render();
        }

        private void yobaivan_KeyDown(object sender, KeyEventArgs e)
        {
             switch (e.KeyData)
            {
                case Keys.Escape:  this.Close(); break;
                case Keys.Space: if (state == GameState.start) state = GameState.play; break;
                //                case Keys.Up: goto case Keys.Down;
                case Keys.Left: if (direction == Direction.Nothing) direction = Direction.Left; break;
                case Keys.Right: if (direction == Direction.Nothing) direction = Direction.Right; break;
                //                case Keys.Down: if (state == GameState.play) game.InputProcessor(e.KeyData, state); break;
            }
        }

       

        private void jumper_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Right && direction == Direction.Right ||
               e.KeyData == Keys.Left && direction == Direction.Left) direction = Direction.Nothing;
    
        }
    }
}
