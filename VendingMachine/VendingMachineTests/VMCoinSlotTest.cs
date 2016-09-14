using VendingMachine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VendingMachineTests
{
    [TestClass]
    public class VmCoinSlotTest
    {
        private VmCoinSlot _coinSlot;
        
        [TestInitialize]
        public void Initialize()
        {
            _coinSlot = new VmCoinSlot();
        }



        [TestMethod]
        public void TestCoinSlotSendsCoinsToValidator()
        {
            string coinToSend = "Quarter";
            Assert.IsTrue(_coinSlot.ReceiveCoinAndSendToValidator(coinToSend));
        }


    }
}
