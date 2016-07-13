using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BackgammonLogic;

namespace BackgammonUI
{
    public partial class Backgammon : Form
    {
        public Backgammon(string type)
        {
            InitializeComponent();
            board.Image = Properties.Resources.Optimized_Game_Board_BackgammonFull_Red_White_3;
            List<PictureBox> pointsList = InitBoard();
            GameController game;
            if (string.Equals(type, "Human"))
            {
                game = new GameController(1);
            }
            else
            {
                game = new GameController(2);
            }
            game.DecideFirstTurn();
            Dice1.Image = (Image)Properties.Resources.ResourceManager.GetObject(string.Format("Dice{0}", game.FirstDice));
            Dice2.Image = (Image)Properties.Resources.ResourceManager.GetObject(string.Format("Dice{0}", game.secondDice));
            if (game.FirstDice > game.secondDice)
            {
                turn.Text = "Black player turn";
                Message.Text = "Black won the initial roll";
            }
            else
            {
                turn.Text = "White player turn";
                Message.Text = "White won the initial roll";
            }
            roll.Enabled = false;
        }

        public List<PictureBox> InitBoard()
        {
            List<PictureBox> retPictureBox = new List<PictureBox>(new PictureBox[24]);
            for (int i = 1; i <= 24; i++)
            {
                retPictureBox[i-1] = ((PictureBox)this.Controls[string.Format("PictureBox{0}", i)]);
                retPictureBox[i].Parent = board;
                retPictureBox[i].BackColor = Color.Transparent;
                
            }
            Bitmap map;
            SolidBrush whiteBrush = new SolidBrush(Color.Green);
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            for (int i = 0; i < retPictureBox.Count; i++)
            {
                map = new Bitmap(retPictureBox[i].Width, retPictureBox[i].Height);
                Graphics g = Graphics.FromImage(map);
                                
                switch (i)
                {
                    case 0:
                        g.FillEllipse(whiteBrush, 0, 0, 22, 15);
                        g.FillEllipse(whiteBrush, 0, 10, 22, 15);
                        break;
                    case 5:
                        g.FillEllipse(blackBrush, 0, 0, 22, 15);
                        g.FillEllipse(blackBrush, 0, 15, 22, 15);
                        g.FillEllipse(blackBrush, 0, 30, 22, 15);
                        g.FillEllipse(blackBrush, 0, 45, 22, 15);
                        g.FillEllipse(blackBrush, 0, 60, 22, 15);
                        break;
                    case 7:
                        g.FillEllipse(blackBrush, 0, 0, 22, 15);
                        g.FillEllipse(blackBrush, 0, 10, 22, 15);
                        g.FillEllipse(blackBrush, 0, 20, 22, 15);
                        break;
                    case 11:
                        g.FillEllipse(whiteBrush, 0, 0, 15, 10);
                        g.FillEllipse(whiteBrush, 0, 10, 15, 10);
                        g.FillEllipse(whiteBrush, 0, 20, 15, 10);
                        g.FillEllipse(whiteBrush, 0, 30, 15, 10);
                        g.FillEllipse(whiteBrush, 0, 40, 15, 10);
                        break;
                    case 12:
                        g.FillEllipse(blackBrush, 0, 0, 15, 10);
                        g.FillEllipse(blackBrush, 0, 10, 15, 10);
                        g.FillEllipse(blackBrush, 0, 20, 15, 10);
                        g.FillEllipse(blackBrush, 0, 30, 15, 10);
                        g.FillEllipse(blackBrush, 0, 40, 15, 10);
                        break;
                    case 16:
                        g.FillEllipse(whiteBrush, 0, 0, 15, 10);
                        g.FillEllipse(whiteBrush, 0, 10, 15, 10);
                        g.FillEllipse(whiteBrush, 0, 20, 15, 10);
                        break;
                    case 18:
                        g.FillEllipse(whiteBrush, 0, 0, 15, 10);
                        g.FillEllipse(whiteBrush, 0, 10, 15, 10);
                        g.FillEllipse(whiteBrush, 0, 20, 15, 10);
                        g.FillEllipse(whiteBrush, 0, 30, 15, 10);
                        g.FillEllipse(whiteBrush, 0, 40, 15, 10);
                        break;
                    case 23:
                        g.FillEllipse(blackBrush, 0, 0, 15, 10);
                        g.FillEllipse(blackBrush, 0, 10, 15, 10);
                        break;
                    default:
                        break;
                }
                retPictureBox[i].Image = (Image)map;
            }
            return retPictureBox;
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
