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
        public int MoveVal { get; private set; }
        public int CheckerBottom { get; }
        private const int numberOfPoints = 25;
        private const int initVal = 99;
        private const int checkerWidth = 22;
        private const int checkerHeight = 15;
        public bool FirstTurn { get; private set; }

        public Backgammon(string type)
        {
            InitializeComponent();
            CheckerBottom = Point0.Height - checkerHeight;
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
            Dice1.Image = (Image)Properties.Resources.ResourceManager.GetObject(string.Format("Dice{0}", Game.GameDice.FirstDice));
            Dice2.Image = (Image)Properties.Resources.ResourceManager.GetObject(string.Format("Dice{0}", Game.GameDice.SecondDice));
            if (Game.GameDice.FirstDice > Game.GameDice.SecondDice)
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
                        DrawChekers(PointsArr[i], CheckerColor.Green, 2, false);
                        break;
                    case 5:
                        DrawChekers(PointsArr[i], CheckerColor.Black, 5, false);
                        break;
                    case 7:
                        DrawChekers(PointsArr[i], CheckerColor.Black, 3, false);
                        break;
                    case 11:
                        DrawChekers(PointsArr[i], CheckerColor.Green, 5, false);
                        break;
                    case 12:
                        DrawChekers(PointsArr[i], CheckerColor.Black, 5, true);
                        break;
                    case 16:
                        DrawChekers(PointsArr[i], CheckerColor.Green, 3, true);
                        break;
                    case 18:
                        DrawChekers(PointsArr[i], CheckerColor.Green, 5, true);
                        break;
                    case 23:
                        DrawChekers(PointsArr[i], CheckerColor.Black, 2, true);
                        break;
                    default:
                        break;
                }
            }
        }

        public void DrawBarChekers(PictureBox currPicture, int blackCheckers, int greenCheckers)
        {
            Bitmap bmp = new Bitmap(currPicture.Width, currPicture.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Transparent);
            SolidBrush brush = new SolidBrush(Color.Black);

            if (blackCheckers > 0)
            {
                for (int i = 0; i < blackCheckers; i++)
                {
                    g.FillEllipse(brush, 0, i * 15, checkerWidth, checkerHeight);
                }
            }
            if (greenCheckers > 0)
            {
                brush = new SolidBrush(Color.Green);
                for (int i = 0; i < greenCheckers; i++)
                {
                    g.FillEllipse(brush, 0, (blackCheckers + i) * 15, checkerWidth, checkerHeight);
                }
            }
            currPicture.Image = bmp;
            brush.Dispose();
            g.Dispose();
        }
        public void DrawChekers(PictureBox currPicture, CheckerColor currColor, int checkers, bool isTopLine)
        {
            Bitmap bmp = new Bitmap(currPicture.Width, currPicture.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Transparent);
            SolidBrush brush;

            if (currColor == CheckerColor.Black)
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
                    g.FillEllipse(brush, 0, CheckerBottom - i * 15, checkerWidth, checkerHeight);
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
            if (roll.Enabled)
            {
                Message.BackColor = Color.Red;
                Message.Text = "Please roll the dice";
            }
            else if (Game.PlayerWon != CheckerColor.Empty)
            {
                Message.BackColor = Color.Red;
                Message.Text = "Game is over";
            }
            else if (Source == initVal)
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
            else if (index == Game.GameBoard.BarSource)
            {
                Message.BackColor = Color.Red;
                Message.Text = "You cannot move into bar";
            }
            else if (Source == Game.GameBoard.BarSource)
            {
                if (Game.CurrentPlayer == CheckerColor.Green)
                {
                    if (index > 5)
                    {
                        Message.BackColor = Color.Red;
                        Message.Text = "Illegal green bar move";
                    }
                    else
                    {
                        MoveVal = index + 1;
                        PlayTurn();
                    }
                }
                else
                {
                    if (index < 18 || index > 23)
                    {
                        Message.BackColor = Color.Red;
                        Message.Text = "Illegal black bar move";
                    }
                    else
                    {
                        MoveVal = Game.GameBoard.BarSource - index;
                        PlayTurn();
                    }
                }
            }
            else
            {
                if (Game.CurrentPlayer == CheckerColor.Black &&
                          index > Source)
                {
                    Message.BackColor = Color.Red;
                    Message.Text = "Black moves counter clockwise";
                }
                else if (Game.CurrentPlayer == CheckerColor.Green &&
                    index < Source)
                {
                    Message.BackColor = Color.Red;
                    Message.Text = "Green moves clockwise";
                }
                else
                {
                    MoveVal = Math.Abs(index - Source);
                    PlayTurn();
                }
            }
        }

        public void CheckLegalMoves()
        {
            if (!Game.CheckLegalMoves())
            {
                turn.Text = string.Format("{0} player turn", Game.CurrentPlayer.ToString());
                Message.Text = "No legal moves were found";
                Message.BackColor = Color.Red;
                roll.Enabled = true;
            }
        }
        public void PlayTurn()
        {
            if (Game.PlayTurn(Source, MoveVal))
            {
                PointsArr[Source].BackColor = Color.Transparent;
                RefreshBoard();
                Source = initVal;
                MoveVal = initVal;
                if (Game.PlayerWon == CheckerColor.Empty)
                {
                    turn.Text = String.Format("{0} player turn", Game.CurrentPlayer.ToString());
                    Message.Text = "";
                    Message.BackColor = SystemColors.Control;
                    if (Game.IsFirstMove)
                    {
                        roll.Enabled = true;
                        Message.Text = "Roll the dice";
                    }
                    else
                    {
                        CheckLegalMoves();
                    }
                }
                else
                {
                    turn.Text = "";
                    if (Game.PlayerWon == CheckerColor.Green)
                    {
                        Message.Text = "Green player won";
                        Message.BackColor = Color.Gold;
                    }
                    else
                    {
                        Message.Text = "Black player won";
                        Message.BackColor = Color.Gold;
                    }
                }
            }
            else
            {
                MoveVal = initVal;
                Message.Text = "Illegal move";
                Message.BackColor = Color.Red;
            }
        }
        public void RefreshBoard()
        {
            for (int i = 0; i < Game.GameBoard.Points.Length / 2; i++)
            {
                DrawChekers(PointsArr[i], Game.GameBoard[i].Color, Game.GameBoard[i].CheckersAmount, false);
            }

            for (int i = Game.GameBoard.Points.Length / 2; i < Game.GameBoard.Points.Length; i++)
            {
                DrawChekers(PointsArr[i], Game.GameBoard[i].Color, Game.GameBoard[i].CheckersAmount, true);
            }

            // Refresh bar 
            DrawBarChekers(PointsArr[Game.GameBoard.BarSource], Game.GameBoard.GetBar(CheckerColor.Black).Checkers, Game.GameBoard.GetOtherBar(CheckerColor.Black).Checkers);
        }

        private void roll_Click(object sender, EventArgs e)
        {
            Game.ThrowDice();
            Dice1.Image = (Image)Properties.Resources.ResourceManager.GetObject(string.Format("Dice{0}", Game.GameDice.FirstDice));
            Dice2.Image = (Image)Properties.Resources.ResourceManager.GetObject(string.Format("Dice{0}", Game.GameDice.SecondDice));
            roll.Enabled = false;
            Message.BackColor = SystemColors.Control;
            Message.Text = "Select you source point";
            CheckLegalMoves();
        }

        private void Dice1_Click(object sender, EventArgs e)
        {
            if (roll.Enabled == false &&
                Game.IsBearOffStage &&
                Source != initVal)
            {
                if (Game.CurrentPlayer == CheckerColor.Black)
                {
                    if (Source - Game.GameDice.FirstDice < 0)
                    {
                        MoveVal = Game.GameDice.FirstDice;
                        PlayTurn();
                    }
                }
                else
                {
                    if (Source + Game.GameDice.FirstDice >= Game.GameBoard.BarSource)
                    {
                        MoveVal = Game.GameDice.FirstDice;
                        PlayTurn();
                    }
                }
            }
        }

        private void Dice2_Click(object sender, EventArgs e)
        {
            if (roll.Enabled == false &&
                Game.IsBearOffStage &&
                Source != initVal)
            {
                if (Game.CurrentPlayer == CheckerColor.Black)
                {
                    if (Source - Game.GameDice.SecondDice < 0)
                    {
                        MoveVal = Game.GameDice.SecondDice;
                        PlayTurn();
                    }
                }
                else
                {
                    if (Source + Game.GameDice.SecondDice >= Game.GameBoard.BarSource)
                    {
                        MoveVal = Game.GameDice.SecondDice;
                        PlayTurn();
                    }
                }
            }
        }
    }
}
