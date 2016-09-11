using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine;

namespace VendingMachineTests
{
    [TestClass]
    public class VMCoinValidatorTest
    {
        [TestMethod]
        public void TestCoinValidatorReturnsTrueWhenAValidCoinIsPassedIn()
        {
            VMCoinValidator testValidator = new VMCoinValidator();
            Assert.IsTrue(testValidator.ValidateCoin());
        }
    }
}
