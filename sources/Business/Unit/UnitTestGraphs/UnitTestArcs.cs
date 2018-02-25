﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graphs;
using Graphs.Interface;

namespace UnitTestGraphs
{
    [TestClass]
    public class UnitTestArcs
    {
        [TestInitialize()]
        public void Initialize()
        {
            Node.Clean();
        }

        [TestMethod]
        public void UnitTestArcs_TestMethodConstructorWithName()
        {
            IArc n = Arc.Create("Arc 1",null,null);
            Assert.AreEqual("Arc 1", n.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Name must have value")]
        public void UnitTestArcs_TestMethodConstructorWithBadParam()
        {
                IArc n = Arc.Create(null, null, null);
        }

        [TestMethod]
        public void UnitTestArcs_TestMethod_NodeFromTo()
        {
            INode nA = Node.Create("A");
            INode nB = Node.Create("B");

            Arc arc = Arc.Create("arc 1", nA, nB) as Arc;

            arc.From = nA;
            arc.To = nB;

            Assert.AreEqual(nA, arc.From);
            Assert.AreEqual(nB, arc.To);
        }
    }
}
