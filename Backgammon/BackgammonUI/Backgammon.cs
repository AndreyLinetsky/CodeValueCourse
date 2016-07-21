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
using System.Threading;
namespace BackgammonUI
{
    public partial class Backgammon : Form
    {
        public GameController Game { get; private set; }
        public PictureBox[] PointsArr { get; private set; }
        public int Source { get; private set; }
        public int Target { get; private set; }
        public int InitVal { get; } = 99;
        public int CheckerWidth { get; } = 22;
        public int CheckerHeight { get; } = 15;
        public bool FirstTurn { get; private set; }

        public Backgammon(bool isFirstAi, bool isSecondAi)
        {
            InitializeComponent();
            InitBoard();
            Game = new GameController(isFirstAi, isSecondAi);
            Game.DecideFirstTurn();
            if (Game.CurrentPlayer.Color != Game.StartingColor)
            {
                roll.Enabled = true;
            }
            RefreshBoard();
        }

        public void InitBoard()
        {
            Source = InitVal;
            Target = InitVal;
            FirstTurn = true;
            PointsArr = this.Controls.OfType<PictureBox>()
                .Where(pb => pb.Name.StartsWith("Point"))
                .OrderBy(pb => int.Parse(pb.Name.Replace("Point", "")))
                .ToArray<PictureBox>();

            foreach (PictureBox currPic in PointsArr)
            {
                currPic.Parent = board;
                currPic.BackColor = Color.Transparent;
                currPic.Click += pictureBox_Click;
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
                    g.FillEllipse(brush, 0, i * CheckerHeight, CheckerWidth, CheckerHeight);
                }
            }
            if (greenCheckers > 0)
            {
                brush = new SolidBrush(Color.Green);
                for (int i = 0; i < greenCheckers; i++)
                {
                    g.FillEllipse(brush, 0, (blackCheckers + i) * CheckerHeight, CheckerWidth, CheckerHeight);
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
                    g.FillEllipse(brush, 0, i * CheckerHeight, CheckerWidth, CheckerHeight);
                }
                else
                {
                    g.FillEllipse(brush, 0, Point0.Height - CheckerHeight - i * CheckerHeight, CheckerWidth, CheckerHeight);
                }
            }
            currPicture.Image = bmp;
            brush.Dispose();
            g.Dispose();
        }

        public void RefreshTurn()
        {
            turn.Text = $"{Game.CurrentPlayer.Color} player turn";
        }

        public void pictureBox_Click(object sender, EventArgs e)
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
            else if (Source == InitVal)
            {
                Source = index;
                PointsArr[index].BackColor = Color.LightSkyBlue;
                Message.BackColor = SystemColors.Control;
                Message.Text = "Select you target point";
            }
            else if (Source == index)
            {
                Source = InitVal;
                PointsArr[index].BackColor = Color.Transparent;
                Message.BackColor = SystemColors.Control;
                Message.Text = "Select you source point";
            }
            else
            {
                Target = index;
                PlayTurn();
            }
        }


        public void CheckLegalMoves()
        {
            if (!Game.CheckLegalMoves())
            {
                RefreshTurn();
                Message.Text = "No legal moves were found";
                Message.BackColor = Color.Red;
                roll.Enabled = true;
            }
        }

        public void PlayTurn()
        {
            if (Game.PlayTurn(Source, Target))
            {
                PointsArr[Source].BackColor = Color.Transparent;
                RefreshBoard();
                Source = InitVal;
                Target = InitVal;
                if (Game.PlayerWon == CheckerColor.Empty)
                {
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
                Target = InitVal;
                Message.Text = "Illegal move";
                Message.BackColor = Color.Red;
            }
        }

        public void RefreshBoard()
        {
            ShowDice();
            RefreshTurn();
            for (int i = 0; i < Game.GameBoard.Points.Length / 2; i++)
            {
                DrawChekers(PointsArr[i], Game.GameBoard[i].Color, Game.GameBoard[i].CheckersAmount, false);
            }

            for (int i = Game.GameBoard.Points.Length / 2; i < Game.GameBoard.Points.Length; i++)
            {
                DrawChekers(PointsArr[i], Game.GameBoard[i].Color, Game.GameBoard[i].CheckersAmount, true);
            }

            // Refresh bar 
            DrawBarChekers(PointsArr[Game.GameBoard.BarSource], Game.GameBoard.GetBar(CheckerColor.Black).Checkers,
                Game.GameBoard.GetOtherBar(CheckerColor.Black).Checkers);
        }

        public void ShowDice()
        {
            Dice1.Image = (Image)Properties.Resources.ResourceManager.GetObject($"Dice{Game.GameDice.FirstDice}");
            Dice2.Image = (Image)Properties.Resources.ResourceManager.GetObject($"Dice{Game.GameDice.SecondDice}");
        }
        private void roll_Click(object sender, EventArgs e)
        {
            Game.ThrowDice();
            ShowDice();
            roll.Enabled = false;
            Message.BackColor = SystemColors.Control;
            Message.Text = "Select you source point";
            CheckLegalMoves();
        }

        private void Dice1_Click(object sender, EventArgs e)
        {
            if (roll.Enabled == false &&
                Game.IsBearOffStage &&
                Source != InitVal &&
                !Game.CheckBounds(Source, Game.GameDice.FirstDice))
            {
                Target = Game.GetBounds(Source, Game.GameDice.FirstDice);
                if (Target != InitVal)
                {
                    PlayTurn();
                }
            }
        }


        private void Dice2_Click(object sender, EventArgs e)
        {
            if (roll.Enabled == false &&
                Game.IsBearOffStage &&
                Source != InitVal &&
                !Game.CheckBounds(Source, Game.GameDice.SecondDice))
            {
                Target = Game.GetBounds(Source, Game.GameDice.SecondDice);
                if (Target != InitVal)
                {
                    PlayTurn();
                }
            }
        }
    }
}