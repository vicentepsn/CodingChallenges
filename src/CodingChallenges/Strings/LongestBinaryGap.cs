using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CodingChallenges.Strings
{


    public class LongestBinaryGap
    {

        public int[] TwoSum(int[] nums, int target)
        {
            int[] result = new int[] { };

            Dictionary<int, int> values = new Dictionary<int, int>();
            for (int i = 0; i< nums.Length; i++)
            {
                int compliment = target - nums[i];
                if (values.ContainsKey(compliment))
                {
                    result = new int[] { values[compliment], i };
                    break;
                }

                values[nums[i]] = i;
            }

            return result;
        }


        public int GetLongestBinaryGap(int N) {
            int longestBinaryGap = 0;
            string binary = Convert.ToString(N, 2);
            int left = 1;
            int right;

            while (left < binary.Length)
            {
                if (binary[left] == '0')
                {
                    right = left + 1;
                    while (right < binary.Length && binary[right] == '0')
                        right++;

                    if (right >= binary.Length)
                        return longestBinaryGap;

                    int currentBinaryGap = right - left;
                    longestBinaryGap = Math.Max(longestBinaryGap, currentBinaryGap);
                    left = right + 1;
                }
                else
                    left++;
            }

            return longestBinaryGap;
        }

        const int MAX_INT_BITS = 32;
        const int MAX_BITS = 30;

        public int CountConformArrays(int A, int B, int C)
        {
            int _and = A & B & C;
            int _or = A | B | C;
            int _xor = A ^ B ^ C;
            int numCurrBitOne = (int)Math.Pow(2, MAX_BITS - 1);

            int left = MAX_INT_BITS - MAX_BITS;

            // jump left 'zeros' for all
            while (left < MAX_INT_BITS && (numCurrBitOne & _or) == 0)
            {
                numCurrBitOne >>= 1;
                left++;
            }
            
            int resultBeforeLeft = (int)Math.Pow(2, left - 2);
            int resultFromleft = CountConformArrays(A, B, C, _and, _or, _xor, left, numCurrBitOne, 0);

            return resultBeforeLeft * resultFromleft;
        }

        private int CountConformArrays(int A, int B, int C, int _and, int _or, int _xor, int left, int numCurrBitOne, int combinacao)
        {
            // jump 'ones" for all
            while (left < MAX_INT_BITS && (numCurrBitOne & _and) >= 1)
            {
                numCurrBitOne >>= 1;
                left++;
            }

            int countAllZeros = 0;
            // jump 'ones" for all
            while (left < MAX_INT_BITS && (numCurrBitOne & _or) == 0)
            {
                numCurrBitOne >>= 1;
                left++;
                countAllZeros++;
            }
            int allZerosCombinations = (int)Math.Pow(2, countAllZeros);

            if (left == MAX_INT_BITS)
                return allZerosCombinations;

            int count = 0;

            combinacao <<= 1;

            count += allZerosCombinations * CountConformArrays(A, B, C, _and, _or, _xor, left + 1, numCurrBitOne >> 1, combinacao + 1);
            
            if (A >= 0 && (A & numCurrBitOne) > 0)
                A = -A;
            if (B >= 0 && (B & numCurrBitOne) > 0)
                B = -B;
            if (C >= 0 && (C & numCurrBitOne) > 0)
                C = -C;
                
            if (A >= 0 || B >= 0 || C >= 0)
                count += allZerosCombinations * CountConformArrays(A, B, C, _and, _or, _xor, left + 1, numCurrBitOne >> 1, combinacao);

            return count;
        }

        public int CountConformArraysOld(int A, int B, int C)
        {
            string binaryA = Convert.ToString(A, 2);
            string binaryB = Convert.ToString(B, 2);
            string binaryC = Convert.ToString(C, 2);

            return CountConformArrays(binaryA, binaryB, binaryC);
        }

        public int CountConformArrays(string binaryA, string binaryB, string binaryC)
        {
            int size = Math.Max(binaryA.Length, Math.Max(binaryB.Length, binaryC.Length));

            binaryA = FillLeft("0", size, binaryA);
            binaryB = FillLeft("0", size, binaryB);
            binaryC = FillLeft("0", size, binaryC);
            StringBuilder binaryADiff = new StringBuilder();
            StringBuilder binaryBDiff = new StringBuilder();
            StringBuilder binaryCDiff = new StringBuilder();

            for (int i = 0; i < size; i++)
            {
                if (!(binaryA[i] == binaryB[i] && binaryB[i] == binaryC[i]))
                {
                    binaryADiff.Append(binaryA[i]);
                    binaryBDiff.Append(binaryB[i]);
                    binaryCDiff.Append(binaryC[i]);
                }
            }

            int intADiff = Convert.ToInt32(binaryADiff.ToString(), 2);
            int intBDiff = Convert.ToInt32(binaryBDiff.ToString(), 2);
            int intCDiff = Convert.ToInt32(binaryCDiff.ToString(), 2);

            int smaller = Math.Min(intADiff, Math.Min(intBDiff, intCDiff));
            int bigger = Convert.ToInt32(FillLeft("1", binaryCDiff.Length, ""), 2);

            int countConforms = 0;
            for (int i = smaller; i <= bigger; i++)
            {
                if (isConform(intADiff, i) || isConform(intBDiff, i) || isConform(intCDiff, i))
                    countConforms++;
            }

            return countConforms;
        }

        private bool isConform(int A, int B)
        {
            int combinedNum = A | B;
            return combinedNum == B;
        }

        private static string FillLeft(string value, int totalCount, string original)
        {
            int count = totalCount - original.Length;
            return new StringBuilder(value.Length * count).Insert(0, value, count).Append(original).ToString();
        }
    }
}
