using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    public interface IPlayer
    {
        bool IsPlayerTurn { get; set; }
        CheckerColor Color { get; }
        int Turns { get; set; }
        bool CheckBearOffStage(Board currBoard);
        bool MakeBarMove(int move, Board currBoard);
        bool MakeMove(int currentIndex, int move, Board currBoard);
        bool MakeBearOffMove(int currentIndex, int move, Board currBoard);
        bool CheckLegalBarMoves(Dices currDice, Board currBoard);
        bool CheckLegalMoves(Dices currDice, Board currBoard);
        bool CheckLegalBearOffMoves(Dices currDice, Board currBoard);

    }
}
