using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    class Program
    {
        struct Rational
        {
            private int numerator;
            private int denominator;

            public Rational(int newNumerator, int newDenominator)
            {
                numerator = newNumerator;
                denominator = newDenominator;
            }

            public Rational(int newNumerator)
            {
                numerator = newNumerator;
                denominator = 1;
            }

            public int Numerator
            {
                get
                {
                    return numerator;
                }
            }

            public int Denominator
            {
                get
                {
                    return denominator;
                }
            }

            public double Value
            {
                get
                {
                    return (double)numerator / denominator;
                }
            }

            public Rational Add(Rational firstNumber)
            {
                Rational secondNumber = this;
                int firstDenominator = firstNumber.denominator;
                firstNumber.denominator = firstNumber.denominator * secondNumber.denominator;
                firstNumber.numerator = firstNumber.numerator * secondNumber.denominator;
                secondNumber.denominator = secondNumber.denominator * firstDenominator;
                secondNumber.numerator = secondNumber.numerator * firstDenominator;
                Rational newRational = new Rational(firstNumber.numerator + secondNumber.numerator, firstNumber.denominator);
                return newRational;
            }

            public Rational Mul(Rational firstNumber)
            {
                Rational newRational = new Rational(firstNumber.numerator * this.numerator, firstNumber.denominator * this.denominator);
                return newRational;
            }

            public void Reduce()
            {
                int numerator = this.numerator;
                int denominator = this.denominator;
                int remainder;
                while (denominator != 0)
                {
                    remainder = numerator % denominator;
                    numerator = denominator;
                    denominator = remainder;
                }
                if (numerator > 1)
                {
                    this.numerator = this.numerator / numerator;
                    this.denominator = this.denominator / numerator;
                }
            }
            public override string ToString()
            {
                return (String.Format("Fraction value is {0}/{1}", this.Numerator, this.Denominator));
            }

            public override bool Equals(object obj)
            {
                if (obj == null)
                {
                    return false;
                }
                Rational firstRational = this;
                if (!(obj is Rational))
                {
                    return false;
                }
                Rational secondRational = (Rational)obj;
                firstRational.Reduce();
                secondRational.Reduce();
                if (firstRational.Numerator == secondRational.Numerator &&
                    firstRational.Denominator == secondRational.Denominator)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public override int GetHashCode()
            {
                return this.Value.GetHashCode();
            }

            public static Rational operator +(Rational firstNumber, Rational secondNumber)
            {
                firstNumber.Reduce();
                secondNumber.Reduce();
                if (firstNumber.Denominator != secondNumber.Denominator)
                {
                    int firstDenominator = firstNumber.denominator;
                    firstNumber.denominator = firstNumber.denominator * secondNumber.denominator;
                    firstNumber.numerator = firstNumber.numerator * secondNumber.denominator;
                    secondNumber.denominator = secondNumber.denominator * firstDenominator;
                    secondNumber.numerator = secondNumber.numerator * firstDenominator;
                }
                Rational newRational = new Rational(firstNumber.numerator + secondNumber.numerator, firstNumber.denominator);
                return newRational;
            }

            public static Rational operator *(Rational firstNumber, Rational secondNumber)
            {
                firstNumber.Reduce();
                secondNumber.Reduce();
                Rational newRational = new Rational(firstNumber.numerator * secondNumber.numerator, firstNumber.denominator * secondNumber.denominator);
                return newRational;
            }

            public static Rational operator /(Rational firstNumber, Rational secondNumber)
            {
                firstNumber.Reduce();
                secondNumber.Reduce();
                Rational revRational = new Rational(secondNumber.Denominator, secondNumber.Numerator);
                Rational newRational = firstNumber.Mul(revRational);
                return newRational;
            }

            public static Rational operator -(Rational firstNumber, Rational secondNumber)
            {
                firstNumber.Reduce();
                secondNumber.Reduce();
                if (firstNumber.Denominator != secondNumber.Denominator)
                {
                    int firstDenominator = firstNumber.denominator;
                    firstNumber.denominator = firstNumber.denominator * secondNumber.denominator;
                    firstNumber.numerator = firstNumber.numerator * secondNumber.denominator;
                    secondNumber.denominator = secondNumber.denominator * firstDenominator;
                    secondNumber.numerator = secondNumber.numerator * firstDenominator;
                }
                Rational newRational = new Rational(firstNumber.numerator - secondNumber.numerator, firstNumber.denominator);
                return newRational;
            }
            public static implicit operator Rational(int num)
            {
                Rational newRational = new Rational(num);
                return newRational;
            }

            public static explicit operator double(Rational rational)
            {
                return rational.Value;
            }
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
}