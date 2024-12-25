using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal abstract class GeometricShape : IComparable, IPrint
    {
        protected string m_Name;
        protected float m_Area;

        protected virtual void GetArea()
        {

        }

        public float GetA()
        {
            return m_Area;
        }

        protected void SetName(string name)
        {
            m_Name = name;
        }
        
        public int CompareTo(object? o)
        {
            if(o is GeometricShape gesh) return GetA().CompareTo(gesh.GetA());
            else throw new ArgumentException("Некорректное значение параметра");    
        }

        public virtual void Print()
        {
            Console.WriteLine(m_Area);
        }
    }
}
