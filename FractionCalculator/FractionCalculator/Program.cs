using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FractionCalculator
{
    class Program
    {
        static void Main()
        {
            // Запитуємо введення першого дробу
            Console.WriteLine("Введіть перший дріб (числівник/знаменник): ");
            Fraction a = ReadFraction();

            // Запитуємо введення другого дробу
            Console.WriteLine("Введіть другий дріб (числівник/знаменник): ");
            Fraction b = ReadFraction();

            // Запитуємо операцію
            Console.WriteLine("Оберіть операцію (+, -, *, /): ");
            char op = Console.ReadKey().KeyChar;
            Console.WriteLine();

            // Виконуємо обрану операцію та виводимо результат
            Fraction result = op switch
            {
                '+' => a + b,
                '-' => a - b,
                '*' => a * b,
                '/' => a / b,
                _ => throw new InvalidOperationException("Недійсна операція")
            };
            Console.WriteLine($"Результат: {result}");
        }

        // Метод для зчитування дробу з консолі
        static Fraction ReadFraction()
        {
            string? input = Console.ReadLine();
            string[] parts = input.Split('/');
            return new Fraction(int.Parse(parts[0]), int.Parse(parts[1]));
        }
    }
}