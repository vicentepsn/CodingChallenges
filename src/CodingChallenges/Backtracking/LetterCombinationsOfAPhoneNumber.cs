namespace CodingChallenges.Backtracking;

/// <summary>
/// Related   : Backtracking, Hash Table, String
/// Title     : 17. Letter Combinations of a Phone Number
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/letter-combinations-of-a-phone-number
/// Approachs : Backtracking
/// </summary>
public class LetterCombinationsOfAPhoneNumber // CG
{
    private Dictionary<char, string> phoneMap = new Dictionary<char, string> {
        {'2',"abc"},
        {'3',"def"},
        {'4',"ghi"},
        {'5',"jkl"},
        {'6',"mno"},
        {'7',"pqrs"},
        {'8',"tuv"},
        {'9',"wxyz"}
    };

    public IList<string> LetterCombinations(string digits)
    {
        List<string> result = [];
        if (string.IsNullOrEmpty(digits)) return result;

        Backtrack(result, digits, 0, "");
        return result;
    }

    private void Backtrack(List<string> result, string digits, int index, string current)
    {
        if (index == digits.Length)
        {
            result.Add(current);
            return;
        }

        string letters = phoneMap[digits[index]];
        foreach (char c in letters)
        {
            Backtrack(result, digits, index + 1, current + c);
        }
    }
}

public class OldImplementationOnLeetcode
{
    Dictionary<char, string> map = new Dictionary<char, string>(){
        {'2', "abc"},
        {'3', "def"},
        {'4', "ghi"},
        {'5', "jkl"},
        {'6', "mno"},
        {'7', "pqrs"},
        {'8', "tuv"},
        {'9', "wxyz"},

    };
    public IList<string> LetterCombinations(string digits)
    {
        IList<string> result = new List<string>();
        if (digits.Length == 0)
            return result;

        LetterCombinations_aux(digits, result, 0, "");

        return result;
    }

    private void LetterCombinations_aux(string digits, IList<string> result, int position, string current)
    {
        string letters = map[digits[position]];
        foreach (char letter in letters)
        {
            var newStr = current + letter.ToString();
            if (position == digits.Length - 1)
                result.Add(newStr);
            else
                LetterCombinations_aux(digits, result, position + 1, newStr);
        }
    }
}