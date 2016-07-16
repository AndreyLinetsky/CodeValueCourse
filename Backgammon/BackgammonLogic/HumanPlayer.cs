using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    public abstract class HumanPlayer : IPlayer
    {
        protected readonly int homePos;
        protected readonly int startPos;
        protected readonly int endpos;

        protected HumanPlayer(CheckerColor initColor, int initHomePos, int initStartPos, int initEndPos)
        {
            Color = initColor;
            Turns = 0;
            IsPlayerTurn = false;
            startPos = initStartPos;
            homePos = initHomePos;
            endpos = initEndPos;
        }
        public bool IsPlayerTurn { get; set; }
        public int Turns { get; set; }
        public CheckerColor Color { get; private set; }

        public bool Checklegality(Dices currDice, Board currBoard)
        {
            if (currBoard.GetBar(Color).Checkers > 0)
            {
                return CheckLegalBarMoves(currDice, currBoard);
            }
            else if (CheckBearOffStage(currBoard))
            {
                return CheckLegalBearOffMoves(currDice, currBoard);
            }
            else
            {
                return CheckLegalMoves(currDice, currBoard);
            }
        }
        public bool PlayTurn(int sourceIndex, int move, Board currBoard)
        {
            if (sourceIndex == currBoard.BarSource)
            {
                return MakeBarMove(move, currBoard);
            }

            else if (CheckBearOffStage(currBoard))
            {
                return MakeBearOffMove(sourceIndex, move, currBoard);
            }
            else
            {
                return MakeMove(sourceIndex, move, currBoard);
            }
        }

        public abstract bool CheckBearOffStage(Board currBoard);


        public abstract bool MakeBarMove(int move, Board currBoard);

        public abstract bool MakeMove(int currentIndex, int move, Board currBoard);

        public abstract bool MakeBearOffMove(int currentIndex, int move, Board currBoard);

        public abstract bool CheckLegalBarMoves(Dices currDice, Board currBoard);

        public abstract bool CheckLegalMoves(Dices currDice, Board currBoard);

        public abstract bool CheckLegalBearOffMoves(Dices currDice, Board currBoard);
    }
}