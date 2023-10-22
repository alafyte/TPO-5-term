using System;

namespace Lab07
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();

            int sum = calculator.Add(5, 3);
            Console.WriteLine($"Результат сложения: {sum}");

            int difference = calculator.Subtract(10, 4);
            Console.WriteLine($"Результат вычитания: {difference}");

            int product = calculator.Multiply(6, 7);
            Console.WriteLine($"Результат умножения: {product}");

            double quotient = calculator.Divide(15, 4);
            Console.WriteLine($"Результат деления: {quotient}");
        }
    }
}
