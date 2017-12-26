using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graphs;
using Graphs.Interface;

namespace UnitTestGraphs
{
    [TestClass]
    public class UnitTestNodes
    {
        [TestMethod]
        public void UnitTestNodes_TestMethodConstructorEmpty()
        {
            INode n = new Node();
            Assert.AreEqual(string.Empty, n.Name);
        }

        [TestMethod]
        public void UnitTestNodes_TestMethodConstructorWithName()
        {
            INode n = new Node("Node 1");
            Assert.AreEqual("Node 1", n.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),"Name parameter is null.")]
        public void UnitTestNodes_TestMethodConstructorWithBadParam()
        {
            INode n = new Node(null);
        }

        [TestMethod]
        public void UnitTestNodes_TestMethod_ArcAfterEmpty_BeforeEmpty()
        {
            INode n = new Node("A");
            Assert.IsNotNull(n.ArcBefore);
            Assert.IsNotNull(n.ArcAfter);
            Assert.AreEqual(0, n.ArcBefore.Count);
            Assert.AreEqual(0, n.ArcAfter.Count);
        }

        [TestMethod]
        public void UnitTestNodes_TestMethod_ArcAfterB_BeforeEmpty()
        {
            INode nA = new Node("A");
            INode nB = new Node("B");

            Assert.AreEqual(true,Node.CreateArc(nA, nB));

            Assert.AreEqual(0, nA.ArcBefore.Count);
            Assert.AreEqual(1, nA.ArcAfter.Count);

            Assert.AreEqual(1, nB.ArcBefore.Count);
            Assert.AreEqual(0, nB.ArcAfter.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UnitTestNodes_TestMethod_AddArc_BadParameter_1()
        {
            INode nA = new Node("A");
            Node.CreateArc(nA, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UnitTestNodes_TestMethod_AddArc_BadParameter_2()
        {
            INode nA = new Node("A");
            Node.CreateArc(null, nA);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UnitTestNodes_TestMethod_AddArc_BadParameter_3()
        {
            INode nA = new Node("A");
            Node.CreateArc(nA, nA);
        }

        [TestMethod]
        public void UnitTestNodes_TestMethod_TwoArc_With_Same_Node()
        {
            INode nA = new Node("A");
            INode nB = new Node("B");

            Assert.AreEqual(true, Node.CreateArc(nA, nB));
            Assert.AreEqual(false, Node.CreateArc(nA, nB));
        }

    }
}
