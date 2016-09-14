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
            Assert.IsTrue(_testValidator.ValidateCoin("Quarter"));
            CheckTransactionTotal(25);
        }

        [TestMethod]
        public void TestCoinValidatorRecognizesDime()
        {
            Assert.IsTrue(_testValidator.ValidateCoin("Dime"));
            CheckTransactionTotal(10);
        }

        [TestMethod]
        public void TestCoinValidatorRecognizesNickel()
        {
            Assert.IsTrue(_testValidator.ValidateCoin("Nickel"));
            CheckTransactionTotal(5);
        }

        [TestMethod]
        public void TestCoinValidatorCanHandleMultpleCoinsPerTransaction()
        {
            _testValidator.ValidateCoin("Quarter");
            CheckTransactionTotal(25);

            _testValidator.ValidateCoin("Dime");
            CheckTransactionTotal(35);

            _testValidator.ValidateCoin("Penny");
            CheckTransactionTotal(35);

            _testValidator.ValidateCoin("Nickel");
            CheckTransactionTotal(40);
        }

        private void CheckTransactionTotal(int expectedTotal)
        {
            Assert.AreEqual(expectedTotal,_testValidator.GetCurrentTransactionTotal());
        }

    }
}
