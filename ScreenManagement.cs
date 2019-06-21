using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OthelloForm
{
    public static class ScreenManagement
    {
        private static int s_SizeOfBoard = 6;
        private static bool s_IsBot = false;
        private static GameBoard s_GameBoard;

        public static void StartNewGame()
        {
            GameSettingForm gameSettingForm = new GameSettingForm();
            gameSettingForm.ShowDialog();
            if (!gameSettingForm.CloseByX)
            {
                s_GameBoard = new GameBoard(s_SizeOfBoard, s_IsBot);
                GameInProgress();
            }
        }

        public static void GameInProgress()
        {
            GameLogic.MarkLegalMoves(s_GameBoard);
            s_GameBoard.Show();
            if (!s_GameBoard.GameIsFinish)
            {
                turnIsOk();
            }
        }

        public static void SetIndex(Button i_Button)
        {
            for (int i = 0; i < s_GameBoard.Size; i++)
            {
                for (int j = 0; j < s_GameBoard.Size; j++)
                {
                    if (s_GameBoard.MatrixButton[i, j] == i_Button)
                    {
                        i_Button.BackColor = s_GameBoard.TurnColor;
                        i_Button.Text = "O";
                        GameLogic.ChangeColorOnBoard(s_GameBoard.TurnColor, i, j, s_GameBoard);
                        doTurn();
                        break;
                    }
                }
            }
        }

        private static void doTurn()
        {
            GameLogic.CountScore(s_GameBoard);
            s_GameBoard.SwitchTurn();
            GameLogic.MarkLegalMoves(s_GameBoard);
            turnIsOk();

            if (s_IsBot && !s_GameBoard.GameIsFinish && s_GameBoard.Turn == eTurn.Computer && GameLogic.CountLegalMoves(s_GameBoard) != 0)
            {
                while (s_GameBoard.Turn == eTurn.Computer && !s_GameBoard.GameIsFinish)
                {
                    GameLogic.MarkLegalMoves(s_GameBoard);
                    GameLogic.BotMove(s_GameBoard);
                    turnIsOk();
                    GameLogic.MarkLegalMoves(s_GameBoard);
                    GameLogic.CountScore(s_GameBoard);
                }
            }

            if (GameLogic.IsGameOver(s_GameBoard) && s_GameBoard.GameIsFinish != true)
            {
                GetResultFromUser();
                GameLogic.CountScore(s_GameBoard);
            }
        }

        private static void turnIsOk()
        {
            int countMove = GameLogic.CountLegalMoves(s_GameBoard);

            if (countMove == 0)
            {
                MessageBox.Show("Out of Moves!");
                s_GameBoard.SwitchTurn();
                GameLogic.MarkLegalMoves(s_GameBoard);
                countMove = GameLogic.CountLegalMoves(s_GameBoard);
                if (countMove == 0)
                {
                    s_GameBoard.GameIsFinish = true;
                    GetResultFromUser();
                }
            }
        }

        public static void GetResultFromUser()
        {
            DialogResult dialog = MessageBox.Show(string.Format("{0}{1}{2}", s_GameBoard.PrintDetails(), Environment.NewLine, "Would You want start a new game?"), string.Empty, MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                s_GameBoard.InitzalizeMatrix();
                GameLogic.MarkLegalMoves(s_GameBoard);
            }
            else
            {
                s_GameBoard.Board.Close();
            }
        }

        public static int SizeBoard
        {
            get
            {
                return s_SizeOfBoard;
            }

            set
            {
                s_SizeOfBoard = value;
            }
        }

        public static bool Bot
        {
            get
            {
                return s_IsBot;
            }

            set
            {
                s_IsBot = value;
            }
        }
    }
}
