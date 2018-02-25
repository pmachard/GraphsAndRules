using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphsAndRules;

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
        public void UnitTestArcs_TestMethod_Constructor_With_Name()
        {
            IArc n = Arc.Create("Arc 1",null,null);
            Assert.AreEqual("Arc 1", n.Name);
        }

        [TestMethod]
        public void UnitTestArcs_TestMethod_Constructor_With_BadParam_null()
        {
            try
            {
                IArc n = Arc.Create(null, null, null);
                Assert.Fail();
            }
            catch (ArgumentException) { }
        }

        [TestMethod]
        public void UnitTestArcs_TestMethod_Constructor_With_BadParam_Name_Empty()
        {
            try
            {
                IArc n = Arc.Create(string.Empty, null, null);
                Assert.Fail();
            }
            catch (ArgumentException) { }
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
