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
        public GameController Game { get; private set; }
        public PictureBox[] PointsArr { get; private set; }
        public int Source { get; private set; }
        public int Target { get; private set; }
        public int MoveVal { get; private set; }
        private readonly int numberOfPoints = 26;
        private readonly int checkerBottom = 130;
        private readonly int greenBar = 24;
        private readonly int blackBar = 25;
        private readonly int initVal = 99;
        public bool FirstTurn { get; private set; }

        public Backgammon(string type)
        {
            InitializeComponent();
            InitBoard();
            if (string.Equals(type, "Human"))
            {
                Game = new GameController(1);
            }
            else
            {
                Game = new GameController(2);
            }
            Game.DecideFirstTurn();
            Dice1.Image = (Image)Properties.Resources.ResourceManager.GetObject(string.Format("Dice{0}", Game.FirstDice));
            Dice2.Image = (Image)Properties.Resources.ResourceManager.GetObject(string.Format("Dice{0}", Game.secondDice));
            if (Game.FirstDice > Game.secondDice)
            {
                turn.Text = "Black player turn";
                Message.Text = "Black won the initial roll";
            }
            else
            {
                turn.Text = "Green player turn";
                Message.Text = "Green won the initial roll";
            }
            roll.Enabled = false;
        }

        public void InitBoard()
        {
            board.Image = Properties.Resources.Optimized_Game_Board_BackgammonFull_Red_White_3;
            Source = initVal;
            Target = initVal;
            MoveVal = initVal;
            FirstTurn = true;
            PointsArr = this.Controls.OfType<PictureBox>()
            .Where(pb => pb.Name.StartsWith("Point"))
            .OrderBy(pb => int.Parse(pb.Name.Replace("Point", "")))
            .ToArray<PictureBox>();

            for (int i = 0; i < numberOfPoints; i++)
            {
                PointsArr[i].Parent = board;
                PointsArr[i].BackColor = Color.Transparent;
                PointsArr[i].Click += pictureBox_Click;
            }
            for (int i = 0; i < PointsArr.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        DrawChekers(PointsArr[i], Color.Green, 2, false);
                        break;
                    case 5:
                        DrawChekers(PointsArr[i], Color.Black, 5, false);
                        break;
                    case 7:
                        DrawChekers(PointsArr[i], Color.Black, 3, false);
                        break;
                    case 11:
                        DrawChekers(PointsArr[i], Color.Green, 5, false);
                        break;
                    case 12:
                        DrawChekers(PointsArr[i], Color.Black, 5, true);
                        break;
                    case 16:
                        DrawChekers(PointsArr[i], Color.Green, 3, true);
                        break;
                    case 18:
                        DrawChekers(PointsArr[i], Color.Green, 5, true);
                        break;
                    case 23:
                        DrawChekers(PointsArr[i], Color.Black, 2, true);
                        break;
                    default:
                        break;
                }
            }
        }

        public void DrawChekers(PictureBox currPicture, Color currColor, int checkers, bool isTopLine)
        {
            Bitmap bmp = new Bitmap(currPicture.Width, currPicture.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Transparent);
            SolidBrush brush;
            int checkerWidth = 22;
            int checkerHeight = 15;

            if (currColor == Color.Black)
            {
                brush = new SolidBrush(Color.Black);
            }
            else
            {
                brush = new SolidBrush(Color.Green);
            }
            for (int i = 0; i < checkers; i++)
            {
                if (isTopLine)
                {
                    g.FillEllipse(brush, 0, i * 15, checkerWidth, checkerHeight);
                }
                else
                {
                    g.FillEllipse(brush, 0, checkerBottom - i * 15, checkerWidth, checkerHeight);
                }
            }
            currPicture.Image = bmp;
            brush.Dispose();
            g.Dispose();
        }

        void pictureBox_Click(object sender, EventArgs e)
        {
            if (FirstTurn)
            {
                BlackLab.Visible = false;
                GreenLab.Visible = false;
                FirstTurn = false;
            }
            PictureBox currPicture = sender as PictureBox;
            int index = Array.IndexOf(PointsArr, currPicture);
            if (Source == initVal)
            {
                Source = index;
                PointsArr[index].BackColor = Color.LightSkyBlue;
                Message.BackColor = SystemColors.Control;
                Message.Text = "Select you target point";
            }
            else if (Source == index)
            {
                Source = initVal;
                PointsArr[index].BackColor = Color.Transparent;
                Message.BackColor = SystemColors.Control;
                Message.Text = "Select you source point";
            }
            else if (Source == greenBar)
            {
                if (index > 5)
                {
                    Message.BackColor = Color.Red;
                    Message.Text = "Illegal bar move";
                }
                else
                {
                    MoveVal = index + 1;
                    PlayTurn();
                }
            }
            else if (Source == blackBar)
            {
                if (index > 23 ||
                    index < 18)
                {
                    Message.BackColor = Color.Red;
                    Message.Text = "Illegal bar move";
                }
                else
                {
                    MoveVal = 24 - index;
                    PlayTurn();
                }
            }
            else
            {
                if (index == greenBar ||
                    index == blackBar)
                {
                    Message.BackColor = Color.Red;
                    Message.Text = "You cannot move into bar";
                }
                Target = index;
                if (Game.CurrentPlayer == CheckerColor.Black &&
                    Target > Source)
                {
                    Message.BackColor = Color.Red;
                    Message.Text = "Black moves counter clockwise";
                }
                else if (Game.CurrentPlayer == CheckerColor.Green &&
                    Target < Source)
                {
                    Message.BackColor = Color.Red;
                    Message.Text = "Green moves clockwise";
                }
                else
                {
                    MoveVal = Math.Abs(Target - Source);
                    PlayTurn();
                }
            }
        }

        public void PlayTurn()
        {
            int outSource = Source;
            if (Source == blackBar)
            {
                outSource = greenBar;
            }
            if (!Game.CheckLegalMoves())
            {
                PointsArr[Source].BackColor = Color.Transparent;
                MoveVal = initVal;
                Source = initVal;
                Target = initVal;
                turn.Text = String.Format("{0} player turn", Game.CurrentPlayer.ToString());
                Message.Text = "No legal moves were found";
                Message.BackColor = Color.Red;
                Dice1.Image = null;
                Dice2.Image = null;
                roll.Enabled = true;
            }
            else
            {
                if (Game.PlayTurn(outSource, MoveVal))
                {
                    PointsArr[Source].BackColor = Color.Transparent;
                    MoveVal = initVal;
                    Source = initVal;
                    Target = initVal;
                    turn.Text = String.Format("{0} player turn", Game.CurrentPlayer.ToString());
                    Message.Text = "";
                    Message.BackColor = SystemColors.Control;
                    if (Game.IsFirstMove)
                    {
                        Dice1.Image = null;
                        Dice2.Image = null;
                        roll.Enabled = true;
                        Message.Text = "Roll the dice";
                    }
                    RefreshBoard();
                }
                else
                {
                    Target = initVal;
                    MoveVal = initVal;
                    Message.Text = "Illegal move";
                    Message.BackColor = Color.Red;
                }
            }
        }
        public void RefreshBoard()
        {
            for (int i = 0; i < Game.GetBoard.Length / 2; i++)
            {
                if (Game.GetBoard[i].Color == CheckerColor.Black)
                {
                    DrawChekers(PointsArr[i], Color.Black, Game.GetBoard[i].CheckersAmount, false);
                }
                else if (Game.GetBoard[i].Color == CheckerColor.Green)
                {
                    DrawChekers(PointsArr[i], Color.Green, Game.GetBoard[i].CheckersAmount, false);
                }
                else
                {
                    DrawChekers(PointsArr[i], Color.Empty, Game.GetBoard[i].CheckersAmount, false);
                }
            }

            for (int i = Game.GetBoard.Length / 2; i < Game.GetBoard.Length; i++)
            {
                if (Game.GetBoard[i].Color == CheckerColor.Black)
                {
                    DrawChekers(PointsArr[i], Color.Black, Game.GetBoard[i].CheckersAmount, true);
                }
                else if (Game.GetBoard[i].Color == CheckerColor.Green)
                {
                    DrawChekers(PointsArr[i], Color.Green, Game.GetBoard[i].CheckersAmount, true);
                }
                else
                {
                    DrawChekers(PointsArr[i], Color.Empty, Game.GetBoard[i].CheckersAmount, true);
                }
            }

            // Refresh bar
            DrawChekers(PointsArr[greenBar], Color.Green, Game.SecondPlayerCheckersOnBar, true);
            DrawChekers(PointsArr[blackBar], Color.Black, Game.FirstPlayerCheckersOnBar, false);
        }

        private void roll_Click(object sender, EventArgs e)
        {
            Game.ThrowDice();
            Dice1.Image = (Image)Properties.Resources.ResourceManager.GetObject(string.Format("Dice{0}", Game.FirstDice));
            Dice2.Image = (Image)Properties.Resources.ResourceManager.GetObject(string.Format("Dice{0}", Game.secondDice));
            roll.Enabled = false;
            Message.Text = "Select you source point";
        }
    }
}
