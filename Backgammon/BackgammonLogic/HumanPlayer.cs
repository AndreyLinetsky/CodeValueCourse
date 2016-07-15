using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    abstract class HumanPlayer : IHumanPlayer
    {
        protected readonly int homePos;
        protected readonly int startPos;
        protected readonly int endpos;
        public HumanPlayer(CheckerColor initColor, int initHomePos, int initStartPos, int initEndPos)
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

        public abstract bool CheckBearOffStage(Board currBoard);

        public bool IsPlayerWin(Board currBoard)
        {
            for (int i = 0; i < 24; i++)
            {
                if (currBoard[i].Color == Color)
                {
                    return false;
                }
            }
            return true;
        }
        public abstract bool MakeBarMove(int Move, Board currBoard);

        public abstract bool MakeMove(int currentIndex, int Move, Board currBoard);

        public abstract bool MakeBearOffMove(int currentIndex, int Move, Board currBoard);

        public abstract bool CheckLegalBarMoves(Dices currDice, Board currBoard);

        public abstract bool CheckLegalMoves(Dices currDice, Board currBoard);

        public abstract bool CheckLegalBearOffMoves(Dices currDice, Board currBoard);
    }
}