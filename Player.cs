using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace OthelloForm
{
    public class Player
    {
        private int m_Score = 2;
        private readonly Color r_Color;

        public Player(Color i_Color)
        {
            this.r_Color = i_Color;
        }

        public int Score
        {
            get
            {
                return m_Score;
            }

            set
            {
                m_Score = value;
            }
        }

        public Color Color
        {
            get
            {
                return r_Color;
            }
        }
    }
}
