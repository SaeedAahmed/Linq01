using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq01.Demo
{
    internal static class IntExtensions
    {
        public static int Reverse(this int Number)
        {
            int ReverseNumber = 0 , Remainder;
            while (Number != 0)
            {
                Remainder = Number % 10;
                ReverseNumber = ReverseNumber * 10 + Remainder;
                Number = Number / 10;
            }
            return ReverseNumber;

        }
    }
}
