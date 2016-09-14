using System;
using VendingMachine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VendingMachineTests
{
    [TestClass]
    public class VmCoinReturnTest
    {
        VmCoinReturn _coinReturn;

        [TestInitialize]
        public void Initialize()
        {
            _coinReturn = new VmCoinReturn();
        }

        [TestMethod]
        public void WhenCoinReturnIsPassedACoinItIsAddedToListOfCoinsInReturn()
        {
            Assert.AreEqual(0, _coinReturn.CoinsInReturn.Count);
            string rejectedCoinToTest = "Coin";
            _coinReturn.ReceiveCoin(rejectedCoinToTest);
            Assert.AreEqual(1,_coinReturn.CoinsInReturn.Count);
        }

        [TestMethod]
        public void WhenCustomerTakesCoinsTheyAreRemovedFromList()
        {
            string rejectedCoinToTest = "Coin";
            _coinReturn.ReceiveCoin(rejectedCoinToTest);
            Assert.AreEqual(1, _coinReturn.CoinsInReturn.Count);
            _coinReturn.RemoveCoinsInReturn();
            Assert.AreEqual(0, _coinReturn.CoinsInReturn.Count);
        }
    }
}
