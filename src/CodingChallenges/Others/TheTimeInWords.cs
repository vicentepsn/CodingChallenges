using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.Others
{
    /// <summary>
    /// Related   : Dictionary
    /// Title     : The Time in Words
    /// Difficult : Medium
    /// Link      : https://www.hackerrank.com/challenges/the-time-in-words/problem
    /// Companies : ??
    /// </summary>
    public static class TheTimeInWords
    {
    public static string timeInWords(int h, int m)
    {
        if (m == 0)
            return getNumberAsText(h) + " o' clock";
        if (m == 15)
            return "quarter past " + getNumberAsText(h);
        if (m == 30)
            return "half past " + getNumberAsText(h);
        if (m < 30)
            return getNumberAsText(m) + " minute" + (m > 1 ? "s" : "") + " past " + getNumberAsText(h);

        var nextHour = h == 12 ? 1 : h + 1;
        if (m == 45)
            return "quarter to " + getNumberAsText(nextHour);

        int minutesToNextHour = 60 - m;
        return getNumberAsText(minutesToNextHour) + " minute" + (minutesToNextHour > 1 ? "s" : "") + " to " + getNumberAsText(nextHour);
    }

    private static string getNumberAsText(int number)
    {
        var numbers = new Dictionary<int, string>(){
            { 1, "one" },
            { 2, "two" },
            { 3, "three" },
            { 4, "four" },
            { 5, "five" },
            { 6, "six" },
            { 7, "seven" },
            { 8, "eight" },
            { 9, "nine" },
            { 10, "ten" },
            { 11, "eleven" },
            { 12, "twelve" },
            { 13, "thirteen" },
            { 14, "forteen" },
            { 15, "fifteen" },
            { 16, "sexteen" },
            { 17, "seventeen" },
            { 18, "eithteen" },
            { 19, "nineteen" },
            { 20, "twenty" },
        };
        
        if(number <= 20)
            return numbers[number];
            
        return numbers[20] + " " + numbers[number - 20];
    }
    }
}
