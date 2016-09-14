using System.Collections.Generic;
using VendingMachine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VendingMachineTests
{
    [TestClass]
    public class VmCoinReturnTest
    {
        private VmCoinReturn _coinReturn;
        private List<string> _coinsInReturn;

        [TestInitialize]
        public void Initialize()
        {
            _coinReturn = new VmCoinReturn();
            _coinsInReturn = _coinReturn.CheckReturn();
        }

        [TestMethod]
        public void TestCheckReturnReturnsListOfCoinsInReturn()
        {
            string coinToTest = "Quarter";
            Assert.AreEqual(0,_coinsInReturn.Count);
            _coinReturn.ReceiveCoin(coinToTest);
            Assert.AreEqual(1, _coinsInReturn.Count);
            Assert.AreEqual(coinToTest, _coinsInReturn[0]);
        }

        [TestMethod]
        public void WhenCoinReturnIsPassedACoinItIsAddedToListOfCoinsInReturn()
        {
            Assert.AreEqual(0, _coinsInReturn.Count);
            string rejectedCoinToTest = "Coin";
            _coinReturn.ReceiveCoin(rejectedCoinToTest);
            Assert.AreEqual(1, _coinsInReturn.Count);
        }

        [TestMethod]
        public void WhenCustomerTakesCoinsTheyAreRemovedFromList()
        {
            string rejectedCoinToTest = "Coin";
            _coinReturn.ReceiveCoin(rejectedCoinToTest);
            Assert.AreEqual(1, _coinsInReturn.Count);
            _coinReturn.RemoveCoinsInReturn();
            Assert.AreEqual(0, _coinsInReturn.Count);
        }
    }
}
