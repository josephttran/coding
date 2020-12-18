using Code.Models;

namespace Code
{
    public class Heap
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            MinHeap heap = new MinHeap(lists.Length);
            ListNode result = null;
            ListNode curr = null;

            for (int i = 0; i < lists.Length; i++)
            {
                if (lists[i] != null)
                {
                    heap.Insert(new MinHeapNode(i, lists[i].val));
                }
            }

            while (heap.GetSize() > 0)
            {
                MinHeapNode min = heap.RemoveRoot();

                ListNode temp = lists[min.KIndex].next;
                ListNode minNode = lists[min.KIndex];
                minNode.next = null;
                lists[min.KIndex] = temp;

                if (lists[min.KIndex] != null)
                {
                    heap.Insert(new MinHeapNode(min.KIndex, lists[min.KIndex].val));
                }

                if (curr == null)
                {
                    curr = minNode;
                    result = curr;
                }
                else
                {
                    curr.next = minNode;
                    curr = curr.next;
                }
            }

            return result;
        }
    }
}
