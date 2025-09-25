namespace CodingChallenges.Heap
{
    public class KthSmallestPrimeFraction
    {
        /// <summary>
        /// Groups    : Heap, Priority Queue, Array
        /// Title     : 786. K-th Smallest Prime Fraction
        /// Difficult : Medium
        /// Link      : https://leetcode.com/problems/k-th-smallest-prime-fraction
        /// Approachs : -
        /// </summary>
        public int[] GetKthSmallestPrimeFraction(int[] arr, int k)
        {
            PriorityQueue<int[], decimal> heap = new PriorityQueue<int[], decimal>(k, new DecimalMaxCompare());

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (heap.Count < k)
                        heap.Enqueue(new int[] { arr[i], arr[j] }, (decimal)arr[i] / arr[j]);
                    else
                    {
                        var tt = (decimal)heap.Peek()[0] / heap.Peek()[1];
                        if ((decimal)arr[i] / arr[j] < (decimal)heap.Peek()[0] / heap.Peek()[1])
                        {
                            heap.DequeueEnqueue(new int[] { arr[i], arr[j] }, (decimal)arr[i] / arr[j]);
                        }
                    }
                }
            }

            return heap.Peek();
        }

        public class DecimalMaxCompare : IComparer<decimal>
        {
            public int Compare(decimal x, decimal y) => y.CompareTo(x);
        }

    }
}
