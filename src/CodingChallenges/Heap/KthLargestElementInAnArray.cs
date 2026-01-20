namespace CodingChallenges.Heap;

/// <summary>
/// Groups    : Bit Manipulation
/// Title     : 67. Add Binary
/// Difficult : Easy
/// Link      : https://leetcode.com/problems/add-binary
/// Approach 1/3: Sort and Select   => O(NlogN) / O(1)
/// Approach 2/3: Min-Heap          => O(N log k) / O(k)   <=  No leetcode, esse com Heap customizado foi o que terminou mais rápido
/// Approach 3/3: QuickSelect       => Best and Average Case: O(N), Worst Case: O(N²) (very rare, especially with randomized pivot)  /  O(1)
/// </summary>
public class KthLargestElementInAnArray_SortAndSelect
{
    public int FindKthLargest(int[] nums, int k)
    {
        Array.Sort(nums);
        return nums[nums.Length - k];
    }
}

public class KthLargestElementInAnArray_Heap
{
    // O(n log k) / O(k)
    public int FindKthLargest(int[] nums, int k)
    {
        // Heap mínimo
        var pq = new PriorityQueue<int, int>();

        foreach (var num in nums)
        {
            pq.Enqueue(num, num);

            // Se o heap passar de tamanho k, removemos o menor
            if (pq.Count > k)
            {
                pq.Dequeue();
            }
        }

        // O topo do heap é o k-ésimo maior
        return pq.Peek();
    }

    // O(n log k) / O(k)  => se k > n / 2, então k = n - k + 1, então k é no máximo n / 2
    public int FindKthLargest_v2(int[] nums, int k)
    {
        // Heap mínimo
        var pq = new PriorityQueue<int, int>();
        bool invert = false;

        if (k > nums.Length / 2)
        {
            k = nums.Length - k + 1;
            invert = true;
        }

        if (invert)
        {
            foreach (var num in nums)
            {
                pq.Enqueue(num, -num);

                // Se o heap passar de tamanho k, removemos o menor
                if (pq.Count > k)
                {
                    pq.Dequeue();
                }
            }
        }
        else
        {
            foreach (var num in nums)
            {
                pq.Enqueue(num, num);

                // Se o heap passar de tamanho k, removemos o menor
                if (pq.Count > k)
                {
                    pq.Dequeue();
                }
            }
        }

        // O topo do heap é o k-ésimo maior
        return pq.Peek();
    }
}

// Leetcode: Beats 86.49% / 49.50%
public class KthLargestElementInAnArray_HeapCustomizado
{
    public int FindKthLargest(int[] nums, int k)
    {
        MinHeap minHeap = new MinHeap(k);
        for (int i = 0; i < k; i++)
        {
            minHeap.Insert(nums[i]);
        }

        for (int i = k; i < nums.Length; i++)
        {
            if (nums[i] > minHeap.Peek())
            {
                minHeap.Pop();
                minHeap.Insert(nums[i]);
            }
        }

        return minHeap.Peek();
    }
}

public class MinHeap
{
    private int[] heap;
    private int size;

    public MinHeap(int capacity)
    {
        heap = new int[capacity];
        size = 0;
    }

    public void Insert(int val)
    {
        heap[size] = val;
        size++;
        BubbleUp();
    }

    public int Peek()
    {
        return heap[0];
    }

    public int Pop()
    {
        int poppedValue = heap[0];
        heap[0] = heap[size - 1];
        size--;
        BubbleDown();
        return poppedValue;
    }

    private void BubbleUp()
    {
        int index = size - 1;
        while (index > 0 && heap[index] < heap[Parent(index)])
        {
            Swap(index, Parent(index));
            index = Parent(index);
        }
    }

    private void BubbleDown()
    {
        int index = 0;
        while (HasLeftChild(index) && (heap[index] > LeftChild(index) || HasRightChild(index) && heap[index] > RightChild(index)))
        {
            int smallerChildIndex = LeftChildIndex(index);
            if (HasRightChild(index) && RightChild(index) < LeftChild(index))
            {
                smallerChildIndex = RightChildIndex(index);
            }
            Swap(index, smallerChildIndex);
            index = smallerChildIndex;
        }
    }

    private int Parent(int index) { return (index - 1) / 2; }
    private int LeftChildIndex(int index) { return 2 * index + 1; }
    private int RightChildIndex(int index) { return 2 * index + 2; }

    private bool HasLeftChild(int index) { return LeftChildIndex(index) < size; }
    private bool HasRightChild(int index) { return RightChildIndex(index) < size; }

    private int LeftChild(int index) { return heap[LeftChildIndex(index)]; }
    private int RightChild(int index) { return heap[RightChildIndex(index)]; }

    private void Swap(int indexOne, int indexTwo)
    {
        int temp = heap[indexOne];
        heap[indexOne] = heap[indexTwo];
        heap[indexTwo] = temp;
    }
}

public class KthLargestElementInAnArray_QuickSelect
{
    // Sem pivot randômico. Essa versão estourou o limite de tempo no Leetcode
    public int FindKthLargest_v1(int[] nums, int k)
    {
        int left = 0, right = nums.Length - 1;
        int target = nums.Length - k; // índice do k-ésimo maior

        while (true)
        {
            int pivotIndex = Partition(nums, left, right);
            if (pivotIndex == target)
            {
                return nums[pivotIndex];
            }
            else if (pivotIndex < target)
            {
                left = pivotIndex + 1;
            }
            else
            {
                right = pivotIndex - 1;
            }
        }
    }

    private int Partition(int[] nums, int left, int right)
    {
        int pivot = nums[right];
        int i = left;

        for (int j = left; j < right; j++)
        {
            if (nums[j] <= pivot)
            {
                Swap(nums, i, j);
                i++;
            }
        }

        Swap(nums, i, right);
        return i;
    }

    private void Swap(int[] nums, int i, int j)
    {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }

}

// Leetcode: Beats 7.46% / 26.92%  => varia por causa do randômico
public class KthLargestElementInAnArray_QuickSelect_random
{
    public int FindKthLargest(int[] nums, int k)
    {
        int left = 0, right = nums.Length - 1;
        Random rand = new Random();
        while (true)
        {
            int pivot_index = left + rand.Next(right - left + 1);
            int new_pivot_index = Partition(nums, left, right, pivot_index);
            if (new_pivot_index == nums.Length - k)
            {
                return nums[new_pivot_index];
            }
            else if (new_pivot_index > nums.Length - k)
            {
                right = new_pivot_index - 1;
            }
            else
            {
                left = new_pivot_index + 1;
            }
        }
    }

    private int Partition(int[] nums, int left, int right, int pivot_index)
    {
        int pivot = nums[pivot_index];
        Swap(nums, pivot_index, right);
        int stored_index = left;
        for (int i = left; i < right; i++)
        {
            if (nums[i] < pivot)
            {
                Swap(nums, i, stored_index);
                stored_index++;
            }
        }
        Swap(nums, right, stored_index);
        return stored_index;
    }

    private void Swap(int[] nums, int i, int j)
    {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
}