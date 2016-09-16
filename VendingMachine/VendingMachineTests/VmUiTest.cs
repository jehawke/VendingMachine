using System.Collections.Generic;
using VendingMachine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VendingMachineTests
{
    [TestClass]
    public class VmUiTest
    {
        VmUi _testUi;

        private VmFoodDispenser _foodDispenser;
        private VmCoinReturn _coinReturn;
        private VmCoinValidator _validator;
        private VmFoodSlot _foodSlot;
        private VmCoinSlot _coinSlot;
        private VmCoinBank _coinBank;

        [TestInitialize]
        public void Initialize()
        {
            _foodDispenser = new VmFoodDispenser();
            _coinReturn = new VmCoinReturn();
            _validator = new VmCoinValidator();
            _coinSlot = new VmCoinSlot(new List<string>(), _coinReturn, _validator);
            _foodSlot = new VmFoodSlot();
            _coinBank = new VmCoinBank(new List<string>(), _validator, _coinSlot, _coinReturn);
            IConsole mockConsole = new MockGetInput();
            _testUi = new VmUi(_coinSlot, _validator, _coinReturn, _foodDispenser, _foodSlot, _coinBank, mockConsole);
        }


        [TestMethod]
        public void TestMainUiIsCalled()
        {
            _testUi.ShowMainUi();
            Assert.IsTrue(_testUi.GetMainUiWasShown());
        }

        [TestMethod]
        public void TestInsertCoinUiIsCalled()
        {
            _testUi.ShowInsertCoinUi();
            Assert.IsTrue(_testUi.GetInsertCoinUiWasShown());
        }
        
        [TestMethod]
        public void TestCoinReturnUiIsCalled()
        {
            _testUi.ShowCoinReturnUi();
            Assert.IsTrue(_testUi.GetCoinReturnUiWasShown());
        }

        [TestMethod]
        public void TestCoinReturnCallsMainUiIfEmpty()
        {
            Assert.IsFalse(_testUi.GetMainUiWasShown());

            _testUi.ShowCoinReturnUi();

            Assert.IsTrue(_testUi.GetCoinReturnUiWasShown());
            Assert.IsTrue(_testUi.GetMainUiWasShown());
        }

        [TestMethod]
        public void TestFoodSlotUiIsCalled()
        {
            _testUi.ShowFoodSlotUi();
            Assert.IsTrue(_testUi.GetFoodSlotUiWasShown());
        }

        [TestMethod]
        public void TestFoodSlotUiCallsMainUiIfEmpty()
        {
            Assert.IsFalse(_testUi.GetMainUiWasShown());

            _testUi.ShowFoodSlotUi();

            Assert.IsTrue(_testUi.GetFoodSlotUiWasShown());
            Assert.IsTrue(_testUi.GetMainUiWasShown());
        }

        [TestMethod]
        public void TestDisplayUiIsCalled()
        {
            _testUi.ShowDisplayUi();
            Assert.IsTrue(_testUi.GetDisplayUiWasShown());
        }
    }
}
