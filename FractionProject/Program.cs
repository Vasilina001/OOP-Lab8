using System;
using Fractions;

class Program
{
    static void Main()
    {
        // Створення дробів
        Fraction f1 = new Fraction(3, 4);
        Fraction f2 = new Fraction(2, 5);
        Fraction f3 = new Fraction(6); // ціле число
        Fraction f4 = new Fraction();  // дріб за замовчуванням (0/1)

        Console.WriteLine($"f1 = {f1}"); // 3/4
        Console.WriteLine($"f2 = {f2}"); // 2/5
        Console.WriteLine($"f3 = {f3}"); // 6/1
        Console.WriteLine($"f4 = {f4}"); // 0/1

        // Арифметичні операції
        Console.WriteLine($"\nАрифметичні операції:");
        Console.WriteLine($"{f1} + {f2} = {f1 + f2}"); // 23/20
        Console.WriteLine($"{f1} - {f2} = {f1 - f2}"); // 7/20
        Console.WriteLine($"{f1} * {f2} = {f1 * f2}"); // 3/10
        Console.WriteLine($"{f1} / {f2} = {f1 / f2}"); // 15/8

        // Унарні оператори
        Console.WriteLine($"\nУнарні оператори:");
        Console.WriteLine($"+{f1} = {+f1}"); // 3/4
        Console.WriteLine($"-{f1} = {-f1}"); // -3/4

        // Порівняння
        Console.WriteLine($"\nПорівняння:");
        Console.WriteLine($"{f1} > {f2} = {f1 > f2}"); // True
        Console.WriteLine($"{f1} == {f2} = {f1 == f2}"); // False
        Console.WriteLine($"{f1} != {f2} = {f1 != f2}"); // True

        // Приведення до double
        Console.WriteLine($"\nПриведення до double:");
        Console.WriteLine($"(double){f1} = {f1.ToDouble():F3}"); // 0.750
        Console.WriteLine($"(double){f2} = {f2.ToDouble():F3}"); // 0.400

        // Скорочення дробу
        Console.WriteLine($"\nСкорочення дробу:");
        Fraction f5 = new Fraction(8, 12);
        Console.WriteLine($"До скорочення: 8/12");
        Console.WriteLine($"Після скорочення: {f5}"); // 2/3

        // Додаткові приклади
        Console.WriteLine($"\nДодаткові приклади:");
        Fraction f6 = new Fraction(-2, 4);
        Console.WriteLine($"f6 = {f6}"); // -1/2

        Fraction f7 = new Fraction(2, -4);
        Console.WriteLine($"f7 = {f7}"); // -1/2
    }
}