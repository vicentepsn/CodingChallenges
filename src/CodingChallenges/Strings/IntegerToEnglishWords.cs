namespace CodingChallenges.Strings
{
    /// <summary>
    /// Related   : Math, String, Recursion, Divide and conquer
    /// Title     : 273. Integer to English Words
    /// Difficult : Hard
    /// Link      : https://leetcode.com/problems/integer-to-english-words/
    /// Companies : Facebook 21, Amazon 18, Microsoft 7, Salesforce 3, DoorDash 3, Expedia 2, Apple 2, Nvidia 2, Booking.com 2 (2022-03-30)
    /// </summary>
    public class IntegerToEnglishWords
    {
        public string NumberToWords(int num)
        {
            if (num == 0)
                return "Zero";

            int billions = num / 1000000000;
            int millions = (num - billions * 1000000000) / 1000000;
            int thousands = (num - billions * 1000000000 - millions * 1000000) / 1000;
            int remain = num - billions * 1000000000 - millions * 1000000 - thousands * 1000;

            string result = "";
            if (billions != 0)
                result = GetHundreds(billions) + " Billion";

            if (millions != 0)
            {
                if (!string.IsNullOrEmpty(result))
                    result += " ";
                result += GetHundreds(millions) + " Million";
            }

            if (thousands != 0)
            {
                if (!string.IsNullOrEmpty(result))
                    result += " ";
                result += GetHundreds(thousands) + " Thousand";
            }

            if (remain != 0)
            {
                if (!string.IsNullOrEmpty(result))
                    result += " ";
                result += GetHundreds(remain);
            }

            return result;
        }

        public string GetHundreds(int num)
        {
            int hundred = num / 100;
            int rest = num - hundred * 100;
            string res = "";
            if (hundred * rest != 0)
                res = GetUnits(hundred) + " Hundred " + GetTens(rest);
            else if ((hundred == 0) && (rest != 0))
                res = GetTens(rest);
            else if ((hundred != 0) && (rest == 0))
                res = GetUnits(hundred) + " Hundred";
            return res;
        }

        public string GetTens(int num)
        {
            if (num == 0)
                return "";

            if (num < 10)
                return GetUnits(num);
            
            if (num < 20)
                return GetTensLessThan20(num);

            int tenner = num / 10;
            int rest = num - tenner * 10;
            if (rest != 0)
                return GetTensWithNoUnits(tenner) + " " + GetUnits(rest);
            else
                return GetTensWithNoUnits(tenner);
        }

        public string GetUnits(int num)
        {
            switch (num)
            {
                case 1: return "One";
                case 2: return "Two";
                case 3: return "Three";
                case 4: return "Four";
                case 5: return "Five";
                case 6: return "Six";
                case 7: return "Seven";
                case 8: return "Eight";
                case 9: return "Nine";
            }
            return "";
        }

        public string GetTensLessThan20(int num)
        {
            switch (num)
            {
                case 10: return "Ten";
                case 11: return "Eleven";
                case 12: return "Twelve";
                case 13: return "Thirteen";
                case 14: return "Fourteen";
                case 15: return "Fifteen";
                case 16: return "Sixteen";
                case 17: return "Seventeen";
                case 18: return "Eighteen";
                case 19: return "Nineteen";
            }
            return "";
        }

        public string GetTensWithNoUnits(int num)
        {
            switch (num)
            {
                case 2: return "Twenty";
                case 3: return "Thirty";
                case 4: return "Forty";
                case 5: return "Fifty";
                case 6: return "Sixty";
                case 7: return "Seventy";
                case 8: return "Eighty";
                case 9: return "Ninety";
            }
            return "";
        }

    }
}
