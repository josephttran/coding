using NUnit.Framework;
using Code.Models;

namespace Code.Tests.LinkedListTests
{
    [TestFixture]
    class MergeKListsTests
    {
        private LinkedList _linkedList;

        [SetUp]
        public void Setup()
        {
            _linkedList = new LinkedList();
        }

        [Test]
        public void MergeKLists_ShouldBeNull_WhenEmpty()
        {
            ListNode[] list = new ListNode[] { };
            ListNode expected = null;

            ListNode result = _linkedList.MergeKLists(list);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void MergeKLists_ShouldBeNull_WhenContainEmptyListNode()
        {
            ListNode[] list = new ListNode[] { null };
            ListNode expected = null;

            ListNode result = _linkedList.MergeKLists(list);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void MergeKLists_WhenContainSingleListNode()
        {
            ListNode[] list = new ListNode[] { new ListNode(1) };
            ListNode expected = new ListNode(1);

            ListNode result = _linkedList.MergeKLists(list);

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
        }

        [Test]
        public void MergeKLists_WhenNotEmpty_ReturnSortedListNode()
        {
            // Arrange
            ListNode zero = new ListNode(1, new ListNode(4, new ListNode(5, null)));
            ListNode one = new ListNode(1, new ListNode(3, new ListNode(4, null)));
            ListNode two = new ListNode(2, new ListNode(6, null));
            ListNode[] list = new ListNode[] { zero, one, two };

            ListNode expected = new ListNode(
                1, new ListNode(
                1, new ListNode(
                2, new ListNode(
                3, new ListNode(
                4, new ListNode(
                4, new ListNode(
                5, new ListNode(
                6, null
            ))))))));

            // Act
            ListNode result = _linkedList.MergeKLists(list);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(expected);
                Assert.NotNull(result);

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

        [Test]
        public void MergeKLists_WhenNotEmpty_ReturnSorted()
        {
            // Arrange
            ListNode zero = null;
            ListNode one = new ListNode(-1, new ListNode(5, new ListNode(11, null)));
            ListNode two = null;
            ListNode three = new ListNode(6, new ListNode(10,  null));
            ListNode[] list = new ListNode[] { zero, one, two, three };

            ListNode expected = new ListNode(
                -1, new ListNode(
                5, new ListNode(
                6, new ListNode(
                10, new ListNode(
                11, null
            )))));

            // Act
            ListNode result = _linkedList.MergeKLists(list);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(expected);
                Assert.NotNull(result);

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
    }
}
