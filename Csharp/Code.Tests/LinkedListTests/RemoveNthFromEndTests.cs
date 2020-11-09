using NUnit.Framework;
using Code.Models;

namespace Code.Tests.LinkedListTests
{
    [TestFixture]
    class RemoveNthFromEndTests
    {
        private LinkedList _linkedList;

        [SetUp]
        public void Setup()
        {
            _linkedList = new LinkedList();
        }

        [Test]
        public void RemoveNthFromEnd_ShouldBeNull_WhenNEqualNumberOfNodes()
        {
            ListNode head = new ListNode(1);
            int n = 1;
            ListNode expected = null;

            ListNode result = _linkedList.RemoveNthFromEnd(head, n);

            Assert.AreEqual(expected, result);
        }

        [TestCase(new int[] { 1, 2 }, 1, new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, new int[] { 1, 2, 3, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5, new int[] { 2, 3, 4, 5 })]
        public void RemoveNthFromEnd_ShouldReturnNewListNodeWithNthNodeRemoveFromEnd(int[] nums, int n, int[] expectedNums)
        {
            ListNode head = null;
            ListNode headPointer = null;
            ListNode expectedHead = null;
            ListNode expectedPointer = null;

            foreach (int num in nums)
            {
                if (headPointer == null)
                {
                    headPointer = new ListNode(num);
                    head = headPointer;
                }
                else
                {
                    headPointer.next = new ListNode(num);
                    headPointer = headPointer.next;
                }
            }

            foreach (int num in expectedNums)
            {
                if (expectedPointer == null)
                {
                    expectedPointer = new ListNode(num);
                    expectedHead = expectedPointer;
                }
                else
                {
                    expectedPointer.next = new ListNode(num);
                    expectedPointer = expectedPointer.next;
                }
            }

            expectedPointer = expectedHead;

            ListNode result = _linkedList.RemoveNthFromEnd(head, n);

            Assert.Multiple(() =>
            {
                Assert.NotNull(expectedPointer);
                Assert.NotNull(result);

                while (expectedPointer != null && result != null)
                {
                    Assert.AreEqual(expectedPointer.val, result.val);

                    if (expectedPointer.next == null && result.next != null || expectedPointer.next != null && result.next == null)
                    {
                        Assert.Fail();
                    }

                    expectedPointer = expectedPointer.next;
                    result = result.next;
                }
            });
        }
    }
}
