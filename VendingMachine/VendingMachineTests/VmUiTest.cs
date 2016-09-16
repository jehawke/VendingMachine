using System.Collections.Generic;
using VendingMachine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VendingMachineTests
{
    [TestClass]
    public class VmUiTest
    {
        VmUi _testUi;

        [TestInitialize]
        public void Initialize()
        {
            VmCoinValidator validator = new VmCoinValidator();
            VmCoinReturn coinReturn = new VmCoinReturn();
            IConsole mockConsole = new MockGetInput();
            _testUi = new VmUi(new VmCoinSlot(new List<string>(), coinReturn, validator), validator, coinReturn, new VmFoodDispenser(), new VmFoodSlot(), mockConsole);
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
