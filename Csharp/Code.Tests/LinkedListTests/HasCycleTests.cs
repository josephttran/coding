using NUnit.Framework;
using Code.Models;
using System.Collections.Generic;

namespace Code.Tests.LinkedListTests
{
    [TestFixture]
    class HasCycleTests
    {
        private LinkedList _linkedList;

        [SetUp]
        public void Setup()
        {
            _linkedList = new LinkedList();
        }

        [Test]
        public void HasCycle_ShouldBeFalse_WhenNull()
        {
            ListNode head = null;

            bool result = _linkedList.HasCycle(head);

            Assert.IsFalse(result);
        }

        [TestCase(new int[] { 1 }, -1)]
        [TestCase(new int[] { 1, 2 }, -1)]
        [TestCase(new int[] { -21, 10, 17, 8, 4, 26, 5, 35, 33, -7, -16, 27, -12, 6, 29, -12, 5, 9, 20, 14, 14, 2, 13, -24, 21, 23, -21, 5 }, -1)]
        public void HasCycle_ShouldBeFalse_WhenNoCycle(int[] nums, int pos)
        {
            // Arrange
            List<ListNode> nodes = new List<ListNode>();

            foreach (int num in nums)
            {
                nodes.Add(new ListNode(num));
            }

            for (int i = 1; i < nodes.Count; ++i)
            {
                nodes[i - 1].next = nodes[i];
            }

            if (pos != -1)
            {
                nodes[nodes.Count - 1].next = nodes[pos];
            }

            ListNode head = nodes[0];

            // Act
            bool result = _linkedList.HasCycle(head);

            // Assert
            Assert.IsFalse(result);
        }


        [Test]
        public void HasCycle_ShouldBeTrue_WhenHasCycle()
        {
            // Arrange
            ListNode head = new ListNode(1);
            ListNode next = new ListNode(2);
            head.next = next;
            next.next = head;

            // Act
            bool result = _linkedList.HasCycle(head);

            // Assert
            Assert.IsTrue(result);
        }

        [TestCase(new int[] { 3, 2, 0, -4 }, 1)]
        public void HasCycle_ShouldBeTrue_HasCycle(int[] nums, int pos)
        {
            // Arrange
            List<ListNode> nodes = new List<ListNode>();

            foreach (int num in nums)
            {
                nodes.Add(new ListNode(num));
            }

            for (int i = 1; i < nodes.Count; ++i)
            {
                nodes[i - 1].next = nodes[i];
            }

            if (pos != -1)
            {
                nodes[nodes.Count - 1].next = nodes[pos];
            }

            ListNode head = nodes[0];

            // Act
            bool result = _linkedList.HasCycle(head);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
