using NUnit.Framework;
using Code.Models;

namespace Code.Tests.LinkedListTests
{
    [TestFixture]
    class ReorderListTests
    {
        private LinkedList _linkedList;

        [SetUp]
        public void Setup()
        {
            _linkedList = new LinkedList();
        }

        [Test]
        public void ReorderList_ShouldBeNull()
        {
            ListNode head = null;
            ListNode expected = null;

            _linkedList.ReorderList(head);

            Assert.AreEqual(expected, head);
        }

        [TestCase(new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 4, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 5, 2, 4, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6}, new int[] { 1, 6, 2, 5, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 7, 2, 6, 3, 5, 4 })]
        public void ReorderList_Tests(int[] nums, int[] expectedNums)
        {
            // Arrange
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

            // Act
            _linkedList.ReorderList(head);
            ListNode result = head;

            // Assert
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
