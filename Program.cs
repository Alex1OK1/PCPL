using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_Part1
{
    internal class Program
    {
        public delegate Object MyDelegate(string value1, int value2);

        static void Main(string[] args)
        {
            //Пункты 2, 3
            string MultiStr(string value1, int value2)
            {
                return string.Concat(Enumerable.Repeat(value1, value2));
            }
            MyDelegate myDelegate = new MyDelegate(MultiStr);
            Console.WriteLine(myDelegate("1", 2));



            //Пункт 4
            void GetMultiIntValue(MyDelegate newDelegate, string firstWord, string delegateWord, int delegateNum)
            {
                Console.WriteLine(firstWord + " " + newDelegate(delegateWord, delegateNum).ToString());
            }
            GetMultiIntValue(new MyDelegate(MultiStr), "World", "Hellow", 1);
            GetMultiIntValue((string source, int increment) => source + " " + increment.ToString(), "Andew", "got", 5);





            //Пункт5
            Func<string, int, Object> multiStr = (s, i) => string.Concat(Enumerable.Repeat(s, i));
            void NewMethod(Func<string, int, Object> func, string firstWord, string delegateWord, int delegateNum)
            {
                Console.WriteLine(firstWord + " " + func(delegateWord, delegateNum).ToString());
            }
            NewMethod(multiStr, "Hello", "World", 3);

            Console.ReadLine();
        }
    }
}
