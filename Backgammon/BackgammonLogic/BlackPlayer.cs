using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    public class BlackPlayer : Player
    {
        public BlackPlayer(CheckerColor initColor, int initHomePos, int initStartPos, int initEndpos, bool isAI)
            : base(initColor, initHomePos, initStartPos, initEndpos, isAI)
        {
        }

        public override bool CheckBearOffStage(Board currBoard)
        {
            for (int i = HomePos + 1; i < StartPos; i++)
            {
                if (currBoard[i].Color == Color)
                {
                    return false;
                }
            }
            return true;
        }
        public override bool CheckMoveBounds(int source, int move)
        {
            return source - move >= Endpos;

        }
        public override int GetMoveBounds(int source, int move)
        {
            return source - move;
        }
        public override bool MakeBearOffMove(int currentIndex, int target, Board currBoard)
        {
            if (target < Endpos)
            {
                if (target < Endpos - 1)
                {
                    for (int i = HomePos; i > currentIndex; i--)
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
                currBoard[StartPos - currDice.FirstDice].IsAvailable(Color))
            {
                currMoves.Add(new KeyValuePair<int, int>(currBoard.BarSource, StartPos - currDice.FirstDice));
            }
            if (!currDice.IsDouble &&
                !currDice.SecondDiceWasPlayed &&
                 currBoard[StartPos - currDice.SecondDice].IsAvailable(Color))
            {
                currMoves.Add(new KeyValuePair<int, int>(currBoard.BarSource, StartPos - currDice.SecondDice));
            }
            return currMoves;
        }
        public override IEnumerable<KeyValuePair<int, int>> GetAvailableMoves(Dices currDice, Board currBoard)
        {
            List<KeyValuePair<int, int>> currMoves = new List<KeyValuePair<int, int>>();
            for (int i = Endpos; i < StartPos; i++)
            {
                if (!currDice.FirstDiceWasPlayed &&
                    i - currDice.FirstDice >= Endpos &&
                    currBoard[i - currDice.FirstDice].IsAvailable(Color) &&
                    currBoard[i].Color == Color)
                {
                    currMoves.Add(new KeyValuePair<int, int>(i, i - currDice.FirstDice));
                }
                if (!currDice.IsDouble &&
                    !currDice.SecondDiceWasPlayed &&
                    i - currDice.SecondDice >= Endpos &&
                    currBoard[i - currDice.SecondDice].IsAvailable(Color) &&
                    currBoard[i].Color == Color)
                {
                    currMoves.Add(new KeyValuePair<int, int>(i, i - currDice.SecondDice));
                }
            }
            return currMoves;
        }
        public override IEnumerable<KeyValuePair<int, int>> GetAvailableBearOffMoves(Dices currDice, Board currBoard)
        {
            List<KeyValuePair<int, int>> currMoves = new List<KeyValuePair<int, int>>();
            for (int i = Endpos; i <= HomePos; i++)
            {
                if (!currDice.FirstDiceWasPlayed &&
                    currBoard[i].Color == Color)
                {
                    if (i - currDice.FirstDice >= Endpos)
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
                if (!currDice.IsDouble &&
                      !currDice.SecondDiceWasPlayed &&
                      currBoard[i].Color == Color)
                {
                    if (i - currDice.SecondDice >= Endpos)
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
