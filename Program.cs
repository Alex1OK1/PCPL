using System;
using System.ComponentModel;

class Program
{
    static double a;
    static double b;
    static double c;
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Уравнение вида ax^2 + bx + c = 0");
            try
            {
                Console.Write("Введите параметр a:");
                a = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите параметр b:");
                b = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите параметр c:");
                c = Convert.ToDouble(Console.ReadLine());
            } catch (FormatException)
            {
                Console.WriteLine("Неверный формат ввода!");
                continue;
            }

            double D = b * b - 4 * a * c;
            if (D < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Нет корней!");
                Console.ResetColor();
            }
            else if (D == 0)
            {
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine("x = " + Convert.ToString((-b + Math.Sqrt(D)) / 2*a));
                Console.ResetColor();
            } 
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("x1 = " + Convert.ToString((-b + Math.Sqrt(D)) / 2 * a));
                Console.WriteLine("x2 = " + Convert.ToString((-b - Math.Sqrt(D)) / 2 * a));
                Console.ResetColor();
            }

            break;
        }
    }
}