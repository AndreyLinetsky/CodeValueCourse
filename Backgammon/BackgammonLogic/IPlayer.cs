using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    interface IPlayer
    {
        bool IsPlayerTurn { get; set; }
        CheckerColor Color { get; }
        bool MakeMove(int currentIndex, int Move);
        bool MakeFinalMove(int currentIndex, int Move);
        bool MakeBarMove(int Move);
        List<Point> GetLegalBarMoves();
        List<Point> GetLegalMoves();
        List<Point> GetLegalFinalMoves();

    }
}
