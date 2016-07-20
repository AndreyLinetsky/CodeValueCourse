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
                FirstPlayer = new BlackPlayer(CheckerColor.Black, 5, 24, 0, false);
                SecondPlayer = new GreenPlayer(CheckerColor.Green, 18, -1, 23, false);
            }
            else if (gameStyle == 2)
            {
                FirstPlayer = new BlackPlayer(CheckerColor.Black, 5, 24, 0, false);
                SecondPlayer = new GreenPlayer(CheckerColor.Green, 18, -1, 23, true);
            }
            else
            {
                FirstPlayer = new BlackPlayer(CheckerColor.Black, 5, 24, 0, true);
                SecondPlayer = new GreenPlayer(CheckerColor.Green, 18, -1, 23, false);
            }
            GameBoard = new Board();
            GameDice = new Dices();
        }

        public Player FirstPlayer { get; private set; }
        public Player SecondPlayer { get; private set; }
        public Board GameBoard { get; private set; }
        public Dices GameDice { get; private set; }
        public bool IsFirstMove { get; private set; }
        public CheckerColor StartingColor { get; private set; }


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

        public CheckerColor PlayerColor
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
                    IsFirstMove = true;
                    StartingColor = PlayerColor;
                    if (FirstPlayer.IsComputer)
                    {
                        OperateAi(FirstPlayer);
                    }
                }
                else if (GameDice.FirstDice < GameDice.SecondDice)
                {
                    SecondPlayer.IsPlayerTurn = true;
                    SecondPlayer.Turns = 2;
                    IsFirstMove = true;
                    StartingColor = PlayerColor;
                    if (SecondPlayer.IsComputer)
                    {
                        OperateAi(SecondPlayer);
                    }
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
                if (CurrentPlayer.IsComputer)
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
                return false;
            }
        }
        public int CheckBounds(int source, int move)
        {
            return CurrentPlayer.CheckMoveBounds(source, move);
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

        public void OperateAi(Player currPlayer)
        {
            while (PlayerWon != currPlayer.Color &&
                currPlayer.Turns > 0 &&
                CheckLegalMoves())
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
                    IsFirstMove = false;
                    FirstPlayer.Turns--;
                    if (FirstPlayer.Turns == 0)
                    {
                        SwapTurns();
                        if (SecondPlayer.IsComputer)
                        {
                            ThrowDice();
                            OperateAi(SecondPlayer);
                        }
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
                    IsFirstMove = false;
                    SecondPlayer.Turns--;
                    if (SecondPlayer.Turns == 0)
                    {
                        SwapTurns();
                        if (FirstPlayer.IsComputer)
                        {
                            ThrowDice();
                            OperateAi(FirstPlayer);
                        }
                    }
                    else if (!GameDice.IsDouble)
                    {
                        if (targetIndex - sourceIndex == GameDice.FirstDice)
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