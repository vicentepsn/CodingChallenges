namespace CodingChallenges.Arrays;

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
        for (int right = 1; right < nums.Length; right++)
        {
            if (nums[right] != nums[right - 1]) // sempre que achar uma sequência com números diferentes, ou seja, sempre que mudar, não repetir
            {
                if (right != left) // se alguma repetição já tiver ocorrido
                    nums[left] = nums[right];
                left++;
            }
        }

        return left;
    }

    public int RemoveDuplicates_20251222(int[] nums)
    {
        if (nums == null || nums.Length == 0)
            return 0;

        int left = 0;
        int right = 1;

        while (right < nums.Length)
        {
            while (right < nums.Length && nums[left] == nums[right]) // pula as repetições
                right++;

            if (right < nums.Length)
            {
                left++;
                if (right > left) // se alguma repetição já tiver ocorrido
                    nums[left] = nums[right];

                right++;
            }

        }

        return left + 1;
    }

    /// <summary>
    /// Groups    : Array
    /// Title     : 80. Remove Duplicates from Sorted Array II
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii
    /// Approachs : Two Pointers
    /// </summary>
    public int RemoveDuplicatesII_20251222(int[] nums)
    {
        if (nums == null || nums.Length == 0)
            return 0;

        int left = 0;
        int right = 1;

        while (right < nums.Length)
        {
            if (nums[left] == nums[right]) // trata a primeira repetição, se houver
            {
                left++;
                if (right > left) // se já tiver ocorrido repetições com mais de 2 números repetidos
                    nums[left] = nums[right];

                right++;
            }

            while (right < nums.Length && nums[left] == nums[right]) // pula as demais repetições
                right++;

            if (right < nums.Length)
            {
                left++;
                if (right > left) // se já tiver ocorrido repetições com mais de 2 números repetidos
                    nums[left] = nums[right];

                right++;
            }

        }

        return left + 1;
    }

    public int RemoveDuplicatesII_20251222_v2(int[] nums)
    {
        if (nums == null || nums.Length == 0)
            return 0;

        int left = 0;
        int right = 1;

        while (right < nums.Length)
        {
            if (nums[left] == nums[right]) // trata a primeira repetição, se houver
                UpdatePointersAndArrayIfNeeded(nums, ref left, ref right);

            while (right < nums.Length && nums[left] == nums[right]) // pula as demais repetições
                right++;

            if (right < nums.Length)
                UpdatePointersAndArrayIfNeeded(nums, ref left, ref right);

        }

        return left + 1;
    }

    private static void UpdatePointersAndArrayIfNeeded(int[] nums, ref int left, ref int right)
    {
        left++;
        if (right > left) // se já tiver ocorrido repetições com mais de 2 números repetidos
            nums[left] = nums[right];
        right++;
    }

}
