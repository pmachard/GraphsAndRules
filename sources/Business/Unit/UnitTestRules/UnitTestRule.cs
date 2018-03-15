using GraphsAndRules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestFact
{
    [TestClass]
    public class UnitTestRule
    {
        [TestInitialize()]
        public void Initialize()
        {
        }

        [TestMethod]
        public void UnitTestRule_TestMethod_Constructor_WithName()
        {
            IRuleBase ruleBase = new RuleBase();
            IRule rule = ruleBase.Create("Rule 1");
            Assert.AreEqual("Rule 1", rule.Name);
        }

        [TestMethod]
        public void UnitTestRule_TestMethod_Constructor_WithBadParam_name_exist()
        {
            try
            {
                var ruleBase = new RuleBase();
                var n1 = ruleBase.Create("Rule 1");
                var n2 = ruleBase.Create("Rule 1");
                Assert.Fail();
            }
            catch (ArgumentException)
            { }
        }

        [TestMethod]
        public void UnitTestRule_TestMethod_Constructor_WithBadParam_name_null()
        {
            try
            {
                var ruleBase = new RuleBase();
                var n1 = ruleBase.Create(null);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }
        }

        [TestMethod]
        public void UnitTestRule_TestMethod_Constructor_WithBadParam_name_empty()
        {
            try
            {
                var ruleBase = new RuleBase();
                var n1 = ruleBase.Create(string.Empty);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }
        }

        [TestMethod]
        public void UnitTestRule_TestMethod_Constructor_Complet()
        {
            try
            {
                var ruleBase = new RuleBase();
                var n1 = ruleBase.Create(string.Empty);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }
        }

    }
}
