namespace CodingChallenges.Arrays;

public class RotateArray
{
    /// <summary>
    /// Related   : Matrix
    /// Title     : 189. Rotate Array
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/rotate-array
    /// Approachs : -
    /// </summary>
    public static void Rotate(int[] nums, int k) // versão com space complexity O(1)
    {
        int n = nums.Length;
        k = k % n;

        if (k == 0)
            return;

        int lastStartIdx = 0;
        int index = 0;
        int movingValue = nums[index];
        for (int i = 0; i < n; i++)
        {
            index = (index + k) % n;
            if (index == lastStartIdx) // caso encontre o mesmo ponto novamente
            {
                nums[index] = movingValue;

                lastStartIdx++;
                index = lastStartIdx;
                movingValue = nums[index];
            }
            else
            {
                int temp = nums[index];
                nums[index] = movingValue;
                movingValue = temp;
            }
        }
    }

    // O(n + k)<=>O(n) / O(k)
    public static void Rotate_v2(int[] nums, int k) // versão com space complexity O(k) ou O(k % n)
    {
        int n = nums.Length;
        k = k % n;

        if (k == 0)
            return;

        Queue<int> rotateQueue = new(nums[..k]);

        for (int i = 0; i < n; i++)
        {
            int idx1 = (i + k) % n;
            rotateQueue.Enqueue(nums[idx1]);
            nums[idx1] = rotateQueue.Dequeue();
        }
    }

}
