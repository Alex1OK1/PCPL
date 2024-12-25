using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5;

namespace Lab5ShowCase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Первое слово: ");
            string s1 = Console.ReadLine();
            Console.Write("Второе слово: ");
            string s2 = Console.ReadLine();
            //Console.WriteLine(s1);
            //Console.WriteLine(s2);
            //Console.WriteLine("_______");


            Console.WriteLine("Расстояние Левенштейна: {0}", Lab5.Levenshtine.LevenshteinDistance(s1, s2));
            Console.ReadLine();
        }
    }
}
