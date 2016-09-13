using System;
using VendingMachine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VendingMachineTests
{
    [TestClass]
    public class VmCoinSlotTest
    {
        private string coinToSend;

        [TestMethod]
        public void TestCoinSlotSendsCoinsToValidator()
        {
            coinToSend = "Quarter";
            VmCoinSlot coinSlot = new VmCoinSlot();


        }

    }
}
