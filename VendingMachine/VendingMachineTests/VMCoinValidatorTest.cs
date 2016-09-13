using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine;

namespace VendingMachineTests
{
    [TestClass]
    public class VMCoinValidatorTest
    {
        private VMCoinValidator testValidator = new VMCoinValidator();

        [TestMethod]
        public void TestCoinValidatorReturnsFalseWhenInvalidCoinIsPassedIn()
        {           
            Assert.IsFalse(testValidator.ValidateCoin("Penny"));
            Assert.AreEqual(0, testValidator.currentTransactionTotal);
        }

        [TestMethod]
        public void TestCoinValidatorRecognizesQuarter()
        {
            Assert.IsTrue(testValidator.ValidateCoin("Quarter"));
            Assert.AreEqual(25, testValidator.currentTransactionTotal);
        }

        [TestMethod]
        public void TestCoinValidatorRecognizesDime()
        {
            Assert.IsTrue(testValidator.ValidateCoin("Dime"));
            Assert.AreEqual(10, testValidator.currentTransactionTotal);
        }

        [TestMethod]
        public void TestCoinValidatorRecognizesNickel()
        {
            Assert.IsTrue(testValidator.ValidateCoin("Nickel"));
            Assert.AreEqual(5, testValidator.currentTransactionTotal);
        }

        [TestMethod]
        public void TestCoinValidatorCanHandleMultpleCoinsPerTransaction()
        {
            testValidator.ValidateCoin("Quarter");
            Assert.AreEqual(25, testValidator.currentTransactionTotal);

            testValidator.ValidateCoin("Dime");
            Assert.AreEqual(35, testValidator.currentTransactionTotal);

            testValidator.ValidateCoin("Penny");
            Assert.AreEqual(35, testValidator.currentTransactionTotal);

            testValidator.ValidateCoin("Nickel");
            Assert.AreEqual(40, testValidator.currentTransactionTotal);
        }

    }
}
