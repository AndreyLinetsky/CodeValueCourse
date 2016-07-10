using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackgammonLogic;
namespace UI
{
    class Program
    {
        public static void drawBoard()
        {
            
        }
        public static void initBoard(Pair[] points)
        {
            for (int i = 0; i < points.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        points[i] = new Pair(2, CheckerColor.White);
                        break;
                    case 5:
                        points[i] = new Pair(5, CheckerColor.Black);
                        break;
                    case 7:
                        points[i] = new Pair(3, CheckerColor.Black);
                        break;
                    case 11:
                        points[i] = new Pair(5, CheckerColor.White);
                        break;
                    case 12:
                        points[i] = new Pair(5, CheckerColor.Black);
                        break;
                    case 16:
                        points[i] = new Pair(3, CheckerColor.White);
                        break;
                    case 18:
                        points[i] = new Pair(5, CheckerColor.White);
                        break;
                    case 23:
                        points[i] = new Pair(2, CheckerColor.Black);
                        break;
                    default:
                        points[i] = new Pair();
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            //Pair[] arr = new Pair[24];
           // initBoard(arr);
            //drawBoard();
            GameController newGame = new GameController();
            Console.WriteLine("First player is {0}", newGame.DecideFirstTurn());
             newGame.ThrowDice();
            bool t = newGame.CheckLegalMoves();
            t =newGame.PlayTurn(23, 2);
           
            t = newGame.CheckLegalMoves();
            t = newGame.PlayTurn(13, 2);
            newGame.ThrowDice();
            t = newGame.CheckLegalMoves();
            t = newGame.PlayTurn(18, 2);
        }
    }
}
