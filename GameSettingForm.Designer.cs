namespace OthelloForm
{
    partial class GameSettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_ButtonToIncreaseBoard = new System.Windows.Forms.Button();
            this.m_ButtonPlayAgainstComputer = new System.Windows.Forms.Button();
            this.m_ButtonAgainstFriend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_ButtonToIncreaseBoard
            // 
            this.m_ButtonToIncreaseBoard.Location = new System.Drawing.Point(12, 22);
            this.m_ButtonToIncreaseBoard.Name = "m_ButtonToIncreaseBoard";
            this.m_ButtonToIncreaseBoard.Size = new System.Drawing.Size(426, 54);
            this.m_ButtonToIncreaseBoard.TabIndex = 0;
            this.m_ButtonToIncreaseBoard.Text = "Board Size : 6x6 (Click to increase)";
            this.m_ButtonToIncreaseBoard.UseVisualStyleBackColor = true;
            this.m_ButtonToIncreaseBoard.Click += new System.EventHandler(this.m_ButtonToIncreaseBoard_Click);
            // 
            // m_ButtonPlayAgainstComputer
            // 
            this.m_ButtonPlayAgainstComputer.Location = new System.Drawing.Point(12, 93);
            this.m_ButtonPlayAgainstComputer.Name = "m_ButtonPlayAgainstComputer";
            this.m_ButtonPlayAgainstComputer.Size = new System.Drawing.Size(178, 59);
            this.m_ButtonPlayAgainstComputer.TabIndex = 1;
            this.m_ButtonPlayAgainstComputer.Text = "Play against the computer";
            this.m_ButtonPlayAgainstComputer.UseVisualStyleBackColor = true;
            this.m_ButtonPlayAgainstComputer.Click += new System.EventHandler(this.buttonToPlay_Click);
            // 
            // m_ButtonAgainstFriend
            // 
            this.m_ButtonAgainstFriend.Location = new System.Drawing.Point(244, 93);
            this.m_ButtonAgainstFriend.Name = "m_ButtonAgainstFriend";
            this.m_ButtonAgainstFriend.Size = new System.Drawing.Size(194, 59);
            this.m_ButtonAgainstFriend.TabIndex = 2;
            this.m_ButtonAgainstFriend.Text = "Play against your friend";
            this.m_ButtonAgainstFriend.UseVisualStyleBackColor = true;
            this.m_ButtonAgainstFriend.Click += new System.EventHandler(this.buttonToPlay_Click);
            // 
            // GameSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 172);
            this.Controls.Add(this.m_ButtonAgainstFriend);
            this.Controls.Add(this.m_ButtonPlayAgainstComputer);
            this.Controls.Add(this.m_ButtonToIncreaseBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Othello - Game Settting";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_ButtonToIncreaseBoard;
        private System.Windows.Forms.Button m_ButtonPlayAgainstComputer;
        private System.Windows.Forms.Button m_ButtonAgainstFriend;
    }
}

