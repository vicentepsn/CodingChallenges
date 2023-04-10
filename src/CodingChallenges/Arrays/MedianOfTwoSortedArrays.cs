using System;

namespace CodingChallenges.Arrays
{
    public class MedianOfTwoSortedArrays
    {
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var maxHeapSize = (nums1.Length + nums2.Length) / 2 + 1;
            var maxHeap = new IntPriorityQueue((a, b) => a.CompareTo(b), maxHeapSize);
            var minHeap = new IntPriorityQueue((a, b) => b.CompareTo(a), maxHeapSize);


            return 0;
        }

    }

    public class IntPriorityQueue
    {
        private readonly Comparison<int> comparer;
        private int capacity;
        public int Size { get; private set; }

        int[] heap;

        public IntPriorityQueue(Comparison<int> comparer, int capacity = 10)
        {
            heap = new int[capacity];
            this.capacity = capacity;
            this.comparer = comparer; //queuePriority == QueuePriority.Min ? new MinIntPriorityQueueComparer() : Comparer<int>.Default;
        }

        private int getLeftChildIndex(int parentIndex) => 2 * parentIndex + 1;
        private int getRightChildIndex(int parentIndex) => 2 * parentIndex + 2;
        private int getParentIndex(int childIndex) => (childIndex - 1) / 2;

        private bool hasLeftChild(int index) => getLeftChildIndex(index) < Size;
        private bool hasRightChild(int index) => getRightChildIndex(index) < Size;
        private bool hasParent(int index) => index > 0;

        private int getLeftChild(int index) => heap[getLeftChildIndex(index)];
        private int getRightChild(int index) => heap[getRightChildIndex(index)];
        private int getParent(int index) => heap[getParentIndex(index)];

        private void swap(int indexOne, int indexTwo)
        {
            int temp = heap[indexOne];
            heap[indexOne] = heap[indexTwo];
            heap[indexTwo] = temp;
        }

        private void ensureExtraCapacity()
        {
            if (Size == capacity)
            {
                capacity *= 2;
                Array.Resize(ref heap, capacity);
            }
        }

        public int Peek()
        {
            if (Size == 0) throw new InvalidOperationException();

            return heap[0];
        }

        public int Pop()
        {
            if (Size == 0) throw new InvalidOperationException();
            int item = heap[0];
            heap[0] = heap[Size - 1];
            Size--;
            heapifyDown();

            return item;
        }

        public void Push(int item)
        {
            ensureExtraCapacity();
            heap[Size] = item;
            Size++;
            heapifyUp();
        }

        private void heapifyUp()
        {
            var index = Size - 1;
            var parentIndex = getParentIndex(index);

            // if the priority of the parent node is less than the children, then swap them
            while (hasParent(index) && comparer.Invoke(heap[parentIndex], heap[index]) < 0)
            {
                swap(parentIndex, index);
                index = parentIndex;
                parentIndex = getParentIndex(index);
            }
        }

        private void heapifyDown()
        {
            var currentIndex = 0;

            while (hasLeftChild(currentIndex))
            {
                var higerPriorityChildIndex = getLeftChildIndex(currentIndex);
                if (hasRightChild(currentIndex) && comparer.Invoke(getRightChild(currentIndex), heap[higerPriorityChildIndex]) > 0)
                    higerPriorityChildIndex = getRightChildIndex(currentIndex);

                if (comparer.Invoke(heap[currentIndex], heap[higerPriorityChildIndex]) > 0)
                    break;

                swap(currentIndex, higerPriorityChildIndex);
                currentIndex = higerPriorityChildIndex;
            }
        }
    }

}
