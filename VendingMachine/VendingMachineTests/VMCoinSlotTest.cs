using System.Collections.Generic;
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
            _coinSlot = new VmCoinSlot(new List<string>(),new VmCoinReturn(), new VmCoinValidator());
        }
        
        [TestMethod]
        public void TestCoinSlotSendsCoinsToValidator()
        {
            string coinToSend = "Q";
            Assert.IsTrue(_coinSlot.ReceiveCoinAndSendToValidator(coinToSend));
        }

        [TestMethod]
        public void TestWhenCoinIsInvalidCoinIsSentToCoinReturn()
        {
            string coinToSend = "Penny";
            Assert.AreEqual(0, _coinSlot.GetTimesSendCoinToReturnWasCalled());
            Assert.IsFalse(_coinSlot.ReceiveCoinAndSendToValidator(coinToSend));
            Assert.AreEqual(1, _coinSlot.GetTimesSendCoinToReturnWasCalled());
        }

        [TestMethod]
        public void TestWhenValidCoinIsInsertedItIsHeldForCurrentTransaction()
        {
            string firstCoinToSend = "Q";
            string secondCoinToSend = "Pocket Lint";
            string thirdCoinToSend = "D";

            Assert.AreEqual(0, _coinSlot.GetCoinsInCurrentTransaction().Count);
            _coinSlot.ReceiveCoinAndSendToValidator(firstCoinToSend);
            Assert.AreEqual(1, _coinSlot.GetCoinsInCurrentTransaction().Count);
            _coinSlot.ReceiveCoinAndSendToValidator(secondCoinToSend);
            Assert.AreEqual(1, _coinSlot.GetCoinsInCurrentTransaction().Count);
            _coinSlot.ReceiveCoinAndSendToValidator(thirdCoinToSend);
            Assert.AreEqual(2, _coinSlot.GetCoinsInCurrentTransaction().Count);
            Assert.AreEqual("Q",_coinSlot.GetCoinsInCurrentTransaction()[0]);
            Assert.AreEqual("D", _coinSlot.GetCoinsInCurrentTransaction()[1]);
        }

        [TestMethod]
        public void TestCoinSlotCanGiveRefundsToCoinReturn()
        {
            string firstCoinToSend = "Q";
            string secondCoinToSend = "D";

            _coinSlot.ReceiveCoinAndSendToValidator(firstCoinToSend);
            _coinSlot.ReceiveCoinAndSendToValidator(secondCoinToSend);

            Assert.AreEqual(2,_coinSlot.GetCoinsInCurrentTransaction().Count);

            _coinSlot.GiveRefund();

            Assert.AreEqual(0,_coinSlot.GetCoinsInCurrentTransaction().Count);
            Assert.AreEqual(2, _coinSlot.GetTimesSendCoinToReturnWasCalled());

        }
    }
}
