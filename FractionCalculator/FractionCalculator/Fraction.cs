using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionCalculator
{
    public class Fraction
    {
        public int Numerator { get; private set; }   // Числівник
        public int Denominator { get; private set; } // Знаменник

        // Конструктор дробу
        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Знаменник не може бути нулем.");
            Numerator = numerator;
            Denominator = denominator;
            Simplify(); // Спрощуємо дріб одразу після створення
        }

        // Метод для спрощення дробу
        private void Simplify()
        {
            int gcd = GCD(Numerator, Denominator);
            Numerator /= gcd;
            Denominator /= gcd;
        }

        // Обчислення найбільшого спільного дільника (НСД)
        private int GCD(int a, int b)
        {
            return b == 0 ? Math.Abs(a) : GCD(b, a % b);
        }

        // Оператор додавання
        public static Fraction operator +(Fraction a, Fraction b)
        {
            return new Fraction(
                a.Numerator * b.Denominator + b.Numerator * a.Denominator,
                a.Denominator * b.Denominator);
        }

        // Оператор віднімання
        public static Fraction operator -(Fraction a, Fraction b)
        {
            return new Fraction(
                a.Numerator * b.Denominator - b.Numerator * a.Denominator,
                a.Denominator * b.Denominator);
        }

        // Оператор множення
        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }

        // Оператор ділення
        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.Numerator == 0)
                throw new DivideByZeroException("Ділення на нуль неможливе.");
            return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        // Перевизначення методу для виведення дробу у вигляді рядка
        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
    }
}
