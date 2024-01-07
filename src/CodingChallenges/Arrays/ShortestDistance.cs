using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.Arrays
{
    public static class ShortestDistanceClass
    {
        public static int ShortestDistance(string[] words, string word1, string word2)
        {
            int left = 0;

            int result = words.Length;
            string firstWord = "";
            string secondWord = "";

            while (left < words.Length - 1 && firstWord == "")
            {
                if (words[left] == word1)
                {
                    firstWord = word1;
                    secondWord = word2;
                }
                else if (words[left] == word2)
                {
                    firstWord = word2;
                    secondWord = word1;
                }
                else
                    left++;
            }

            int right = left + 1;

            while (left < words.Length - 1 && right < words.Length)
            {
                if (words[right] == firstWord)
                    left = right;
                else if (words[right] == secondWord)
                {
                    int distance = right - left;
                    result = distance < result ? distance : result;
                    left = right;
                    string tmp = firstWord;
                    firstWord = secondWord;
                    secondWord = tmp;
                }

                right++;
            }

            return result;
        }

        public static int shortestDistance(string[] words, string word1, string word2)
        {
            // Initialize the shortest distance with the length of the words list
            int shortestDistance = words.Length;
            int position1 = -1, position2 = -1; // Initialize the positions of word1 and word2 with -1

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                if (word.Equals(word1))
                { // If the current word is word1, update the position1
                    position1 = i;
                }
                else if (word.Equals(word2))
                { // If the current word is word2, update the position2
                    position2 = i;
                }
                // If both the positions are updated, update the shortest distance
                if (position1 != -1 && position2 != -1)
                {
                    shortestDistance = Math.Min(shortestDistance, Math.Abs(position1 - position2));
                }
            }
            return shortestDistance;
        }

    }
}
