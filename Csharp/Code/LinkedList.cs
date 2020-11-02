using System;
using System.Collections.Generic;
using System.Text;
using Code.Models;

namespace Code
{
    public class LinkedList
    {
        public ListNode ReverseLinkedList(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            if (head.next == null)
            {
                return head;
            }

            ListNode current = head;
            ListNode reverseList = new ListNode(current.val);
            current = current.next;

            while (current.next != null)
            {
                ListNode temp = new ListNode(current.val);
                temp.next = reverseList;
                reverseList = temp;
                current = current.next;
            }

            ListNode last = new ListNode(current.val);
            last.next = reverseList;

            return last;
        }
    }
}
