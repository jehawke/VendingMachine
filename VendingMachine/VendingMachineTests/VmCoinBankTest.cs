using System.Collections.Generic;
using VendingMachine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VendingMachineTests
{
    [TestClass]
    public class VmCoinBankTest
    {
        readonly VmCoinBank _coinBank = new VmCoinBank(new List<string>(), new VmCoinValidator());
        
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
            List<string> testChange = _coinBank.GiveChange(40);
            
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
