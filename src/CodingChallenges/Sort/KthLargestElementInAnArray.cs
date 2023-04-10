namespace CodingChallenges.Sort
{
    /// <summary>
    /// Groups    : Sort, Array
    /// Title     : 215. Kth Largest Element in an Array
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/kth-largest-element-in-an-array/
    /// Approach  : QuickSort
    /// </summary>
    public static class KthLargestElementInAnArray
    {
        public static int FindKthLargest(int[] nums, int k)
        {
            return QuickSelection(nums, 0, nums.Length - 1, nums.Length - k);
        }

        public static int QuickSelection(int[] arr, int left, int right, int position)
        {
            var length = right - left + 1;
            if (length <= 1)
                return arr[position];

            if (length == 2)
            {
                if (arr[left] > arr[right])
                    swap(arr, left, right);

                return arr[position];
            }

            int partitionIdx = GetPartition(arr, left, right);

            if(partitionIdx == position)
                return arr[position];

            if(partitionIdx > position)
                return QuickSelection(arr, left, partitionIdx - 1, position);

            return QuickSelection(arr, partitionIdx + 1, right, position);
        }

        public static void QuickSort(int[] arr, int left, int right)
        {
            var length = right - left + 1;
            if (length <= 1)
                return;

            if (length == 2)
            {
                if (arr[left] > arr[right])
                    swap(arr, left, right);

                return;
            }

            int partitionIdx = GetPartition(arr, left, right);
            QuickSort(arr, left, partitionIdx - 1);
            QuickSort(arr, partitionIdx + 1, right);
        }

        private static int GetPartition(int[] arr, int left, int right)
        {
            int partitionIdx = left;
            int pivotElement = arr[right];

            for (int j = left; j < right; j++)
            {
                if(arr[j] < pivotElement)
                {
                    swap(arr, j, partitionIdx);
                    partitionIdx++;
                }
            }
            swap(arr, right, partitionIdx);
            return partitionIdx;
        }

        private static void swap(int[] arr, int a, int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
    }
}
