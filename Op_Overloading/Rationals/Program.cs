using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    class Program
    {
        static void Main(string[] args)
        {
            Rational firstRational = new Rational(10, 15);
            Rational secondRational = new Rational(7);
            Rational thirdRational = new Rational(2, 3);
            Console.WriteLine("First rat double value - {0}", firstRational.Value);
            Console.WriteLine(firstRational.ToString());
            Console.WriteLine("Second rat double value - {0}", secondRational.Value);
            Console.WriteLine(secondRational.ToString());
            // +
            Rational fourthRational = firstRational + thirdRational;
            Console.WriteLine("Fourth rat double value - {0}", fourthRational.Value);
            Console.WriteLine(fourthRational.ToString());
            fourthRational = secondRational + thirdRational;
            Console.WriteLine("Fourth rat double value - {0}", fourthRational.Value);
            Console.WriteLine(fourthRational.ToString());
            // *
            fourthRational = firstRational * thirdRational;
            Console.WriteLine("Fourth rat double value - {0}", fourthRational.Value);
            Console.WriteLine(fourthRational.ToString());
            fourthRational = secondRational * thirdRational;
            Console.WriteLine("Fourth rat double value - {0}", fourthRational.Value);
            Console.WriteLine(fourthRational.ToString());
            // -
            fourthRational = firstRational - thirdRational;
            Console.WriteLine("Fourth rat double value - {0}", fourthRational.Value);
            Console.WriteLine(fourthRational.ToString());
            fourthRational = secondRational - thirdRational;
            Console.WriteLine("Fourth rat double value - {0}", fourthRational.Value);
            Console.WriteLine(fourthRational.ToString());
            // /
            fourthRational = firstRational / thirdRational;
            Console.WriteLine("Fourth rat double value - {0}", fourthRational.Value);
            Console.WriteLine(fourthRational.ToString());
            fourthRational = secondRational / thirdRational;
            Console.WriteLine("Fourth rat double value - {0}", fourthRational.Value);
            Console.WriteLine(fourthRational.ToString());
            // int to rational
            int testNum = 5;
            Rational intRational = testNum;
            Console.WriteLine("Int rational double value - {0}", (double)intRational);
            Console.WriteLine(intRational.ToString());
            // rational to double
            double testDouble = (double)firstRational;
            Console.WriteLine("First rational double value is: {0}", testDouble);
        }
    }
}
