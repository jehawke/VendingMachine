﻿using System;
using VendingMachine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VendingMachineTests
{
    [TestClass]
    public class VmCoinReturnTest
    {

        
        [TestMethod]
        public void WhenCoinReturnIsPassedACoinItIsAddedToListOfCoinsInReturn()
        {
            VmCoinReturn coinReturn = new VmCoinReturn();
            Assert.AreEqual(0, coinReturn.coinsInReturn.Count);
            string rejectedCoinToTest = "Coin";
            coinReturn.ReceiveCoin(rejectedCoinToTest);
            Assert.AreEqual(1,coinReturn.coinsInReturn.Count);
        }

        [TestMethod]
        public void WhenCustomerTakesCoinsTheyAreRemovedFromList()
        {
            VmCoinReturn coinReturn = new VmCoinReturn();
            string rejectedCoinToTest = "Coin";
            coinReturn.ReceiveCoin(rejectedCoinToTest);
            Assert.AreEqual(1, coinReturn.coinsInReturn.Count);
            coinReturn.RemoveCoinsInReturn();
            Assert.AreEqual(0, coinReturn.coinsInReturn.Count);
        }
    }
}
