using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals_API_DotNet.Services
{
    public class IntegerConversionService : IIntegerConversionService
    {
        public string ToRomanNumerals(int input)
        {
            var builder = new StringBuilder();

            while (input > 0)
            {
                if (input >= 1000)
                {
                    builder.Append("M");
                    input -= 1000;
                }
                else if (input >= 900)
                {
                    builder.Append("CM");
                    input -= 900;
                }
                else if (input >= 500)
                {
                    builder.Append("D");
                    input -= 500;
                }
                else if (input >= 400)
                {
                    builder.Append("CD");
                    input -= 400;
                }
                else if (input >= 100)
                {
                    builder.Append("C");
                    input -= 100;
                }
                else if (input >= 90)
                {
                    builder.Append("XC");
                    input -= 90;
                }
                else if (input >= 50)
                {
                    builder.Append("L");
                    input -= 50;
                }
                else if (input >= 40)
                {
                    builder.Append("XL");
                    input -= 40;
                }
                else if (input >= 10)
                {
                    builder.Append("X");
                    input -= 10;
                }
                else if (input >= 9)
                {
                    builder.Append("IX");
                    input -= 9;
                }
                else if (input >= 5)
                {
                    builder.Append("V");
                    input -= 5;
                }
                else if (input >= 4)
                {
                    builder.Append("IV");
                    input -= 4;
                }
                else if (input >= 1)
                {
                    builder.Append("I");
                    input -= 1;
                }
            }

            return builder.ToString();
        }
    }
}
