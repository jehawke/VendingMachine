using System;
using VendingMachine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VendingMachineTests
{
    [TestClass]
    public class VMCoinSlotTest
    {
        [TestMethod]
        public void TestCoinSlotAcceptsItems()
        {
            VMCoinSlot coinSlot = new VMCoinSlot();
            Assert.IsFalse(coinSlot.bItemWasInserted);
            coinSlot.sendInsertedItemToValidator();
            Assert.IsTrue(coinSlot.bItemWasInserted);
        }
    }
}
