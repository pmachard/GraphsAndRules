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
            catch (ArgumentException)
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
            catch (ArgumentException)
            { }
        }

        [TestMethod]
        public void UnitTestFact_TestMethod_Constructor_WithName_and_value_string()
        {
            IFact fact = Fact.Create("A", "polo");
            Assert.AreEqual("A", fact.Name);
            Assert.AreEqual("polo", fact.Value);
        }

        [TestMethod]
        public void UnitTestFact_TestMethod_Constructor_WithName_and_value_int()
        {
            IFact fact = Fact.Create("B", "10");
            Assert.AreEqual("B", fact.Name);
            Assert.AreEqual("10", fact.Value);
        }

        [TestMethod]
        public void UnitTestFact_TestMethod_Constructor_WithName_and_value_double()
        {
            IFact fact = Fact.Create("C", "1.33");
            Assert.AreEqual("C", fact.Name);
            Assert.AreEqual("1.33", fact.Value);
        }
    }
}
