using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Adventures_of_Bill_Guy
{
    public partial class Form1 : Form
    {
        int jumpSpeed = 6;

        List<int> brick = new List<int>();
        int[] playerJump = new int[] { 6, 5, 4, 3, 2, 1, -1, -2, -3, -4, -5, -6};

        int playerX = 65;
        int playerY = 520;
        int playerHeight = 600;
        int playerWidth = 70;


        Pen darkGrey = new Pen(Color.DimGray);
        SolidBrush darkGrayBrush = new SolidBrush(Color.DimGray);

        int playerspeed = 6;

        bool wDown = false;
        bool aDown = false;
        bool sDown = false;
        bool dDown = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(darkGrey, playerX, playerY, playerWidth, playerHeight);
            e.Graphics.FillRectangle(darkGrayBrush, playerX, playerY, playerWidth, playerHeight);
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if(aDown == true && playerX > 0)
            {
                playerX -= playerspeed;
            }
            else if(dDown == true && playerX < this.Width - playerWidth)
            {
                playerX += playerspeed;
            }
          else if (wDown == true & playerY > 0)
            {
                playerY -= playerspeed;
            }
            else if (wDown == false & playerY > 0)
            {
                playerY += playerspeed;
            }

            Refresh();

        }
    }
}
