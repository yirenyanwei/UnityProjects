using System;
using UnityEngine;
namespace CNamespace
{
    public class Rectangle
    {
        enum EnumDay
        {
            SUN,
            MON,
            TUE,
            WED,
            THU,
            FRI,
            SAT
        };
        public double width;
        public double height;
        private int id;
        protected string name;

        public Rectangle(double _width, double _height)
        {
            width = _width;
            height = _height;
        }
        public void Display()
        {
            Debug.Log(String.Format("宽高{0}, {1}", width, height));
        }
        public void ChangeValue(ref int a, int b)
        {
            a = 100;
            b = 200;
        }

        public void GetValue(out int a)
        {
            a = 300;
        }

        public void ConsoleEnum()
        {
            EnumDay day = EnumDay.SUN;
            Debug.Log(day);
        }
    }
    
    struct Books
    {
        public string id;
        public string name;
    };

}
