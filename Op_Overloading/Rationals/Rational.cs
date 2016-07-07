using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    public struct Rational
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
            Rational newRational = new Rational(firstNumber.Numerator * this.Denominator + firstNumber.Denominator * this.Numerator, firstNumber.Denominator * this.Denominator);
            newRational.Reduce();
            return newRational;
        }

        public Rational Mul(Rational firstNumber)
        {
            Rational newRational = new Rational(firstNumber.Numerator * this.Numerator, firstNumber.Denominator * this.Denominator);
            newRational.Reduce();
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
            Rational newRational = firstNumber.Add(secondNumber);
            return newRational;
        }

        public static Rational operator *(Rational firstNumber, Rational secondNumber)
        {
            Rational newRational = firstNumber.Mul(secondNumber);
            return newRational;
        }

        public static Rational operator /(Rational firstNumber, Rational secondNumber)
        {
            Rational revRational = new Rational(secondNumber.Denominator, secondNumber.Numerator);
            Rational newRational = firstNumber.Mul(revRational);
            return newRational;
        }

        public static Rational operator -(Rational firstNumber, Rational secondNumber)
        {
            Rational revRational = new Rational(-1 * secondNumber.Numerator, secondNumber.Denominator);
            Rational newRational = firstNumber.Add(revRational);
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
    }
}
