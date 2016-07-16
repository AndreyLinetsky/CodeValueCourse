using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    public class GreenPlayer : HumanPlayer
    {
        public GreenPlayer(CheckerColor initColor, int initHomePos, int initStartPos, int initEndPos)
            : base(initColor, initHomePos, initStartPos, initEndPos)
        {
        }

        public override bool CheckBearOffStage(Board currBoard)
        {
            for (int i = startPos + 1; i < homePos; i++)
            {
                if (currBoard[i].Color == Color)
                {
                    return false;
                }
            }
            return true;
        }
        public override bool MakeBarMove(int move, Board currBoard)
        {
            if (currBoard[startPos + move].IsAvailable(Color))
            {
                if (currBoard[startPos + move].Color == CheckerColor.Empty)
                {
                    currBoard.GetBar(Color).RemoveBarChecker();
                    currBoard[startPos + move].AddChecker(Color);
                    return true;
                }
                else if (currBoard[startPos + move].Color == Color)
                {
                    currBoard.GetBar(Color).RemoveBarChecker();
                    currBoard[startPos + move].AddChecker();
                    return true;
                }
                else
                {
                    currBoard.GetBar(Color).RemoveBarChecker();
                    currBoard.GetOtherBar(Color).AddBarChecker();
                    currBoard[startPos + move].RemoveChecker();
                    currBoard[startPos + move].AddChecker(Color);
                    return true;
                }
            }
            return false;
        }
        public override bool MakeMove(int currentIndex, int move, Board currBoard)
        {
            if (currentIndex + move > endpos)
            {
                return false;
            }
            if (currBoard[currentIndex + move].IsAvailable(Color))
            {
                if (currBoard[currentIndex + move].Color == CheckerColor.Empty)
                {
                    currBoard[currentIndex].RemoveChecker();
                    currBoard[currentIndex + move].AddChecker(Color);
                    return true;
                }
                else if (currBoard[currentIndex + move].Color == Color)
                {
                    currBoard[currentIndex].RemoveChecker();
                    currBoard[currentIndex + move].AddChecker();
                    return true;
                }
                else
                {
                    currBoard[currentIndex].RemoveChecker();
                    currBoard.GetOtherBar(Color).AddBarChecker();
                    currBoard[currentIndex + move].RemoveChecker();
                    currBoard[currentIndex + move].AddChecker(Color);
                    return true;
                }
            }
            return false;
        }
        public override bool MakeBearOffMove(int currentIndex, int move, Board currBoard)
        {
            if (currentIndex + move > endpos)
            {
                if (currentIndex + move > endpos + 1)
                {
                    for (int i = homePos; i < currentIndex; i++)
                    {
                        if (currBoard[i].Color == Color)
                        {
                            return false;
                        }
                    }
                }
                currBoard[currentIndex].RemoveChecker();
                return true;
            }

            else if (currBoard[currentIndex + move].IsAvailable(Color))
            {
                if (currBoard[currentIndex + move].Color == CheckerColor.Empty)
                {
                    currBoard[currentIndex].RemoveChecker();
                    currBoard[currentIndex + move].AddChecker(Color);
                    return true;
                }
                else if (currBoard[currentIndex + move].Color == Color)
                {
                    currBoard[currentIndex].RemoveChecker();
                    currBoard[currentIndex + move].AddChecker();
                    return true;
                }
                else
                {
                    currBoard[currentIndex].RemoveChecker();
                    currBoard.GetOtherBar(Color).AddBarChecker();
                    currBoard[currentIndex + move].RemoveChecker();
                    currBoard[currentIndex + move].AddChecker(Color);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public override bool CheckLegalBarMoves(Dices currDice, Board currBoard)
        {
            if (!currDice.FirstDiceWasPlayed &&
                currBoard[startPos + currDice.FirstDice].IsAvailable(Color))
            {
                return true;
            }
            return !currDice.IsDouble &&
                    !currDice.SecondDiceWasPlayed &&
                    currBoard[startPos + currDice.SecondDice].IsAvailable(Color);
        }
        public override bool CheckLegalMoves(Dices currDice, Board currBoard)
        {
            for (int i = startPos + 1; i <= endpos; i++)
            {
                if (!currDice.FirstDiceWasPlayed &&
                    i + currDice.FirstDice <= endpos &&
                    currBoard[i + currDice.FirstDice].IsAvailable(Color))
                {
                    return true;
                }
                if (!currDice.IsDouble &&
                    !currDice.SecondDiceWasPlayed &&
                    i + currDice.SecondDice <= endpos &&
                    currBoard[i + currDice.SecondDice].IsAvailable(Color))
                {
                    return true;
                }
            }
            return false;
        }
        public override bool CheckLegalBearOffMoves(Dices currDice, Board currBoard)
        {
            for (int i = homePos; i <= endpos; i++)
            {
                if (!currDice.FirstDiceWasPlayed)
                {
                    if (i + currDice.FirstDice <= endpos)
                    {
                        if (currBoard[i + currDice.FirstDice].IsAvailable(Color))
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
                         !currDice.SecondDiceWasPlayed)
                {
                    if (i + currDice.SecondDice <= endpos)
                    {
                        if (currBoard[i + currDice.SecondDice].IsAvailable(Color))
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
