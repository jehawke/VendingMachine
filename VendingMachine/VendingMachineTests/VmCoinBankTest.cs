using System.Collections.Generic;
using VendingMachine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VendingMachineTests
{
    [TestClass]
    public class VmCoinBankTest
    {

        private VmCoinReturn _coinReturn;
        private VmCoinValidator _validator;
        private VmCoinSlot _coinSlot;
        private VmCoinBank _coinBank;

        [TestInitialize]
        public void Initialize()
        {
            _coinReturn = new VmCoinReturn();
            _validator = new VmCoinValidator();
            _coinSlot = new VmCoinSlot(new List<string>(), _coinReturn, _validator);
            _coinBank = new VmCoinBank(new List<string>(), _validator, _coinSlot, _coinReturn);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _coinReturn = null;
            _validator = null;
            _coinSlot = null;
            _coinBank = null;
        }


        [TestMethod]
        public void TestCoinBankCanAddCoins()
        {
            Assert.AreEqual(0, _coinBank.GetListOfCoinsInBank().Count);
            _coinBank.Restock();
            Assert.IsTrue(_coinBank.GetListOfCoinsInBank().Count > 0);
        }

        [TestMethod]
        public void TestCoinBankCanGiveCoins()
        {
            _coinBank.Restock();
            _coinBank.MakeChange(40);
            List<string> testChange = _coinReturn.CheckReturn();

            Assert.AreEqual("Q", testChange[0]);
            Assert.AreEqual("D", testChange[1]);
            Assert.AreEqual("N", testChange[2]);
        }

        [TestMethod]
        public void TestCoinBankCanBankTransaction()
        {
            List<string> testTransaction = new List<string> {"Q"};
            Assert.AreEqual(0,_coinBank.GetListOfCoinsInBank().Count);
            _coinBank.AcceptMoney(testTransaction);
            Assert.AreEqual(1,_coinBank.GetListOfCoinsInBank().Count);
            Assert.AreEqual("Q",_coinBank.GetListOfCoinsInBank()[0]);
        }
   }
}
