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
        int jumpCounter = 0;
        bool jump = false;
       
      int[] jumpList = new int[]{-90, -32, -24, -16, -8, 0, 8, 16, 24, 32, 90};

        int playerX = 69;
        int playerY = 540;
        int playerHeight = 60;
        int playerWidth = 40;


        Pen darkGrey = new Pen(Color.DimGray);
        SolidBrush darkGrayBrush = new SolidBrush(Color.DimGray);

        int playerspeed = 6;


        bool wDown = false;
        bool aDown = false;
        bool sDown = false;
        bool dDown = false;

        Rectangle ledge = new Rectangle(400, 440, 400, 20);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
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
                case Keys.Space:
                    if(jump == false)
                    {
                        jump = true;
                    }
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

            e.Graphics.DrawRectangle(darkGrey, 400, 440, 400, 20);
            e.Graphics.FillRectangle(darkGrayBrush, 400, 440, 400, 20);
      

        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            Rectangle playerRec = new Rectangle(playerX, playerY, playerWidth, playerHeight);

            //if(wDown == false)
            //{
            //    playerY += playerspeed;
            //}
            if(jump == true)
            {
                playerY += jumpList[jumpCounter];
                jumpCounter++;
                if (jumpCounter == 11)
                {
                    jumpCounter = 0;
                    jump = false;
                }
            }

     
      
            if (aDown == true && playerX > 0)
            {
                playerX -= playerspeed;
            }
            else if (dDown == true && playerX < this.Width - playerWidth)
            {
                playerX += playerspeed;
            }
            else if(wDown == true && playerY > 0)
            {
                for(int i = 0; i > jumpList.Length; i++)
                {
                    playerY -= jumpList[i];
                }
            }

            Refresh();
        }  
    }
}
