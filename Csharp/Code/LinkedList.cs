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


        /* Merge two sorted linked lists and return it as a new sorted list. 
         * The new list should be made by splicing together the nodes of the first two lists.
         */
        public ListNode MergeTwoSortedLists(ListNode l1, ListNode l2)
        {
            ListNode sortedListHead = null;
            ListNode current = null;
            ListNode insertNode = null;
            ListNode nextNode = null;

            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    nextNode = l1.next;
                    insertNode = l1;
                    l1 = nextNode;
                }
                else
                {
                    nextNode = l2.next;
                    insertNode = l2;
                    l2 = nextNode;
                }

                insertNode.next = null;

                if (current == null)
                {
                    current = insertNode;
                    sortedListHead = current;
                }
                else
                {
                    current.next = insertNode;
                    current = current.next;
                }
            }

            if (l1 != null)
            {
                if (sortedListHead == null)
                {
                    return l1;
                }
                else
                {
                    current.next = l1;
                }
            }

            if (l2 != null)
            {
                if (sortedListHead == null)
                {
                    return l2;
                }
                else
                {
                    current.next = l2;
                }            
            }

            return sortedListHead;
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
