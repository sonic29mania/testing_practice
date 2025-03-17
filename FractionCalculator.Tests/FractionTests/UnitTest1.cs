using Xunit; // Для xUnit
using Xunit.Abstractions; // Добавьте эту строку

namespace FractionTests
{
    public class FractionUnitTests
    {
        private readonly ITestOutputHelper _output;

        // Конструктор для получения ITestOutputHelper
        public FractionUnitTests(ITestOutputHelper output)
        {
            _output = output;
        }
        [Fact]
        public void TestSimplify()
        {
            // Arrange
            Fraction gcd = new Fraction(4, 8);

            // Act & Assert
            Assert.Equal("1/2", gcd.ToString());

            _output.WriteLine($"Результат спрощення: {gcd.ToString()}");
        }
        [Fact]
        public void TestAddition()
        {
            // Arrange
            Fraction a = new Fraction(1, 2);
            Fraction b = new Fraction(1, 3);

            // Act
            Fraction result = a + b;

            // Assert
            Assert.Equal("5/6", result.ToString());

            // Вывод дополнительной информации
            _output.WriteLine($"Результат додавання: {result.ToString()}");
        }
        [Fact]
        public void TestSubtraction()
        {
            // Arrange
            Fraction a = new Fraction(5, 2);
            Fraction b = new Fraction(7, 3);

            // Act
            Fraction result = a - b;

            // Assert
            Assert.Equal("1/6", result.ToString());
        }
        [Fact]
        public void TestDivision() 
        {
            // Arrange
            Fraction a = new Fraction(3, 2);
            Fraction b = new Fraction(5, 3);

            // Act
            Fraction result = a / b;

            // Assert
            Assert.Equal("9/10", result.ToString());

            _output.WriteLine($"Результат ділення: {result.ToString()}");
        }
       
        [Fact]
        public void TestMultiplication()
        {
            // Arrange
            Fraction a = new Fraction(3, 3);
            Fraction b = new Fraction(5, 3);

            // Act
            Fraction result = a * b;

            // Assert
            Assert.Equal("5/3", result.ToString());

            _output.WriteLine($"Результат множення: {result.ToString()}");
        }
        [Fact]
        public void TestDivisionByZeroThrowsException()
        {
            // Arrange
            Fraction a = new Fraction(1, 2);
            Fraction b = new Fraction(0, 1);

            // Act & Assert
            var exception = Assert.Throws<DivideByZeroException>(() => a / b);

            Assert.Equal("Неможливо поділити на дріб із нульовим чисельником.", exception.Message);

            _output.WriteLine($"Повідомлення : {exception.Message}");
        }

        [Fact]
        public void TestZeroDenominatorThrowsException()
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new Fraction(1, 0));

            Assert.Equal("Знаменник не може дорівнювати нулю.", exception.Message);

            _output.WriteLine($"Повідомлення : {exception.Message}");
        }

        [Fact]
        public void TestAdditionWithSameDenominator()
        {
            // Arrange
            Fraction a = new Fraction(3, 4);
            Fraction b = new Fraction(1, 4);

            // Act
            Fraction result = a + b;

            // Assert
            Assert.Equal("1/1", result.ToString());

            _output.WriteLine($"Результат додавання з однаковими знаменниками: {result.ToString()}");
        }



    }
}

