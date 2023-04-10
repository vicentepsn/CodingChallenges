using System.Collections.Generic;

namespace CodingChallenges.Arrays
{
    /// <summary>
    /// Related   : String, Array, Two Pointers
    /// Title     : Items In Container
    /// Difficult : Medium
    /// Link      : -
    /// Companies : Amazon (Hackerrank Demo test)
    /// Documment : Docs/ItemsInContainer.png / Docs/ItemsInContainer.html
    /// </summary>
    public class ItemsInContainer
    {
        /*
    * Complete the 'numberOfItems' function below.
    *
    * The function is expected to return an INTEGER_ARRAY.
    * The function accepts following parameters:
    *  1. STRING s
    *  2. INTEGER_ARRAY startIndices
    *  3. INTEGER_ARRAY endIndices
    */

        public static List<int> numberOfItems(string s, List<int> startIndices, List<int> endIndices)
        {
            int lastPipeDistanceToLeft = -1;
            int lastPipeDistanceToRigth = -1;

            int[] distancesToLeft = new int[s.Length];
            int[] distancesToRight = new int[s.Length];
            int[] pipeCountToLeft = new int[s.Length];
            int[] pipeCountToRight = new int[s.Length];
            int pipeCount = 0;

            for (int left = 0; left < s.Length; left++)
            {
                if (s[left] == '|')
                {
                    lastPipeDistanceToLeft = 0;
                    pipeCount++;
                }
                else if (lastPipeDistanceToLeft != -1)
                    lastPipeDistanceToLeft++;
                pipeCountToLeft[left] = pipeCount;
                distancesToLeft[left] = lastPipeDistanceToLeft;
            }
            pipeCount = 0;
            for (int right = s.Length - 1; right >= 0; right--)
            {
                if (s[right] == '|')
                {
                    lastPipeDistanceToRigth = 0;
                    pipeCount++;
                }
                else if (lastPipeDistanceToRigth != -1)
                    lastPipeDistanceToRigth++;

                pipeCountToRight[right] = pipeCount;
                distancesToRight[right] = lastPipeDistanceToRigth;
            }

            var result = new List<int>(startIndices.Count);
            for (int i = 0; i < startIndices.Count; i++)
            {
                int startIdx = startIndices[i] - 1;
                int endIdx = endIndices[i] - 1;

                result.Add(0);
                if (distancesToRight[startIdx] == -1 || distancesToLeft[endIdx] == -1)
                    continue;

                startIdx += distancesToRight[startIdx];
                endIdx -= distancesToLeft[endIdx];

                if (startIdx >= endIdx)
                    continue;

                var pipesInTheMidle = pipeCount - pipeCountToLeft[startIdx] - pipeCountToRight[endIdx];
                result[i] = endIdx - startIdx - 1 - pipesInTheMidle;
            }

            return result;
        }
    }
}
