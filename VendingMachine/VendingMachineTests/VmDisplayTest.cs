using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine;

namespace VendingMachineTests
{
    [TestClass]
    public class VmDisplayTest
    {
        private VmDisplay _testDisplay;
        private IConsole _mockConsole;

        [TestInitialize]
        public void Initialize()
        {
            _mockConsole = new MockGetInput();
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
