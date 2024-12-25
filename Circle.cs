using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Circle : GeometricShape
    {
        private float m_Radius;
        public float Radius 
        {
            get => m_Radius;
            set => m_Radius = value;
        }

        public Circle(float radius)
        {
            Radius = radius;
            m_Name = "Круг";
            GetArea();
        }

        protected override void GetArea()
        {
            m_Area = (float)Math.PI * m_Radius * m_Radius;
        }

        public override string ToString()
        {
            return m_Name + ":\n Радиус: " + m_Radius + "\n Площадь: " + m_Area;
        }

        public override void Print()
        {
            Console.WriteLine(ToString());
        }
    }
}
