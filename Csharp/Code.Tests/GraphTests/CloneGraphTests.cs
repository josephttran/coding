using Code.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Code.Tests.GraphTests
{
    [TestFixture]
    class CloneGraphTests
    {
        private Graph _graph;

        [SetUp]
        public void SetUp()
        {
            _graph = new Graph();
        }

        [Test]
        public void CloneGraph_ShouldBeEmpty()
        {
            Node node = null;
            Node expected = null;

            Node result = _graph.CloneGraph(node);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CloneGraph_ShouldBeOne()
        {
            Node node = new Node(1);
            Node expected = new Node(1);
            int expectedNeighbor = 0;

            Node result = _graph.CloneGraph(node);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expected.val, result.val);
                Assert.AreEqual(expectedNeighbor, expected.neighbors.Count);
                Assert.AreEqual(expectedNeighbor, result.neighbors.Count);
            });
        }

        [Test]
        public void CloneGraph_ShouldDeepCloneOne()
        {
            Node node = new Node(1);
            Node expected = new Node(1);
            int expectedNeighbor = 0;

            Node result = _graph.CloneGraph(node);

            Assert.Multiple(() => 
            {
                Assert.IsFalse(result.Equals(node));
                Assert.AreEqual(expected.val, result.val);
                Assert.AreEqual(expectedNeighbor, expected.neighbors.Count);
                Assert.AreEqual(expectedNeighbor, result.neighbors.Count);
            });
        }

        [Test]
        public void CloneGraph_ShouldDeepCopyGraph()
        {
            Node one = new Node(1);
            Node two = new Node(2);
            Node three = new Node(3);
            Node four = new Node(4);

            one.neighbors = new List<Node> { two, four };
            two.neighbors = new List<Node> { one, three };
            three.neighbors = new List<Node> { two, four };
            four.neighbors = new List<Node> { one, three };

            int expectedOneVal = 1;
            int expectedTwoVal = 2;
            int expectedThreeVal = 3;
            int expectedFourVal = 4;
            int[] expectedOneNeighbors = { 2, 4 };
            int[] expectedTwoNeighbors = { 1, 3 };
            int[] expectedThreeNeighbors = { 2, 4 };
            int[] expectedFourNeighbors = { 1, 3 };

            Node result = _graph.CloneGraph(one);

            Assert.Multiple(() =>
            {
                Node currNode = result;
                Assert.IsFalse(currNode.Equals(one));
                Assert.AreEqual(expectedOneVal, currNode.val);
                Assert.IsTrue(IsSameNeighbors(expectedOneNeighbors, currNode.neighbors));

                currNode = currNode.neighbors[0];
                Assert.IsFalse(currNode.Equals(two));
                Assert.AreEqual(expectedTwoVal, currNode.val);
                Assert.IsTrue(IsSameNeighbors(expectedTwoNeighbors, currNode.neighbors));

                currNode = currNode.neighbors[1];
                Assert.IsFalse(currNode.Equals(three));
                Assert.AreEqual(expectedThreeVal, currNode.val);
                Assert.IsTrue(IsSameNeighbors(expectedThreeNeighbors, currNode.neighbors));

                currNode = currNode.neighbors[1];
                Assert.IsFalse(currNode.Equals(four));
                Assert.AreEqual(expectedFourVal, currNode.val);
                Assert.IsTrue(IsSameNeighbors(expectedFourNeighbors, currNode.neighbors));
            });
        }

        private bool IsSameNeighbors(int[] expected, IList<Node> neighbors)
        {
            if (expected.Length != neighbors.Count)
            {
                return false;
            }

            foreach (Node node in neighbors)
            {
                if (Array.IndexOf(expected, node.val) == -1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
