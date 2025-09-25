using System.Text;

namespace CodingChallenges.Strings
{
    public class IntToRoman
    {
        public static string ConvertIntToRomanNumerals(int value)
        {
            if (value < 0 || value >= 4000)
                return "INVALID";

            if (value == 0)
                return "";

            var map = new Dictionary<int, char>{
                { 1,    'I' },
                { 5,    'V' },
                { 10,   'X' },
                { 50,   'L' },
                { 100,  'C' },
                { 500,  'D' },
                { 1000, 'M' }
            };

            StringBuilder result = new StringBuilder();
            
            int order = 1000;

            while (value > 0) { 
                int currOrderValue = value / order;

                if (currOrderValue == 0) 
                {
                    order /= 10;
                    continue;
                }
                    
                value -= currOrderValue * order;

                if (currOrderValue == 9)
                    result.Append($"{map[order]}{map[order * 10]}");
                else if (currOrderValue >= 5)
                {
                    result.Append(map[order * 5]);
                    while (currOrderValue > 5)
                    {
                        result.Append(map[order]);
                        currOrderValue--;
                    }
                }
                else if (currOrderValue == 4)
                    result.Append($"{map[order]}{map[order * 5]}");
                else
                {
                    while (currOrderValue > 0)
                    {
                        result.Append(map[order]);
                        currOrderValue--;
                    }
                }

                order /= 10;
            }

            return result.ToString();
        }


        public static string ConvertIntToRomanNumerals_v1(int value)
        {
            if (value < 0 || value >= 4000)
                return "INVALID";

            if (value == 0)
                return "";

            string result = "";

            int tousands = value / 1000;
            value -= tousands * 1000;

            while (tousands > 0)
            {
                result += "M";
                tousands--;
            }

            int hundreds = value / 100;
            value -= hundreds * 100;

            if (hundreds == 9)
                result += "CM";
            else if (hundreds >= 5)
            {
                result += "D";
                while (hundreds > 5)
                {
                    result += "C";
                    hundreds--;
                }
            }
            else if (hundreds == 4)
                result += "CD";
            else
            {
                while (hundreds > 0)
                {
                    result += "C";
                    hundreds--;
                }
            }

            int tens = value / 10;
            value -= tens * 10;
            if (tens == 9)
                result += "XC";
            else if (tens >= 5)
            {
                result += "L";
                while (tens > 5)
                {
                    result += "X";
                    tens--;
                }
            }
            else if (tens == 4)
                result += "XL";
            else
            {
                while (tens > 0)
                {
                    result += "X";
                    tens--;
                }
            }

            int units = value;
            if (units == 9)
                result += "IX";
            else if (units >= 5)
            {
                result += "V";
                while (units > 5)
                {
                    result += "I";
                    units--;
                }
            }
            else if (units == 4)
                result += "IV";
            else
            {
                while (units > 0)
                {
                    result += "I";
                    units--;
                }
            }

            return result;
        }
    }
}
