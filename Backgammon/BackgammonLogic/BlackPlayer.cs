using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    public class BlackPlayer : Player
    {
        public BlackPlayer(CheckerColor initColor, int initHomePos, int initStartPos, int initEndPos, bool isAI)
            : base(initColor, initHomePos, initStartPos, initEndPos, isAI)
        {
        }

        public override bool CheckBearOffStage(Board currBoard)
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

        public override bool CheckMoveBounds(int target)
        {
            return target >= endpos;
        }
        public override int CheckMoveBounds(int source, int move)
        {
            if (source - move >= endpos)
            {
                return source - move;
            }
            else
            {
                return -1;
            }
        }
        public override bool MakeBearOffMove(int currentIndex, int target, Board currBoard)
        {
            if (target < endpos)
            {
                if (target < endpos - 1)
                {
                    for (int i = homePos; i > currentIndex; i--)
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
            else
            {
                return MakeMove(currentIndex, target, currBoard);
            }
        }

        public override IEnumerable<KeyValuePair<int, int>> GetAvailableBarMoves(Dices currDice, Board currBoard)
        {
            List<KeyValuePair<int, int>> currMoves = new List<KeyValuePair<int, int>>();
            if (!currDice.FirstDiceWasPlayed &&
                currBoard[startPos - currDice.FirstDice].IsAvailable(Color))
            {
                currMoves.Add(new KeyValuePair<int, int>(currBoard.BarSource, startPos - currDice.FirstDice));
            }
            if (!currDice.IsDouble &&
                !currDice.SecondDiceWasPlayed &&
                 currBoard[startPos - currDice.SecondDice].IsAvailable(Color))
            {
                currMoves.Add(new KeyValuePair<int, int>(currBoard.BarSource, startPos - currDice.SecondDice));
            }
            return currMoves;
        }
        public override IEnumerable<KeyValuePair<int, int>> GetAvailableMoves(Dices currDice, Board currBoard)
        {
            List<KeyValuePair<int, int>> currMoves = new List<KeyValuePair<int, int>>();
            for (int i = endpos; i < startPos; i++)
            {
                if (!currDice.FirstDiceWasPlayed &&
                    i - currDice.FirstDice >= endpos &&
                    currBoard[i - currDice.FirstDice].IsAvailable(Color))
                {
                    currMoves.Add(new KeyValuePair<int, int>(i, i - currDice.FirstDice));
                }
                if (!currDice.IsDouble &&
                    !currDice.SecondDiceWasPlayed &&
                    i - currDice.SecondDice >= endpos &&
                    currBoard[i - currDice.SecondDice].IsAvailable(Color))
                {
                    currMoves.Add(new KeyValuePair<int, int>(i, i - currDice.SecondDice));
                }
            }
            return currMoves;
        }
        public override IEnumerable<KeyValuePair<int, int>> GetAvailableBearOffMoves(Dices currDice, Board currBoard)
        {
            List<KeyValuePair<int, int>> currMoves = new List<KeyValuePair<int, int>>();
            for (int i = endpos; i <= homePos; i++)
            {
                if (!currDice.FirstDiceWasPlayed)
                {
                    if (i - currDice.FirstDice >= endpos)
                    {
                        if (currBoard[i - currDice.FirstDice].IsAvailable(Color))
                        {
                            currMoves.Add(new KeyValuePair<int, int>(i, i - currDice.FirstDice));
                        }
                    }
                    else
                    {
                        currMoves.Add(new KeyValuePair<int, int>(i, i - currDice.FirstDice));
                    }
                }
                else if (!currDice.IsDouble &&
                       !currDice.SecondDiceWasPlayed)
                {
                    if (i - currDice.SecondDice >= endpos)
                    {
                        if (currBoard[i - currDice.SecondDice].IsAvailable(Color))
                        {
                            currMoves.Add(new KeyValuePair<int, int>(i, i - currDice.SecondDice));
                        }
                    }
                    else
                    {
                        currMoves.Add(new KeyValuePair<int, int>(i, i - currDice.SecondDice));
                    }
                }
            }
            return currMoves;
        }
    }
}
