using NUnit.Framework;
using Code.Models;

namespace Code.Tests.LinkedListTests
{
    [TestFixture]
    class ReverseLinkedListTests
    {
        private LinkedList _linkedList;

        [SetUp]
        public void Setup()
        {
            _linkedList = new LinkedList();
        }

        [Test]
        public void ReverseLinkedList_WhenNull()
        {
            // Arrange
            ListNode head = null;

            // Act
            ListNode result = _linkedList.ReverseLinkedList(head);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void ReverseLinkedList_WhenSingle()
        {
            // Arrange
            ListNode head = new ListNode(4);

            // Act
            ListNode result = _linkedList.ReverseLinkedList(head);

            // Assert
            Assert.AreSame(head, result);
        }

        [Test]
        public void ReverseLinkedList_ShouldReturnReverseList()
        {
            // Arrange
            int startVal = 1;
            int endVal = 5;
            ListNode head = new ListNode(startVal);

            for (int i = startVal + 1; i <= endVal; ++i)
            {
                ListNode current = head;

                while (current.next != null)
                {
                    current = current.next;
                }

                current.next = new ListNode(i);
            }

            // Act
            ListNode result = _linkedList.ReverseLinkedList(head);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(result);

                int val = endVal;

                while (result.next != null)
                {
                    Assert.AreEqual(val, result.val);
                    result = result.next;
                    val--;
                }

                Assert.AreEqual(startVal, result.val);
            });
        }   
    }
}
