using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2visual
{
    class RomanNumberExtend : RomanNumber
    {
        private ushort dec;
        private ushort[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        private string[] numerals = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
        public RomanNumberExtend(string num) 
        {
            int i, f, j;
            f = num.Length;
            i = 0; dec = 0; j = 2;
            while (num.Length > 0) 
            {
                if (f == 1) j = 1;
                if (i == 13) { j = 1; i = 0; }
                if (numerals[i] == num.Substring(0, j))
                {
                    dec = (ushort)(dec + values[i]); 
                    num = num.Remove(0, j);  
                    i = 0;
                    j = 2; 
                    f = num.Length; 
                }
                else i++;
            }
        }
        public ushort GetDec() { return dec; }
    }
}
