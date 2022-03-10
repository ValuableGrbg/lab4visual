using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2visual
{
    public class RomanNumber : ICloneable, IComparable
    {
        private ushort dec;
        private short[] values = new short[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        private string[] numerals = new string[]
        { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };


        private short ToShort()
        {
            short res = ((short)dec);
            return res;
        }

        public RomanNumber() { }
        //Конструктор получает представление числа n в римской записи
        public RomanNumber(ushort n)
        {

            if (n <= 0 || n > 3999)
                throw new RomanNumberException("Value must be > 0 and <3999");
            else {
                dec = n;
            }
        }
        //Сложение римских чисел
         public static RomanNumber operator +(RomanNumber? n1, RomanNumber? n2)
         {
            ushort r;
            r = (ushort)(n1.dec + n2.dec);
            if (r > 3999 || r <= 0) throw new RomanNumberException("Result is more than 3999");
            else {
                RomanNumber rez = new(r);
                return rez;
            }
            
         }
        //Вычитание римских чисел
        public static RomanNumber operator -(RomanNumber? n1, RomanNumber? n2)
        {
            if ((short)((short)n1.dec - (short)n2.dec) <= 0) throw new RomanNumberException("Result is less than zero");
            else {
                RomanNumber rez = new((ushort)(n1.dec - n2.dec));
                return rez;
            }
        }
        //Умножение римских чисел
        public static RomanNumber operator *(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1.dec * n2.dec > 3999) throw new RomanNumberException("Result is more than 3999");
            else {
                RomanNumber rez = new((ushort)(n1.dec * n2.dec));
                return rez;
            }
        }
        //Целочисленное деление римских чисел
        public static RomanNumber operator /(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1.dec / n2.dec <=0) throw new RomanNumberException("Result is less than 0");
            else
            {
                RomanNumber rez = new((ushort)(n1.dec / n2.dec));
                return rez;
            }
        }
        //Возвращает строковое представление римского числа
        public override string ToString()
        {
            StringBuilder roman = new();
            short n = (short)dec;


            for (int i = 0; i < 13; ++i)
            {
                while (n >= values[i])
                {
                    n -= values[i];
                    roman.Append(numerals[i]);
                }
            }
            return roman.ToString(); 
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public int CompareTo(object? o)
        {
            if (o is RomanNumber romanNumber) return ((short)dec).CompareTo(romanNumber.ToShort());
            else throw new RomanNumberException("Incorrect parameter");
        }
    }

}
