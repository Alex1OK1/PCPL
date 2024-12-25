using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float width = float.Parse(Console.ReadLine());
            float height = float.Parse(Console.ReadLine());
            Rectangle rectangle = new Rectangle(width, height);
            rectangle.Print();

            float length = float.Parse(Console.ReadLine());
            Square square = new Square(length);
            square.Print();

            float radius = float.Parse(Console.ReadLine());
            Circle circle = new Circle(radius);
            circle.Print();
            
            Console.WriteLine("---------------------");
            
            ArrayList geosh = new ArrayList();
            geosh.Add(rectangle);
            geosh.Add(square);
            geosh.Add(circle);
            
            
            
            geosh.Sort();

            foreach (GeometricShape g in geosh)
            {
                g.Print();
            }
            
            Console.WriteLine("---------------------");
            List<GeometricShape> geoshList = new List<GeometricShape>();
            geoshList.Add(rectangle);
            geoshList.Add(square);
            geoshList.Add(circle);
            geoshList.Sort();
            
            for (int i = 0; i < 3; i++)
            {
                geoshList[i].Print();
            }
            Console.WriteLine("---------------------");
            
        }
    }
}
