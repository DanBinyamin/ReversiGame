using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OthelloForm
{
    public class GameLogic
    {
        public static void MarkLegalMoves(GameBoard i_Board)
        {
            for (int i = 0; i < i_Board.Size; i++)
            {
                for (int j = 0; j < i_Board.Size; j++)
                {
                    i_Board.MatrixButton[i, j].Enabled = false;
                    if (i_Board.MatrixButton[i, j].Text == string.Empty)
                    {
                        i_Board.MatrixButton[i, j].BackColor = Color.Empty;
                        if (CheckIfLegalMove(i, j, i_Board))
                        {
                            i_Board.MatrixButton[i, j].BackColor = Color.LimeGreen;
                            i_Board.MatrixButton[i, j].Enabled = true;
                        }
                    }
                }
            }
        }

        public static int CountLegalMoves(GameBoard i_Board)
        {
            int countMove = 0;

            for (int i = 0; i < i_Board.Size; i++)
            {
                for (int j = 0; j < i_Board.Size; j++)
                {
                    if (i_Board.MatrixButton[i, j].Text == string.Empty)
                    {
                        if (CheckIfLegalMove(i, j, i_Board))
                        {
                            countMove++;
                        }
                    }
                }
            }

            return countMove;
        }

        public static bool CheckIfLegalMove(int i_Row, int i_Col, GameBoard i_Borad)
        {
            bool northNorth, northWest, northEast, southWest, southEast, southSouth, westWest, eastEast, vaildIndex = false;

            if (i_Borad.MatrixButton[i_Row, i_Col].Text == string.Empty)
            {
                northNorth = vaildMove(i_Borad.TurnColor, -1, 0, i_Row, i_Col, i_Borad);
                northWest = vaildMove(i_Borad.TurnColor, -1, -1, i_Row, i_Col, i_Borad);
                northEast = vaildMove(i_Borad.TurnColor, -1, 1, i_Row, i_Col, i_Borad);
                westWest = vaildMove(i_Borad.TurnColor, 0, -1, i_Row, i_Col, i_Borad);
                eastEast = vaildMove(i_Borad.TurnColor, 0, 1, i_Row, i_Col, i_Borad);
                southWest = vaildMove(i_Borad.TurnColor, 1, -1, i_Row, i_Col, i_Borad);
                southEast = vaildMove(i_Borad.TurnColor, 1, 1, i_Row, i_Col, i_Borad);
                southSouth = vaildMove(i_Borad.TurnColor, 1, 0, i_Row, i_Col, i_Borad);

                if (northNorth || northWest || northEast || westWest || eastEast || southWest || southEast || southSouth)
                {
                    vaildIndex = true;
                }
            }

            return vaildIndex;
        }

        private static bool vaildMove(Color i_Color, int i_DirectionRow, int i_DirectionCol, int i_Row, int i_Col, GameBoard i_Borad)
        {
            bool vaildIndex = false;
            Color other = Color.Black;

            if (i_Color == Color.Black)
            {
                other = Color.White;
            }

            if (i_DirectionRow + i_Row < 0 || i_DirectionRow + i_Row >= i_Borad.Size || i_DirectionCol + i_Col < 0 || i_DirectionCol + i_Col >= i_Borad.Size)
            {
                vaildIndex = false;
            }
            else if (i_Borad.MatrixButton[i_Row + i_DirectionRow, i_Col + i_DirectionCol].BackColor != other)
            {
                vaildIndex = false;
            }
            else
            {
                if (i_Color != i_Borad.MatrixButton[i_Row + i_DirectionRow, i_DirectionCol + i_Col].BackColor && i_Borad.MatrixButton[i_Row + i_DirectionRow, i_DirectionCol + i_Col].Text != string.Empty)
                {
                    vaildIndex = checkLineIsGood(i_Color, i_DirectionRow, i_DirectionCol, i_DirectionRow + i_Row, i_DirectionCol + i_Col, i_Borad);
                }
            }

            return vaildIndex;
        }

        private static bool checkLineIsGood(Color i_Color, int i_DirectionRow, int i_DirectionCol, int i_Row, int i_Col, GameBoard i_Borad)
        {
            bool vaildIndex = false;

            if (i_Borad.MatrixButton[i_Row, i_Col].Text == string.Empty)
            {
                vaildIndex = false;
            }
            else if (i_Borad.MatrixButton[i_Row, i_Col].BackColor == i_Color)
            {
                vaildIndex = true;
            }
            else
            {
                if (i_DirectionRow + i_Row < 0 || i_DirectionRow + i_Row >= i_Borad.Size || i_DirectionCol + i_Col < 0 || i_DirectionCol + i_Col >= i_Borad.Size)
                {
                    vaildIndex = false;
                }
                else
                {
                    vaildIndex = checkLineIsGood(i_Color, i_DirectionRow, i_DirectionCol, i_DirectionRow + i_Row, i_DirectionCol + i_Col, i_Borad);
                }
            }

            return vaildIndex;
        }

        private static bool flipLine(Color i_Color, int i_DirectionRow, int i_DirectionCol, int i_Row, int i_Col, GameBoard i_Borad)
        {
            bool vaildIndex = false;

            if (i_DirectionRow + i_Row < 0 || i_DirectionRow + i_Row >= i_Borad.Size || i_DirectionCol + i_Col < 0 || i_DirectionCol + i_Col >= i_Borad.Size)
            {
                vaildIndex = false;
            }
            else
            {
                if (i_Borad.MatrixButton[i_DirectionRow + i_Row, i_DirectionCol + i_Col].Text == string.Empty)
                {
                    vaildIndex = false;
                }
                else
                {
                    if (i_Borad.MatrixButton[i_DirectionRow + i_Row, i_DirectionCol + i_Col].BackColor == i_Color)
                    {
                        vaildIndex = true;
                    }
                    else
                    {
                        if (flipLine(i_Color, i_DirectionRow, i_DirectionCol, i_DirectionRow + i_Row, i_DirectionCol + i_Col, i_Borad) == true)
                        {
                            i_Borad.MatrixButton[i_DirectionRow + i_Row, i_DirectionCol + i_Col].BackColor = i_Color;
                            i_Borad.MatrixButton[i_DirectionRow + i_Row, i_DirectionCol + i_Col].Text = "O";
                            vaildIndex = true;
                        }
                        else
                        {
                            vaildIndex = false;
                        }
                    }
                }
            }

            return vaildIndex;
        }

        public static void ChangeColorOnBoard(Color i_Color, int i_Row, int i_Col, GameBoard i_Board)
        {
            flipLine(i_Board.TurnColor, -1, 0, i_Row, i_Col, i_Board);
            flipLine(i_Board.TurnColor, -1, -1, i_Row, i_Col, i_Board);
            flipLine(i_Board.TurnColor, -1, 1, i_Row, i_Col, i_Board);
            flipLine(i_Board.TurnColor, 0, -1, i_Row, i_Col, i_Board);
            flipLine(i_Board.TurnColor, 0, 1, i_Row, i_Col, i_Board);
            flipLine(i_Board.TurnColor, 1, -1, i_Row, i_Col, i_Board);
            flipLine(i_Board.TurnColor, 1, 1, i_Row, i_Col, i_Board);
            flipLine(i_Board.TurnColor, 1, 0, i_Row, i_Col, i_Board);
        }

        public static void BotMove(GameBoard i_Board)
        {
            Random random = new Random();
            int row = 0, col = 0;

            do
            {
                row = random.Next(0, i_Board.Size);
                col = random.Next(0, i_Board.Size);
            }
            while (!CheckIfLegalMove(row, col, i_Board));

            i_Board.MatrixButton[row, col].BackColor = i_Board.TurnColor;
            i_Board.MatrixButton[row, col].Text = "O";
            i_Board.MatrixButton[row, col].Enabled = false;
            ChangeColorOnBoard(i_Board.TurnColor, row, col, i_Board);
            i_Board.SwitchTurn();
        }

        public static void CountScore(GameBoard i_Board)
        {
            int countBlack = 0, countWhite = 0;

            for (int i = 0; i < i_Board.Size; i++)
            {
                for (int j = 0; j < i_Board.Size; j++)
                {
                    if (i_Board.MatrixButton[i, j].BackColor == Color.White)
                    {
                        countWhite++;
                    }
                    else if (i_Board.MatrixButton[i, j].BackColor == Color.Black)
                    {
                        countBlack++;
                    }
                }
            }

            i_Board.UpdateScore(countWhite, countBlack);
        }

        public static bool isEmpty(GameBoard i_Board)
        {
            bool isEmpty = false;

            for (int i = 0; i < i_Board.Size; i++)
            {
                for (int j = 0; j < i_Board.Size; j++)
                {
                    if (i_Board.MatrixButton[i, j].Text == string.Empty)
                    {
                        isEmpty = true;
                    }
                }
            }

            return isEmpty;
        }

        public static bool IsGameOver(GameBoard i_Board)
        {
            return !(i_Board.Score != 0 && GameLogic.isEmpty(i_Board));
        }
    }
}
