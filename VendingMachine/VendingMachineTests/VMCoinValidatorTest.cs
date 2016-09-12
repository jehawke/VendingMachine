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
            Assert.IsFalse(testValidator.ValidateCoin("Coin"));
        }
    }
}
