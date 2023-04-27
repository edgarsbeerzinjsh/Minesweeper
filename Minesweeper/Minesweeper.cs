using Minesweeper.Core;
using System;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Minesweeper : Form
    {
        private int _timePlayed = 0;
        private Board _board;

        public Minesweeper()
        {
            InitializeComponent();

            _board = new Board(this, 9, 9, 10);
            _board.SetupBoard();
            timer1.Start();
            updateTimer.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _timePlayed++;
            timeCounter.Text = _timePlayed.ToString();
        }

        private void resetGameButton(object sender, MouseEventArgs e)
        {
            _board.NotMine = null;
            _board.ResetGame();
            _timePlayed = 0;
            timer1.Start();
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            flagCounter.Text = _board.FlagsToUse().ToString();
            if (_board.GameEnded)
            {
                timer1.Stop();
            }
        }
    }
}