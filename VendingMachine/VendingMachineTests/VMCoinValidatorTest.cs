using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine;

namespace VendingMachineTests
{
    [TestClass]
    public class VMCoinValidatorTest
    {
        [TestMethod]
        public void TestCoinValidatorReturnsFalseWhenInvalidCoinIsPassedIn()
        {
            VMCoinValidator testValidator = new VMCoinValidator();
            Assert.IsFalse(testValidator.ValidateCoin("Penny"));
        }

        [TestMethod]
        public void TestCoinValidatorReturnsTrueWhenQuarterPassedIn()
        {
            VMCoinValidator testValidator = new VMCoinValidator();
            Assert.IsTrue(testValidator.ValidateCoin("Quarter"));
        }

        [TestMethod]
        public void TestCoinValidatorReturnsTrueWhenDimePassedIn()
        {
            VMCoinValidator testValidator = new VMCoinValidator();
            Assert.IsTrue(testValidator.ValidateCoin("Dime"));
        }

        [TestMethod]
        public void TestCoinValidatorReturnsTrueWhenNIckelPassedIn()
        {
            VMCoinValidator testValidator = new VMCoinValidator();
            Assert.IsTrue(testValidator.ValidateCoin("Nickel"));
        }
    }
}
