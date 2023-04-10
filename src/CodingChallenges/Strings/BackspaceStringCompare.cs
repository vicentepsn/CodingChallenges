namespace CodingChallenges.Strings
{
    /// <summary>
    /// 844. Backspace String Compare
    /// https://leetcode.com/problems/backspace-string-compare/
    /// </summary>
    public static class BackspaceStringCompare
    {
        public static bool BackspaceCompare(string s, string t)
        {
            int iS = s.Length - 1;
            int iT = t.Length - 1;

            while (iS >= 0 || iT >= 0)
            {

                moveIndexToNextValid(ref s, ref iS);
                moveIndexToNextValid(ref t, ref iT);

                if ((iT < 0 ^ iS < 0) || ((iT >= 0 && iS >= 0) && s[iS] != t[iT]))
                    return false;

                iS--;
                iT--;
            }

            return true;
        }

        private static void moveIndexToNextValid(ref string str, ref int index)
        {
            int deleteCount = 0;

            while (index >= 0 && (str[index] == '#' || deleteCount > 0))
            {
                if (str[index] == '#')
                    deleteCount++;
                else
                    deleteCount--;

                index--;
            }
        }
    }
}
