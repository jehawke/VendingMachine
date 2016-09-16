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
            string expectedCoin = "Q";
            List<string> listOfCoinToTest = new List<string> { expectedCoin };
            Assert.AreEqual(0,_coinsInReturn.Count);
            _coinReturn.ReceiveCoin(listOfCoinToTest);
            Assert.AreEqual(1, _coinsInReturn.Count);
            Assert.AreEqual(expectedCoin, _coinsInReturn[0]);
        }

        [TestMethod]
        public void WhenCoinReturnIsPassedACoinItIsAddedToListOfCoinsInReturn()
        {
            Assert.AreEqual(0, _coinsInReturn.Count);
            string rejectedCoinToTest = "Coin";
            _coinReturn.ReceiveCoin(new List<string> {rejectedCoinToTest});
            Assert.AreEqual(1, _coinsInReturn.Count);
        }

        [TestMethod]
        public void WhenCustomerTakesCoinsTheyAreRemovedFromList()
        {
            string rejectedCoinToTest = "Coin";
            _coinReturn.ReceiveCoin(new List<string> {rejectedCoinToTest});
            Assert.AreEqual(1, _coinsInReturn.Count);
            _coinReturn.RemoveCoinsInReturn();
            Assert.AreEqual(0, _coinsInReturn.Count);
        }
    }
}
