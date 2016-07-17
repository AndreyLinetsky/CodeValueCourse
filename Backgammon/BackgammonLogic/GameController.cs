using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    public class GameController
    {
        public GameController(int gameStyle)
        {
            if (gameStyle == 1)
            {
                FirstPlayer = new BlackPlayer(CheckerColor.Black, 5, 24, 0);
                SecondPlayer = new GreenPlayer(CheckerColor.Green, 18, -1, 23);
            }
            else
            {
                //firstPlayer = new BlackPlayer(CheckerColor.Black);
                // secondPlayer = new WhitePlayer(CheckerColor.White);
            }
            GameBoard = new Board();
            GameDice = new Dices();
        }

        public BlackPlayer FirstPlayer { get; private set; }
        public GreenPlayer SecondPlayer { get; private set; }
        public Board GameBoard { get; private set; }
        public Dices GameDice { get; private set; }
        public bool IsFirstMove { get; private set; }


        public CheckerColor PlayerWon
        {
            get
            {
                if (GameBoard.GetBar(CheckerColor.Black).Checkers == 0 &&
                    GameBoard.NoCheckersLeft(CheckerColor.Black))
                {
                    return CheckerColor.Black;
                }
                else if (GameBoard.GetBar(CheckerColor.Green).Checkers == 0 &&
                         GameBoard.NoCheckersLeft(CheckerColor.Green))
                {
                    return CheckerColor.Green;
                }
                else
                {
                    return CheckerColor.Empty;
                }
            }
        }

        public CheckerColor CurrentPlayer
        {
            get
            {
                if (FirstPlayer.IsPlayerTurn)
                {
                    return FirstPlayer.Color;
                }
                else
                {
                    return SecondPlayer.Color;
                }
            }
        }

        public bool IsBearOffStage
        {
            get
            {
                if (FirstPlayer.IsPlayerTurn)
                {
                    return FirstPlayer.CheckBearOffStage(GameBoard);
                }
                else
                {
                    return SecondPlayer.CheckBearOffStage(GameBoard);
                }
            }
        }

        public void DecideFirstTurn()
        {
            while (GameDice.FirstDice == GameDice.SecondDice)
            {
                GameDice.ThrowDice();
                if (GameDice.FirstDice > GameDice.SecondDice)
                {
                    FirstPlayer.IsPlayerTurn = true;
                    FirstPlayer.Turns = 2;
                    IsFirstMove = true;
                }
                else if (GameDice.FirstDice < GameDice.SecondDice)
                {
                    SecondPlayer.IsPlayerTurn = true;
                    SecondPlayer.Turns = 2;
                    IsFirstMove = true;
                }
            }
        }

        public void ThrowDice()
        {
            int currTurns = 2;
            GameDice.ThrowDice();
            if (GameDice.IsDouble)
            {
                currTurns = 4;
            }
            if (FirstPlayer.IsPlayerTurn)
            {
                FirstPlayer.Turns = currTurns;
            }
            else
            {
                SecondPlayer.Turns = currTurns;
            }
        }

        public bool CheckLegalMoves()
        {
            if (FirstPlayer.IsPlayerTurn)
            {
                if (FirstPlayer.Checklegality(GameDice, GameBoard))
                {
                    return true;
                }
                else
                {
                    SwapTurns();
                    return false;
                }
            }

            else
            {
                if (SecondPlayer.Checklegality(GameDice, GameBoard))
                {
                    return true;
                }
                else
                {
                    SwapTurns();
                    return false;
                }
            }
        }

        public void SwapTurns()
        {
            IsFirstMove = true;
            if (FirstPlayer.IsPlayerTurn)
            {
                FirstPlayer.IsPlayerTurn = false;
                SecondPlayer.IsPlayerTurn = true;
                FirstPlayer.Turns = 0;
            }
            else
            {
                FirstPlayer.IsPlayerTurn = true;
                SecondPlayer.IsPlayerTurn = false;
                SecondPlayer.Turns = 0;
            }
        }

        public bool PlayTurn(int sourceIndex, int move)
        {
            if (move != GameDice.FirstDice &&
                move != GameDice.SecondDice)
            {
                return false;
            }

            if (move > 6 ||
                move < 1)
            {
                return false;
            }

            if (sourceIndex > GameBoard.BarSource ||
                sourceIndex < 0)
            {
                return false;
            }
            if (GameBoard.GetBar(CurrentPlayer).Checkers > 0 &&
                sourceIndex != GameBoard.BarSource)
            {
                return false;
            }
            if (GameBoard.GetBar(CurrentPlayer).Checkers == 0 &&
                sourceIndex == GameBoard.BarSource)
            {
                return false;
            }
            if (sourceIndex != GameBoard.BarSource &&
                GameBoard[sourceIndex].Color != CurrentPlayer)
            {
                return false;
            }
            if (FirstPlayer.IsPlayerTurn)
            {
                if (FirstPlayer.PlayTurn(sourceIndex, move, GameBoard))
                {
                    IsFirstMove = false;
                    FirstPlayer.Turns--;
                    if (FirstPlayer.Turns == 0)
                    {
                        SwapTurns();
                    }
                    else if (!GameDice.IsDouble)
                    {
                        if (move == GameDice.FirstDice)
                        {
                            GameDice.ResetFirstDice();
                        }
                        else
                        {
                            GameDice.ResetSecondDice();
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (SecondPlayer.PlayTurn(sourceIndex, move, GameBoard))
                {
                    IsFirstMove = false;
                    SecondPlayer.Turns--;
                    if (SecondPlayer.Turns == 0)
                    {
                        SwapTurns();
                    }
                    else if (!GameDice.IsDouble)
                    {
                        if (move == GameDice.FirstDice)
                        {
                            GameDice.ResetFirstDice();
                        }
                        else
                        {
                            GameDice.ResetSecondDice();
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}