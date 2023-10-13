using System;

namespace MyApp 
{
    class Fraction
    {
        private int numerator;
        private int denominator;

        private int GCD(int a, int b)
        {
            if (b == 0)
                return a;
            return GCD(b, a % b);
        }

        private void Reduce()
        {
            int commonFactor = GCD(Math.Abs(numerator), Math.Abs(denominator));
            numerator /= commonFactor;
            denominator /= commonFactor;
        }

        public Fraction(int num = 0, int denom = 1)
        {
            numerator = num;
            denominator = denom;
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменник не може бути нулем.");
            }
            Reduce();
        }

        public void InputFraction()
        {
            Console.Write("Введіть чисельник: ");
            numerator = int.Parse(Console.ReadLine());
            do
            {
                Console.Write("Введіть знаменник (не нуль): ");
                denominator = int.Parse(Console.ReadLine());
            } while (denominator == 0);
            Reduce();
        }

        public void DisplayFraction()
        {
            if (numerator == 0 || denominator == 0)
                Console.WriteLine(0);
            else
                Console.WriteLine($"{numerator}/{denominator}");
        }

        public Fraction Add(Fraction other)
        {
            int resultNumerator = (numerator * other.denominator) + (other.numerator * denominator);
            int resultDenominator = denominator * other.denominator;
            return new Fraction(resultNumerator, resultDenominator);
        }

        public Fraction Subtract(Fraction other)
        {
            int resultNumerator = (numerator * other.denominator) - (other.numerator * denominator);
            int resultDenominator = denominator * other.denominator;
            return new Fraction(resultNumerator, resultDenominator);
        }

        public Fraction Multiply(Fraction other)
        {
            int resultNumerator = numerator * other.numerator;
            int resultDenominator = denominator * other.denominator;
            return new Fraction(resultNumerator, resultDenominator);
        }

        public Fraction Divide(Fraction other)
        {
            if (other.numerator == 0)
            {
                throw new ArgumentException("/0");
            }
            int resultNumerator = numerator * other.denominator;
            int resultDenominator = denominator * other.numerator;
            return new Fraction(resultNumerator, resultDenominator);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Fraction fraction1, fraction2;
            fraction1 = new Fraction();
            fraction2 = new Fraction();
            fraction1.InputFraction();
            fraction2.InputFraction();

            Fraction sumFraction = fraction1.Add(fraction2);
            Console.WriteLine("sum = ");
            sumFraction.DisplayFraction();

            Console.WriteLine("\nsub = ");
            Fraction subFraction = fraction1.Subtract(fraction2);
            subFraction.DisplayFraction();

            Fraction multiplyFraction = fraction1.Multiply(fraction2);
            Console.WriteLine("\nmultiply = ");
            multiplyFraction.DisplayFraction();

            Console.WriteLine("\ndivide = ");
            Fraction divideFraction = fraction1.Divide(fraction2);
            divideFraction.DisplayFraction();
        }
    }
}