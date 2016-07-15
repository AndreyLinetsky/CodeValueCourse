using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    class BlackPlayer : HumanPlayer
    {
        public BlackPlayer(CheckerColor initColor, int initHomePos, int initStartPos, int initEndPos)
            : base(initColor, initHomePos, initStartPos, initEndPos)
        {
        }

        public bool CheckBearOffStage(Board currBoard)
        {
            for (int i = homePos + 1; i < startPos; i++)
            {
                if (currBoard[i].Color == Color)
                {
                    return false;
                }
            }
            return true;
        }

        public bool MakeBarMove(int Move, Board currBoard)
        {
            if (currBoard[startPos - Move].IsAvailable(Color))
            {
                if (currBoard[startPos - Move].Color == CheckerColor.Empty)
                {
                    currBoard.GetBar(Color).RemoveBarChecker();
                    currBoard[startPos - Move].AddChecker(Color);
                    return true;
                }
                else if (currBoard[startPos - Move].Color == Color)
                {
                    currBoard.GetBar(Color).RemoveBarChecker();
                    currBoard[startPos - Move].AddChecker();
                    return true;
                }
                else
                {
                    currBoard.GetBar(Color).RemoveBarChecker();
                    currBoard.GetOtherBar(Color).AddBarChecker();
                    currBoard[startPos - Move].RemoveChecker();
                    currBoard[startPos - Move].AddChecker(Color);
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
            if (currentIndex - Move < startPos)
            {
                return false;
            }
            if (currBoard[currentIndex - Move].IsAvailable(Color))
            {
                if (currBoard[currentIndex - Move].Color == CheckerColor.Empty)
                {
                    currBoard[currentIndex].RemoveChecker();
                    currBoard[currentIndex - Move].AddChecker(Color);
                    return true;
                }
                else if (currBoard[currentIndex - Move].Color == Color)
                {
                    currBoard[currentIndex].RemoveChecker();
                    currBoard[currentIndex - Move].AddChecker();
                    return true;
                }
                else
                {
                    currBoard[currentIndex].RemoveChecker();
                    currBoard.GetOtherBar(Color).AddBarChecker();
                    currBoard[currentIndex - Move].RemoveChecker();
                    currBoard[currentIndex - Move].AddChecker(Color);
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
            if (currentIndex - Move < startPos)
            {
                if (currentIndex - Move < startPos - 1)
                {
                    for (int i = homePos; i > currentIndex; i--)
                    {
                        if (currBoard[i].IsAvailable(Color))
                        {
                            return false;
                        }
                    }
                }
                currBoard[currentIndex].RemoveChecker();
                return true;
            }

            else if (currBoard[currentIndex - Move].IsAvailable(Color))
            {
                if (currBoard[currentIndex - Move].Color == CheckerColor.Empty)
                {
                    currBoard[currentIndex].RemoveChecker();
                    currBoard[currentIndex - Move].AddChecker(Color);
                    return true;
                }
                else if (currBoard[currentIndex - Move].Color == Color)
                {
                    currBoard[currentIndex].RemoveChecker();
                    currBoard[currentIndex - Move].AddChecker();
                    return true;
                }
                else
                {
                    currBoard[currentIndex].RemoveChecker();
                    currBoard.GetOtherBar(Color).AddBarChecker();
                    currBoard[currentIndex - Move].RemoveChecker();
                    currBoard[currentIndex - Move].AddChecker(Color);
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
                currBoard[startPos - currDice.FirstDice].IsAvailable(Color))
            {
                return true;
            }
            if (!currDice.IsDouble)
            {
                if (currDice.SecondDice > 0 &&
                    currBoard[startPos - currDice.SecondDice].IsAvailable(Color))
                {
                    return true;
                }
            }
            return false;
        }
        public bool CheckLegalMoves(Dices currDice, Board currBoard)
        {
            for (int i = endpos; i < startPos; i++)
            {
                if (currDice.FirstDice > 0 &&
                    i - currDice.FirstDice >= endpos)
                {
                    if (currBoard[i - currDice.FirstDice].IsAvailable(Color))
                    {
                        return true;
                    }
                }
                if (currDice.SecondDice > 0 && i - currDice.SecondDice >= endpos &&
                    !currDice.IsDouble)
                {
                    if (currBoard[i - currDice.SecondDice].IsAvailable(Color))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool CheckLegalBearOffMoves(Dices currDice, Board currBoard)
        {
            for (int i = startPos; i <= homePos; i++)
            {
                if (currDice.FirstDice > 0)
                {
                    if (i - currDice.FirstDice >= endpos)
                    {
                        if (currBoard[i - currDice.FirstDice].IsAvailable(Color))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
                else if (!currDice.IsDouble &&
                        currDice.SecondDice > 0)
                {
                    if (i - currDice.SecondDice >= endpos)
                    {
                        if (currBoard[i - currDice.SecondDice].IsAvailable(Color))
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
