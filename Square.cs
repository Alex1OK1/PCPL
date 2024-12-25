using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Square : Rectangle
    {
        public Square(float length) : base(length)
        {
            Width = length;
            Height = length;
            m_Name = "Квадрат";
            GetArea();
        }

        public override string ToString()
        {
            return m_Name + ":\n Сторона: " + m_Width + "\n Площадь: " + m_Area;
        }
    }
}
