namespace CodingChallenges.Arrays
{
    /// <summary>
    /// Groups    : Array
    /// Title     : 26. Remove Duplicates from Sorted Array
    /// Difficult : Easy
    /// Link      : https://leetcode.com/problems/remove-duplicates-from-sorted-array/
    /// Approachs : Two Pointers
    /// </summary>
    public class RemoveDuplicatesFromSortedArray
    {
        public int RemoveDuplicates(int[] nums)
        {
            int left = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[i - 1])
                {
                    if (i != left)
                        nums[left] = nums[i];
                    left++;
                }
            }

            return left;
        }
    }
}
