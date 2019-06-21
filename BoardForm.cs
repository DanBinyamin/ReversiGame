using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OthelloForm
{
    public class BoardForm : Form
    {
        public BoardForm(int i_SizeOfBoard)
        {
            initizalizeForm(i_SizeOfBoard);
        }

        private void initizalizeForm(int i_SizeOfBoard)
        {
            int topOfButton = 4, leftOfButton = 4;

            for (int i = 0; i < i_SizeOfBoard; i++)
            {
                for (int j = 0; j < i_SizeOfBoard; j++)
                {
                    Button button = new Button();
                    button.Width = 40;
                    button.Height = 40;
                    button.Left = leftOfButton;
                    button.Top = topOfButton;
                    button.Click += button_Click;
                    Controls.Add(button);
                    leftOfButton += button.Width;
                }

                leftOfButton = 4;
                topOfButton += 40;
            }

            this.Width = (i_SizeOfBoard * 40) + 14;
            this.Height = topOfButton + 32;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        public void button_Click(object sender, EventArgs e)
        {
            ScreenManagement.SetIndex((Button)sender);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "BoardForm";
            this.Text = "7";
            this.ResumeLayout(false);
        }
    }
}
