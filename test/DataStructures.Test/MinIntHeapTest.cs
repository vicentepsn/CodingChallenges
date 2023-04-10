namespace DataStructures.Test
{
    public class MinIntHeapTest
    {
        [Fact]
        public void MinIntHeap()
        {
            var heap = new MinIntPriorityQueue();

            heap.Push(10);

            heap.Push(8);
            heap.Push(7);
            heap.Push(21);
            heap.Push(13);

            Assert.Equal(7, heap.Peek());
        }

        [Fact]
        public void PriorityQueue_MinInt()
        {
            var minComparer = new MinIntPriorityQueueComparer();

            var heap = new PriorityQueue<int>(minComparer);

            heap.Push(10);

            heap.Push(8);
            heap.Push(7);
            heap.Push(21);
            heap.Push(13);

            Assert.Equal(7, heap.Peek());
        }

        [Fact]
        public void PriorityQueue_MaxInt()
        {
            var minComparer = new MaxIntPriorityQueueComparer();

            var heap = new PriorityQueue<int>(minComparer);

            heap.Push(10);

            heap.Push(8);
            heap.Push(7);
            heap.Push(21);
            heap.Push(13);

            Assert.Equal(21, heap.Peek());
        }

        [Fact]
        public void IntPriorityQueue_Min()
        {
            var heap = new IntPriorityQueue(QueuePriority.Min);

            heap.Push(10);

            heap.Push(8);
            heap.Push(7);
            heap.Push(21);
            heap.Push(13);

            Assert.Equal(7, heap.Peek());
        }

        [Fact]
        public void IntPriorityQueue_Max()
        {
            var minComparer = new MaxIntPriorityQueueComparer();

            var heap = new IntPriorityQueue(QueuePriority.Max);

            heap.Push(10);

            heap.Push(8);
            heap.Push(7);
            heap.Push(21);
            heap.Push(13);

            Assert.Equal(21, heap.Peek());
        }
    }
}