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
        private IConsole MockConsole;

        [TestInitialize]
        public void Initialize()
        {
            MockConsole = new MockGetInput();
            _foodDispenser = new VmFoodDispenser();
            _coinReturn = new VmCoinReturn();
            _validator = new VmCoinValidator();
            _coinSlot = new VmCoinSlot(new List<string>(), _coinReturn, _validator);
            _foodSlot = new VmFoodSlot();
            _coinBank = new VmCoinBank(new List<string>(), _validator, _coinSlot, _coinReturn);
            _testDisplay = new VmDisplay(_validator, MockConsole);
        }

/*
        [TestMethod]
        public void TestDisplayShowsInsertCoinByDefault()
        {
           Assert.AreEqual("INSERT COIN" , _testDisplay.CheckDisplay());
        }

        [TestMethod]
        public void TestDisplayShowsCurrentTransactionTotal()
        {
            _validator.ValidateCoin("Q");
            Assert.AreEqual(".25", _testDisplay.CheckDisplay());
        }*/

        [TestMethod]
        public void TestDisplayShowsThankYouWhenRequested()
        {
            string expectedMessage = "The Display Reads: [THANK YOU]";
            _testDisplay.ThankYouMessage();
            Assert.AreEqual(expectedMessage, MockConsole.GetLastMessageDisplayed());
        }
    }
}
