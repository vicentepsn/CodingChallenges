﻿namespace CodingChallenges.Arrays
{
    /// <summary>
    /// Related   : Array, Prefix Sum
    /// Title     : 238. Product of Array Except Self
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/product-of-array-except-self/
    /// Companies : Amazon 31, Facebook 19, Microsoft 13, Apple 9, Uber 6, Google 3 (2022-03-30)
    /// </summary>
    public class ProductOfArrayExceptSelf
    {
        // Complexity: T => O(N)  /  S => O(1)
        public int[] ProductExceptSelf(int[] nums)
        {
            int firstZeroIdx = -1;
            int product = 1;

            var result = new int[nums.Length]; // filled with zeros by default

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    if (firstZeroIdx >= 0) // one 'zero' was already found
                        return result;

                    firstZeroIdx = i;
                }
                else
                    product *= nums[i];
            }

            if (firstZeroIdx >= 0)
            {
                result[firstZeroIdx] = product;
                return result;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = product / nums[i];
            }

            return result;
        }

        // Leetcode solution: S => O(1)
        public int[] productExceptSelf_opt(int[] nums)
        {

            // The length of the input array 
            int length = nums.Length;

            // Final answer array to be returned
            int[] answer = new int[length];

            // answer[i] contains the product of all the elements to the left
            // Note: for the element at index '0', there are no elements to the left,
            // so the answer[0] would be 1
            answer[0] = 1;
            for (int i = 1; i < length; i++)
            {

                // answer[i - 1] already contains the product of elements to the left of 'i - 1'
                // Simply multiplying it with nums[i - 1] would give the product of all 
                // elements to the left of index 'i'
                answer[i] = nums[i - 1] * answer[i - 1];
            }

            // R contains the product of all the elements to the right
            // Note: for the element at index 'length - 1', there are no elements to the right,
            // so the R would be 1
            int R = 1;
            for (int i = length - 1; i >= 0; i--)
            {

                // For the index 'i', R would contain the 
                // product of all elements to the right. We update R accordingly
                answer[i] = answer[i] * R;
                R *= nums[i];
            }

            return answer;
        }

        // Leetcode left/right solution: S => O(N)
        public int[] productExceptSelf(int[] nums)
        {

            // The length of the input array
            int length = nums.Length;

            // The left and right arrays as described in the algorithm
            int[] L = new int[length];
            int[] R = new int[length];

            // Final answer array to be returned
            int[] answer = new int[length];

            // L[i] contains the product of all the elements to the left
            // Note: for the element at index '0', there are no elements to the left,
            // so L[0] would be 1
            L[0] = 1;
            for (int i = 1; i < length; i++)
            {

                // L[i - 1] already contains the product of elements to the left of 'i - 1'
                // Simply multiplying it with nums[i - 1] would give the product of all
                // elements to the left of index 'i'
                L[i] = nums[i - 1] * L[i - 1];
            }

            // R[i] contains the product of all the elements to the right
            // Note: for the element at index 'length - 1', there are no elements to the right,
            // so the R[length - 1] would be 1
            R[length - 1] = 1;
            for (int i = length - 2; i >= 0; i--)
            {

                // R[i + 1] already contains the product of elements to the right of 'i + 1'
                // Simply multiplying it with nums[i + 1] would give the product of all
                // elements to the right of index 'i'
                R[i] = nums[i + 1] * R[i + 1];
            }

            // Constructing the answer array
            for (int i = 0; i < length; i++)
            {
                // For the first element, R[i] would be product except self
                // For the last element of the array, product except self would be L[i]
                // Else, multiple product of all elements to the left and to the right
                answer[i] = L[i] * R[i];
            }

            return answer;
        }
    }
}
