using VendingMachine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VendingMachineTests
{
    [TestClass]
    public class VmUiTest
    {
        [TestMethod]
        public void TestMainUiIsCalled()
        {
            VmUi testUi = new VmUi();
            testUi.ShowMainUi();
            Assert.IsTrue(testUi.GetMainUiWasShown());
        }

        [TestMethod]
        public void TestInsertCoinUiIsCalled()
        {
            VmUi testUi = new VmUi();
            testUi.ShowInsertCoinUi();
            Assert.IsTrue(testUi.GetInsertCoinUiWasShown());
        }
        
        [TestMethod]
        public void TestCoinReturnUiIsCalled()
        {
            VmUi testUi = new VmUi();
            testUi.ShowCoinReturnUi();
            Assert.IsTrue(testUi.GetCoinReturnUiWasShown());
        }

        [TestMethod]
        public void TestFoodSlotUiIsCalled()
        {
            VmUi testUi = new VmUi();
            testUi.ShowFoodSlotUi();
            Assert.IsTrue(testUi.GetFoodSlotUiWasShown());
        }
        
        [TestMethod]
        public void TestDisplayUiIsCalled()
        {
            VmUi testUi = new VmUi();
            testUi.ShowDisplayUi();
            Assert.IsTrue(testUi.GetDisplayUiWasShown());
        }
    }
}
