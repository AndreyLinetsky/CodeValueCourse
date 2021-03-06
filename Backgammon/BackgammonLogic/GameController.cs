﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    public class GameController
    {
        public GameController(bool isFirstAi, bool isSecondAi)
        {
            FirstPlayer = new BlackPlayer(CheckerColor.Black, 5, 24, 0, isFirstAi);
            SecondPlayer = new GreenPlayer(CheckerColor.Green, 18, -1, 23, isSecondAi);
            GameBoard = new Board();
            GameDice = new Dices();
        }

        public Player FirstPlayer { get; private set; }
        public Player SecondPlayer { get; private set; }
        public Board GameBoard { get; private set; }
        public Dices GameDice { get; private set; }
        public bool IsTurnStart { get; private set; }
        


        public CheckerColor PlayerWon
        {
            get
            {
                if (GameBoard.GetBar(CheckerColor.Black).Checkers == 0 &&
                    !GameBoard.IsCheckersLeft(CheckerColor.Black))
                {
                    return CheckerColor.Black;
                }
                else if (GameBoard.GetBar(CheckerColor.Green).Checkers == 0 &&
                         !GameBoard.IsCheckersLeft(CheckerColor.Green))
                {
                    return CheckerColor.Green;
                }
                else
                {
                    return CheckerColor.Empty;
                }
            }
        }

        public Player CurrentPlayer
        {
            get
            {
                if (FirstPlayer.IsPlayerTurn)
                {
                    return FirstPlayer;
                }
                else
                {
                    return SecondPlayer;
                }
            }
        }

        public bool IsBearOffStage
        {
            get
            {
                return CurrentPlayer.CheckBearOffStage(GameBoard);
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
                    IsTurnStart = true;
                }
                else if (GameDice.FirstDice < GameDice.SecondDice)
                {
                    SecondPlayer.IsPlayerTurn = true;
                    SecondPlayer.Turns = 2;
                    IsTurnStart = true;
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
            if (CurrentPlayer.Checklegality(GameDice, GameBoard))
            {
                return true;
            }
            else
            {
                SwapTurns();
                return false;
            }
        }
        public bool CheckBounds(int source, int move)
        {
            return CurrentPlayer.CheckMoveBounds(source, move);
        }
        public int GetBounds(int source, int move)
        {
            return CurrentPlayer.GetMoveBounds(source, move);
        }
        public void SwapTurns()
        {
            IsTurnStart = true;
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

        public void PlayAiTurn()
        {
            ThrowDice();
            if (FirstPlayer.IsPlayerTurn)
            {
                OperateAi(FirstPlayer);
            }
            else
            {
                OperateAi(SecondPlayer);
            }
        }
        public void OperateAi(Player currPlayer)
        {
            while (PlayerWon == CheckerColor.Empty &&
                currPlayer.Turns > 0 &&
                currPlayer.Checklegality(GameDice, GameBoard))
            {
                KeyValuePair<int, int> currMove = currPlayer.PlayAiTurn(GameDice, GameBoard);
                currPlayer.Turns--;
                if (!GameDice.IsDouble)
                {
                    if (currPlayer.Color == CheckerColor.Black)
                    {
                        if (currMove.Key - currMove.Value == GameDice.FirstDice)
                        {
                            GameDice.DisableFirstDice();
                        }
                        else
                        {
                            GameDice.DisableSecondDice();
                        }
                    }
                    else
                    {
                        int gameMove;
                        if (currMove.Key == GameBoard.BarSource)
                        {
                            gameMove = currMove.Value + 1;
                        }
                        else
                        {
                            gameMove = currMove.Value - currMove.Key;
                        }
                        if (gameMove == GameDice.FirstDice)
                        {
                            GameDice.DisableFirstDice();
                        }
                        else
                        {
                            GameDice.DisableSecondDice();
                        }
                    }
                }
            }
            if (PlayerWon != currPlayer.Color)
            {
                SwapTurns();
            }
        }

        public bool PlayTurn(int sourceIndex, int targetIndex)
        {
            if (!CurrentPlayer.ValidateTurn(GameDice, GameBoard, sourceIndex, targetIndex))
            {
                return false;
            }

            if (FirstPlayer.IsPlayerTurn)
            {
                if (FirstPlayer.PlayTurn(sourceIndex, targetIndex, GameBoard))
                {
                    IsTurnStart = false;
                    FirstPlayer.Turns--;
                    if (FirstPlayer.Turns == 0)
                    {
                        SwapTurns();
                    }
                    else if (!GameDice.IsDouble)
                    {
                        if (sourceIndex - targetIndex == GameDice.FirstDice)
                        {
                            GameDice.DisableFirstDice();
                        }
                        else
                        {
                            GameDice.DisableSecondDice();
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
                if (SecondPlayer.PlayTurn(sourceIndex, targetIndex, GameBoard))
                {
                    IsTurnStart = false;
                    SecondPlayer.Turns--;
                    if (SecondPlayer.Turns == 0)
                    {
                        SwapTurns();
                    }
                    else if (!GameDice.IsDouble)
                    {

                        int gameMove;
                        if (sourceIndex == GameBoard.BarSource)
                        {
                            gameMove = targetIndex + 1;
                        }
                        else
                        {
                            gameMove = targetIndex - sourceIndex;
                        }
                        if (gameMove == GameDice.FirstDice)
                        {
                            GameDice.DisableFirstDice();
                        }
                        else
                        {
                            GameDice.DisableSecondDice();
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