using Lab07;
using NUnit.Framework;

namespace CalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [Test]
        public void Add_ShouldReturnSumOfTwoNumbers()
        {
            var result = calculator.Add(5, 10);
            Assert.That(result, Is.EqualTo(15));
        }

        [Test]
        public void Subtract_ShouldReturnDifferenceOfTwoPositiveNumbers()
        {
            var result = calculator.Subtract(10, 5);
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void Subtract_ShouldReturnSumOfTwoNegativeNumbers()
        {
            var result = calculator.Subtract(10, -35);
            Assert.That(result, Is.EqualTo(45));
        }

        [Test]
        public void Subtract_ShouldReturnDifferenceOfTwoNumbers()
        {
            var result = calculator.Subtract(10, 35);
            Assert.That(result, Is.EqualTo(-25));
        }

        [Test]
        public void Multiply_ShouldReturnProductOfTwoNumbers()
        {
            var result = calculator.Multiply(5, 10);
            Assert.That(result, Is.EqualTo(50));
        }

        [Test]
        public void Multiply_ShouldReturnProductOfPositiveAndNegativeNumbers()
        {
            var result = calculator.Multiply(5, -3);
            Assert.That(result, Is.EqualTo(-15));
        }

        [Test]
        public void Divide_ShouldReturnQuotientOfTwoNumbers()
        {
            var result = calculator.Divide(10, 5);
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Divide_ShouldReturnQuotientOfTwoNumbersWithDecimalResult()
        {
            var result = calculator.Divide(10, 4);
            Assert.That(result, Is.EqualTo(2.5f));
        }

        [Test]
        public void Divide_ShouldThrowArgumentExceptionWhenDividingByZero()
        {
            Assert.Throws<ArgumentException>(() => calculator.Divide(10, 0));
        }

        [TestCase(5, 5, 1.0f)]
        [TestCase(10, 5, 2.0f)]
        [TestCase(0, 5, 0.0f)]
        public void Divide_ShouldReturnExpectedQuotient(int a, int b, double expected)
        {
            var result = calculator.Divide(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
