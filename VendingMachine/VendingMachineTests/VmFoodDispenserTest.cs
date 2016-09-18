using System.Collections.Generic;
using VendingMachine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VendingMachineTests
{
    [TestClass]
    public class VmFoodDispenserTest
    {
        private VmFoodDispenser _testFoodDispenser;
        private List<List<string>> _inventoryToTest;
        private VmCoinReturn _coinReturn;
        private VmCoinValidator _validator;
        private VmFoodSlot _foodSlot;
        private VmCoinSlot _coinSlot;
        private VmCoinBank _coinBank;
        private VmDisplay _display;

        [TestInitialize]
        public void Initialize()
        {
            _testFoodDispenser = new VmFoodDispenser();
            _inventoryToTest = new List<List<string>>();
            _coinReturn = new VmCoinReturn();
            _validator = new VmCoinValidator();
            _coinSlot = new VmCoinSlot(new List<string>(), _coinReturn, _validator);
            _foodSlot = new VmFoodSlot();
            _coinBank = new VmCoinBank(new List<string>(), _validator, _coinSlot, _coinReturn);
            _display = new VmDisplay(new MockGetInput());
        }

        [TestCleanup]
        public void Cleanup()
        {
            _testFoodDispenser = null;
            _inventoryToTest = null;
            _coinReturn = null;
            _validator = null;
            _coinSlot = null;
            _foodSlot = null;
            _coinBank = null;
            _display = null;
        }

        [TestMethod]
        public void TestItemsAreAddedToInventoryWhenRestockIsCalled()
        {
            Assert.AreEqual(0, _inventoryToTest.Count);
            _testFoodDispenser.Restock();
            _inventoryToTest = _testFoodDispenser.GetInventory();
            Assert.AreEqual(3,_inventoryToTest.Count);
            Assert.AreEqual(5, _inventoryToTest[0].Count);
            Assert.AreEqual(5, _inventoryToTest[1].Count);
            Assert.AreEqual(5, _inventoryToTest[2].Count);
        }

        [TestMethod]
        public void TestItemsAreProperlyRemovedFromInventoryWhenDispensed()
        {
            string testItem = "S";

            _testFoodDispenser.Restock();
            InsertCoinsForTesting();
            _inventoryToTest = _testFoodDispenser.GetInventory();
            Assert.AreEqual(5, _inventoryToTest[0].Count);
            _testFoodDispenser.Dispense(testItem, _validator, _coinBank, _foodSlot, _display);
            Assert.AreEqual(4, _inventoryToTest[0].Count);
            Assert.AreEqual(5, _inventoryToTest[1].Count);
            Assert.AreEqual(5, _inventoryToTest[2].Count);
        }

        [TestMethod]
        public void TestFoodDispenserCanDispenseSoda()
        {
            string testItem = "S";
            _testFoodDispenser.Restock();
            InsertCoinsForTesting();
            Assert.IsTrue(_testFoodDispenser.Dispense(testItem, _validator, _coinBank, _foodSlot, _display));
            Assert.AreEqual(4, _testFoodDispenser.GetInventory()[0].Count);
        }

        [TestMethod]
        public void TestFoodDispenserCanDispenseChips()
        {
            string testItem = "H";
            _testFoodDispenser.Restock();
            InsertCoinsForTesting();
            Assert.IsTrue(_testFoodDispenser.Dispense(testItem, _validator, _coinBank, _foodSlot, _display));
            Assert.AreEqual(4, _testFoodDispenser.GetInventory()[1].Count);
        }

        [TestMethod]
        public void TestFoodDispenserCanDispenseCandy()
        {
            string testItem = "C";
            _testFoodDispenser.Restock();
            InsertCoinsForTesting();
            Assert.IsTrue(_testFoodDispenser.Dispense(testItem, _validator, _coinBank, _foodSlot, _display));
            Assert.AreEqual(4, _testFoodDispenser.GetInventory()[2].Count);
        }

        [TestMethod]
        public void TestFoodDispenserDoesNotDispenseWhenItHasNoItemToDispense()
        {
            string testItem = "S";
            _inventoryToTest = _testFoodDispenser.GetInventory();
            Assert.AreEqual(0,_inventoryToTest.Count);
            InsertCoinsForTesting();
            Assert.IsFalse(_testFoodDispenser.Dispense(testItem, _validator, _coinBank, _foodSlot, _display));
        }

        [TestMethod]

        public void TestFoodDispenserRestocks()
        {
            _testFoodDispenser.Restock();
            _inventoryToTest = _testFoodDispenser.GetInventory();
            Assert.AreEqual(3, _inventoryToTest.Count);
        }

        [TestMethod]
        public void TestFoodDispenserReturnsFalseWhenPassedAnItemItWillNeverHaveInStock()
        {
            string testItem = "Steak";
            InsertCoinsForTesting();
            Assert.IsFalse(_testFoodDispenser.Dispense(testItem, _validator, _coinBank, _foodSlot, _display));
        }

        private void InsertCoinsForTesting()
        {
            for (int i = 0; i < 5; i++)
            {
                _validator.ValidateCoin("Q");
            }
        }
    }
}
