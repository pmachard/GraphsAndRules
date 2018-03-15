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
        }

        [TestMethod]
        public void UnitTestFact_TestMethod_Constructor_WithName()
        {
            var factBase = new FactBase();
            var fact = factBase.Create("Fact 1");
            Assert.AreEqual("Fact 1", fact.Name);
        }

        [TestMethod]
        public void UnitTestFact_TestMethod_Constructor_WithBadParam_name_exist()
        {
            try
            {
                var factBase = new FactBase();
                var n1 = factBase.Create("Fact 1");
                var n2 = factBase.Create("Fact 1");
                Assert.Fail();
            }
            catch (ArgumentException)
            { }
        }

        [TestMethod]
        public void UnitTestFact_TestMethod_Constructor_WithBadParam_name_null()
        {
            try
            {
                var factBase = new FactBase();
                var n = factBase.Create(null);
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
                var factBase = new FactBase();
                var n = factBase.Create(string.Empty);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }
        }

        [TestMethod]
        public void UnitTestFact_TestMethod_Constructor_WithName_and_value_string()
        {
            var factBase = new FactBase();
            var fact = factBase.Create("A", "polo");
            Assert.AreEqual("A", fact.Name);
            Assert.AreEqual("polo", fact.Value);
        }

        [TestMethod]
        public void UnitTestFact_TestMethod_Constructor_WithName_and_value_int()
        {
            var factBase = new FactBase();
            var fact = factBase.Create("B", "10");

            Assert.AreEqual("B", fact.Name);
            Assert.AreEqual("10", fact.Value);
        }

        [TestMethod]
        public void UnitTestFact_TestMethod_Constructor_WithName_and_value_double()
        {
            var factBase = new FactBase();
            var fact = factBase.Create("C", "1.33");

            Assert.AreEqual("C", fact.Name);
            Assert.AreEqual("1.33", fact.Value);
        }
    }
}
