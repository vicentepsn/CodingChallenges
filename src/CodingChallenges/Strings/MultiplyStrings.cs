using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenges.Strings
{
    /// <summary>
    /// Groups    : String, Math
    /// Title     : 43. Multiply Strings
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/multiply-strings/
    /// Approach  : -
    /// </summary>
    public class MultiplyStrings
    {
        // Complexity: T => O(M² + N.M) / S => O(M² + N.M)
        public static string Multiply(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0")
                return "0";

            var num1Rev = num1.Reverse().ToArray();
            var num2Rev = num2.Reverse().ToArray();

            var toSum = new List<string>();

            StringBuilder zeros = new StringBuilder(num1.Length - 1);
            for(int idx2 = 0; idx2 < num2Rev.Length; idx2++)
            {
                var strNum = new StringBuilder(num1.Length + idx2 + 1);
                strNum.Append(zeros);
                var accumulated = 0;
                for(int idx1 = 0; idx1 < num1Rev.Length; idx1++)
                {
                    var dig1 = ParceCharToDigit(num1Rev[idx1]);
                    var dig2 = ParceCharToDigit(num2Rev[idx2]);

                    var digMult = dig1 * dig2 + accumulated;
                    strNum.Append(digMult % 10);
                    accumulated = digMult / 10;
                }
                if (accumulated != 0)
                    strNum.Append(accumulated);

                zeros.Append(0);
                toSum.Add(strNum.ToString());
            }

            var op1 = toSum[0];
            for (int idxOp = 1; idxOp < toSum.Count; idxOp++)
            {
                var op2 = toSum[idxOp];
                var sum = Sum(op1, op2);
                op1 = sum;
            }

            return new string(op1.Reverse().ToArray());
        }

        private static string Sum(string op1, string op2)
        {
            var strNum = new StringBuilder(op2.Length + 1);
            var accumulated = 0;
            var minLength = Math.Min(op1.Length, op2.Length);
            for (int idxDig = 0; idxDig <= minLength; idxDig++)
            {
                var dig1 = idxDig < op1.Length ? int.Parse(op1.Substring(idxDig, 1)) : 0;
                var dig2 = idxDig < op2.Length ? int.Parse(op2.Substring(idxDig, 1)) : 0;
                var digSum = dig1 + dig2 + accumulated;

                strNum.Append(digSum % 10);
                accumulated = digSum / 10;
            }

            if (accumulated != 0)
                strNum.Append(accumulated);

            return strNum.ToString();
        }

        // Complexity: T => O(M.N)  /  S => O(M + N)
        public static string Multiply_Optimized(string num1, string num2)
        {
            if(num1 == "0" || num2 == "0")
                return "0";

            var digits1Rev = num1.Reverse().ToArray();
            var digits2Rev = num2.Reverse().ToArray();

            int[] digitsResultRev = new int[num1.Length + num2.Length];

            for (int idx2 = 0; idx2 < digits2Rev.Length; idx2++)
            {
                var digit2 = ParceCharToDigit(digits2Rev[idx2]);
                for (int idx1 = 0; idx1 < digits1Rev.Length; idx1++)
                {
                    var digit1 = ParceCharToDigit(digits1Rev[idx1]);
                    int idxR = idx1 + idx2;
                    var currentCarry = digitsResultRev[idxR];

                    var multiplication = digit1 * digit2 + currentCarry;

                    digitsResultRev[idxR] = multiplication % 10;
                    digitsResultRev[idxR + 1] += multiplication / 10; // sometimes it is not a simple digit
                }
            }

            return ReversedDigitsArrayToStringNum(digitsResultRev);
        }

        private static string ReversedDigitsArrayToStringNum(int[] digits)
        {
            StringBuilder result = new StringBuilder(digits.Length);
            int startFrom = digits.Length - 1;
            while (digits[startFrom] == 0)
                startFrom--;
            for (int i = startFrom; i >= 0; i--)
                result.Append(ParceDigitToChar(digits[i]));
            return result.ToString();
        }

        private static int ParceCharToDigit(char digit) => digit - '0';
        private static char ParceDigitToChar(int digit) => (char)(digit + '0');


        public static string Multiply_NotReversing(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0")
                return "0";

            var toSum = new List<string>();

            var zerosToRight = new StringBuilder(num1.Length - 1);
            for (int i = num1.Length - 1; i >= 0; i--)
            {
                var strNum = new StringBuilder(num2.Length + 1);
                var acumulated = 0;
                for (int j = num2.Length - 1; j >= 0; j--)
                {
                    var a = (int.Parse(num1.Substring(i, 1)) * int.Parse(num2.Substring(j, 1))) + acumulated;
                    var b = a % 10;
                    acumulated = (a - b) / 10;
                    strNum.Insert(0, b);
                }
                if (acumulated != 0)
                    strNum.Insert(0, acumulated);

                strNum.Append(zerosToRight);
                zerosToRight.Append("0");

                toSum.Add(strNum.ToString());
            }

            var n1 = toSum[0];
            for (int i = 1; i < toSum.Count; i++)
            {
                var n2 = toSum[i];
                var strNum = new StringBuilder();
                var acumulated = 0;
                var minLength = Math.Min(n1.Length, n2.Length);
                for (int j = 1; j <= minLength; j++)
                {
                    var a = int.Parse(n1.Substring(n1.Length - j, 1))
                             + int.Parse(n2.Substring(n2.Length - j, 1)) + acumulated;
                    var b = a % 10;
                    acumulated = (a - b) / 10;
                    strNum.Insert(0, b);
                }
                var c = 0;
                if (n1.Length > n2.Length)
                    c = int.Parse(n1.Substring(0, n1.Length - n2.Length));
                else if (n1.Length < n2.Length)
                    c = int.Parse(n2.Substring(0, n2.Length - n1.Length));
                c += acumulated;
                if (c != 0)
                    strNum.Insert(0, c);
                n1 = strNum.ToString();
            }

            return n1;
        }

    }
}
