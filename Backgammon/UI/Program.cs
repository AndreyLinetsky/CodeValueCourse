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
        public static void drawBoard(Point[] points, int blackbar, int whitebar)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("12 13 14 15 16 17 18 19 20 21 22 23");
            for (int i = points.Length / 2; i < points.Length; i++)
            {
                if (points[i].Color == CheckerColor.Empty)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("{0}  ", 0);
                }
                else if (points[i].Color == CheckerColor.Black)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("{0}  ", points[i].CheckersAmount);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0}  ", points[i].CheckersAmount);
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            for (int i = points.Length / 2 - 1; i >= 0; i--)
            {
                if (points[i].Color == CheckerColor.Empty)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("{0}  ", 0);
                }
                else if (points[i].Color == CheckerColor.Black)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("{0}  ", points[i].CheckersAmount);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0}  ", points[i].CheckersAmount);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("11 10 9  8  7  6  5  4  3  2  1  0");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Bar");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(blackbar);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(whitebar);
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            GameController newGame = new GameController(1);
            bool isLastMoveLegal = true;
            drawBoard(newGame.GetBoard, newGame.FirstPlayerCheckersOnBar, newGame.SecondPlayerCheckersOnBar);
            Console.WriteLine("Randomazing turns order");
            newGame.DecideFirstTurn();
            Console.WriteLine("First player is {0}", newGame.CurrentPlayer);
            while (!newGame.IsGameOver)
            {
                Console.WriteLine("It is {0} player turn", newGame.CurrentPlayer);
                if (isLastMoveLegal)
                {
                    newGame.ThrowDice();

                    Console.WriteLine("First dice is {0},second dice is {1}", newGame.FirstDice, newGame.secondDice);
                    if (!newGame.CheckLegalMoves())
                    {
                        Console.WriteLine("No legal turns were found,you skip your turn");
                        continue;
                    }
                }
                Console.WriteLine("Please write move source(0-23,bar is 24)");
                int source = int.Parse(Console.ReadLine());
                Console.WriteLine("Please write move (1-6)");
                int move = int.Parse(Console.ReadLine());
                if (!newGame.PlayTurn(source, move))
                {
                    Console.WriteLine("Illegal move");
                    isLastMoveLegal = false;
                    continue;
                }
                else
                {
                    drawBoard(newGame.GetBoard, newGame.FirstPlayerCheckersOnBar, newGame.SecondPlayerCheckersOnBar);
                    isLastMoveLegal = true;
                }
                while (!newGame.IsFirstMove)
                {
                    if (!newGame.CheckLegalMoves())
                    {
                        Console.WriteLine("No legal turns were found,you skip your turn");
                        continue;
                    }
                    Console.WriteLine("{0} player please play your next turn", newGame.CurrentPlayer);
                    Console.WriteLine("Please write move source(0-23,bar is 24)");
                    source = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please write move (1-6)");
                    move = int.Parse(Console.ReadLine());
                    if (!newGame.PlayTurn(source, move))
                    {
                        Console.WriteLine("Illegal move");
                    }
                    else
                    {
                        drawBoard(newGame.GetBoard, newGame.FirstPlayerCheckersOnBar, newGame.SecondPlayerCheckersOnBar);
                    }
                }
            }
        }
    }
}
