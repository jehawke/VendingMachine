using VendingMachine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VendingMachineTests
{
    [TestClass]
    public class VmCoinSlotTest
    {
        private string _coinToSend;

        [TestMethod]
        public void TestCoinSlotSendsCoinsToValidator()
        {
            _coinToSend = "Quarter";
            VmCoinSlot coinSlot = new VmCoinSlot();


        }

    }
}
