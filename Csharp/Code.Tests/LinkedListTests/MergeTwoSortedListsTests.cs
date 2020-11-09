using NUnit.Framework;
using Code.Models;
using System.Collections.Generic;

namespace Code.Tests.LinkedListTests
{
    [TestFixture]
    class MergeTwoSortedListsTests
    {
        private LinkedList _linkedList;

        [SetUp]
        public void Setup()
        {
            _linkedList = new LinkedList();
        }

        [Test]
        public void MergeTwoSortedLists_ShouldBeNullothWhenNull()
        {
            ListNode firstHead = null;
            ListNode secondHead = null;
            ListNode expected = null;

            ListNode result = _linkedList.MergeTwoSortedLists(firstHead, secondHead);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void MergeTwoSortedLists_WhenOneListNull_ReturnOther()
        {
            ListNode firstHead = null;
            ListNode secondHead = new ListNode(0);
            ListNode expected = new ListNode(0);

            ListNode result = _linkedList.MergeTwoSortedLists(firstHead, secondHead);

            Assert.Multiple(() =>
            {
                while (expected != null && result != null)
                {
                    Assert.AreEqual(expected.val, result.val);

                    if (expected.next == null && result.next != null || expected.next != null && result.next == null)
                    {
                        Assert.Fail();
                    }

                    expected = expected.next;
                    result = result.next;
                }
            });
        }

        [TestCase(new int[] { 1, 2, 4 }, new int[] { 1, 3, 4 }, new int[] { 1, 1, 2, 3, 4, 4 })]
        public void MergeTwoSortedLists_ShouldReturnMergeSortedList(int[] firstNumList, int[] secondNumList, int[] expectedNumList)
        {
            // Arrange
            ListNode firstHead = null;
            ListNode secondHead = null;
            ListNode expectedHead = null;
            ListNode firstListPointer = null;
            ListNode secondListPointer = null;
            ListNode expectedListPointer = null;

            foreach (int num in firstNumList)
            {
                if (firstListPointer == null)
                {
                    firstListPointer = new ListNode(num);
                    firstHead = firstListPointer;
                }
                else
                {
                    firstListPointer.next = new ListNode(num);
                    firstListPointer = firstListPointer.next;
                }
            }

            foreach (int num in secondNumList)
            {
                if (secondListPointer == null)
                {
                    secondListPointer = new ListNode(num);
                    secondHead = secondListPointer;
                }
                else
                {
                    secondListPointer.next = new ListNode(num);
                    secondListPointer = secondListPointer.next;
                }
            }

            foreach (int num in expectedNumList)
            {
                if (expectedListPointer == null)
                {
                    expectedListPointer = new ListNode(num);
                    expectedHead = expectedListPointer;
                }
                else
                {
                    expectedListPointer.next = new ListNode(num);
                    expectedListPointer = expectedListPointer.next;
                }
            }

            expectedListPointer = expectedHead;

            // Act
            ListNode result = _linkedList.MergeTwoSortedLists(firstHead, secondHead);

            // Assert
            Assert.Multiple(() =>
            {
                int i = 0;

                while (expectedListPointer != null && result != null)
                {
                    Assert.AreEqual(expectedListPointer.val, result.val);

                    i++;
                    expectedListPointer = expectedListPointer.next;
                    result = result.next;
                }

                Assert.AreEqual(i, expectedNumList.Length);
            });
        }
    }
}
