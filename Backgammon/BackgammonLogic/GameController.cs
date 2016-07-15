using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    public class GameController
    {
        private BlackPlayer firstPlayer;
        private WhitePlayer secondPlayer;
        private Board gameBoard;
        private Dices gameDice;
        private bool isFirstMove;
        private int barSource = 24;

        public GameController(int gameStyle)
        {
            if(gameStyle == 1)
            {
                firstPlayer = new BlackPlayer(CheckerColor.Black);
                secondPlayer = new WhitePlayer(CheckerColor.Green);
            }
            else
            {
                //firstPlayer = new BlackPlayer(CheckerColor.Black);
               // secondPlayer = new WhitePlayer(CheckerColor.White);
            }
            gameBoard = new Board();
            gameDice = new Dices();
        }
        public bool IsFirstMove
        {
            get
            {
                return isFirstMove;
            }
        }
        public int FirstDice
        {
            get
            {
                return gameDice.FirstDice;
            }
        }
        public int secondDice
        {
            get
            {
                return gameDice.SecondDice;
            }
        }

        public int FirstPlayerCheckersOnBar
        {
            get
            {
                return gameBoard.FirstPlayerBarCheckers;
            }
        }

        public int SecondPlayerCheckersOnBar
        {
            get
            {
                return gameBoard.SecondPlayerBarCheckers;
            }
        }

        public bool IsGameOver
        {
            get
            {
                if ((gameBoard.FirstPlayerBarCheckers == 0 &&
                    firstPlayer.IsPlayerWon(gameBoard)) ||
                   gameBoard.SecondPlayerBarCheckers == 0 &&
                   secondPlayer.IsPlayerWon(gameBoard))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Point[] GetBoard
        {
            get
            {
                return gameBoard.GetBoard;
            }
        }
        public CheckerColor CurrentPlayer
        {
            get
            {
                if (firstPlayer.IsPlayerTurn)
                {
                    return firstPlayer.Color;
                }
                else
                {
                    return secondPlayer.Color;
                }
            }
        }
        public void DecideFirstTurn()
        {
            while (gameDice.FirstDice == gameDice.SecondDice)
            {
                gameDice.ThrowDice();
                if (gameDice.FirstDice > gameDice.SecondDice)
                {
                    firstPlayer.IsPlayerTurn = true;
                    firstPlayer.Turns = 2;
                    isFirstMove = true;
                }
                else if (gameDice.FirstDice < gameDice.SecondDice)
                {
                    secondPlayer.IsPlayerTurn = true;
                    secondPlayer.Turns = 2;
                    isFirstMove = true;
                }
            }
        }

        public void ThrowDice()
        {
            gameDice.ThrowDice();
            if (firstPlayer.IsPlayerTurn)
            {
                if (gameDice.IsDouble)
                {
                    firstPlayer.Turns = 4;
                }
                else
                {
                    firstPlayer.Turns = 2;
                }
            }
            else
            {
                if (gameDice.IsDouble)
                {
                    secondPlayer.Turns = 4;
                }
                else
                {
                    secondPlayer.Turns = 2;
                }
            }
        }

        public bool CheckLegalMoves()
        {
            if (firstPlayer.IsPlayerTurn)
            {
                if (gameBoard.FirstPlayerBarCheckers > 0)
                {
                    if (firstPlayer.CheckLegalBarMoves(gameDice, gameBoard))
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
                    if (firstPlayer.CheckBearOffStage(gameBoard))
                    {
                        if (firstPlayer.CheckLegalBearOffMoves(gameDice, gameBoard))
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
                        if (firstPlayer.CheckLegalMoves(gameDice, gameBoard))
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
            }
            else
           if (gameBoard.SecondPlayerBarCheckers > 0)
            {
                if (secondPlayer.CheckLegalBarMoves(gameDice, gameBoard))
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
                if (secondPlayer.CheckBearOffStage(gameBoard))
                {
                    if (secondPlayer.CheckLegalBearOffMoves(gameDice, gameBoard))
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
                    if (secondPlayer.CheckLegalMoves(gameDice, gameBoard))
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
        }

        public void SwapTurns()
        {
            if (firstPlayer.IsPlayerTurn)
            {
                firstPlayer.IsPlayerTurn = false;
                secondPlayer.IsPlayerTurn = true;
                isFirstMove = true;
                firstPlayer.Turns = 0;
            }
            else
            {
                firstPlayer.IsPlayerTurn = true;
                secondPlayer.IsPlayerTurn = false;
                isFirstMove = true;
                secondPlayer.Turns = 0;
            }
        }
        public bool PlayTurn(int SourceIndex, int Move)
        {
            if (Move != gameDice.FirstDice &&
                Move != gameDice.SecondDice)
            {
                return false;
            }

            if (Move > 6 ||
                Move < 1)
            {
                return false;
            }

            if (SourceIndex > 24 ||
                SourceIndex < 0)
            {
                return false;
            }
            if (firstPlayer.IsPlayerTurn)
            {
                if (gameBoard.FirstPlayerBarCheckers > 0 &&
                    SourceIndex != barSource)
                {
                    return false;
                }
                if (gameBoard.FirstPlayerBarCheckers == 0 &&
                    SourceIndex == barSource)
                {
                    return false;
                }
                if (SourceIndex != barSource &&
                    gameBoard[SourceIndex].Color != firstPlayer.Color)
                {
                    return false;
                }

                if (SourceIndex == barSource)
                {
                    if (firstPlayer.MakeBarMove(Move, gameBoard))
                    {
                        isFirstMove = false;
                        firstPlayer.Turns--;
                        if (firstPlayer.Turns == 0)
                        {
                            SwapTurns();
                        }
                        else if (!gameDice.IsDouble)
                        {
                            if (Move == gameDice.FirstDice)
                            {
                                gameDice.ResetFirstDice();
                            }
                            else
                            {
                                gameDice.ResetSecondDice();
                            }
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                else if (firstPlayer.CheckBearOffStage(gameBoard))
                {
                    if (firstPlayer.MakeBearOffMove(SourceIndex, Move, gameBoard))
                    {
                        isFirstMove = false;
                        firstPlayer.Turns--;
                        if (firstPlayer.Turns == 0)
                        {
                            SwapTurns();
                        }
                        else if (!gameDice.IsDouble)
                        {
                            if (Move == gameDice.FirstDice)
                            {
                                gameDice.ResetFirstDice();
                            }
                            else
                            {
                                gameDice.ResetSecondDice();
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
                    if (firstPlayer.MakeMove(SourceIndex, Move, gameBoard))
                    {
                        isFirstMove = false;
                        firstPlayer.Turns--;
                        if (firstPlayer.Turns == 0)
                        {
                            SwapTurns();
                        }
                        else if (!gameDice.IsDouble)
                        {
                            if (Move == gameDice.FirstDice)
                            {
                                gameDice.ResetFirstDice();
                            }
                            else
                            {
                                gameDice.ResetSecondDice();
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
            else
            {
                if (gameBoard.SecondPlayerBarCheckers > 0 &&
                    SourceIndex != barSource)
                {
                    return false;
                }
                if (gameBoard.SecondPlayerBarCheckers == 0 &&
                    SourceIndex == barSource)
                {
                    return false;
                }
                if (SourceIndex != barSource &&
                    gameBoard[SourceIndex].Color != secondPlayer.Color)
                {
                    return false;
                }
                if (SourceIndex == barSource)
                {
                    if (secondPlayer.MakeBarMove(Move, gameBoard))
                    {
                        isFirstMove = false;
                        secondPlayer.Turns--;
                        if (secondPlayer.Turns == 0)
                        {
                            SwapTurns();
                        }
                        else if (!gameDice.IsDouble)
                        {
                            if (Move == gameDice.FirstDice)
                            {
                                gameDice.ResetFirstDice();
                            }
                            else
                            {
                                gameDice.ResetSecondDice();
                            }
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                else if (secondPlayer.CheckBearOffStage(gameBoard))
                {
                    if (secondPlayer.MakeBearOffMove(SourceIndex, Move, gameBoard))
                    {
                        isFirstMove = false;
                        secondPlayer.Turns--;
                        if (secondPlayer.Turns == 0)
                        {
                            SwapTurns();
                        }
                        else if (!gameDice.IsDouble)
                        {
                            if (Move == gameDice.FirstDice)
                            {
                                gameDice.ResetFirstDice();
                            }
                            else
                            {
                                gameDice.ResetSecondDice();
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
                    if (secondPlayer.MakeMove(SourceIndex, Move, gameBoard))
                    {
                        isFirstMove = false;
                        secondPlayer.Turns--;
                        if (secondPlayer.Turns == 0)
                        {
                            SwapTurns();
                        }
                        else if (!gameDice.IsDouble)
                        {
                            if (Move == gameDice.FirstDice)
                            {
                                gameDice.ResetFirstDice();
                            }
                            else
                            {
                                gameDice.ResetSecondDice();
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
}
