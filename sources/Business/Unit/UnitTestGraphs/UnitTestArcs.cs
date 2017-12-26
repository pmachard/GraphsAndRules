using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graphs;
using Graphs.Interface;

namespace UnitTestGraphs
{
    [TestClass]
    public class UnitTestArcs
    {
        [TestMethod]
        public void UnitTestArcs_TestMethodConstructorEmpty()
        {
            Arc n = new Arc();
            Assert.AreEqual(string.Empty, n.Name);
        }

        [TestMethod]
        public void UnitTestArcs_TestMethodConstructorWithName()
        {
            Arc n = new Arc("Arc 1");
            Assert.AreEqual("Arc 1", n.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),"Name parameter is null.")]
        public void UnitTestArcs_TestMethodConstructorWithBadParam()
        {
            Arc n = new Arc(null);
        }

        [TestMethod]
        public void UnitTestArcs_TestMethod_NodeFromTo()
        {
            INode nA = new Node("A");
            INode nB = new Node("B");

            Arc arc = new Arc("arc 1");

            arc.From = nA;
            arc.To = nB;

            Assert.AreEqual(nA, arc.From);
            Assert.AreEqual(nB, arc.To);
        }

    }
}
