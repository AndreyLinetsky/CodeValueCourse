using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    public abstract class Player
    {
        protected Player(CheckerColor initColor, int initHomePos, int initStartPos, int initEndpos, bool isAI)
        {
            Color = initColor;
            Turns = 0;
            IsPlayerTurn = false;
            StartPos = initStartPos;
            HomePos = initHomePos;
            Endpos = initEndpos;
            IsComputer = isAI;
        }
        public int HomePos { get; }
        public int StartPos { get; }
        public int Endpos { get; }
        public bool IsPlayerTurn { get; set; }
        public int Turns { get; set; }
        public bool IsComputer { get; private set; }
        public CheckerColor Color { get; private set; }

        public bool Checklegality(Dices currDice, Board currBoard)
        {
            if (currBoard.GetBar(Color).Checkers > 0)
            {
                return GetAvailableBarMoves(currDice, currBoard).ToList().Count > 0;
            }
            else if (CheckBearOffStage(currBoard))
            {
                return GetAvailableBearOffMoves(currDice, currBoard).ToList().Count > 0;
            }
            else
            {
                return GetAvailableMoves(currDice, currBoard).ToList().Count > 0;
            }
        }

        public bool ValidateTurn(Dices currDice, Board currBoard, int sourceIndex, int targetIndex)
        {
            if (currBoard.GetBar(Color).Checkers > 0)
            {
                return GetAvailableBarMoves(currDice, currBoard).ToList().Contains(new KeyValuePair<int, int>(sourceIndex, targetIndex));
            }
            else if (CheckBearOffStage(currBoard))
            {
                return GetAvailableBearOffMoves(currDice, currBoard).ToList().Contains(new KeyValuePair<int, int>(sourceIndex, targetIndex)); ;
            }
            else
            {
                return GetAvailableMoves(currDice, currBoard).ToList().Contains(new KeyValuePair<int, int>(sourceIndex, targetIndex)); ;
            }
        }
        public bool PlayTurn(int sourceIndex, int target, Board currBoard)
        {
            if (sourceIndex == currBoard.BarSource)
            {
                return MakeBarMove(target, currBoard);
            }

            else if (CheckBearOffStage(currBoard))
            {
                return MakeBearOffMove(sourceIndex, target, currBoard);
            }
            else
            {
                return MakeMove(sourceIndex, target, currBoard);
            }
        }

        public KeyValuePair<int, int> PlayAiTurn(Dices currDice, Board currBoard)
        {
            KeyValuePair<int, int> firstMove;
            if (currBoard.GetBar(Color).Checkers > 0)
            {
                firstMove = GetAvailableBarMoves(currDice, currBoard).ToList().First();
                MakeBarMove(firstMove.Value, currBoard);
            }
            else if (CheckBearOffStage(currBoard))
            {
                firstMove = GetAvailableBearOffMoves(currDice, currBoard).ToList().First();
                MakeBearOffMove(firstMove.Key, firstMove.Value, currBoard);
            }
            else
            {
                firstMove = GetAvailableMoves(currDice, currBoard).ToList().First();
                MakeMove(firstMove.Key, firstMove.Value, currBoard);
            }
            return firstMove;
        }

        public bool MakeBarMove(int target, Board currBoard)
        {
            if (!currBoard[target].IsAvailable(Color))
            {
                return false;
            }
            if (currBoard[target].Color == CheckerColor.Empty)
            {
                currBoard.GetBar(Color).RemoveBarChecker();
                currBoard[target].AddChecker(Color);
            }
            else if (currBoard[target].Color == Color)
            {
                currBoard.GetBar(Color).RemoveBarChecker();
                currBoard[target].AddChecker();
            }
            else
            {
                currBoard.GetBar(Color).RemoveBarChecker();
                currBoard.GetOtherBar(Color).AddBarChecker();
                currBoard[target].RemoveChecker();
                currBoard[target].AddChecker(Color);
            }
            return true;
        }
        public bool MakeMove(int currentIndex, int target, Board currBoard)
        {
            if (!currBoard[target].IsAvailable(Color))
            {
                return false;
            }
            if (currBoard[target].Color == CheckerColor.Empty)
            {
                currBoard[currentIndex].RemoveChecker();
                currBoard[target].AddChecker(Color);
            }
            else if (currBoard[target].Color == Color)
            {
                currBoard[currentIndex].RemoveChecker();
                currBoard[target].AddChecker();
            }
            else
            {
                currBoard[currentIndex].RemoveChecker();
                currBoard.GetOtherBar(Color).AddBarChecker();
                currBoard[target].RemoveChecker();
                currBoard[target].AddChecker(Color);
            }
            return true;
        }
        public abstract bool CheckBearOffStage(Board currBoard);
        public abstract bool CheckMoveBounds(int source, int move);
        public abstract int GetMoveBounds(int source, int move);
        public abstract bool MakeBearOffMove(int currentIndex, int target, Board currBoard);

        public abstract IEnumerable<KeyValuePair<int, int>> GetAvailableBarMoves(Dices currDice, Board currBoard);
        public abstract IEnumerable<KeyValuePair<int, int>> GetAvailableMoves(Dices currDice, Board currBoard);
        public abstract IEnumerable<KeyValuePair<int, int>> GetAvailableBearOffMoves(Dices currDice, Board currBoard);

    }
}