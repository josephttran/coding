using System.Collections.Generic;

namespace Code.Models
{
    class IntMaxHeap
    {
        List<int> items;
        int size;

        public IntMaxHeap()
        {
            items = new List<int>();
        }

        public int GetSize()
        {
            return size;
        }

        public void Insert(int num)
        {
            items.Add(num);
            size++;
            HeapifyUp(size - 1);
        }

        public int PeekTop()
        {
            return items[0];
        }

        public int? RemoveRoot()
        {
            if (size > 0)
            {
                int max = items[0];
                items[0] = items[size - 1];
                items.RemoveAt(size - 1);
                size--;
                HeapifyDown(0);

                return max;
            }

            return null;
        }

        private int GetParentIndex(int index) { return (index - 1) / 2; }
        private int GetLeftChildIndex(int index) { return (index * 2) + 1; }
        private int GetRightChildIndex(int index) { return (index * 2) + 2; }

        private void HeapifyDown(int i)
        {
            int left = GetLeftChildIndex(i);
            int right = GetRightChildIndex(i);
            int largest = i;

            while (i < size)
            {
                if (left < size && items[left] > items[largest])
                {
                    largest = left;
                }

                if (right < size && items[right] > items[largest])
                {
                    largest = right;
                }

                if (i == largest)
                {
                    break;
                }

                Swap(i, largest);
                i = largest;
                left = GetLeftChildIndex(i);
                right = GetRightChildIndex(i);
            }
        }

        private void HeapifyUp(int i)
        {
            int parent = GetParentIndex(i);

            while (i > 0)
            {
                if (items[i] > items[parent])
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
                int temp = items[i];
                items[i] = items[j];
                items[j] = temp;
            }
        }
    }
}
