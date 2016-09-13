using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine;

namespace VendingMachineTests
{
    [TestClass]
    public class VmCoinValidatorTest
    {
        private readonly VmCoinValidator _testValidator = new VmCoinValidator();

        [TestMethod]
        public void TestCoinValidatorReturnsFalseWhenInvalidCoinIsPassedIn()
        {           
            Assert.IsFalse(_testValidator.ValidateCoin("Penny"));
            Assert.AreEqual(0, _testValidator.CurrentTransactionTotal);
        }

        [TestMethod]
        public void TestCoinValidatorRecognizesQuarter()
        {
            Assert.IsTrue(_testValidator.ValidateCoin("Quarter"));
            Assert.AreEqual(25, _testValidator.CurrentTransactionTotal);
        }

        [TestMethod]
        public void TestCoinValidatorRecognizesDime()
        {
            Assert.IsTrue(_testValidator.ValidateCoin("Dime"));
            Assert.AreEqual(10, _testValidator.CurrentTransactionTotal);
        }

        [TestMethod]
        public void TestCoinValidatorRecognizesNickel()
        {
            Assert.IsTrue(_testValidator.ValidateCoin("Nickel"));
            Assert.AreEqual(5, _testValidator.CurrentTransactionTotal);
        }

        [TestMethod]
        public void TestCoinValidatorCanHandleMultpleCoinsPerTransaction()
        {
            _testValidator.ValidateCoin("Quarter");
            Assert.AreEqual(25, _testValidator.CurrentTransactionTotal);

            _testValidator.ValidateCoin("Dime");
            Assert.AreEqual(35, _testValidator.CurrentTransactionTotal);

            _testValidator.ValidateCoin("Penny");
            Assert.AreEqual(35, _testValidator.CurrentTransactionTotal);

            _testValidator.ValidateCoin("Nickel");
            Assert.AreEqual(40, _testValidator.CurrentTransactionTotal);
        }

    }
}
