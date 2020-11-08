using System;
using System.Collections.Generic;
using System.Text;
using Code.Models;

namespace Code
{
    public class LinkedList
    {
        /* Given head, the head of a linked list, determine if the linked list has a cycle in it. 
         * There is a cycle in a linked list if there is some node in the list that can be reached again by 
         * continuously following the next pointer. Internally, pos is used to denote the index of the node 
         * that tail's next pointer is connected to. Note that pos is not passed as a parameter.
         * Return true if there is a cycle in the linked list. Otherwise, return false.
         */
        public bool HasCycle(ListNode head)
        {
            if (head == null)
            {
                return false;
            }

            ListNode slowPointer = head;
            ListNode fastPointer = head;

            while (slowPointer.next != null && fastPointer.next != null)
            {
                slowPointer = slowPointer.next;
                fastPointer = fastPointer.next;

                if (fastPointer.next != null)
                {
                    fastPointer = fastPointer.next;
                }
                else
                {
                    break;
                }

                if (slowPointer == fastPointer)
                {
                    return true;
                }
            }

            return false;
        }

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
