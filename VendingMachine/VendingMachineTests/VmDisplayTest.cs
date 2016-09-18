using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine;

namespace VendingMachineTests
{
    [TestClass]
    public class VmDisplayTest
    {
        private VmFoodDispenser _foodDispenser;
        private VmCoinReturn _coinReturn;
        private VmCoinValidator _validator;
        private VmFoodSlot _foodSlot;
        private VmCoinSlot _coinSlot;
        private VmCoinBank _coinBank;
        private VmDisplay _testDisplay;
        private IConsole _mockConsole;

        [TestInitialize]
        public void Initialize()
        {
            _mockConsole = new MockGetInput();
            _foodDispenser = new VmFoodDispenser();
            _coinReturn = new VmCoinReturn();
            _validator = new VmCoinValidator();
            _coinSlot = new VmCoinSlot(new List<string>(), _coinReturn, _validator);
            _foodSlot = new VmFoodSlot();
            _coinBank = new VmCoinBank(new List<string>(), _validator, _coinSlot, _coinReturn);
            _testDisplay = new VmDisplay(_mockConsole);
        }

        [TestMethod]
        public void TestDisplayShowsThankYouWhenRequested()
        {
            string expectedMessage = "The Display Reads: [THANK YOU]";
            _testDisplay.ThankYouMessage();
            Assert.AreEqual(expectedMessage, _mockConsole.GetLastMessageDisplayed());
        }

        [TestMethod]
        public void TestDisplayShowsSoldOutWhenRequested()
        {
            string expectedMessage = "The Display Reads: [SOLD OUT]";
            _testDisplay.SoldOutMessage();
            Assert.AreEqual(expectedMessage, _mockConsole.GetLastMessageDisplayed());
        }

        [TestMethod]
        public void TestDisplayShowsPriceWhenRequested()
        {
            int priceToCheck = 50;
            string expectedMessage = "The Display Reads: [PRICE: 50]";
            _testDisplay.PriceMessage(priceToCheck);
            Assert.AreEqual(expectedMessage, _mockConsole.GetLastMessageDisplayed());
        }

        [TestMethod]
        public void TestDisplayShowsExactChengeWhenRequested()
        {
            string expectedMessage = "The Display Reads: [EXACT CHANGE ONLY]";
            _testDisplay.ExactChangeMessage();
            Assert.AreEqual(expectedMessage, _mockConsole.GetLastMessageDisplayed());
        }

        [TestMethod]
        public void TestDisplayShowsInsertCoinWhenRequested()
        {
            string expectedMessage = "The Display Reads: [INSERT COIN]";
            _testDisplay.InsertCoinMessage();
            Assert.AreEqual(expectedMessage, _mockConsole.GetLastMessageDisplayed());
        }

        [TestMethod]
        public void TestDisplayShowsCurrentTransactionTotalWhenRequested()
        {
            int amountToCheck = 50;
            string expectedMessage = "The Display Reads: [50]";
            _testDisplay.CurrentTotalMessage(amountToCheck);
            Assert.AreEqual(expectedMessage, _mockConsole.GetLastMessageDisplayed());
        }
    }
}
