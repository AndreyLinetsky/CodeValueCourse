using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    interface IHumanPlayer
    {
        bool IsPlayerTurn { get; set; }
        
        CheckerColor Color { get; }
        int Turns { get; set; }
        bool IsPlayerWon(Board currBoard);
        bool CheckBearOffStage(Board currBoard);
        bool MakeBarMove(int Move, Board currBoard);
        bool MakeMove(int currentIndex, int Move, Board currBoard);
        bool MakeBearOffMove(int currentIndex, int Move, Board currBoard);
        bool CheckLegalBarMoves(Dices currDice, Board currBoard);
        bool CheckLegalMoves(Dices currDice, Board currBoard);
        bool CheckLegalBearOffMoves(Dices currDice, Board currBoard);

    }
}
