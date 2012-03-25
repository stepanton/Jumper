using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace mygame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mygame());
        }
    }
    enum GameState
        //Определяет набор возможных состояний игры
    {
        start, //исходное состояние
        play, //режим игры
        pause //режим паузы
    }
}
