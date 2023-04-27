using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Minesweeper.Core
{
    public class Board
    {
        public bool GameEnded = false;
        public Cell NotMine;
        public Minesweeper Minesweeper { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int NumMines { get; set; }
        public Cell[,] Cells { get; set; }

        public Board(Minesweeper minesweeper, int width, int height, int mines)
        {
            Minesweeper = minesweeper;
            Width = width;
            Height = height;
            NumMines = mines;
            Cells = new Cell[width, height];
        }

        public void SetupBoard()
        {
            var minePositions = MinePositionsRandomiser(NumMines);

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    var c = new Cell
                    {
                        CellState = CellState.Closed,
                        CellSize = 50,
                        Board = this,
                        XLoc = i,
                        YLoc = j
                    };

                    var position = CoordinatesToString(i, j);
                    if (minePositions.Contains(position))
                    {
                        c.CellType = CellType.Mine;
                    }
                    else
                    {
                        c.CellType = CellType.Regular;
                        var numberList = NeighboringMineCount(i, j);
                        var num = numberList.Count(x=> minePositions.Contains(x));
                        c.NumMines = num;
                    }

                    c.SetupDesign();
                    c.MouseDown += Cell_MouseClick;

                    Cells[i, j] = c;
                    Minesweeper.Controls.Add(c);
                }
            }

            if (NotMine != null)
            {
                if (Cells[NotMine.XLoc, NotMine.YLoc].CellType == CellType.Mine)
                {
                    ResetGame();
                }
                else
                {
                    Cells[NotMine.XLoc, NotMine.YLoc].OnClick();
                }
            }
        }

        public List<string> MinePositionsRandomiser(int mineCount)
        {
            var random = new Random();
            var mineLocations = new List<string>();
            while (mineLocations.Count < mineCount)
            {
                var nextMineX = random.Next(Width);
                var nextMineY = random.Next(Height);
                var nextMine = CoordinatesToString(nextMineX, nextMineY);
                if (!mineLocations.Contains(nextMine))
                {
                    mineLocations.Add(nextMine);
                }
            }

            return mineLocations;
        }

        public List<string> NeighboringMineCount(int x, int y)
        {
            var neighborLocations = new List<string>();
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (!(i == x && j == y))
                    {
                        neighborLocations.Add(CoordinatesToString(i, j));
                    }
                }
            }

            return neighborLocations;
        }

        public string CoordinatesToString(int x, int y)
        {
            return $"{x}, {y}";
        }

        public void Cell_MouseClick(object sender, MouseEventArgs e)
        {
            var cell = (Cell) sender;

            if (cell.CellState == CellState.Opened)
                return;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    cell.OnClick();
                    break;

                case MouseButtons.Right:
                    cell.OnFlag();
                    break;

                default:
                    return;
            }
        }

        public void OpenedEmptyCell(Cell zeroCell)
        {
            var zeroX = zeroCell.XLoc;
            var zeroY = zeroCell.YLoc;
            for (int i = zeroX - 1; i <= zeroX + 1; i++)
            {
                if (i >= 0 && i < Width)
                {
                    for (int j = zeroY - 1; j <= zeroY + 1; j++)
                    {
                        if (j >= 0 && j < Height)
                        {
                            Cells[i, j].OnClick(true);
                        }
                    }
                }

            }
        }

        public void OpenedMine()
        {
            var openedCells = 0;
            foreach (var cell in Cells)
            {
                if (IsOpened(cell))
                {
                    NotMine = cell;
                    openedCells++;
                }
            }

            if (openedCells == 1)
            {
                ResetGame();
            }
            else
            {
                NotMine = null;
                foreach (var cell in Cells)
                {
                    if (IsClosedMineOrFlaggedMine(cell))
                    {
                        cell.SetText();
                        cell.BackColor = Color.Red;
                    }
                }

                GameEnd();
            }
        }

        public int FlagsToUse()
        {
            var flagged = 0;
            foreach (var cell in Cells)
            {
                if (IsClosedFlaggedOrFlaggedMine(cell))
                {
                    flagged++;
                }
            }

            return NumMines - flagged;
        }

        public bool OnlyMinesLeft()
        {
            var nonMinesLeft = 0;
            foreach (var cell in Cells)
            {
                if (IsClosedRegularOrFlagged(cell))
                {
                    nonMinesLeft++;
                }
            }
            return nonMinesLeft == 0;
        }

        public bool IsOpened(Cell cell)
        {
            return cell.CellState == CellState.Opened;
        }

        public bool IsClosedMineOrFlaggedMine(Cell cell)
        {
            return (cell.CellState == CellState.Closed &&
                    (cell.CellType == CellType.Mine || cell.CellType == CellType.FlaggedMine));
        }

        public bool IsClosedFlaggedOrFlaggedMine(Cell cell)
        {
            return (cell.CellState == CellState.Closed &&
                    (cell.CellType == CellType.Flagged || cell.CellType == CellType.FlaggedMine));
        }

        public bool IsClosedRegularOrFlagged(Cell cell)
        {
            return (cell.CellState == CellState.Closed &&
                    (cell.CellType == CellType.Regular || cell.CellType == CellType.Flagged));
        }

        public void GameEnd()
        {
            foreach (var cell in Cells)
            {
                cell.MouseDown -= Cell_MouseClick;
            }

            GameEnded = true;
        }

        public void ResetGame()
        {
            foreach (var cell in Cells)
            {
                this.Minesweeper.Controls.Remove(cell);
            }
            SetupBoard();
            GameEnded = false;
        }
    }
}
