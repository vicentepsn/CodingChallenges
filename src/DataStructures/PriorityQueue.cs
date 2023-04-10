using System;
using System.Collections.Generic;

namespace DataStructures
{
    // using Comparison
    public class PriorityQueue_2<T>
    {
        private int capacity;
        public int Size { get; private set; }
        private readonly Comparison<T> comparer;

        public T[] Heap { get => heap; }
        private T[] heap;

        public PriorityQueue_2(Comparison<T> comparer, int capacity = 10)
        {
            heap = new T[capacity];
            this.capacity = capacity;
            this.comparer = comparer;
        }

        private int getLeftChildIndex(int parentIndex) => 2 * parentIndex + 1;
        private int getRightChildIndex(int parentIndex) => 2 * parentIndex + 2;
        private int getParentIndex(int childIndex) => (childIndex - 1) / 2;

        private bool hasLeftChild(int index) => getLeftChildIndex(index) < Size;
        private bool hasRightChild(int index) => getRightChildIndex(index) < Size;
        private bool hasParent(int index) => index > 0;

        private T getLeftChild(int index) => heap[getLeftChildIndex(index)];
        private T getRightChild(int index) => heap[getRightChildIndex(index)];
        private T getParent(int index) => heap[getParentIndex(index)];

        private void swap(int indexOne, int indexTwo)
        {
            var temp = heap[indexOne];
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

        public T Peek()
        {
            if (Size == 0) throw new InvalidOperationException();

            return heap[0];
        }

        public T Pop()
        {
            if (Size == 0) throw new InvalidOperationException();
            var item = heap[0];
            heap[0] = heap[Size - 1];
            Size--;
            heapifyDown();

            return item;
        }

        public T PopAndPush(T newItem)
        {
            if (Size == 0) throw new InvalidOperationException();
            var deletedItem = heap[0];
            heap[0] = newItem;
            heapifyDown();

            return deletedItem;
        }

        public void Push(T item)
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
                {
                    higerPriorityChildIndex = getRightChildIndex(currentIndex);
                }

                if (comparer.Invoke(heap[currentIndex], heap[higerPriorityChildIndex]) > 0)
                {
                    break;
                }

                swap(currentIndex, higerPriorityChildIndex);
                currentIndex = higerPriorityChildIndex;
            }
        }
    }

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private int capacity;
        public int Size { get; private set; }
        private readonly Comparer<T> comparer;

        T[] heap;

        public PriorityQueue(Comparer<T> comparer, int capacity = 10)
        {
            heap = new T[capacity];
            this.capacity = capacity;
            this.comparer = comparer ?? Comparer<T>.Default;
        }

        private int getLeftChildIndex(int parentIndex) => 2 * parentIndex + 1;
        private int getRightChildIndex(int parentIndex) => 2 * parentIndex + 2;
        private int getParentIndex(int childIndex) => (childIndex - 1) / 2;

        private bool hasLeftChild(int index) => getLeftChildIndex(index) < Size;
        private bool hasRightChild(int index) => getRightChildIndex(index) < Size;
        private bool hasParent(int index) => index > 0;

        private T getLeftChild(int index) => heap[getLeftChildIndex(index)];
        private T getRightChild(int index) => heap[getRightChildIndex(index)];
        private T getParent(int index) => heap[getParentIndex(index)];

        private void swap(int indexOne, int indexTwo)
        {
            var temp = heap[indexOne];
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

        public T Peek()
        {
            if (Size == 0) throw new InvalidOperationException();

            return heap[0];
        }

        public T Pop()
        {
            if (Size == 0) throw new InvalidOperationException();
            var item = heap[0];
            heap[0] = heap[Size - 1];
            Size--;
            heapifyDown();

            return item;
        }

        public void Push(T item)
        {
            ensureExtraCapacity();
            heap[Size] = item;
            Size++;
            heapifyUp();
        }

        public T PopAndPush(T newItem)
        {
            if (Size == 0) throw new InvalidOperationException();
            var deletedItem = heap[0];
            heap[0] = newItem;
            heapifyDown();

            return deletedItem;
        }

        private void heapifyUp()
        {
            var index = Size - 1;
            var parentIndex = getParentIndex(index);

            // if the priority of the parent node is less than the children, then swap them
            while (hasParent(index) && comparer.Compare(heap[parentIndex], heap[index]) < 0)
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
                if (hasRightChild(currentIndex) && comparer.Compare(getRightChild(currentIndex), heap[higerPriorityChildIndex]) > 0)
                {
                    higerPriorityChildIndex = getRightChildIndex(currentIndex);
                }

                if (comparer.Compare(heap[currentIndex], heap[higerPriorityChildIndex]) > 0)
                {
                    break;
                }

                swap(currentIndex, higerPriorityChildIndex);
                currentIndex = higerPriorityChildIndex;
            }
        }
    }
}
