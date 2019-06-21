using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace OthelloForm
{
    public class GameBoard
    {
        private BoardForm m_FormOfPlay;
        private readonly int r_MatrixSize = 0;
        private Player m_Player1 = null;
        private Player m_Player2 = null;
        private bool m_IsBotPlay = false;
        private eTurn m_Turn = eTurn.Player1;
        private Button[,] m_Buttons;
        private bool m_GameIsFinishGame = false;

        public GameBoard(int i_SizeOfForm, bool i_IsBotPlay)
        {
            m_FormOfPlay = new BoardForm(i_SizeOfForm);
            r_MatrixSize = i_SizeOfForm;
            m_IsBotPlay = i_IsBotPlay;
            m_Player1 = new Player(Color.White);
            if (!m_IsBotPlay)
            {
                m_Player2 = new Player(Color.Black);
            }

            m_Buttons = new Button[i_SizeOfForm, i_SizeOfForm];
            InitzalizeMatrix();
        }

        public void InitzalizeMatrix()
        {
            int k = 0;

            if (!m_IsBotPlay)
            {
                m_Player2.Score = 2;
            }

            m_GameIsFinishGame = false;
            Board.Text = "Othello - White's Turn";
            m_Turn = eTurn.Player1;

            m_Player1.Score = 2;

            for (int i = 0; i < r_MatrixSize; i++)
            {
                for (int j = 0; j < r_MatrixSize; j++)
                {
                    m_Buttons[i, j] = (Button)m_FormOfPlay.Controls[k++];
                    m_Buttons[i, j].Text = string.Empty;
                    m_Buttons[i, j].BackColor = Color.Empty;
                }
            }

            m_Buttons[(r_MatrixSize / 2) - 1, (r_MatrixSize / 2) - 1].BackColor = Color.White;
            m_Buttons[(r_MatrixSize / 2) - 1, (r_MatrixSize / 2) - 1].Text = "O";
            m_Buttons[(r_MatrixSize / 2) - 1, r_MatrixSize / 2].BackColor = Color.Black;
            m_Buttons[(r_MatrixSize / 2) - 1, r_MatrixSize / 2].Text = "O";
            m_Buttons[r_MatrixSize / 2, (r_MatrixSize / 2) - 1].BackColor = Color.Black;
            m_Buttons[r_MatrixSize / 2, (r_MatrixSize / 2) - 1].Text = "O";
            m_Buttons[r_MatrixSize / 2, r_MatrixSize / 2].BackColor = Color.White;
            m_Buttons[r_MatrixSize / 2, r_MatrixSize / 2].Text = "O";
        }

        public void Show()
        {
            m_FormOfPlay.ShowDialog();
        }

        public void UpdateScore(int i_CountWhite, int i_CountBlack)
        {
            if (m_Player1.Color == Color.White)
            {
                m_Player1.Score = i_CountWhite;
                if (m_Player2 != null)
                {
                    m_Player2.Score = i_CountBlack;
                }
            }
            else
            {
                m_Player1.Score = i_CountBlack;
                if (m_Player2 != null)
                {
                    m_Player2.Score = i_CountWhite;
                }
            }
        }

        public void SwitchTurn()
        {
            if (m_IsBotPlay == false)
            {
                if (m_Turn == eTurn.Player1)
                {
                    Board.Text = "Othello - Black's Turn";
                    m_Turn = eTurn.Player2;
                }
                else
                {
                    Board.Text = "Othello - White's Turn";
                    m_Turn = eTurn.Player1;
                }
            }
            else
            {
                if (m_Turn == eTurn.Player1)
                {
                    m_Turn = eTurn.Computer;
                }
                else
                {
                    m_Turn = eTurn.Player1;
                }
            }
        }

        public string PrintDetails()
        {
            if (m_Player2 != null)
            {
                if (m_Player1.Score > m_Player2.Score)
                {
                    return string.Format("{0} Won!! ({1}/{2})", m_Player1.Color, m_Player2.Score, m_Player1.Score);
                }
                else
                {
                    return string.Format("{0} Won!! ({1}/{2})", m_Player2.Color, m_Player1.Score, m_Player2.Score);
                }
            }
            else
            {
                if (m_Player1.Score > r_MatrixSize * r_MatrixSize / 2)
                {
                    return string.Format("{0} Won!! ({1}/{2})", m_Player1.Color, m_Player1.Score, r_MatrixSize * r_MatrixSize);
                }
                else
                {
                    return string.Format("{0} Won!! ({1}/{2})", eTurn.Computer, (r_MatrixSize * r_MatrixSize) - m_Player1.Score, r_MatrixSize * r_MatrixSize);
                }
            }
        }

        public Form Board
        {
            get
            {
                return m_FormOfPlay;
            }
        }

        public int Size
        {
            get
            {
                return r_MatrixSize;
            }
        }

        public Button[,] MatrixButton
        {
            get
            {
                return m_Buttons;
            }
        }

        public int Score
        {
            get
            {
                int score = m_Player1.Score;

                if (m_Turn == eTurn.Player1)
                {
                    score = m_Player1.Score;
                }
                else
                {
                    if (m_Turn == eTurn.Player2)
                    {
                        score = m_Player2.Score;
                    }
                }

                return score;
            }

            set
            {
                if (m_Turn == eTurn.Player1)
                {
                    m_Player1.Score = value;
                }
                else
                {
                    if (m_Turn == eTurn.Player2)
                    {
                        m_Player2.Score = value;
                    }
                }
            }
        }

        public Color TurnColor
        {
            get
            {
                if (m_Turn == eTurn.Player1)
                {
                    return m_Player1.Color;
                }
                else if (m_Turn == eTurn.Player2)
                {
                    return m_Player2.Color;
                }
                else
                {
                    return Color.Black;
                }
            }
        }

        public eTurn Turn
        {
            get
            {
                if (m_Turn == eTurn.Player1)
                {
                    return eTurn.Player1;
                }
                else if (m_Turn == eTurn.Player2)
                {
                    return eTurn.Player2;
                }
                else
                {
                    return eTurn.Computer;
                }
            }
        }

        public bool GameIsFinish
        {
            get
            {
                return m_GameIsFinishGame;
            }

            set
            {
                m_GameIsFinishGame = value;
            }
        }
    }
}
