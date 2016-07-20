using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    public class Dices
    {
        public Dices()
        {
            DisableFirstDice();
            DisableSecondDice();
            FirstDice = 0;
            SecondDice = 0;
        }
        public int FirstDice { get; private set; }
        public int SecondDice { get; private set; }

        public bool IsDouble
        {
            get
            {
                return FirstDice == SecondDice;
            }
        }

        public bool FirstDiceWasPlayed { get; private set; }
       
        public bool SecondDiceWasPlayed { get; private set; }
        

        public void ThrowDice()
        {
            Random rnd = new Random();
            FirstDice = rnd.Next(1, 7);
            SecondDice = rnd.Next(1, 7);
            FirstDiceWasPlayed = false;
            SecondDiceWasPlayed = false;
        }
        public void DisableFirstDice()
        {
            FirstDiceWasPlayed = true;
        }
        public void DisableSecondDice()
        {
            SecondDiceWasPlayed = true;
        }
    }
}