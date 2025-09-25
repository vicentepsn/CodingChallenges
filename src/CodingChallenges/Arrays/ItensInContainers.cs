using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Arrays;

public class ItensInContainers
{

    public static List<int> numberOfItems(string s, List<int> startIndices, List<int> endIndices)
    {
        var result = new List<int>();

        int[] closedLeftToRight = new int[s.Length];
        int[] diffRightToLeft = new int[s.Length];

        
        int right = 0;
        

        while (right < s.Length && s[right] == '*')
        {
            closedLeftToRight[right] = 0;
            diffRightToLeft[right] = 0;
            right++;
        }

        while (right < s.Length && s[right] == '|')
        {
            closedLeftToRight[right] = 0;
            diffRightToLeft[right] = 0;
            right++;
        }

        int left = right;
        int containerCount = 0;
        int closedSoFarCount = 0;

        while (right < s.Length)
        {
            while (right < s.Length && s[right] == '*')
            {
                closedLeftToRight[right] = closedSoFarCount;
                containerCount++;
                right++;
            }
            
            if (right < s.Length) // means s[right] == '|'
            {
                closedSoFarCount += containerCount;
                closedLeftToRight[right] = closedSoFarCount;
                
                right++;
            }

            for (int i = right - 1; i >= left; i--)
                diffRightToLeft[i] = closedSoFarCount;

            left = right;
            containerCount = 0;
        }


        for (int i = 0; i < startIndices.Count; i++)
        {
            var currResult = closedLeftToRight[endIndices[i] - 1] - diffRightToLeft[startIndices[i] - 1];
            result.Add(currResult > 0 ? currResult : 0);
        }
            

        return result;
    }
}
