using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.Strings
{
    public static class Anagram
    {
        public static bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            Dictionary<char, int> lettersQts = new Dictionary<char, int>(s.Length);

            for (int i = 0; i < s.Length; i++)
                lettersQts[s[i]] = lettersQts.GetValueOrDefault(s[i], 0) + 1;

            for (int i = 0; i < t.Length; i++)
            {
                char letter = t[i];
                int count = lettersQts.GetValueOrDefault(letter, 0);
                if (count == 0)
                    return false;

                if (count == 1)
                    lettersQts.Remove(letter);
                else
                    lettersQts[letter] = count - 1;
            }

            if (lettersQts.Count > 0)
                return false;

            return true;
        }

        public static bool isAnagram(string s, string t)
        {
            // Check if the lengths of both strings are equal. If not, return false.
            if (s.Length != t.Length)
                return false;

            // Create a hash map to store the frequency of characters in both strings.
            Dictionary<char, int> freqMap = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                // Increment the frequency of the character in string s.
                freqMap[s[i]] = freqMap.GetValueOrDefault(s[i], 0) + 1;
                // Decrement the frequency of the character in string t.
                freqMap[t[i]] = freqMap.GetValueOrDefault(t[i], 0) - 1;
            }

            // Check if the frequency of all characters is 0.
            foreach(int qtd in freqMap.Values)
            {
                if (qtd != 0)
                    return false;
            }

            // If all characters have a frequency of 0, this means that 't' is an anagram of 's'.
            return true;
        }
    }
}
