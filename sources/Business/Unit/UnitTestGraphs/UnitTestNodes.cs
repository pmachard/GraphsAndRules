using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphsAndRules;
using System;
using System.Collections.Generic;

namespace UnitTestGraphs
{
    [TestClass]
    public class UnitTestNodes
    {
        [TestInitialize()]
        public void Initialize()
        {
            Node.Clean();
        }

        [TestMethod]
        public void UnitTestNodes_TestMethodConstructorWithName()
        {
            INode n = Node.Create("Node 1");
            Assert.AreEqual("Node 1", n.Name);
        }

        [TestMethod]
        public void UnitTestNodes_TestMethodConstructorWithBadParam()
        {
            try
            {
                INode n = Node.Create(null);
                Assert.Fail();
            }
            catch (ArgumentNullException)
            {
            }
        }

        [TestMethod]
        public void UnitTestNodes_TestMethodConstructorEmpty()
        {
            try
            {
                INode n = Node.Create(string.Empty);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }
        }

    [TestMethod]
        public void UnitTestNodes_TestMethodConstructorWithSameName()
        {
            try
            {
                INode nA = Node.Create("A");
                INode nAbis = Node.Create("A");
                Assert.Fail();
            }
            catch (ArgumentException)
            { }
        }

        [TestMethod]
        public void UnitTestNodes_TestMethodConstructorWithSameName_ButWithsection()
        {
            using (Node.Create("A")) { }
            using (Node.Create("A")) { }
        }

        [TestMethod]
        public void UnitTestNodes_TestMethod_ArcAfterEmpty_BeforeEmpty()
        {
            INode n = Node.Create("A");
            Assert.IsNotNull(n.ArcsBefore);
            Assert.IsNotNull(n.ArcsAfter);
            Assert.AreEqual(0, n.ArcsBefore.Count);
            Assert.AreEqual(0, n.ArcsAfter.Count);
        }

        [TestMethod]
        public void UnitTestNodes_TestMethod_ArcAfterB_BeforeEmpty()
        {
            INode nA = Node.Create("A");
            INode nB = Node.Create("B");

            Assert.AreEqual(true,Node.CreateArc(nA, nB));

            Assert.AreEqual(0, nA.ArcsBefore.Count);
            Assert.AreEqual(1, nA.ArcsAfter.Count);

            Assert.AreEqual(1, nB.ArcsBefore.Count);
            Assert.AreEqual(0, nB.ArcsAfter.Count);
        }

        [TestMethod]
        public void UnitTestNodes_TestMethod_AddArc_BadParameter_1()
        {
            try
            {
                INode nA = Node.Create("A");
                Node.CreateArc(nA, null);
                Assert.Fail();
            }
            catch (ArgumentNullException) { }
        }

        [TestMethod]
        public void UnitTestNodes_TestMethod_AddArc_BadParameter_2()
        {
            try
            {
                INode nA = Node.Create("A");
                Node.CreateArc(null, nA);
                Assert.Fail();
            }
            catch (ArgumentNullException)
            { }
        }

        [TestMethod]
        public void UnitTestNodes_TestMethod_AddArc_BadParameter_3()
        {
            try
            {
                INode nA = Node.Create("A");
                Node.CreateArc(nA, nA);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }
        }

        [TestMethod]
        public void UnitTestNodes_TestMethod_TwoArc_With_Same_Node()
        {
            INode nA = Node.Create("A");
            INode nB = Node.Create("B");

            Assert.AreEqual(true, Node.CreateArc(nA, nB));
            Assert.AreEqual(false, Node.CreateArc(nA, nB));
        }

        [TestMethod]
        public void UnitTestNodes_TestMethod_Arc_AB_BA()
        {
            INode nA = Node.Create("A");
            INode nB = Node.Create("B");

            Assert.AreEqual(true, Node.CreateArc(nA, nB));
            Assert.AreEqual(true, Node.CreateArc(nB, nA));
        }

        [TestMethod]
        public void UnitTestNodes_TestMethod_Arc_AB_BC_CA()
        {
            INode nA = Node.Create("A");
            INode nB = Node.Create("B");
            INode nC = Node.Create("C");

            Assert.AreEqual(true, Node.CreateArc(nA, nB));
            Assert.AreEqual(true, Node.CreateArc(nB, nC));
            Assert.AreEqual(true, Node.CreateArc(nC, nA));
        }

        [TestMethod]
        public void UnitTestNodes_TestMethod_Way_A()
        {
            INode nA = Node.Create("A");
            IList<INode> way = nA.Way();

            Assert.IsNotNull(way);
            Assert.AreEqual(1, way.Count);
            Assert.AreEqual(nA, way[0]);
        }

        [TestMethod]
        public void UnitTestNodes_TestMethod_Way_AB_Without_Arc()
        {
            INode nA = Node.Create("A");
            INode nB = Node.Create("B");
            IList<INode> way = nA.Way();

            Assert.IsNotNull(way);
            Assert.AreEqual(1, way.Count);
            Assert.AreEqual(nA, way[0]);
        }

        [TestMethod]
        public void UnitTestNodes_TestMethod_Way_AB_With_Arc_AB()
        {
            INode nA = Node.Create("A");
            INode nB = Node.Create("B");

            Assert.AreEqual(true, Node.CreateArc(nA, nB));
            IList<INode> way = nA.Way();

            Assert.IsNotNull(way);
            Assert.AreEqual(2, way.Count);
            Assert.AreEqual(nA, way[0]);
            Assert.AreEqual(nB, way[1]);
        }

        [TestMethod]
        public void UnitTestNodes_TestMethod_Way_ABC_With_Arc_AB_BC()
        {
            INode nA = Node.Create("A");
            INode nB = Node.Create("B");
            INode nC = Node.Create("C");

            Assert.AreEqual(true, Node.CreateArc(nA, nB));
            Assert.AreEqual(true, Node.CreateArc(nB, nC));
            IList<INode> way = nA.Way();

            Assert.IsNotNull(way);
            Assert.AreEqual(3, way.Count);
            Assert.AreEqual(nA, way[0]);
            Assert.AreEqual(nB, way[1]);
            Assert.AreEqual(nC, way[2]);
        }
    }
}
