using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionTests
{
    internal class Fraction
    {
        public int Denominator { get; set; } // знаменник
        public int Numerator { get; set; }   // чисельник

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменник не може дорівнювати нулю.");
            }
            Numerator = numerator;
            Denominator = denominator;
            Simplify(); // Спрощуємо дріб одразу після створення
        }

        // Метод для спрощення дробу
        private void Simplify()
        {
            int gcd = GCD(Math.Abs(Numerator), Math.Abs(Denominator)); // Знаходимо НСД
            Numerator /= gcd;
            Denominator /= gcd;

            // Переносимо знак у чисельник, щоб знаменник завжди був додатнім
            if (Denominator < 0)
            {
                Numerator = -Numerator;
                Denominator = -Denominator;
            }
        }

        // Метод для знаходження найбільшого спільного дільника (НСД)
        private int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        // Операція додавання
        public static Fraction operator +(Fraction a, Fraction b)
        {
            int commonDenominator = a.Denominator * b.Denominator;
            int numerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
            return new Fraction(numerator, commonDenominator);
        }

        // Операція віднімання
        public static Fraction operator -(Fraction a, Fraction b)
        {
            int commonDenominator = a.Denominator * b.Denominator;
            int numerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
            return new Fraction(numerator, commonDenominator);
        }

        // Операція множення
        public static Fraction operator *(Fraction a, Fraction b)
        {
            int numerator = a.Numerator * b.Numerator;
            int denominator = a.Denominator * b.Denominator;
            return new Fraction(numerator, denominator);
        }

        // Операція ділення
        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.Numerator == 0)
            {
                throw new DivideByZeroException("Неможливо поділити на дріб із нульовим чисельником.");
            }
            int numerator = a.Numerator * b.Denominator;
            int denominator = a.Denominator * b.Numerator;
            return new Fraction(numerator, denominator);
        }

        // Перевизначення методу ToString для зручного відображення дробів
        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
    }
}
