using System;

namespace DataStructures
{
    /// <summary>
    /// Complexity: Add and Delete: T = O(log N), S = O(1)
    /// </summary>
    public class MinIntPriorityQueue
    {
        private int capacity = 10;
        public int Size { get; private set; }

        int[] heap;

        public MinIntPriorityQueue()
        {
            heap = new int[capacity];
        }
        public MinIntPriorityQueue(int capacity)
        {
            heap = new int[capacity];
            this.capacity = capacity;
        }

        private int getLeftChildIndex(int parentIndex) => 2 * parentIndex + 1;
        private int getRightChildIndex(int parentIndex) => 2 * parentIndex + 2;
        private int getParentIndex(int childIndex) => (childIndex - 1) / 2;

        private bool hasLeftChild(int index) => getLeftChildIndex(index) < Size;
        private bool hasRightChild(int index) => getRightChildIndex(index) < Size;
        private bool hasParent(int index) => index > 0;// getParentIndex(index) >= 0;

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

            while (hasParent(index) && heap[parentIndex] > heap[index])
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
                var smallerChildIndex = getLeftChildIndex(currentIndex);
                if (hasRightChild(currentIndex) && getRightChild(currentIndex) < heap[smallerChildIndex])
                {
                    smallerChildIndex = getRightChildIndex(currentIndex);
                }

                if (heap[currentIndex] < heap[smallerChildIndex])
                {
                    break;
                }

                swap(currentIndex, smallerChildIndex);
                currentIndex = smallerChildIndex;
            }
        }
    }
}
