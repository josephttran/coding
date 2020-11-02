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
            ListNode reverseList = null;
            ListNode current = head;

            while (current != null)
            {
                ListNode next = current.next;
                current.next = reverseList;
                reverseList = current;
                current = next;
            }

            return reverseList;
        }
    }
}
