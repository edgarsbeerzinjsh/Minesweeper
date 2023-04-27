using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper.Core
{
    public enum CellType
    {
        Regular, Mine, Flagged, FlaggedMine
    }

    public enum CellState
    {
        Opened, Closed
    }

    public class Cell : Button
    {
        public int XLoc { get; set; }
        public int YLoc { get; set; }
        public int CellSize { get; set; }
        public CellState CellState { get; set; }
        public CellType CellType { get; set; }
        public int NumMines { get; set; }
        public Board Board { get; set; }

        public void SetupDesign()
        {
            this.Location = new Point(XLoc * CellSize, YLoc * CellSize + 100);
            this.Size = new Size(CellSize, CellSize);
            this.UseVisualStyleBackColor = false;
        }

        public void SetText()
        {
            switch (CellType)
            {
                case CellType.Regular:
                case CellType.Flagged:
                    if (NumMines != 0)
                    {
                        this.Text = NumMines.ToString();
                        this.ForeColor = GetCellColour();
                    }
                    else
                    {
                        this.Text = "";
                    }

                    this.Font = new Font("Arial", 15.75F, FontStyle.Bold);
                    break;

                case CellType.Mine:
                case CellType.FlaggedMine:
                    this.Text = "M";
                    this.ForeColor = DefaultForeColor;
                    this.Font = new Font("Wingdings", 15.75F, FontStyle.Bold);
                    break;
            }
        }

        public void OnFlag()
        {
            switch (CellType)
            {
                case CellType.Flagged:
                    CellType = CellType.Regular;
                    break;
                case CellType.FlaggedMine:
                    CellType = CellType.Mine;
                    break;
                case CellType.Mine:
                    CellType = CellType.FlaggedMine;
                    break;
                case CellType.Regular:
                    CellType = CellType.Flagged;
                    break;
            }

            if (this.Text == "")
            {
                this.Text = "O";
                this.Font = new Font("Wingdings", 15.75F, FontStyle.Bold);
            }
            else
            {
                this.Text = "";
            }
        }

        public void OnClick(bool recursiveCall = false)
        {
            if (!(recursiveCall && CellState == CellState.Opened))
            {
                CellState = CellState.Opened;
                SetText();

                if (CellType == CellType.FlaggedMine || CellType == CellType.Mine)
                {
                    this.BackColor = Color.Red;
                    Board.OpenedMine();
                }
                else if (this.NumMines == 0)
                {
                    this.BackColor = Color.DeepSkyBlue;
                    Board.OpenedEmptyCell(this);
                }

                if (Board.OnlyMinesLeft())
                {
                    Board.GameEnd();
                    MessageBox.Show("You Won!", "Won!");
                }
            }
        }

        private Color GetCellColour()
        {
            switch (NumMines)
            {
                case 1:
                    return ColorTranslator.FromHtml("0x0000FE"); // 1
                case 2:
                    return ColorTranslator.FromHtml("0x186900"); // 2
                case 3:
                    return ColorTranslator.FromHtml("0xAE0107"); // 3
                case 4:
                    return ColorTranslator.FromHtml("0x000177"); // 4
                case 5:
                    return ColorTranslator.FromHtml("0x8D0107"); // 5
                case 6:
                    return ColorTranslator.FromHtml("0x007A7C"); // 6
                case 7:
                    return ColorTranslator.FromHtml("0x902E90"); // 7
                case 8:
                    return ColorTranslator.FromHtml("0x000000"); // 8
                default:
                    return ColorTranslator.FromHtml("0xffffff");
            }
        }
    }
}