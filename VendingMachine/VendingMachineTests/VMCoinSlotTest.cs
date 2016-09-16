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
            Assert.IsFalse(_coinSlot.GetSendCoinToReturnWasCalled());
            Assert.IsFalse(_coinSlot.ReceiveCoinAndSendToValidator(coinToSend));
            Assert.IsTrue(_coinSlot.GetSendCoinToReturnWasCalled());
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
    }
}
