using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OthelloForm
{
    public partial class GameSettingForm : Form
    {
        private const int  k_UpTheSizeOfBoard = 2;
        private const int k_MaxSizeOfBoard = 12;
        private bool m_closeByX = true;

        public GameSettingForm()
        {
            InitializeComponent();
        }

        private void m_ButtonToIncreaseBoard_Click(object sender, EventArgs e)
        {
            ScreenManagement.SizeBoard = (ScreenManagement.SizeBoard + k_UpTheSizeOfBoard) % (k_MaxSizeOfBoard + 2);
            if (ScreenManagement.SizeBoard == 0)
            {
                ScreenManagement.SizeBoard = 6;
            }

            m_ButtonToIncreaseBoard.Text = string.Format("Board Size : {0}x{0} (Click to increase)", ScreenManagement.SizeBoard);
        }

        private void buttonToPlay_Click(object sender, EventArgs e)
        {
            m_closeByX = false;

            if (sender == m_ButtonPlayAgainstComputer)
            {
                ScreenManagement.Bot = true;
            }
          
            this.Close();
        }

        public bool CloseByX
        {
            get
            {
                return m_closeByX;
            }
        }
    }
}
