using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine;

namespace VendingMachineTests
{
    [TestClass]
    public class VmCoinValidatorTest
    {
        VmCoinValidator _testValidator;

        [TestInitialize]
        public void Initialize()
        {
            _testValidator = new VmCoinValidator();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _testValidator = null;
        }

        [TestMethod]
        public void TestGetCurrentTransactionTotalReturnsTransactionTotal()
        {
            Assert.IsNotNull(_testValidator.GetCurrentTransactionTotal());
        }

        [TestMethod]
        public void TestCoinValidatorReturnsFalseWhenInvalidCoinIsPassedIn()
        {           
            Assert.IsFalse(_testValidator.ValidateCoin("Penny"));
            CheckTransactionTotal(0);
        }

        [TestMethod]
        public void TestCoinValidatorRecognizesQuarter()
        {
            Assert.IsTrue(_testValidator.ValidateCoin("Q"));
            CheckTransactionTotal(25);
        }

        [TestMethod]
        public void TestCoinValidatorRecognizesDime()
        {
            Assert.IsTrue(_testValidator.ValidateCoin("D"));
            CheckTransactionTotal(10);
        }

        [TestMethod]
        public void TestCoinValidatorRecognizesNickel()
        {
            Assert.IsTrue(_testValidator.ValidateCoin("N"));
            CheckTransactionTotal(5);
        }

        [TestMethod]
        public void TestCoinValidatorCanHandleMultpleCoinsPerTransaction()
        {
            _testValidator.ValidateCoin("Q");
            CheckTransactionTotal(25);

            _testValidator.ValidateCoin("D");
            CheckTransactionTotal(35);

            _testValidator.ValidateCoin("Penny");
            CheckTransactionTotal(35);

            _testValidator.ValidateCoin("N");
            CheckTransactionTotal(40);
        }

        [TestMethod]
        public void TestGetQuarterGivesQuarter()
        {
            Assert.AreEqual("Q", _testValidator.GetQuarterDefinition());
        }
        [TestMethod]
        public void TestGetDimeGivesDime()
        {
            Assert.AreEqual("D", _testValidator.GetDimeDefinition());
        }

        [TestMethod]
        public void TestGetNickelGivesNickel()
        {
            Assert.AreEqual("N", _testValidator.GetNickelDefinition());
        }

        [TestMethod]
        public void TestCurrentTransactionClearedWhenPurchaseIsComplete()
        {
            _testValidator.ValidateCoin("Q");
            Assert.AreEqual(25, _testValidator.GetCurrentTransactionTotal());
            _testValidator.CompleteTransaction();
            Assert.AreEqual(0, _testValidator.GetCurrentTransactionTotal());
        }

        private void CheckTransactionTotal(int expectedTotal)
        {
            Assert.AreEqual(expectedTotal,_testValidator.GetCurrentTransactionTotal());
        }
    }
}
