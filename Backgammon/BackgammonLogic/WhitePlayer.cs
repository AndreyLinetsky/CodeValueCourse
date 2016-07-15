using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    class WhitePlayer : IHumanPlayer
    {
        private CheckerColor color;
        private int startPos;
        private int homePos;
        public WhitePlayer(CheckerColor initColor)
        {
            color = initColor;
            Turns = 0;
            IsPlayerTurn = false;
            startPos = -1;
            homePos = 18;
        }
        public bool IsPlayerTurn { get; set; }
        public int Turns { get; set; }
        public CheckerColor Color
        {
            get
            {
                return color;
            }
        }
        public bool IsPlayerWon(Board currBoard)
        {
            for (int i = 0; i < 24; i++)
            {
                if (currBoard[i].Color == color)
                {
                    return false;
                }
            }
            return true;
        }
        public bool CheckBearOffStage(Board currBoard)
        {
            for (int i = startPos + 1; i < homePos; i++)
            {
                if (currBoard[i].Color == color)
                {
                    return false;
                }
            }
            return true;
        }
        public bool MakeBarMove(int Move, Board currBoard)
        {
            if (currBoard[startPos + Move].IsAvailable(color))
            {
                if (currBoard[startPos + Move].Color == CheckerColor.Empty)
                {
                    currBoard.DecreaseSecondPlayerBar();
                    currBoard[startPos + Move].AddChecker(color);
                    return true;
                }
                else if (currBoard[startPos + Move].Color == color)
                {
                    currBoard.DecreaseSecondPlayerBar();
                    currBoard[startPos + Move].AddChecker();
                    return true;
                }
                else
                {
                    currBoard.DecreaseSecondPlayerBar();
                    currBoard.IncreaseFirstPlayerBar();
                    currBoard[startPos + Move].RemoveChecker();
                    currBoard[startPos + Move].AddChecker(color);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        public bool MakeMove(int currentIndex, int Move, Board currBoard)
        {
            if (currentIndex + Move > 23)
            {
                return false;
            }
            if (currBoard[currentIndex + Move].IsAvailable(color))
            {
                if (currBoard[currentIndex + Move].Color == CheckerColor.Empty)
                {
                    currBoard[currentIndex].RemoveChecker();
                    currBoard[currentIndex + Move].AddChecker(color);
                    return true;
                }
                else if (currBoard[currentIndex + Move].Color == color)
                {
                    currBoard[currentIndex].RemoveChecker();
                    currBoard[currentIndex + Move].AddChecker();
                    return true;
                }
                else
                {
                    currBoard[currentIndex].RemoveChecker();
                    currBoard.IncreaseFirstPlayerBar();
                    currBoard[currentIndex + Move].RemoveChecker();
                    currBoard[currentIndex + Move].AddChecker(color);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        public bool MakeBearOffMove(int currentIndex, int Move, Board currBoard)
        {
            if (currentIndex + Move > 23)
            {
                currBoard[currentIndex].RemoveChecker();
                return true;
            }

            else if (currBoard[currentIndex + Move].IsAvailable(color))
            {
                if (currBoard[currentIndex + Move].Color == CheckerColor.Empty)
                {
                    currBoard[currentIndex].RemoveChecker();
                    currBoard[currentIndex + Move].AddChecker(color);
                    return true;
                }
                else if (currBoard[currentIndex + Move].Color == color)
                {
                    currBoard[currentIndex].RemoveChecker();
                    currBoard[currentIndex + Move].AddChecker();
                    return true;
                }
                else
                {
                    currBoard[currentIndex].RemoveChecker();
                    currBoard.IncreaseFirstPlayerBar();
                    currBoard[currentIndex + Move].RemoveChecker();
                    currBoard[currentIndex + Move].AddChecker(color);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public bool CheckLegalBarMoves(Dices currDice, Board currBoard)
        {
            if (currDice.FirstDice > 0 &&
                currBoard[startPos + currDice.FirstDice].IsAvailable(color))
            {
                return true;
            }
            if (!currDice.IsDouble)
            {
                if (currDice.SecondDice > 0 &&
                    currBoard[startPos + currDice.SecondDice].IsAvailable(color))
                {
                    return true;
                }
            }
            return false;
        }
        public bool CheckLegalMoves(Dices currDice, Board currBoard)
        {
            for (int i = startPos + 1; i < 24; i++)
            {
                if (currDice.FirstDice > 0 &&
                    i + currDice.FirstDice < 24)
                {
                    if (currBoard[i + currDice.FirstDice].IsAvailable(color))
                    {
                        return true;
                    }
                }
                if (currDice.SecondDice > 0 &&
                    i + currDice.SecondDice < 24 &&
                    !currDice.IsDouble)
                {
                    if (currBoard[i + currDice.SecondDice].IsAvailable(color))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool CheckLegalBearOffMoves(Dices currDice, Board currBoard)
        {
            for (int i = homePos; i <= 23; i++)
            {
                if (currDice.FirstDice > 0 &&
                    i + currDice.FirstDice < 24)
                {
                    if (currBoard[i + currDice.FirstDice].IsAvailable(color))
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
                if (!currDice.IsDouble)
                {
                    if (currDice.SecondDice > 0 && 
                        i + currDice.SecondDice < 24)
                    {
                        if (currBoard[i + currDice.SecondDice].IsAvailable(color))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
