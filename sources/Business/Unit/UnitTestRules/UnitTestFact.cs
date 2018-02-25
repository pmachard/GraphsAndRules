using GraphsAndRules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestFact
{
    [TestClass]
    public class UnitTestFact
    {
        [TestInitialize()]
        public void Initialize()
        {
            // Fact.Clean();
        }

        [TestMethod]
        public void UnitTestFact_TestMethod_Constructor_WithName()
        {
            IFact fact = Fact.Create("Fact 1");
            Assert.AreEqual("Fact 1", fact.Name);
        }

        [TestMethod]
        public void UnitTestFact_TestMethod_Constructor_WithBadParam_name_null()
        {
            try
            {
                IFact n = Fact.Create(null);
                Assert.Fail();
            }
            catch (ArgumentNullException)
            { }
        }

        [TestMethod]
        public void UnitTestFact_TestMethod_Constructor_WithBadParam_name_empty()
        {
            try
            {
                IFact n = Fact.Create(string.Empty);
                Assert.Fail();
            }
            catch (ArgumentNullException)
            { }
        }
    }
}
