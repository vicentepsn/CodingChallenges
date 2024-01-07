using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.Strings
{
    public static class ReverseVowelsClass
    {
        public static string ReverseVowels(string s)
        {
            HashSet<char> vowels =
              new HashSet<char>(new char[]{ 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' });

            int n = s.Length;
            char[] result = new char[n];

            int left = 0, right = n - 1;
            while (left < right)
            {
                bool leftIsVowel = vowels.Contains(s[left]);
                bool rightIsVowel = vowels.Contains(s[right]);

                if (leftIsVowel && rightIsVowel)
                {
                    result[left] = s[right];
                    result[right] = s[left];
                    left++;
                    right--;
                }
                else if (leftIsVowel)
                {
                    result[right] = s[right];
                    right--;
                }
                else if (rightIsVowel)
                {
                    result[left] = s[left];
                    left++;
                }
                else
                {
                    result[left] = s[left];
                    result[right] = s[right];
                    left++;
                    right--;
                }
            }
            if (left == right)
                result[left] = s[left];

            return new string(result);
        }

        public static string reverseVowels(string s)
        {
            HashSet<char> vowels =
              new HashSet<char>(new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' });

            int first = 0, last = s.Length - 1; // Initialize the two pointers
            char[] array = s.ToCharArray();
            while (first < last)
            {
                while (first < last && vowels.Contains(array[first]))
                {
                    first++; // Skip non-vowel characters from the start
                }
                while (first < last && vowels.Contains(array[last]))
                {
                    last--; // Skip non-vowel characters from the end
                }
                char temp = array[first]; // Swap the vowels found at first and last
                array[first] = array[last];
                array[last] = temp;
                first++;
                last--;
            }
            return new string(array); // Return the reversed string
        }


    }
}
