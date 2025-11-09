using System;

namespace Fractions
{
    public class Fraction
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        // Конструктор за замовчуванням
        public Fraction() : this(0, 1) { }

        // Основний конструктор
        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Знаменник не може бути нулем.");

            Numerator = numerator;
            Denominator = denominator;
            Simplify();
        }

        // Конструктор для цілих чисел
        public Fraction(int wholeNumber) : this(wholeNumber, 1) { }

        // Конструктор копіювання
        public Fraction(Fraction other) : this(other.Numerator, other.Denominator) { }

        // Метод для скорочення дробу
        private void Simplify()
        {
            if (Numerator == 0)
            {
                Denominator = 1;
                return;
            }

            int gcd = GCD(Math.Abs(Numerator), Math.Abs(Denominator));
            Numerator /= gcd;
            Denominator /= gcd;

            // Забезпечення додатного знаменника
            if (Denominator < 0)
            {
                Numerator = -Numerator;
                Denominator = -Denominator;
            }
        }

        // Обчислення найбільшого спільного дільника (НСД)
        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // Унарні оператори
        public static Fraction operator +(Fraction fraction)
        {
            return new Fraction(fraction);
        }

        public static Fraction operator -(Fraction fraction)
        {
            return new Fraction(-fraction.Numerator, fraction.Denominator);
        }

        // Бінарні арифметичні оператори
        public static Fraction operator +(Fraction left, Fraction right)
        {
            int numerator = left.Numerator * right.Denominator + right.Numerator * left.Denominator;
            int denominator = left.Denominator * right.Denominator;
            return new Fraction(numerator, denominator);
        }

        public static Fraction operator -(Fraction left, Fraction right)
        {
            int numerator = left.Numerator * right.Denominator - right.Numerator * left.Denominator;
            int denominator = left.Denominator * right.Denominator;
            return new Fraction(numerator, denominator);
        }

        public static Fraction operator *(Fraction left, Fraction right)
        {
            int numerator = left.Numerator * right.Numerator;
            int denominator = left.Denominator * right.Denominator;
            return new Fraction(numerator, denominator);
        }

        public static Fraction operator /(Fraction left, Fraction right)
        {
            if (right.Numerator == 0)
                throw new DivideByZeroException("Ділення на нульовий дріб.");

            int numerator = left.Numerator * right.Denominator;
            int denominator = left.Denominator * right.Numerator;
            return new Fraction(numerator, denominator);
        }

        // Оператори порівняння
        public static bool operator ==(Fraction left, Fraction right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (left is null || right is null) return false;
            return left.Numerator == right.Numerator && left.Denominator == right.Denominator;
        }

        public static bool operator !=(Fraction left, Fraction right)
        {
            return !(left == right);
        }

        public static bool operator <(Fraction left, Fraction right)
        {
            return (double)left < (double)right;
        }

        public static bool operator >(Fraction left, Fraction right)
        {
            return (double)left > (double)right;
        }

        public static bool operator <=(Fraction left, Fraction right)
        {
            return (double)left <= (double)right;
        }

        public static bool operator >=(Fraction left, Fraction right)
        {
            return (double)left >= (double)right;
        }

        // Оператор приведення до double
        public static explicit operator double(Fraction fraction)
        {
            return (double)fraction.Numerator / fraction.Denominator;
        }

        // Перевизначення методів Object
        public override bool Equals(object obj)
        {
            return obj is Fraction fraction && this == fraction;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Numerator, Denominator);
        }

        // Перевизначення ToString()
        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        // Додаткові методи для зручності
        public double ToDouble()
        {
            return (double)this;
        }

        public void Reduce()
        {
            Simplify();
        }
    }
}