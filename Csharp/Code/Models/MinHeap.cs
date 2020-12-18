namespace Code.Models
{
    class MinHeap
    { 
        /* 
         * Node at i
         * parent at (i - 1) / 2
         * left child at 2 * i + 1
         * right child at 2 * i + 2
         */
        MinHeapNode[] items;
        int size;

        public MinHeap(int capacity)
        {
            items = new MinHeapNode[capacity];
        }

        public int GetSize()
        {
            return size;
        }

        public void Insert(MinHeapNode node)
        {
            if (size < items.Length)
            {
                items[size] = node;
                size++;

                HeapifyUp(size - 1);
            }
        }

        public MinHeapNode RemoveRoot()
        {
            MinHeapNode min = null;

            if (size == 0)
            {
                return null;
            }
            else if (size == 1)
            {
                min = items[0];
                items[0] = null;
                size--;
            }
            else
            {
                min = items[0];
                items[0] = items[size - 1];
                items[size - 1] = null;
                size--;

                HeapifyDown(0);
            }

            return min;
        }

        private int GetParentIndex(int index) { return (index - 1) / 2; }
        private int GetLeftChildIndex(int index) { return (index * 2) + 1; }
        private int GetRightChildIndex(int index) { return (index * 2) + 2; }

        private void HeapifyDown(int i)
        {
            int left = GetLeftChildIndex(i);
            int right = GetRightChildIndex(i);
            int smallest = i;

            while (i < size)
            {
                if (left < size && items[left].Value < items[smallest].Value)
                {
                    smallest = left;
                }

                if (right < size && items[right].Value < items[smallest].Value)
                {
                    smallest = right;
                }

                if (i == smallest)
                {
                    break;
                }

                Swap(i, smallest);
                i = smallest;
                left = GetLeftChildIndex(i);
                right = GetRightChildIndex(i);
            }
        }

        private void HeapifyUp(int i)
        {
            int parent = GetParentIndex(i);

            while (i > 0)
            {
                if (items[i].Value < items[parent].Value)
                {
                    Swap(i, parent);
                    i = parent;
                    parent = GetParentIndex(i);
                }
                else
                {
                    break;
                }
            }
        }

        private void Swap(int i, int j)
        {
            if (i <= size && j <= size && i != j)
            {
                MinHeapNode temp = items[i];
                items[i] = items[j];
                items[j] = temp;
            }
        }
    }
}
